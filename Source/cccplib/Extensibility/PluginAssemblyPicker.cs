using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCCPLib.Extensibility
{
    public partial class PluginAssemblyPicker : Form
    {
        private List<PluginInformation> piList;

        public List<PluginInformation> PickedPlugins
        {
            get { return piList; }
        }

        public PluginAssemblyPicker()
        {
            InitializeComponent();

            piList = null;
        }

        public void LoadAssemblyList()
        {
            SortedList<string, AssemblyDisplayInformation> sl = PluginHelper.EnumerateGAC();

            foreach (KeyValuePair<string, AssemblyDisplayInformation> kvp in sl)
            {
                ListViewItem lvi = new ListViewItem(kvp.Value.ShortName);
                lvi.Tag = kvp.Key;
                lvi.SubItems.Add(kvp.Value.VersionString);
                lvi.SubItems.Add(kvp.Value.Culture);
                lvi.SubItems.Add(kvp.Value.PublicKeyToken);
                lvi.SubItems.Add(kvp.Value.ProcessorArchitecture);
                assemblyList.Items.Add(lvi);
            }

        }

        private void addAssemblyToCCCP_Click(object sender, EventArgs e)
        {
            if (assemblyList.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select an assembly");
                return;
            }

            string assemblyFullName = (string)assemblyList.SelectedItems[0].Tag;
            piList = PluginHelper.GetPluginInformationFromAssembly(assemblyFullName);

            if (piList.Count == 0)
            {
                MessageBox.Show("This assembly does not contain any valid plugins");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}