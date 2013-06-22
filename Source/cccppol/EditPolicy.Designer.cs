namespace CCCPPol
{
    partial class EditPolicy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPolicy));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblVersionInfo = new System.Windows.Forms.LinkLabel();
            this.TreatPeAsVCheckBox = new System.Windows.Forms.CheckBox();
            this.OptionsTabControl = new System.Windows.Forms.TabControl();
            this.StandardOptionsTab = new System.Windows.Forms.TabPage();
            this.ckDoCheckOverrideElements = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckVbNetCheckBox = new System.Windows.Forms.CheckBox();
            this.CheckCSharpCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clbElements = new System.Windows.Forms.CheckedListBox();
            this.clbVisibility = new System.Windows.Forms.CheckedListBox();
            this.PathsToVerifyTab = new System.Windows.Forms.TabPage();
            this.RemovePathButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ServerPathToAdd = new System.Windows.Forms.TextBox();
            this.IncludedPathsListbox = new System.Windows.Forms.ListBox();
            this.AddPathButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ExcludedNamespacesTab = new System.Windows.Forms.TabPage();
            this.RemoveNamespaceFromExcludedListButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.NamespaceToExcludeTextbox = new System.Windows.Forms.TextBox();
            this.ExcludedNamespacesListbox = new System.Windows.Forms.ListBox();
            this.AddNamespaceToExcludedListButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.AdvancedTab = new System.Windows.Forms.TabPage();
            this.pluginDescription = new System.Windows.Forms.TextBox();
            this.configurePlugin = new System.Windows.Forms.Button();
            this.removePlugin = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pluginListBox = new System.Windows.Forms.CheckedListBox();
            this.OptionsTabControl.SuspendLayout();
            this.StandardOptionsTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PathsToVerifyTab.SuspendLayout();
            this.ExcludedNamespacesTab.SuspendLayout();
            this.AdvancedTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(285, 379);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 28);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(389, 379);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 28);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // lblVersionInfo
            // 
            this.lblVersionInfo.AutoSize = true;
            this.lblVersionInfo.Location = new System.Drawing.Point(21, 385);
            this.lblVersionInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersionInfo.Name = "lblVersionInfo";
            this.lblVersionInfo.Size = new System.Drawing.Size(135, 17);
            this.lblVersionInfo.TabIndex = 2;
            this.lblVersionInfo.TabStop = true;
            this.lblVersionInfo.Text = "based on nrefactory";
            this.lblVersionInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblVersionInfo_LinkClicked);
            // 
            // TreatPeAsVCheckBox
            // 
            this.TreatPeAsVCheckBox.AutoSize = true;
            this.TreatPeAsVCheckBox.Location = new System.Drawing.Point(21, 351);
            this.TreatPeAsVCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TreatPeAsVCheckBox.Name = "TreatPeAsVCheckBox";
            this.TreatPeAsVCheckBox.Size = new System.Drawing.Size(266, 21);
            this.TreatPeAsVCheckBox.TabIndex = 1;
            this.TreatPeAsVCheckBox.Text = "Treat parser errors as policy violation";
            this.TreatPeAsVCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsTabControl
            // 
            this.OptionsTabControl.Controls.Add(this.StandardOptionsTab);
            this.OptionsTabControl.Controls.Add(this.PathsToVerifyTab);
            this.OptionsTabControl.Controls.Add(this.ExcludedNamespacesTab);
            this.OptionsTabControl.Controls.Add(this.AdvancedTab);
            this.OptionsTabControl.Location = new System.Drawing.Point(16, 15);
            this.OptionsTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OptionsTabControl.Name = "OptionsTabControl";
            this.OptionsTabControl.SelectedIndex = 0;
            this.OptionsTabControl.Size = new System.Drawing.Size(479, 325);
            this.OptionsTabControl.TabIndex = 0;
            // 
            // StandardOptionsTab
            // 
            this.StandardOptionsTab.Controls.Add(this.ckDoCheckOverrideElements);
            this.StandardOptionsTab.Controls.Add(this.groupBox1);
            this.StandardOptionsTab.Controls.Add(this.label1);
            this.StandardOptionsTab.Controls.Add(this.label2);
            this.StandardOptionsTab.Controls.Add(this.clbElements);
            this.StandardOptionsTab.Controls.Add(this.clbVisibility);
            this.StandardOptionsTab.Location = new System.Drawing.Point(4, 25);
            this.StandardOptionsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StandardOptionsTab.Name = "StandardOptionsTab";
            this.StandardOptionsTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StandardOptionsTab.Size = new System.Drawing.Size(471, 296);
            this.StandardOptionsTab.TabIndex = 0;
            this.StandardOptionsTab.Text = "Options";
            this.StandardOptionsTab.UseVisualStyleBackColor = true;
            // 
            // ckDoCheckOverrideElements
            // 
            this.ckDoCheckOverrideElements.AutoSize = true;
            this.ckDoCheckOverrideElements.Location = new System.Drawing.Point(17, 250);
            this.ckDoCheckOverrideElements.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckDoCheckOverrideElements.Name = "ckDoCheckOverrideElements";
            this.ckDoCheckOverrideElements.Size = new System.Drawing.Size(190, 21);
            this.ckDoCheckOverrideElements.TabIndex = 5;
            this.ckDoCheckOverrideElements.Text = "Check Override Elements";
            this.ckDoCheckOverrideElements.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckVbNetCheckBox);
            this.groupBox1.Controls.Add(this.CheckCSharpCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(8, 153);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(449, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Languages to Check";
            // 
            // CheckVbNetCheckBox
            // 
            this.CheckVbNetCheckBox.AutoSize = true;
            this.CheckVbNetCheckBox.Location = new System.Drawing.Point(9, 54);
            this.CheckVbNetCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckVbNetCheckBox.Name = "CheckVbNetCheckBox";
            this.CheckVbNetCheckBox.Size = new System.Drawing.Size(80, 21);
            this.CheckVbNetCheckBox.TabIndex = 1;
            this.CheckVbNetCheckBox.Text = "VB.NET";
            this.CheckVbNetCheckBox.UseVisualStyleBackColor = true;
            // 
            // CheckCSharpCheckBox
            // 
            this.CheckCSharpCheckBox.AutoSize = true;
            this.CheckCSharpCheckBox.Location = new System.Drawing.Point(9, 25);
            this.CheckCSharpCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckCSharpCheckBox.Name = "CheckCSharpCheckBox";
            this.CheckCSharpCheckBox.Size = new System.Drawing.Size(47, 21);
            this.CheckCSharpCheckBox.TabIndex = 0;
            this.CheckCSharpCheckBox.Text = "C#";
            this.CheckCSharpCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visibility";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Elements";
            // 
            // clbElements
            // 
            this.clbElements.FormattingEnabled = true;
            this.clbElements.Location = new System.Drawing.Point(253, 30);
            this.clbElements.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbElements.Name = "clbElements";
            this.clbElements.Size = new System.Drawing.Size(203, 106);
            this.clbElements.TabIndex = 3;
            // 
            // clbVisibility
            // 
            this.clbVisibility.FormattingEnabled = true;
            this.clbVisibility.Location = new System.Drawing.Point(8, 30);
            this.clbVisibility.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbVisibility.Name = "clbVisibility";
            this.clbVisibility.Size = new System.Drawing.Size(203, 106);
            this.clbVisibility.TabIndex = 1;
            // 
            // PathsToVerifyTab
            // 
            this.PathsToVerifyTab.Controls.Add(this.RemovePathButton);
            this.PathsToVerifyTab.Controls.Add(this.label5);
            this.PathsToVerifyTab.Controls.Add(this.ServerPathToAdd);
            this.PathsToVerifyTab.Controls.Add(this.IncludedPathsListbox);
            this.PathsToVerifyTab.Controls.Add(this.AddPathButton);
            this.PathsToVerifyTab.Controls.Add(this.label4);
            this.PathsToVerifyTab.Location = new System.Drawing.Point(4, 25);
            this.PathsToVerifyTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PathsToVerifyTab.Name = "PathsToVerifyTab";
            this.PathsToVerifyTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PathsToVerifyTab.Size = new System.Drawing.Size(471, 296);
            this.PathsToVerifyTab.TabIndex = 2;
            this.PathsToVerifyTab.Text = "Included Paths";
            this.PathsToVerifyTab.UseVisualStyleBackColor = true;
            // 
            // RemovePathButton
            // 
            this.RemovePathButton.Location = new System.Drawing.Point(360, 92);
            this.RemovePathButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RemovePathButton.Name = "RemovePathButton";
            this.RemovePathButton.Size = new System.Drawing.Size(100, 28);
            this.RemovePathButton.TabIndex = 4;
            this.RemovePathButton.Text = "Remove";
            this.RemovePathButton.UseVisualStyleBackColor = true;
            this.RemovePathButton.Click += new System.EventHandler(this.RemovePathButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Included paths (empty list: ALL)";
            // 
            // ServerPathToAdd
            // 
            this.ServerPathToAdd.Location = new System.Drawing.Point(13, 30);
            this.ServerPathToAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServerPathToAdd.Name = "ServerPathToAdd";
            this.ServerPathToAdd.Size = new System.Drawing.Size(337, 22);
            this.ServerPathToAdd.TabIndex = 1;
            this.ServerPathToAdd.Text = "$/Projectname/Main/Source/Subdirectory";
            // 
            // IncludedPathsListbox
            // 
            this.IncludedPathsListbox.FormattingEnabled = true;
            this.IncludedPathsListbox.HorizontalScrollbar = true;
            this.IncludedPathsListbox.ItemHeight = 16;
            this.IncludedPathsListbox.Location = new System.Drawing.Point(13, 92);
            this.IncludedPathsListbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IncludedPathsListbox.Name = "IncludedPathsListbox";
            this.IncludedPathsListbox.Size = new System.Drawing.Size(337, 196);
            this.IncludedPathsListbox.TabIndex = 3;
            // 
            // AddPathButton
            // 
            this.AddPathButton.Location = new System.Drawing.Point(360, 30);
            this.AddPathButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddPathButton.Name = "AddPathButton";
            this.AddPathButton.Size = new System.Drawing.Size(100, 28);
            this.AddPathButton.TabIndex = 2;
            this.AddPathButton.Text = "Add";
            this.AddPathButton.UseVisualStyleBackColor = true;
            this.AddPathButton.Click += new System.EventHandler(this.AddPathButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Server path to include in code comment checks:";
            // 
            // ExcludedNamespacesTab
            // 
            this.ExcludedNamespacesTab.Controls.Add(this.RemoveNamespaceFromExcludedListButton);
            this.ExcludedNamespacesTab.Controls.Add(this.label6);
            this.ExcludedNamespacesTab.Controls.Add(this.NamespaceToExcludeTextbox);
            this.ExcludedNamespacesTab.Controls.Add(this.ExcludedNamespacesListbox);
            this.ExcludedNamespacesTab.Controls.Add(this.AddNamespaceToExcludedListButton);
            this.ExcludedNamespacesTab.Controls.Add(this.label7);
            this.ExcludedNamespacesTab.Location = new System.Drawing.Point(4, 25);
            this.ExcludedNamespacesTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExcludedNamespacesTab.Name = "ExcludedNamespacesTab";
            this.ExcludedNamespacesTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExcludedNamespacesTab.Size = new System.Drawing.Size(471, 296);
            this.ExcludedNamespacesTab.TabIndex = 3;
            this.ExcludedNamespacesTab.Text = "Excluded Namespaces";
            this.ExcludedNamespacesTab.UseVisualStyleBackColor = true;
            // 
            // RemoveNamespaceFromExcludedListButton
            // 
            this.RemoveNamespaceFromExcludedListButton.Location = new System.Drawing.Point(359, 90);
            this.RemoveNamespaceFromExcludedListButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RemoveNamespaceFromExcludedListButton.Name = "RemoveNamespaceFromExcludedListButton";
            this.RemoveNamespaceFromExcludedListButton.Size = new System.Drawing.Size(100, 28);
            this.RemoveNamespaceFromExcludedListButton.TabIndex = 9;
            this.RemoveNamespaceFromExcludedListButton.Text = "Remove";
            this.RemoveNamespaceFromExcludedListButton.UseVisualStyleBackColor = true;
            this.RemoveNamespaceFromExcludedListButton.Click += new System.EventHandler(this.RemoveNamespaceFromExcludedListButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Excluded namespaces (empty list: NONE)";
            // 
            // NamespaceToExcludeTextbox
            // 
            this.NamespaceToExcludeTextbox.Location = new System.Drawing.Point(12, 27);
            this.NamespaceToExcludeTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NamespaceToExcludeTextbox.Name = "NamespaceToExcludeTextbox";
            this.NamespaceToExcludeTextbox.Size = new System.Drawing.Size(337, 22);
            this.NamespaceToExcludeTextbox.TabIndex = 6;
            this.NamespaceToExcludeTextbox.Text = "Company.NamespaceOne.Sample";
            // 
            // ExcludedNamespacesListbox
            // 
            this.ExcludedNamespacesListbox.FormattingEnabled = true;
            this.ExcludedNamespacesListbox.HorizontalScrollbar = true;
            this.ExcludedNamespacesListbox.ItemHeight = 16;
            this.ExcludedNamespacesListbox.Location = new System.Drawing.Point(12, 90);
            this.ExcludedNamespacesListbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExcludedNamespacesListbox.Name = "ExcludedNamespacesListbox";
            this.ExcludedNamespacesListbox.Size = new System.Drawing.Size(337, 196);
            this.ExcludedNamespacesListbox.TabIndex = 8;
            // 
            // AddNamespaceToExcludedListButton
            // 
            this.AddNamespaceToExcludedListButton.Location = new System.Drawing.Point(359, 27);
            this.AddNamespaceToExcludedListButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddNamespaceToExcludedListButton.Name = "AddNamespaceToExcludedListButton";
            this.AddNamespaceToExcludedListButton.Size = new System.Drawing.Size(100, 28);
            this.AddNamespaceToExcludedListButton.TabIndex = 7;
            this.AddNamespaceToExcludedListButton.Text = "Add";
            this.AddNamespaceToExcludedListButton.UseVisualStyleBackColor = true;
            this.AddNamespaceToExcludedListButton.Click += new System.EventHandler(this.AddNamespaceToExcludedListButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(331, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Namespace to exclude from code comment checks:";
            // 
            // AdvancedTab
            // 
            this.AdvancedTab.Controls.Add(this.pluginDescription);
            this.AdvancedTab.Controls.Add(this.configurePlugin);
            this.AdvancedTab.Controls.Add(this.removePlugin);
            this.AdvancedTab.Controls.Add(this.addButton);
            this.AdvancedTab.Controls.Add(this.label3);
            this.AdvancedTab.Controls.Add(this.pluginListBox);
            this.AdvancedTab.Location = new System.Drawing.Point(4, 25);
            this.AdvancedTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AdvancedTab.Name = "AdvancedTab";
            this.AdvancedTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AdvancedTab.Size = new System.Drawing.Size(471, 296);
            this.AdvancedTab.TabIndex = 1;
            this.AdvancedTab.Text = "Advanced";
            this.AdvancedTab.UseVisualStyleBackColor = true;
            // 
            // pluginDescription
            // 
            this.pluginDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pluginDescription.Enabled = false;
            this.pluginDescription.Location = new System.Drawing.Point(12, 160);
            this.pluginDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pluginDescription.Multiline = true;
            this.pluginDescription.Name = "pluginDescription";
            this.pluginDescription.ReadOnly = true;
            this.pluginDescription.Size = new System.Drawing.Size(417, 85);
            this.pluginDescription.TabIndex = 5;
            // 
            // configurePlugin
            // 
            this.configurePlugin.Enabled = false;
            this.configurePlugin.Location = new System.Drawing.Point(329, 36);
            this.configurePlugin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.configurePlugin.Name = "configurePlugin";
            this.configurePlugin.Size = new System.Drawing.Size(100, 28);
            this.configurePlugin.TabIndex = 4;
            this.configurePlugin.Text = "Configure";
            this.configurePlugin.UseVisualStyleBackColor = true;
            this.configurePlugin.Click += new System.EventHandler(this.configurePlugin_Click);
            // 
            // removePlugin
            // 
            this.removePlugin.Location = new System.Drawing.Point(329, 71);
            this.removePlugin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.removePlugin.Name = "removePlugin";
            this.removePlugin.Size = new System.Drawing.Size(100, 28);
            this.removePlugin.TabIndex = 3;
            this.removePlugin.Text = "Remove";
            this.removePlugin.UseVisualStyleBackColor = true;
            this.removePlugin.Click += new System.EventHandler(this.removePlugin_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(329, 123);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 28);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add Plugin";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Plugins";
            // 
            // pluginListBox
            // 
            this.pluginListBox.FormattingEnabled = true;
            this.pluginListBox.Location = new System.Drawing.Point(8, 36);
            this.pluginListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pluginListBox.Name = "pluginListBox";
            this.pluginListBox.Size = new System.Drawing.Size(293, 106);
            this.pluginListBox.TabIndex = 0;
            this.pluginListBox.SelectedIndexChanged += new System.EventHandler(this.pluginListBox_SelectedIndexChanged);
            this.pluginListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.pluginListBox_ItemCheck);
            // 
            // EditPolicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 425);
            this.Controls.Add(this.OptionsTabControl);
            this.Controls.Add(this.TreatPeAsVCheckBox);
            this.Controls.Add(this.lblVersionInfo);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EditPolicy";
            this.Text = "Edit Code Comment Checking Policy";
            this.Load += new System.EventHandler(this.EditPolicy_Load);
            this.OptionsTabControl.ResumeLayout(false);
            this.StandardOptionsTab.ResumeLayout(false);
            this.StandardOptionsTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PathsToVerifyTab.ResumeLayout(false);
            this.PathsToVerifyTab.PerformLayout();
            this.ExcludedNamespacesTab.ResumeLayout(false);
            this.ExcludedNamespacesTab.PerformLayout();
            this.AdvancedTab.ResumeLayout(false);
            this.AdvancedTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.LinkLabel lblVersionInfo;
        private System.Windows.Forms.CheckBox TreatPeAsVCheckBox;
        private System.Windows.Forms.TabControl OptionsTabControl;
        private System.Windows.Forms.TabPage StandardOptionsTab;
        private System.Windows.Forms.CheckBox ckDoCheckOverrideElements;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckVbNetCheckBox;
        private System.Windows.Forms.CheckBox CheckCSharpCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbElements;
        private System.Windows.Forms.CheckedListBox clbVisibility;
        private System.Windows.Forms.TabPage AdvancedTab;
        private System.Windows.Forms.TextBox pluginDescription;
        private System.Windows.Forms.Button configurePlugin;
        private System.Windows.Forms.Button removePlugin;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox pluginListBox;
        private System.Windows.Forms.TabPage PathsToVerifyTab;
        private System.Windows.Forms.Button RemovePathButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ServerPathToAdd;
        private System.Windows.Forms.ListBox IncludedPathsListbox;
        private System.Windows.Forms.Button AddPathButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage ExcludedNamespacesTab;
        private System.Windows.Forms.Button RemoveNamespaceFromExcludedListButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NamespaceToExcludeTextbox;
        private System.Windows.Forms.ListBox ExcludedNamespacesListbox;
        private System.Windows.Forms.Button AddNamespaceToExcludedListButton;
        private System.Windows.Forms.Label label7;
    }
}