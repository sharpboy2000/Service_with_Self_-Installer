using System.Drawing;
using System.Windows.Forms;

namespace Self_Installer_service
{
    partial class Form1:Form
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
            this.ServiceInstall = new System.Windows.Forms.Button();
            this.ServiceMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServiceInstall
            // 
            this.ServiceInstall.Location = new System.Drawing.Point(12, 43);
            this.ServiceInstall.Name = "ServiceInstall";
            this.ServiceInstall.Size = new System.Drawing.Size(150, 29);
            this.ServiceInstall.TabIndex = 0;
            this.ServiceInstall.Text = "Install Service";
            this.ServiceInstall.UseVisualStyleBackColor = true;
            this.ServiceInstall.Click += new System.EventHandler(this.ServiceInstall_Click);
            // 
            // ServiceMode
            // 
            this.ServiceMode.Location = new System.Drawing.Point(12, 78);
            this.ServiceMode.Name = "ServiceMode";
            this.ServiceMode.Size = new System.Drawing.Size(150, 29);
            this.ServiceMode.TabIndex = 0;
            this.ServiceMode.Text = "Stop";
            this.ServiceMode.UseVisualStyleBackColor = true;
            this.ServiceMode.Click += new System.EventHandler(this.ServiceMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 172);
            this.Controls.Add(this.ServiceMode);
            this.Controls.Add(this.ServiceInstall);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button ServiceInstall;
        private Button ServiceMode;
    }

}