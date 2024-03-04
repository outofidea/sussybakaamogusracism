using System.Windows.Forms;

namespace EOSClient
{
	// Token: 0x02000006 RID: 6
	public partial class AuthenticateForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000026B8 File Offset: 0x000008B8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000026F4 File Offset: 0x000008F4
		private void InitializeComponent()
		{
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblExamCode = new System.Windows.Forms.Label();
            this.txtExamCode = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.linkLBLCheckFont = new System.Windows.Forms.LinkLabel();
            this.lblLinkCheckSound = new System.Windows.Forms.LinkLabel();
            this.linkLBLCheckGUI = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(114, 222);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(103, 26);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(115, 92);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(327, 22);
            this.txtUser.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(115, 138);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(327, 26);
            this.txtPassword.TabIndex = 2;
            // 
            // txtDomain
            // 
            this.txtDomain.Enabled = false;
            this.txtDomain.Location = new System.Drawing.Point(115, 185);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(327, 22);
            this.txtDomain.TabIndex = 9;
            this.txtDomain.Text = "FU.EDU.VN";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(18, 92);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(99, 20);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "User Name:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(29, 138);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(88, 20);
            this.lblPass.TabIndex = 7;
            this.lblPass.Text = "Password:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(276, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Exit";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomain.Location = new System.Drawing.Point(44, 185);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(72, 20);
            this.lblDomain.TabIndex = 5;
            this.lblDomain.Text = "Domain:";
            // 
            // lblExamCode
            // 
            this.lblExamCode.AutoSize = true;
            this.lblExamCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamCode.Location = new System.Drawing.Point(17, 44);
            this.lblExamCode.Name = "lblExamCode";
            this.lblExamCode.Size = new System.Drawing.Size(100, 20);
            this.lblExamCode.TabIndex = 10;
            this.lblExamCode.Text = "Exam Code:";
            // 
            // txtExamCode
            // 
            this.txtExamCode.Location = new System.Drawing.Point(115, 44);
            this.txtExamCode.Name = "txtExamCode";
            this.txtExamCode.Size = new System.Drawing.Size(327, 22);
            this.txtExamCode.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(28, 288);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(425, 20);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "Register the exam may take some minutes, please wait!";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(319, 10);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(121, 16);
            this.lblVersion.TabIndex = 12;
            this.lblVersion.Text = "Version 21.07.20.17";
            // 
            // linkLBLCheckFont
            // 
            this.linkLBLCheckFont.AutoSize = true;
            this.linkLBLCheckFont.Location = new System.Drawing.Point(272, 263);
            this.linkLBLCheckFont.Name = "linkLBLCheckFont";
            this.linkLBLCheckFont.Size = new System.Drawing.Size(69, 16);
            this.linkLBLCheckFont.TabIndex = 13;
            this.linkLBLCheckFont.TabStop = true;
            this.linkLBLCheckFont.Text = "Check font";
            this.linkLBLCheckFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLBLCheckFont_LinkClicked);
            // 
            // lblLinkCheckSound
            // 
            this.lblLinkCheckSound.AutoSize = true;
            this.lblLinkCheckSound.Location = new System.Drawing.Point(112, 263);
            this.lblLinkCheckSound.Name = "lblLinkCheckSound";
            this.lblLinkCheckSound.Size = new System.Drawing.Size(135, 16);
            this.lblLinkCheckSound.TabIndex = 14;
            this.lblLinkCheckSound.TabStop = true;
            this.lblLinkCheckSound.Text = "Check sound (7 secs)";
            this.lblLinkCheckSound.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkCheckSound_LinkClicked);
            // 
            // linkLBLCheckGUI
            // 
            this.linkLBLCheckGUI.AutoSize = true;
            this.linkLBLCheckGUI.Location = new System.Drawing.Point(0, 0);
            this.linkLBLCheckGUI.Name = "linkLBLCheckGUI";
            this.linkLBLCheckGUI.Size = new System.Drawing.Size(185, 16);
            this.linkLBLCheckGUI.TabIndex = 0;
            this.linkLBLCheckGUI.TabStop = true;
            this.linkLBLCheckGUI.Text = "Check exam GUI (debug only)";
            this.linkLBLCheckGUI.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLBLCheckGUI_LinkClicked);
            // 
            // AuthenticateForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(460, 333);
            this.Controls.Add(this.lblLinkCheckSound);
            this.Controls.Add(this.linkLBLCheckFont);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblExamCode);
            this.Controls.Add(this.txtExamCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.linkLBLCheckGUI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthenticateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EOS Login Form";
            this.Load += new System.EventHandler(this.AuthenticateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        // Token: 0x04000008 RID: 8
        private global::System.Windows.Forms.Button btnLogin;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.TextBox txtUser;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.TextBox txtPassword;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.TextBox txtDomain;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label lblUser;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Label lblPass;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label lblDomain;

		// Token: 0x04000010 RID: 16
		private global::System.ComponentModel.Container components = null;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Label lblExamCode;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Label lblMessage;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Label lblVersion;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.LinkLabel linkLBLCheckFont;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.LinkLabel lblLinkCheckSound;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.TextBox txtExamCode;

		private global::System.Windows.Forms.LinkLabel linkLBLCheckGUI;
	}
}
