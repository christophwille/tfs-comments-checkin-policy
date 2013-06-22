using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCCPLibContrib.Test
{
    public partial class ConfigurablePluginForm : Form
    {
        public ConfigurablePluginForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        public string TheValue
        {
            get { return theValueBox.Text; }
            set { theValueBox.Text = value;  }
        }
    }
}