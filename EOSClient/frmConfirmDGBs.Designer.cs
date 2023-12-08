using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;

namespace EOSClient
{
    partial class frmConfirmDGBs
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
            this.btnCanc = new System.Windows.Forms.Button();
            this.btnConf = new System.Windows.Forms.Button();
            this.lblconf = new System.Windows.Forms.Label();
            this.txtLoadExam = new System.Windows.Forms.TextBox();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.chkLoad = new System.Windows.Forms.CheckBox();
            this.lblLoad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCanc
            // 
            this.btnCanc.Location = new System.Drawing.Point(110, 133);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(98, 24);
            this.btnCanc.TabIndex = 0;
            this.btnCanc.Text = "nah bro";
            this.btnCanc.Click += new System.EventHandler(this.btnCancClickedHandler);
            // 
            // btnConf
            // 
            this.btnConf.Location = new System.Drawing.Point(320, 133);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(98, 24);
            this.btnConf.TabIndex = 1;
            this.btnConf.Text = "ye bruh";
            this.btnConf.Click += new System.EventHandler(this.btnConfClickedHandler);
            // 
            // lblconf
            // 
            this.lblconf.AutoSize = true;
            this.lblconf.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblconf.Location = new System.Drawing.Point(168, 13);
            this.lblconf.Name = "lblconf";
            this.lblconf.Size = new System.Drawing.Size(213, 40);
            this.lblconf.TabIndex = 2;
            this.lblconf.Text = "bro u sure ?";
            // 
            // txtLoadExam
            // 
            this.txtLoadExam.Location = new System.Drawing.Point(162, 82);
            this.txtLoadExam.Name = "txtLoadExam";
            this.txtLoadExam.Size = new System.Drawing.Size(256, 22);
            this.txtLoadExam.TabIndex = 0;
            this.txtLoadExam.Enabled = false;
            this.txtLoadExam.TextChanged += new System.EventHandler(this.txtLoadExam_TextChanged);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.AutoSize = true;
            this.btnBrowseFile.Location = new System.Drawing.Point(424, 80);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(69, 26);
            this.btnBrowseFile.TabIndex = 3;
            this.btnBrowseFile.Text = "Browse";
            this.btnBrowseFile.Enabled = false;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // chkLoad
            // 
            this.chkLoad.AutoSize = true;
            this.chkLoad.Location = new System.Drawing.Point(63, 85);
            this.chkLoad.Name = "chkLoad";
            this.chkLoad.Size = new System.Drawing.Size(18, 17);
            this.chkLoad.TabIndex = 4;
            this.chkLoad.CheckedChanged += new System.EventHandler(this.chkLoad_CheckedChanged);
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(81, 85);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(75, 16);
            this.lblLoad.TabIndex = 5;
            this.lblLoad.Text = "Load Exam";
            // 
            // frmConfirmDGBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 177);
            this.Controls.Add(this.btnCanc);
            this.Controls.Add(this.btnConf);
            this.Controls.Add(this.lblconf);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.txtLoadExam);
            this.Controls.Add(this.chkLoad);
            this.Controls.Add(this.lblLoad);
            this.Name = "frmConfirmDGBs";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        



        private global::System.Windows.Forms.Button btnConf;

        private global::System.Windows.Forms.Button btnCanc;

        private global::System.Windows.Forms.Label lblconf;

        private global::System.Windows.Forms.TextBox txtLoadExam;

        private global::System.Windows.Forms.FileDialog fdlg;

        private global::System.Windows.Forms.Button btnBrowseFile;

        private global::System.Windows.Forms.CheckBox chkLoad;

        private global::System.Windows.Forms.Label lblLoad;
    
    }
}