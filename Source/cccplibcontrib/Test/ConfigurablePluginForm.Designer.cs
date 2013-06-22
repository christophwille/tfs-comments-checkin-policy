namespace CCCPLibContrib.Test
{
    partial class ConfigurablePluginForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.theValueBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(141, 13);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(131, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK Test Value";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // theValueBox
            // 
            this.theValueBox.Location = new System.Drawing.Point(13, 13);
            this.theValueBox.Name = "theValueBox";
            this.theValueBox.Size = new System.Drawing.Size(122, 20);
            this.theValueBox.TabIndex = 1;
            // 
            // ConfigurablePluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 54);
            this.Controls.Add(this.theValueBox);
            this.Controls.Add(this.okButton);
            this.Name = "ConfigurablePluginForm";
            this.Text = "ConfigurablePluginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox theValueBox;
    }
}