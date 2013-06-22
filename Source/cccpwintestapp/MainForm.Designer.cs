namespace cccpwintestapp
{
    partial class MainForm
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
            this.checkForPolicyViolation = new System.Windows.Forms.Button();
            this.theCodeToCheck = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.cmdPropertiesWindow = new System.Windows.Forms.Button();
            this.cmdSerialize = new System.Windows.Forms.Button();
            this.cmdVerifyVBNET = new System.Windows.Forms.Button();
            this.testAssemblyPicker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkForPolicyViolation
            // 
            this.checkForPolicyViolation.Location = new System.Drawing.Point(156, 409);
            this.checkForPolicyViolation.Name = "checkForPolicyViolation";
            this.checkForPolicyViolation.Size = new System.Drawing.Size(65, 23);
            this.checkForPolicyViolation.TabIndex = 0;
            this.checkForPolicyViolation.Text = "Verify C#";
            this.checkForPolicyViolation.UseVisualStyleBackColor = true;
            this.checkForPolicyViolation.Click += new System.EventHandler(this.checkForPolicyViolation_Click);
            // 
            // theCodeToCheck
            // 
            this.theCodeToCheck.Location = new System.Drawing.Point(13, 13);
            this.theCodeToCheck.Multiline = true;
            this.theCodeToCheck.Name = "theCodeToCheck";
            this.theCodeToCheck.Size = new System.Drawing.Size(721, 390);
            this.theCodeToCheck.TabIndex = 1;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(13, 447);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(721, 139);
            this.output.TabIndex = 2;
            // 
            // cmdPropertiesWindow
            // 
            this.cmdPropertiesWindow.Location = new System.Drawing.Point(13, 409);
            this.cmdPropertiesWindow.Name = "cmdPropertiesWindow";
            this.cmdPropertiesWindow.Size = new System.Drawing.Size(103, 23);
            this.cmdPropertiesWindow.TabIndex = 3;
            this.cmdPropertiesWindow.Text = "Edit Configuration";
            this.cmdPropertiesWindow.UseVisualStyleBackColor = true;
            this.cmdPropertiesWindow.Click += new System.EventHandler(this.cmdPropertiesWindow_Click);
            // 
            // cmdSerialize
            // 
            this.cmdSerialize.Location = new System.Drawing.Point(630, 409);
            this.cmdSerialize.Name = "cmdSerialize";
            this.cmdSerialize.Size = new System.Drawing.Size(104, 23);
            this.cmdSerialize.TabIndex = 4;
            this.cmdSerialize.Text = "Serialize Test";
            this.cmdSerialize.UseVisualStyleBackColor = true;
            this.cmdSerialize.Click += new System.EventHandler(this.cmdSerialize_Click);
            // 
            // cmdVerifyVBNET
            // 
            this.cmdVerifyVBNET.Location = new System.Drawing.Point(227, 409);
            this.cmdVerifyVBNET.Name = "cmdVerifyVBNET";
            this.cmdVerifyVBNET.Size = new System.Drawing.Size(91, 23);
            this.cmdVerifyVBNET.TabIndex = 5;
            this.cmdVerifyVBNET.Text = "Verify VB.NET";
            this.cmdVerifyVBNET.UseVisualStyleBackColor = true;
            this.cmdVerifyVBNET.Click += new System.EventHandler(this.cmdVerifyVBNET_Click);
            // 
            // testAssemblyPicker
            // 
            this.testAssemblyPicker.Location = new System.Drawing.Point(360, 410);
            this.testAssemblyPicker.Name = "testAssemblyPicker";
            this.testAssemblyPicker.Size = new System.Drawing.Size(75, 23);
            this.testAssemblyPicker.TabIndex = 6;
            this.testAssemblyPicker.Text = "button1";
            this.testAssemblyPicker.UseVisualStyleBackColor = true;
            this.testAssemblyPicker.Click += new System.EventHandler(this.testAssemblyPicker_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 598);
            this.Controls.Add(this.testAssemblyPicker);
            this.Controls.Add(this.cmdVerifyVBNET);
            this.Controls.Add(this.cmdSerialize);
            this.Controls.Add(this.cmdPropertiesWindow);
            this.Controls.Add(this.output);
            this.Controls.Add(this.theCodeToCheck);
            this.Controls.Add(this.checkForPolicyViolation);
            this.Name = "MainForm";
            this.Text = "Test Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkForPolicyViolation;
        private System.Windows.Forms.TextBox theCodeToCheck;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button cmdPropertiesWindow;
        private System.Windows.Forms.Button cmdSerialize;
        private System.Windows.Forms.Button cmdVerifyVBNET;
        private System.Windows.Forms.Button testAssemblyPicker;
    }
}

