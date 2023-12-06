using System.Runtime.CompilerServices;

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

            this.SuspendLayout();
            // 
            // btnCanc
            // 
            this.btnCanc.Location = new System.Drawing.Point(77, 112);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(103, 43);
            this.btnCanc.TabIndex = 0;
            this.btnCanc.Text = "nah bro";
            // 
            // btnConf
            // 
            this.btnConf.Location = new System.Drawing.Point(287, 112);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(103, 43);
            this.btnConf.TabIndex = 1;
            this.btnConf.Text = "ye bruh";
            // 
            // lblconf
            // 
            this.lblconf.AutoSize = true;
            this.lblconf.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblconf.Location = new System.Drawing.Point(125, 9);
            this.lblconf.Name = "lblconf";
            this.lblconf.Size = new System.Drawing.Size(213, 40);
            this.lblconf.TabIndex = 2;
            this.lblconf.Text = "bro u sure ?";
            // 
            // frmConfirmDGBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 177);
            this.Controls.Add(this.btnCanc);
            this.Controls.Add(this.btnConf);
            this.Controls.Add(this.lblconf);
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
    }
}