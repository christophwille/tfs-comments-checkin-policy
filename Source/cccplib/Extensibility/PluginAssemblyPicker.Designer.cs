namespace CCCPLib.Extensibility
{
    partial class PluginAssemblyPicker
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
            this.assemblyList = new System.Windows.Forms.ListView();
            this.colAssemblyName = new System.Windows.Forms.ColumnHeader();
            this.colVersion = new System.Windows.Forms.ColumnHeader();
            this.colCulture = new System.Windows.Forms.ColumnHeader();
            this.colPublicKeyToken = new System.Windows.Forms.ColumnHeader();
            this.colPA = new System.Windows.Forms.ColumnHeader();
            this.addAssemblyToCCCP = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // assemblyList
            // 
            this.assemblyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssemblyName,
            this.colVersion,
            this.colCulture,
            this.colPublicKeyToken,
            this.colPA});
            this.assemblyList.FullRowSelect = true;
            this.assemblyList.Location = new System.Drawing.Point(12, 12);
            this.assemblyList.MultiSelect = false;
            this.assemblyList.Name = "assemblyList";
            this.assemblyList.Size = new System.Drawing.Size(584, 310);
            this.assemblyList.TabIndex = 0;
            this.assemblyList.UseCompatibleStateImageBehavior = false;
            this.assemblyList.View = System.Windows.Forms.View.Details;
            // 
            // colAssemblyName
            // 
            this.colAssemblyName.Text = "Assembly Name";
            this.colAssemblyName.Width = 292;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            this.colVersion.Width = 82;
            // 
            // colCulture
            // 
            this.colCulture.Text = "Culture";
            // 
            // colPublicKeyToken
            // 
            this.colPublicKeyToken.Text = "Public Key Token";
            // 
            // colPA
            // 
            this.colPA.Text = "Processor Architecture";
            // 
            // addAssemblyToCCCP
            // 
            this.addAssemblyToCCCP.Location = new System.Drawing.Point(12, 328);
            this.addAssemblyToCCCP.Name = "addAssemblyToCCCP";
            this.addAssemblyToCCCP.Size = new System.Drawing.Size(75, 23);
            this.addAssemblyToCCCP.TabIndex = 1;
            this.addAssemblyToCCCP.Text = "Add";
            this.addAssemblyToCCCP.UseVisualStyleBackColor = true;
            this.addAssemblyToCCCP.Click += new System.EventHandler(this.addAssemblyToCCCP_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(93, 328);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // PluginAssemblyPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 369);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addAssemblyToCCCP);
            this.Controls.Add(this.assemblyList);
            this.Name = "PluginAssemblyPicker";
            this.Text = "Pick CCCP Plugin Assembly";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView assemblyList;
        private System.Windows.Forms.ColumnHeader colAssemblyName;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.Button addAssemblyToCCCP;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ColumnHeader colCulture;
        private System.Windows.Forms.ColumnHeader colPublicKeyToken;
        private System.Windows.Forms.ColumnHeader colPA;
    }
}