using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CCCPLib;
using CCCPLib.Extensibility;

namespace CCCPPol
{
    public partial class EditPolicy : Form
    {
        Dictionary<string, PluginInformation> localPluginList;

        public EditPolicy()
        {
            InitializeComponent();
            localPluginList = new Dictionary<string, PluginInformation>();
        }

        #region Setters
        public void SetVisibilityToCheck(CodeCommentCheckingVisibility cccv)
        {
            string[] enNames = Enum.GetNames(typeof(CodeCommentCheckingVisibility));
            Array enValues = Enum.GetValues(typeof(CodeCommentCheckingVisibility));
            for (int i = 0; i < enNames.Length; i++)
            {
                clbVisibility.Items.Add(enNames[i], (((CodeCommentCheckingVisibility)enValues.GetValue(i)) & cccv) == ((CodeCommentCheckingVisibility)enValues.GetValue(i)));
            }
        }

        public void SetElementsToCheck(CodeCommentCheckingElements ccce)
        {
            string[] enNames = Enum.GetNames(typeof(CodeCommentCheckingElements));
            Array enValues = Enum.GetValues(typeof(CodeCommentCheckingElements));
            for (int i = 0; i < enNames.Length; i++)
            {
                clbElements.Items.Add(enNames[i], (((CodeCommentCheckingElements)enValues.GetValue(i)) & ccce) == ((CodeCommentCheckingElements)enValues.GetValue(i)));
            }
        }

        public void SetPlugins(List<PluginInformation> list)
        {
            int numberOfPlugins = list.Count;
            PluginInformation [] tempArray = new PluginInformation[numberOfPlugins];
            list.CopyTo(tempArray);
            
            for (int i = 0; i < numberOfPlugins; i++)
            {
                localPluginList.Add(tempArray[i].Name, tempArray[i]);
                pluginListBox.Items.Add(tempArray[i].Name, tempArray[i].Enabled);
            }
        }

        public void SetIncludedPaths(List<string> list)
        {
            int numberOfPaths = list.Count;

            for (int i = 0; i < numberOfPaths; i++)
            {
                IncludedPathsListbox.Items.Add(list[i]);
            }
        }

        public void SetExcludedNamespaces(List<string> list)
        {
            int numberOfPaths = list.Count;

            for (int i = 0; i < numberOfPaths; i++)
            {
                ExcludedNamespacesListbox.Items.Add(list[i]);
            }
        }
        #endregion

        #region Getters
        public PluginInformation[] GetPlugins()
        {
            PluginInformation[] tempArray = new PluginInformation[localPluginList.Count];
            localPluginList.Values.CopyTo(tempArray, 0);
            return tempArray;
        }

        public CodeCommentCheckingElements GetElementsToCheck()
        {
            CodeCommentCheckingElements ccce = 0;
            foreach (object ci in clbElements.CheckedItems)
            {
                CodeCommentCheckingElements val = (CodeCommentCheckingElements)Enum.Parse(typeof(CodeCommentCheckingElements), ci.ToString());
                ccce |= val;
            }

            return ccce;
        }

        public CodeCommentCheckingVisibility GetVisibilityToCheck()
        {
            CodeCommentCheckingVisibility cccv = 0;
            foreach (object ci in clbVisibility.CheckedItems)
            {
                CodeCommentCheckingVisibility val = (CodeCommentCheckingVisibility)Enum.Parse(typeof(CodeCommentCheckingVisibility), ci.ToString());
                cccv |= val;
            }

            return cccv;
        }

        public List<string> GetIncludedPaths()
        {
            int numberOfPaths = IncludedPathsListbox.Items.Count;
            List<string> list = new List<string>();
            
            // intentionally *not* NULL but an empty list
            if (0 == numberOfPaths) return list;

            for (int i=0; i < numberOfPaths; i++)
            {
                list.Add((string)IncludedPathsListbox.Items[i]);
            }

            return list;
        }

        public List<string> GetExcludedNamespaces()
        {
            int numberOfExcludedNamespaces = ExcludedNamespacesListbox.Items.Count;
            List<string> list = new List<string>();

            // intentionally *not* NULL but an empty list
            if (0 == numberOfExcludedNamespaces) return list;

            for (int i = 0; i < numberOfExcludedNamespaces; i++)
            {
                list.Add((string)ExcludedNamespacesListbox.Items[i]);
            }

            return list;
        }
        #endregion

        #region Properties
        public bool CheckCSharp
        {
            get
            {
                return CheckCSharpCheckBox.Checked;
            }
            set
            {
                CheckCSharpCheckBox.Checked = value;
            }
        }

        public bool CheckVbNet
        {
            get
            {
                return CheckVbNetCheckBox.Checked;
            }
            set
            {
                CheckVbNetCheckBox.Checked = value;
            }
        }

        public bool TreatParserErrorsAsPolicyViolation
        {
            get
            {
                return TreatPeAsVCheckBox.Checked;
            }
            set
            {
                TreatPeAsVCheckBox.Checked = value;
            }
        }

        public bool DoCheckOverrideElements
        {
            get
            {
                return ckDoCheckOverrideElements.Checked;
            }
            set
            {
                ckDoCheckOverrideElements.Checked = value;
            }
        }
        #endregion

        private void EditPolicy_Load(object sender, EventArgs e)
        {
            lblVersionInfo.Text = "Powered by NRefactory " + CheckCodeComments.GetNRefactoryVersion();
        }

        private void lblVersionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.icsharpcode.net/opensource/sd/");
            }
            catch (Exception)
            {
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            PluginAssemblyPicker pap = new PluginAssemblyPicker();

            pap.LoadAssemblyList();
            if (DialogResult.OK == pap.ShowDialog())
            {
                // first: copy to local plugin list (yes, this will create duplicates at the moment)
                int numberOfPlugins = pap.PickedPlugins.Count;
                PluginInformation[] tempArray = new PluginInformation[numberOfPlugins];
                pap.PickedPlugins.CopyTo(tempArray);

                for (int i = 0; i < numberOfPlugins; i++)
                {
                    localPluginList.Add(tempArray[i].Name, tempArray[i]);
                    pluginListBox.Items.Add(tempArray[i].Name);
                }
            }
        }

        private void pluginListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pluginName = (string)pluginListBox.SelectedItem;
            if (null == pluginName || !localPluginList.ContainsKey(pluginName)) return;

            PluginInformation pi = localPluginList[pluginName];

            if (pi.SupportsConfiguration)
                configurePlugin.Enabled = true;
            else
                configurePlugin.Enabled = false;
        }

        private void configurePlugin_Click(object sender, EventArgs e)
        {
            string pluginName = (string)pluginListBox.SelectedItem;
            PluginInformation pi = localPluginList[pluginName];

            PluginHelper.ConfigurePlugin(pi);
        }

        private void removePlugin_Click(object sender, EventArgs e)
        {
            string pluginName = (string)pluginListBox.SelectedItem;
            if (null == pluginName || !localPluginList.ContainsKey(pluginName)) return;

            localPluginList.Remove(pluginName);
            pluginListBox.Items.Remove(pluginName);
        }

        private void pluginListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string pluginName = (string)pluginListBox.SelectedItem;
            if (null == pluginName || !localPluginList.ContainsKey(pluginName)) return;

            localPluginList[pluginName].Enabled = (e.NewValue == CheckState.Checked ? true : false);
        }

        private void AddPathButton_Click(object sender, EventArgs e)
        {
            string pathToAdd = ServerPathToAdd.Text.Trim();

            // TODO: add more sanity checks
            if (String.IsNullOrEmpty(pathToAdd)) return;

            IncludedPathsListbox.Items.Add(pathToAdd);
        }

        private void RemovePathButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = IncludedPathsListbox.SelectedIndex;

            if (-1 == selectedIndex) return;

            IncludedPathsListbox.Items.RemoveAt(selectedIndex);
        }

        private void AddNamespaceToExcludedListButton_Click(object sender, EventArgs e)
        {
            string namespaceToAdd = NamespaceToExcludeTextbox.Text.Trim();

            // TODO: add more sanity checks
            if (String.IsNullOrEmpty(namespaceToAdd)) return;

            ExcludedNamespacesListbox.Items.Add(namespaceToAdd);
        }

        private void RemoveNamespaceFromExcludedListButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = ExcludedNamespacesListbox.SelectedIndex;

            if (-1 == selectedIndex) return;

            ExcludedNamespacesListbox.Items.RemoveAt(selectedIndex);
        }
    }
}