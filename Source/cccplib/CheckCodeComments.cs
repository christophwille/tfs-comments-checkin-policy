using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.PrettyPrinter;
using ICSharpCode.NRefactory.Visitors;
using ICSharpCode.SharpDevelop.Dom.NRefactoryResolver;
using ICSharpCode.SharpDevelop.Dom;
using CCCPLib.Extensibility;

namespace CCCPLib
{
    public class CheckCodeComments : ICheckCodeCommentsHost
    {
        #region Properties
        private List<CodeCommentError> cce;
        private CodeCommentCheckingVisibility cccv;
        private CodeCommentCheckingElements ccce;
        private bool accumulateErrors;
        private bool accumulateStatistics;
        private bool trackStatistics;
        private CodeCommentStatistics ccs = null;
        private bool treatParserErrorsAsPolicyViolation;
        private bool doCheckOverrideElements;
        private PluginManager pluginManager;
        private List<string> excludedNamespaces;

        public PluginManager PluginManager
        {
            get { return pluginManager; }
        }

        public bool DoCheckOverrideElements
        {
            get { return doCheckOverrideElements; }
            set { doCheckOverrideElements = value; }
        }

        public bool TreatParserErrorsAsPolicyViolation
        {
            get { return treatParserErrorsAsPolicyViolation; }
            set { treatParserErrorsAsPolicyViolation = value; }
        }

        public CodeCommentStatistics CommentStatistics
        {
            get { return ccs; }
        }

        public List<string> ExcludedNamespaces
        {
            get { return excludedNamespaces; }
        }

        public bool TrackStatistics
        {
            get { return trackStatistics; }
            set 
            { 
                trackStatistics = value;

                // if statistics tracking is being disabled, simply throw away existing statistics
                // reason: so no one accesses outdated statistics inadvertently
                if (!trackStatistics)
                {
                    ccs = null;
                }

                // defer creation of statistics to the latest point in time
                // why the null check? if TrackStatistics is set to true more than once
                if (trackStatistics && (null == ccs))
                {
                    ccs = CodeCommentStatistics.CreateInstance(ccce, cccv);
                }
            }
        }

        public bool AccumulateStatistics
        {
            get { return accumulateStatistics; }
            set { accumulateStatistics = value; }
        }

        public bool AccumulateErrors
        {
            get { return accumulateErrors; }
            set { accumulateErrors = value; }
        }

        public CodeCommentCheckingVisibility VisibilityToCheck
        {
            get { return cccv; }
        }

        public CodeCommentCheckingElements ElementsToCheck
        {
            get { return ccce; }
        }

        public List<CodeCommentError> CodeCommentErrors
        {
            get { return cce; }
        }
        #endregion

        private CheckCodeComments()
        {
            cce = new List<CodeCommentError>();
            accumulateErrors = true;
            accumulateStatistics = true;
            trackStatistics = false;
            treatParserErrorsAsPolicyViolation = true;
            doCheckOverrideElements = true;

            pluginManager = new PluginManager(this);
            excludedNamespaces = new List<string>();
        }

        public static CheckCodeComments CreateInstance(CodeCommentCheckingElements elementFlags, CodeCommentCheckingVisibility visibilityFlags)
        {
            CheckCodeComments instance = new CheckCodeComments();

            instance.ccce = elementFlags;
            instance.cccv = visibilityFlags;

            return instance;
        }

        // default, old behavior of constructor creation only
        public static CheckCodeComments CreateInstance()
        {
            CheckCodeComments instance = new CheckCodeComments();

            instance.cccv = CodeCommentCheckingVisibility.Public;
            instance.ccce = CodeCommentCheckingElements.Methods;

            return instance;
        }


        public bool Verify(TextReader input, SupportedLanguage theLanguage)
        {
            using (input)
            {
                return Verify(input.ReadToEnd(), theLanguage);
            }
        }

        public bool Verify(string sourceCode, SupportedLanguage theLanguage)
        {
            if (!accumulateErrors) cce.Clear();
            if (trackStatistics && !accumulateStatistics) ccs.Clear();

            IParser parser = null;

            try
            {
                // an exception will be thrown when the file cannot be parsed
                parser = GetParser(sourceCode, theLanguage);
            }
            catch (Exception e)
            {
                if (treatParserErrorsAsPolicyViolation)
                {
                    cce.Add(new CodeCommentError("Failed parsing file"));
                }

                Trace.Write("Triple-Slash policy failed parsing: " + e.Message);
                return false;
            }

            NRefactoryASTConvertVisitor visitor = new NRefactoryASTConvertVisitor(new DefaultProjectContent(), theLanguage);
            visitor.Specials = parser.Lexer.SpecialTracker.RetrieveSpecials();
            parser.CompilationUnit.AcceptVisitor(visitor, null);

            pluginManager.BeginCompilationUnitVerification(sourceCode, parser, visitor);

            int numberOfExcludedNamespaces = excludedNamespaces.Count;
            foreach (IClass theClass in visitor.Cu.Classes)
            {
                if (0 == numberOfExcludedNamespaces)
                {
                    CheckClass(theClass);
                }
                else
                {
                    bool bCheckClass = true;
                    for (int i = 0; i < numberOfExcludedNamespaces; i++)
                    {
                        if (theClass.Namespace.StartsWith(excludedNamespaces[i],
                            false,
                            System.Globalization.CultureInfo.InvariantCulture))
                        {
                            bCheckClass = false;
                            break;
                        }
                    }

                    if (bCheckClass) CheckClass(theClass);
                }
            }

            pluginManager.EndCompilationUnitVerification();

            return (cce.Count == 0);
        }

        private IParser GetParser(string sourceCode, SupportedLanguage theLanguage)
        {
            StringReader input = new StringReader(sourceCode);
            IParser parser = ParserFactory.CreateParser(theLanguage, input);
            parser.Parse();

            if (parser.Errors.Count > 0)
            {
                string ErrorMessage = parser.Errors.ErrorOutput;
                throw new ArgumentException(ErrorMessage);
            }

            return parser;
        }

        private void CheckClass(IClass c)
        {
            foreach (IClass ic in c.InnerClasses)
            {
                CheckClass(ic);
            }

            if (CodeCommentCheckingElements.Class == (ccce & CodeCommentCheckingElements.Class))
            {
                // class is special-cased because IClass -> IDecoration and not IClass -> IMember -> IDecoration
                if (DecorationNeedsVerification(c))
                {
                    CheckCodeCommentsVerificationState state = pluginManager.VerifyClass(c);

                    // we check only if all plugins forfeited their checking obligations (last bastion)
                    if (CheckCodeCommentsVerificationState.Forfeit == state)
                    {
                        if (!DecorationHasComment(c))
                        {
                            cce.Add(new CodeCommentError("class itself", c.Name, c.BodyRegion.BeginLine));
                            state = CheckCodeCommentsVerificationState.Fail;
                        }
                        else 
                            state = CheckCodeCommentsVerificationState.Pass;
                    }

                    if (CheckCodeCommentsVerificationState.Fail == state)
                    {
                        if (trackStatistics)
                            ccs.IncMissingCommentCount(CodeCommentCheckingElements.Class, DomVisToCodeCommentCheckingVis(c));
                    }
                    else
                    {
                        if (trackStatistics)
                            ccs.IncCommentCount(CodeCommentCheckingElements.Class, DomVisToCodeCommentCheckingVis(c));
                    }
                }
            }

            // constructors and operators are treated as methods
            if (CodeCommentCheckingElements.Methods == (ccce & CodeCommentCheckingElements.Methods))
            {
                foreach (IMethod m in c.Methods)
                    CheckMember(c, m, CodeCommentCheckingElements.Methods);
            }

            if (CodeCommentCheckingElements.Properties == (ccce & CodeCommentCheckingElements.Properties))
            {
                foreach (IProperty p in c.Properties)
                    CheckMember(c, p, CodeCommentCheckingElements.Properties);
            }

            if (CodeCommentCheckingElements.Events == (ccce & CodeCommentCheckingElements.Events))
            {
                foreach (IEvent e in c.Events)
                    CheckMember(c, e, CodeCommentCheckingElements.Events);
            }

            if (CodeCommentCheckingElements.Fields == (ccce & CodeCommentCheckingElements.Fields))
            {
                foreach (IField f in c.Fields)
                    CheckMember(c, f, CodeCommentCheckingElements.Fields);
            }
        }

        private void CheckMember(IClass c, IMember member, CodeCommentCheckingElements elementType)
        {
            if (DecorationNeedsVerification(member))
            {
                CheckCodeCommentsVerificationState state = pluginManager.VerifyMember(member, elementType);

                // we check only if all plugins forfeited their checking obligations (last bastion)
                if (CheckCodeCommentsVerificationState.Forfeit == state)
                {
                    if (DecorationHasComment(member))
                    {
                        state = CheckCodeCommentsVerificationState.Pass;
                    }
                    else
                    {
                        state = CheckCodeCommentsVerificationState.Fail;
                        cce.Add(new CodeCommentError(c.Name, member.Name, member.BodyRegion.BeginLine));
                    }
                }

                if (CheckCodeCommentsVerificationState.Fail == state)
                {
                    if (trackStatistics) 
                        ccs.IncMissingCommentCount(elementType, DomVisToCodeCommentCheckingVis(member));
                }
                else
                {
                    if (trackStatistics)
                        ccs.IncCommentCount(elementType, DomVisToCodeCommentCheckingVis(member));
                }
            }
        }

        private CodeCommentCheckingVisibility DomVisToCodeCommentCheckingVis(IEntity d)
        {
            if (d.IsPublic)
                return CodeCommentCheckingVisibility.Public;
            else if (d.IsPrivate)
                return CodeCommentCheckingVisibility.Private;

            return CodeCommentCheckingVisibility.Protected;
        }

        private bool DecorationHasComment(IEntity d)
        {
            if ("" == d.Documentation)
                return false;

            return true;
        }

        private bool DecorationNeedsVerification(IEntity d)
        {
            if (!doCheckOverrideElements && d.IsOverride)
            {
                // if the code to be checked is eg "public override void SayHello()"; applies to *all* visibilities, thus checked first
                return false;
            }

            if ((CodeCommentCheckingVisibility.Public == (cccv & CodeCommentCheckingVisibility.Public) && d.IsPublic))
            {
                return true;
            }
            else if ((CodeCommentCheckingVisibility.Private == (cccv & CodeCommentCheckingVisibility.Private) && d.IsPrivate))
            {
                return true;
            }
            else if ((CodeCommentCheckingVisibility.Protected == (cccv & CodeCommentCheckingVisibility.Protected) && d.IsProtected))
            {
                return true;
            }

            return false;
        }

        public static string GetNRefactoryVersion()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetAssembly(typeof(VBNetOutputVisitor));
            Version v = asm.GetName().Version;

            string s = string.Format("{0:0}.{1:0}.{2:0}.{3:0}",
                    v.Major, v.Minor, v.Build, v.Revision);

            return s;
        }

        #region ICheckCodeCommentsHost Members

        public void ReportError(string offendingClass, string offendingElement, int offendingLine)
        {
            cce.Add(new CodeCommentError(offendingClass, offendingElement, offendingLine));
        }

        public void ReportError(string offendingError)
        {
            cce.Add(new CodeCommentError(offendingError));
        }

        #endregion
    }
}
