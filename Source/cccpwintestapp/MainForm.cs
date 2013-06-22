using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CCCPLib;
using ICSharpCode.NRefactory; // must be included for SupportedLanguage enumeration

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace cccpwintestapp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private CodeCommentCheckingElements elements = 0;
        private CodeCommentCheckingVisibility visibility = 0;

        private void checkForPolicyViolation_Click(object sender, EventArgs e)
        {
            PerformVerification(SupportedLanguage.CSharp);
        }

        private void cmdVerifyVBNET_Click(object sender, EventArgs e)
        {
            PerformVerification(SupportedLanguage.VBNet);
        }

        private void PerformVerification(SupportedLanguage theLanguage)
        {
            output.Text = "";

            CheckCodeComments ccc = CheckCodeComments.CreateInstance(elements, visibility);
            bool result = ccc.Verify(theCodeToCheck.Text, theLanguage);

            if (!result)
            {
                StringBuilder stb = new StringBuilder();

                List<CodeCommentError> cceList = ccc.CodeCommentErrors;
                foreach (CodeCommentError cce in cceList)
                {
                    stb.Append(cce.ToString() + Environment.NewLine);
                }

                output.Text = stb.ToString();
            }
        }

        private void cmdPropertiesWindow_Click(object sender, EventArgs e)
        {
            CCCPPol.EditPolicy ep = new CCCPPol.EditPolicy();
            ep.SetVisibilityToCheck(visibility);
            ep.SetElementsToCheck(elements);

            if (DialogResult.OK == ep.ShowDialog())
            {
                elements = ep.GetElementsToCheck();
                visibility = ep.GetVisibilityToCheck();
            }
        }

        private void cmdSerialize_Click(object sender, EventArgs e)
        {
            SerializeTest();
            DeSerializeTest();
        }

        public void SerializeTest()
        {
            CCCPPol.CCCPTfsPolicy inst = new CCCPPol.CCCPTfsPolicy();
            inst.Edit(null);

            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fs, inst);
            fs.Close();
        }

        public void DeSerializeTest()
        {
            CCCPPol.CCCPTfsPolicy inst = null;

            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            inst = (CCCPPol.CCCPTfsPolicy)b.Deserialize(fs);
            fs.Close();
            inst.Edit(null);
        }

        private void testAssemblyPicker_Click(object sender, EventArgs e)
        {
            CCCPLib.Extensibility.PluginAssemblyPicker pap = new CCCPLib.Extensibility.PluginAssemblyPicker();

            pap.LoadAssemblyList();
            pap.ShowDialog();
        }
    }
}