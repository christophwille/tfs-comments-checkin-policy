using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Diagnostics;

using Microsoft.TeamFoundation.VersionControl.Client;

using CCCPLib;
using CCCPLib.Extensibility;
using ICSharpCode.NRefactory;
using System.Globalization;

namespace CCCPPol
{
    [Serializable]
    public class CCCPTfsPolicy : PolicyBase
    {
        public CodeCommentCheckingElements elementsToCheck;
        public CodeCommentCheckingVisibility visibilityToCheck;
        public bool checkCSharp;
        public bool checkVbNet;
        public bool treatParserErrorsAsPolicyViolation;
        public bool doCheckOverrideElements;
        public List<PluginInformation> checkingPlugins;
        public List<string> includedServerPaths;
        public List<string> excludedNamespaces;

        public CCCPTfsPolicy()
        {
            elementsToCheck = CodeCommentCheckingElements.Methods;
            visibilityToCheck = CodeCommentCheckingVisibility.Public;

            checkCSharp = true;
            checkVbNet = true;
            treatParserErrorsAsPolicyViolation = true;
            doCheckOverrideElements = true;
            checkingPlugins = new List<PluginInformation>();
            includedServerPaths = new List<string>();
            excludedNamespaces = new List<string>();
        }

        public override bool CanEdit
        {
            get { return true; }
        }

        public override bool Edit(IPolicyEditArgs policyEditArgs)
        {
            EditPolicy ep = new EditPolicy();
            ep.SetVisibilityToCheck(visibilityToCheck);
            ep.SetElementsToCheck(elementsToCheck);
            ep.CheckCSharp = checkCSharp; 
            ep.CheckVbNet = checkVbNet;
            ep.TreatParserErrorsAsPolicyViolation = treatParserErrorsAsPolicyViolation;
            ep.DoCheckOverrideElements = doCheckOverrideElements;
            ep.SetPlugins(checkingPlugins);
            ep.SetIncludedPaths(includedServerPaths);
            ep.SetExcludedNamespaces(excludedNamespaces); 

            if (DialogResult.OK == ep.ShowDialog())
            {
                elementsToCheck = ep.GetElementsToCheck();
                visibilityToCheck = ep.GetVisibilityToCheck();
                checkCSharp = ep.CheckCSharp;
                checkVbNet = ep.CheckVbNet;
                treatParserErrorsAsPolicyViolation = ep.TreatParserErrorsAsPolicyViolation;
                doCheckOverrideElements = ep.DoCheckOverrideElements;
                includedServerPaths = ep.GetIncludedPaths();
                excludedNamespaces = ep.GetExcludedNamespaces();

                checkingPlugins.Clear();
                checkingPlugins.AddRange(ep.GetPlugins());
            }

            return true;
        }


        public override PolicyFailure[] Evaluate()
        {
            PendingChange[] pendingChanges = PendingCheckin.PendingChanges.CheckedPendingChanges;
            List<PolicyFailure> pfList = new List<PolicyFailure>();

            CheckCodeComments cce = CheckCodeComments.CreateInstance(elementsToCheck, visibilityToCheck);
            cce.ExcludedNamespaces.AddRange(excludedNamespaces);
            cce.AccumulateErrors = false;   // in each iteration of the loop we get the errors
            cce.TrackStatistics = false;    // we don't need statistics (off by default anyways)
            cce.TreatParserErrorsAsPolicyViolation = treatParserErrorsAsPolicyViolation;
            cce.DoCheckOverrideElements = doCheckOverrideElements;
            cce.PluginManager.Load(checkingPlugins);

            foreach (PendingChange pc in pendingChanges)
            {
                Trace.Write("Local item: " + pc.LocalItem + 
                    ", change type: " + pc.ChangeType.ToString() +
                    ", server item: " + pc.ServerItem + 
                    ", in /// checkin policy" + 
                    Environment.NewLine);

                // first check: is this a change we are interested in (ordered for short-circuiting)
                if (IsVerifyableChangeType(pc.ChangeType) &&
                    IsVerifyableServerPath(pc.ServerItem) && 
                    IsVerifyableFileType(pc.LocalItem))
                {
                    try
                    {
                        Trace.Write("Verifying file " + pc.LocalItem + " in Triple-Slash checkin policy" + Environment.NewLine);
                        cce.Verify(File.ReadAllText(pc.LocalItem), InferFileLanguage(pc.LocalItem));
                    }
                    catch
                    {
                        Trace.Write("Failed loading file " + pc.LocalItem + " in Triple-Slash checkin policy" + Environment.NewLine);
                    }

                    foreach (CodeCommentError error in cce.CodeCommentErrors)
                    {
                        pfList.Add(new PolicyFailure(error.ToString() + " " + pc.LocalItem, this));
                    }
                }
            }

            return pfList.ToArray();
        }

        private bool IsVerifyableChangeType(ChangeType ct)
        {
            if ((ChangeType.Add == (ct & ChangeType.Add)) ||
                    (ChangeType.Edit == (ct & ChangeType.Edit)))
            {
                return true;
            }

            return false;
        }

        private bool IsVerifyableServerPath(string serverItem)
        {
            int numberOfPaths = includedServerPaths.Count;
            
            // 0 elements equals to "check everything" (retains previous versions default)
            if (0 == numberOfPaths) return true;

            for (int i = 0; i < numberOfPaths; i++)
            {
                if (serverItem.StartsWith(includedServerPaths[i], true, CultureInfo.InvariantCulture))
                    return true;
            }

            return false;
        }

        private bool IsVerifyableFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            // Reference.cs | .vb: Web Service proxies

            if (checkCSharp && 
                (0 == String.Compare(extension, ".cs", true, CultureInfo.InvariantCulture))
                && (0 != String.Compare(fileName, "AssemblyInfo.cs", true, CultureInfo.InvariantCulture)) 
                && !fileName.Contains(".Designer.")
                && (0 != String.Compare(fileName, "Reference.cs", true, CultureInfo.InvariantCulture)))
            {
                return true;
            }

            if (checkVbNet &&
                (0 == String.Compare(extension, ".vb", true, CultureInfo.InvariantCulture))
                && (0 != String.Compare(fileName, "AssemblyInfo.vb", true, CultureInfo.InvariantCulture))
                && !fileName.Contains(".Designer.")
                && (0 != String.Compare(fileName, "Reference.vb", true, CultureInfo.InvariantCulture)))
            {
                return true;
            }

            return false;
        }

        private SupportedLanguage InferFileLanguage(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            if (0 == String.Compare(extension, ".cs", true, CultureInfo.InvariantCulture))
            {
                return SupportedLanguage.CSharp;
            }

            return SupportedLanguage.VBNet;
        }

        #region Info Overloads
        public override string Type
        {
            get { return "Check for Code Comments (///) Policy " + CCCPTfsPolicy.GetPolicyVersion(); }
        }

        public override string TypeDescription
        {
            get { return "This policy verifies that developers have added code comments to the types in their projects."; }
        }

        public override string Description
        {
            get { return "Verify that code comments (///) have been added"; }
        }

        public override string InstallationInstructions
        {
            get { return "No installation instructions are hard-coded into the assembly, see readme.txt"; }
        }
        #endregion

        // Pending changes auto-update doesn't seem to work this way though... because we aren't auto-updated
        public override void Initialize(IPendingCheckin pendingCheckin)
        {
            base.Initialize(pendingCheckin);

            // would result in unverifiable code, and I don't like this at all:
            //pendingCheckin.PendingChanges.CheckedPendingChangesChanged += delegate(object sender, EventArgs e)
            //        {
            //            base.OnPolicyStateChanged(Evaluate());
            //        };

            pendingCheckin.PendingChanges.CheckedPendingChangesChanged += OnCheckedPendingChangesChanged;
        }

        void OnCheckedPendingChangesChanged(object sender, EventArgs e)
        {
            base.OnPolicyStateChanged(Evaluate());
        }

        // Activate and DisplayHelp overloads missing intentionally

        public static string GetPolicyVersion()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetAssembly(typeof(CCCPTfsPolicy));
            Version v = asm.GetName().Version;

            string s = string.Format("{0:0}.{1:0}.{2:0}.{3:0}",
                    v.Major, v.Minor, v.Build, v.Revision);

            return s;
        }
    }
}
