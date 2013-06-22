using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.NRefactory;
using ICSharpCode.SharpDevelop.Dom.NRefactoryResolver;

namespace CCCPLib.Extensibility
{
    public class PluginManager
    {
        CheckCodeComments assignedHost;

        public PluginManager(CheckCodeComments host)
        {
            assignedHost = host;
        }

        List<ICheckCodeCommentsPlugin> pluginList = new List<ICheckCodeCommentsPlugin>();

        public bool Load(List<PluginInformation> listOfPluginsToLoad)
        {
            foreach (PluginInformation pi in listOfPluginsToLoad)
            {
                if (!pi.Enabled) continue;

                ICheckCodeCommentsPlugin plugin =
                        (ICheckCodeCommentsPlugin)AppDomain.CurrentDomain.CreateInstanceAndUnwrap(pi.AssemblyFullName, pi.TypeFullName);

                if (pi.SupportsConfiguration)
                {
                    ICheckCodeCommentsPluginConfiguration config =
                        (ICheckCodeCommentsPluginConfiguration)plugin;

                    config.Load(pi.Configuration);
                }

                plugin.Initialize(assignedHost);

                pluginList.Add(plugin);
            }

            return true;
        }

        public bool PluginsLoaded
        {
            get {  return pluginList.Count != 0;  }
        }

        public CheckCodeCommentsVerificationState VerifyClass(ICSharpCode.SharpDevelop.Dom.IClass c)
        {
            if (!PluginsLoaded) return CheckCodeCommentsVerificationState.Forfeit;

            CheckCodeCommentsVerificationState aggregatedState = CheckCodeCommentsVerificationState.Forfeit;

            foreach (ICheckCodeCommentsPlugin current in pluginList)
            {
                CheckCodeCommentsVerificationState state = CheckCodeCommentsVerificationState.Forfeit;
                try
                {
                    state = current.VerifyClass(c);
                }
                catch
                {
                    // if something goes wrong in the addin, we silently catch the exception and forfeit voting
                    // because the result could not be trusted
                    state = CheckCodeCommentsVerificationState.Forfeit;
                }

                // we short circuit on the first failed plugin, we do not run the other plugins, one failure is enough
                if (CheckCodeCommentsVerificationState.Fail == state) return state;

                // a "forfeit" is only then reported back when all plugins forfeit this check
                if (CheckCodeCommentsVerificationState.Pass == state)
                    aggregatedState = state;
            }

            return aggregatedState;
        }

        public CheckCodeCommentsVerificationState VerifyMember(IMember element, CodeCommentCheckingElements elementType)
        {
            if (!PluginsLoaded) return CheckCodeCommentsVerificationState.Forfeit;

            CheckCodeCommentsVerificationState aggregatedState = CheckCodeCommentsVerificationState.Forfeit;

            foreach (ICheckCodeCommentsPlugin current in pluginList)
            {
                CheckCodeCommentsVerificationState state = CheckCodeCommentsVerificationState.Forfeit;
                try
                {
                    switch (elementType)
                    {
                        case CodeCommentCheckingElements.Methods:
                            state = current.VerifyMethod((IMethod)element);
                            break;
                        case CodeCommentCheckingElements.Fields:
                            state = current.VerifyField((IField)element);
                            break;
                        case CodeCommentCheckingElements.Properties:
                            state = current.VerifyProperty((IProperty)element);
                            break;
                        case CodeCommentCheckingElements.Events:
                            state = current.VerifyEvent((IEvent)element);
                            break;
                    }
                }
                catch
                {
                    // if something goes wrong in the addin, we silently catch the exception and forfeit voting
                    // because the result could not be trusted
                    state = CheckCodeCommentsVerificationState.Forfeit;
                }

                // we short circuit on the first failed plugin, we do not run the other plugins, one failure is enough
                if (CheckCodeCommentsVerificationState.Fail == state) return state;

                // a "forfeit" is only then reported back when all plugins forfeit this check
                if (CheckCodeCommentsVerificationState.Pass == state)
                    aggregatedState = state;
            }

            return aggregatedState;
        }

        public void BeginCompilationUnitVerification(string sourceCode, IParser parser, NRefactoryASTConvertVisitor visitor)
        {
            if (!PluginsLoaded) return;

            foreach (ICheckCodeCommentsPlugin current in pluginList)
            {
                current.BeginCompilationUnitVerification(sourceCode, parser, visitor);
            }
        }


        public void EndCompilationUnitVerification()
        {
            if (!PluginsLoaded) return;

            foreach (ICheckCodeCommentsPlugin current in pluginList)
            {
                current.EndCompilationUnitVerification();
            }
        }

    }
}
