namespace ExamClient
{
	// Token: 0x02000019 RID: 25
	public partial class frmEnglishExamClient : global::System.Windows.Forms.Form, global::IRemote.IExamclient
	{
		// Token: 0x060000DB RID: 219 RVA: 0x00004B38 File Offset: 0x00003B38
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				bool flag = this.components != null;
				if (flag)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004B70 File Offset: 0x00003B70
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ExamClient.frmEnglishExamClient));
			this.tabControlQuestion = new global::System.Windows.Forms.TabControl();
			this.tabPageReadingM = new global::System.Windows.Forms.TabPage();
			this.btnReadingZoomOut = new global::System.Windows.Forms.Button();
			this.btnReadingZoomIn = new global::System.Windows.Forms.Button();
			this.btnReadingRealSize = new global::System.Windows.Forms.Button();
			this.panelReadingM = new global::System.Windows.Forms.Panel();
			this.panelReading = new global::System.Windows.Forms.Panel();
			this.lblReadingContent = new global::System.Windows.Forms.Label();
			this.splitterPic = new global::System.Windows.Forms.Splitter();
			this.panelPicReadingM = new global::System.Windows.Forms.Panel();
			this.picBoxReadingM = new global::System.Windows.Forms.PictureBox();
			this.lblReading = new global::System.Windows.Forms.Label();
			this.label18 = new global::System.Windows.Forms.Label();
			this.btnNextQuestionM = new global::System.Windows.Forms.Button();
			this.label13 = new global::System.Windows.Forms.Label();
			this.btnNextReadingM = new global::System.Windows.Forms.Button();
			this.chkReadingF_M = new global::System.Windows.Forms.CheckBox();
			this.chkReadingE_M = new global::System.Windows.Forms.CheckBox();
			this.chkReadingD_M = new global::System.Windows.Forms.CheckBox();
			this.chkReadingC_M = new global::System.Windows.Forms.CheckBox();
			this.chkReadingB_M = new global::System.Windows.Forms.CheckBox();
			this.chkReadingA_M = new global::System.Windows.Forms.CheckBox();
			this.lstReadingQuestionM = new global::System.Windows.Forms.ListBox();
			this.tabPageGrammar = new global::System.Windows.Forms.TabPage();
			this.panelGrammar = new global::System.Windows.Forms.Panel();
			this.panelMC_Text = new global::System.Windows.Forms.Panel();
			this.lblMC_Text = new global::System.Windows.Forms.Label();
			this.splitterGrammar = new global::System.Windows.Forms.Splitter();
			this.panelPicGrammar = new global::System.Windows.Forms.Panel();
			this.picBoxGrammar = new global::System.Windows.Forms.PictureBox();
			this.lblGrammarNumber = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.btnNextGrammar = new global::System.Windows.Forms.Button();
			this.chkGrammarF = new global::System.Windows.Forms.CheckBox();
			this.chkGrammarE = new global::System.Windows.Forms.CheckBox();
			this.chkGrammarD = new global::System.Windows.Forms.CheckBox();
			this.chkGrammarC = new global::System.Windows.Forms.CheckBox();
			this.chkGrammarB = new global::System.Windows.Forms.CheckBox();
			this.chkGrammarA = new global::System.Windows.Forms.CheckBox();
			this.tabPageIndicateMistake = new global::System.Windows.Forms.TabPage();
			this.panelIndicateMistake = new global::System.Windows.Forms.Panel();
			this.lblIndicateMistake = new global::System.Windows.Forms.Label();
			this.lblIndicateNumber = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.btnNextIndiMistake = new global::System.Windows.Forms.Button();
			this.chkIndiMistakeF = new global::System.Windows.Forms.CheckBox();
			this.chkIndiMistakeE = new global::System.Windows.Forms.CheckBox();
			this.chkIndiMistakeD = new global::System.Windows.Forms.CheckBox();
			this.chkIndiMistakeC = new global::System.Windows.Forms.CheckBox();
			this.chkIndiMistakeB = new global::System.Windows.Forms.CheckBox();
			this.chkIndiMistakeA = new global::System.Windows.Forms.CheckBox();
			this.tabPageMatching = new global::System.Windows.Forms.TabPage();
			this.panelB = new global::System.Windows.Forms.Panel();
			this.lblColumnB = new global::System.Windows.Forms.Label();
			this.panelA = new global::System.Windows.Forms.Panel();
			this.lblColumnA = new global::System.Windows.Forms.Label();
			this.lblLetter = new global::System.Windows.Forms.Label();
			this.lblNumber = new global::System.Windows.Forms.Label();
			this.txtLetter = new global::System.Windows.Forms.TextBox();
			this.txtNumber = new global::System.Windows.Forms.TextBox();
			this.lblMatchNumber = new global::System.Windows.Forms.Label();
			this.lblAnswerMatch = new global::System.Windows.Forms.Label();
			this.btnNextMaching = new global::System.Windows.Forms.Button();
			this.btnRemoveMSolution = new global::System.Windows.Forms.Button();
			this.btnAddMSolution = new global::System.Windows.Forms.Button();
			this.lstAnswerMatch = new global::System.Windows.Forms.ListBox();
			this.tabPageFillBlank = new global::System.Windows.Forms.TabPage();
			this.panelFillBlank = new global::System.Windows.Forms.Panel();
			this.lblFillBlankNumber = new global::System.Windows.Forms.Label();
			this.btnNextFillBlank = new global::System.Windows.Forms.Button();
			this.tabPageEssay = new global::System.Windows.Forms.TabPage();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.btnRedo = new global::System.Windows.Forms.Button();
			this.btnUndo = new global::System.Windows.Forms.Button();
			this.label4 = new global::System.Windows.Forms.Label();
			this.btnSaveEssay = new global::System.Windows.Forms.Button();
			this.btnWordCount = new global::System.Windows.Forms.Button();
			this.lblWordCount = new global::System.Windows.Forms.Label();
			this.btnEssayZoom = new global::System.Windows.Forms.Button();
			this.btnEssayNormal = new global::System.Windows.Forms.Button();
			this.panelEssay = new global::System.Windows.Forms.Panel();
			this.txtWrittingEssay = new global::System.Windows.Forms.TextBox();
			this.splitterEssay = new global::System.Windows.Forms.Splitter();
			this.panelPicEssay = new global::System.Windows.Forms.Panel();
			this.pictureBoxEssay = new global::System.Windows.Forms.PictureBox();
			this.tabPageImagePaper = new global::System.Windows.Forms.TabPage();
			this.btnRedoPaper = new global::System.Windows.Forms.Button();
			this.btnUndoPaper = new global::System.Windows.Forms.Button();
			this.label6 = new global::System.Windows.Forms.Label();
			this.lblTime_copy = new global::System.Windows.Forms.Label();
			this.lblTimeLeft_Copy = new global::System.Windows.Forms.Label();
			this.btnFullScreen = new global::System.Windows.Forms.Button();
			this.panelAnswer = new global::System.Windows.Forms.Panel();
			this.label19 = new global::System.Windows.Forms.Label();
			this.lblPicSize = new global::System.Windows.Forms.Label();
			this.trackBarPicSize = new global::System.Windows.Forms.TrackBar();
			this.panelPaper = new global::System.Windows.Forms.Panel();
			this.pictureBoxPaper = new global::System.Windows.Forms.PictureBox();
			this.lblOver = new global::System.Windows.Forms.Label();
			this.lblExamCode = new global::System.Windows.Forms.Label();
			this.lblExamServer = new global::System.Windows.Forms.Label();
			this.lblMachine = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.lblDuration = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.lblSize = new global::System.Windows.Forms.Label();
			this.lblMark = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.lblTime = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.lblLogin = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.nudFontSize = new global::System.Windows.Forms.NumericUpDown();
			this.chbWantFinish = new global::System.Windows.Forms.CheckBox();
			this.lblSaveServer = new global::System.Windows.Forms.Label();
			this.btnFinish = new global::System.Windows.Forms.Button();
			this.btnExit = new global::System.Windows.Forms.Button();
			this.timerCountDown = new global::System.Windows.Forms.Timer(this.components);
			this.lblMesage = new global::System.Windows.Forms.Label();
			this.txtGuide = new global::System.Windows.Forms.TextBox();
			this.txtOpenCode = new global::System.Windows.Forms.TextBox();
			this.lblOpenCode = new global::System.Windows.Forms.Label();
			this.btnShowExam = new global::System.Windows.Forms.Button();
			this.timerTopMost = new global::System.Windows.Forms.Timer(this.components);
			this.label2 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.lblTotalMarks = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.panelQuestionList = new global::System.Windows.Forms.Panel();
			this.chbWantFinishTop = new global::System.Windows.Forms.CheckBox();
			this.btnFinishTop = new global::System.Windows.Forms.Button();
			this.lblVol = new global::System.Windows.Forms.Label();
			this.nudVol = new global::System.Windows.Forms.NumericUpDown();
			this.domainUpDown = new global::System.Windows.Forms.DomainUpDown();
			this.lblFont = new global::System.Windows.Forms.Label();
			this.timerBOTTest = new global::System.Windows.Forms.Timer(this.components);
			this.pictureBoxIcon = new global::System.Windows.Forms.PictureBox();
			this.btnSubmit = new global::System.Windows.Forms.Button();
			this.tabControlQuestion.SuspendLayout();
			this.tabPageReadingM.SuspendLayout();
			this.panelReadingM.SuspendLayout();
			this.panelReading.SuspendLayout();
			this.panelPicReadingM.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picBoxReadingM).BeginInit();
			this.tabPageGrammar.SuspendLayout();
			this.panelGrammar.SuspendLayout();
			this.panelMC_Text.SuspendLayout();
			this.panelPicGrammar.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picBoxGrammar).BeginInit();
			this.tabPageIndicateMistake.SuspendLayout();
			this.panelIndicateMistake.SuspendLayout();
			this.tabPageMatching.SuspendLayout();
			this.panelB.SuspendLayout();
			this.panelA.SuspendLayout();
			this.tabPageFillBlank.SuspendLayout();
			this.panelFillBlank.SuspendLayout();
			this.tabPageEssay.SuspendLayout();
			this.panelEssay.SuspendLayout();
			this.panelPicEssay.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxEssay).BeginInit();
			this.tabPageImagePaper.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarPicSize).BeginInit();
			this.panelPaper.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPaper).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudFontSize).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudVol).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxIcon).BeginInit();
			base.SuspendLayout();
			this.tabControlQuestion.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tabControlQuestion.Controls.Add(this.tabPageReadingM);
			this.tabControlQuestion.Controls.Add(this.tabPageGrammar);
			this.tabControlQuestion.Controls.Add(this.tabPageIndicateMistake);
			this.tabControlQuestion.Controls.Add(this.tabPageMatching);
			this.tabControlQuestion.Controls.Add(this.tabPageFillBlank);
			this.tabControlQuestion.Controls.Add(this.tabPageEssay);
			this.tabControlQuestion.Controls.Add(this.tabPageImagePaper);
			this.tabControlQuestion.Enabled = false;
			this.tabControlQuestion.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tabControlQuestion.Location = new global::System.Drawing.Point(16, 162);
			this.tabControlQuestion.Name = "tabControlQuestion";
			this.tabControlQuestion.SelectedIndex = 0;
			this.tabControlQuestion.Size = new global::System.Drawing.Size(925, 330);
			this.tabControlQuestion.TabIndex = 48;
			this.tabControlQuestion.SelectedIndexChanged += new global::System.EventHandler(this.tabControlQuestion_SelectedIndexChanged);
			this.tabPageReadingM.BackColor = global::System.Drawing.SystemColors.Control;
			this.tabPageReadingM.Controls.Add(this.btnReadingZoomOut);
			this.tabPageReadingM.Controls.Add(this.btnReadingZoomIn);
			this.tabPageReadingM.Controls.Add(this.btnReadingRealSize);
			this.tabPageReadingM.Controls.Add(this.panelReadingM);
			this.tabPageReadingM.Controls.Add(this.lblReading);
			this.tabPageReadingM.Controls.Add(this.label18);
			this.tabPageReadingM.Controls.Add(this.btnNextQuestionM);
			this.tabPageReadingM.Controls.Add(this.label13);
			this.tabPageReadingM.Controls.Add(this.btnNextReadingM);
			this.tabPageReadingM.Controls.Add(this.chkReadingF_M);
			this.tabPageReadingM.Controls.Add(this.chkReadingE_M);
			this.tabPageReadingM.Controls.Add(this.chkReadingD_M);
			this.tabPageReadingM.Controls.Add(this.chkReadingC_M);
			this.tabPageReadingM.Controls.Add(this.chkReadingB_M);
			this.tabPageReadingM.Controls.Add(this.chkReadingA_M);
			this.tabPageReadingM.Controls.Add(this.lstReadingQuestionM);
			this.tabPageReadingM.Location = new global::System.Drawing.Point(4, 22);
			this.tabPageReadingM.Name = "tabPageReadingM";
			this.tabPageReadingM.Size = new global::System.Drawing.Size(917, 304);
			this.tabPageReadingM.TabIndex = 3;
			this.tabPageReadingM.Text = "Reading";
			this.btnReadingZoomOut.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnReadingZoomOut.Location = new global::System.Drawing.Point(831, 3);
			this.btnReadingZoomOut.Name = "btnReadingZoomOut";
			this.btnReadingZoomOut.Size = new global::System.Drawing.Size(75, 23);
			this.btnReadingZoomOut.TabIndex = 75;
			this.btnReadingZoomOut.Text = "Zoom Out";
			this.btnReadingZoomOut.UseVisualStyleBackColor = true;
			this.btnReadingZoomOut.Click += new global::System.EventHandler(this.btnReadingZoomOut_Click);
			this.btnReadingZoomIn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnReadingZoomIn.Location = new global::System.Drawing.Point(740, 4);
			this.btnReadingZoomIn.Name = "btnReadingZoomIn";
			this.btnReadingZoomIn.Size = new global::System.Drawing.Size(75, 23);
			this.btnReadingZoomIn.TabIndex = 74;
			this.btnReadingZoomIn.Text = "Zoom In";
			this.btnReadingZoomIn.UseVisualStyleBackColor = true;
			this.btnReadingZoomIn.Click += new global::System.EventHandler(this.btnReadingZoomIn_Click);
			this.btnReadingRealSize.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnReadingRealSize.Location = new global::System.Drawing.Point(648, 4);
			this.btnReadingRealSize.Name = "btnReadingRealSize";
			this.btnReadingRealSize.Size = new global::System.Drawing.Size(75, 23);
			this.btnReadingRealSize.TabIndex = 73;
			this.btnReadingRealSize.Text = "Real size";
			this.btnReadingRealSize.UseVisualStyleBackColor = true;
			this.btnReadingRealSize.Click += new global::System.EventHandler(this.btnReadingRealSize_Click);
			this.panelReadingM.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelReadingM.Controls.Add(this.panelReading);
			this.panelReadingM.Controls.Add(this.splitterPic);
			this.panelReadingM.Controls.Add(this.panelPicReadingM);
			this.panelReadingM.Location = new global::System.Drawing.Point(152, 29);
			this.panelReadingM.Name = "panelReadingM";
			this.panelReadingM.Size = new global::System.Drawing.Size(754, 262);
			this.panelReadingM.TabIndex = 72;
			this.panelReading.AutoScroll = true;
			this.panelReading.BackColor = global::System.Drawing.Color.White;
			this.panelReading.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelReading.Controls.Add(this.lblReadingContent);
			this.panelReading.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelReading.Location = new global::System.Drawing.Point(0, 0);
			this.panelReading.Name = "panelReading";
			this.panelReading.Size = new global::System.Drawing.Size(311, 262);
			this.panelReading.TabIndex = 3;
			this.panelReading.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panelReading_MouseDown);
			this.lblReadingContent.AutoSize = true;
			this.lblReadingContent.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblReadingContent.Location = new global::System.Drawing.Point(3, 3);
			this.lblReadingContent.Name = "lblReadingContent";
			this.lblReadingContent.Size = new global::System.Drawing.Size(124, 17);
			this.lblReadingContent.TabIndex = 4;
			this.lblReadingContent.Text = "lblReadingContent";
			this.lblReadingContent.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.lblReadingContent_MouseDown_1);
			this.splitterPic.BackColor = global::System.Drawing.Color.Red;
			this.splitterPic.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.splitterPic.Location = new global::System.Drawing.Point(311, 0);
			this.splitterPic.Name = "splitterPic";
			this.splitterPic.Size = new global::System.Drawing.Size(3, 262);
			this.splitterPic.TabIndex = 2;
			this.splitterPic.TabStop = false;
			this.panelPicReadingM.AutoScroll = true;
			this.panelPicReadingM.AutoScrollMargin = new global::System.Drawing.Size(10, 10);
			this.panelPicReadingM.AutoScrollMinSize = new global::System.Drawing.Size(10, 10);
			this.panelPicReadingM.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelPicReadingM.Controls.Add(this.picBoxReadingM);
			this.panelPicReadingM.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panelPicReadingM.Location = new global::System.Drawing.Point(314, 0);
			this.panelPicReadingM.Name = "panelPicReadingM";
			this.panelPicReadingM.Size = new global::System.Drawing.Size(440, 262);
			this.panelPicReadingM.TabIndex = 0;
			this.picBoxReadingM.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.picBoxReadingM.Location = new global::System.Drawing.Point(0, 0);
			this.picBoxReadingM.Name = "picBoxReadingM";
			this.picBoxReadingM.Size = new global::System.Drawing.Size(450, 300);
			this.picBoxReadingM.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picBoxReadingM.TabIndex = 0;
			this.picBoxReadingM.TabStop = false;
			this.lblReading.AutoSize = true;
			this.lblReading.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblReading.ForeColor = global::System.Drawing.Color.Blue;
			this.lblReading.Location = new global::System.Drawing.Point(144, 8);
			this.lblReading.Name = "lblReading";
			this.lblReading.Size = new global::System.Drawing.Size(85, 17);
			this.lblReading.TabIndex = 71;
			this.lblReading.Text = "lblReading";
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.Location = new global::System.Drawing.Point(80, 32);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(54, 17);
			this.label18.TabIndex = 67;
			this.label18.Text = "Answer";
			this.btnNextQuestionM.Location = new global::System.Drawing.Point(16, 240);
			this.btnNextQuestionM.Name = "btnNextQuestionM";
			this.btnNextQuestionM.Size = new global::System.Drawing.Size(96, 23);
			this.btnNextQuestionM.TabIndex = 60;
			this.btnNextQuestionM.Text = "Next Question";
			this.btnNextQuestionM.Click += new global::System.EventHandler(this.btnNextQuestionM_Click);
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.Location = new global::System.Drawing.Point(8, 8);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(72, 17);
			this.label13.TabIndex = 59;
			this.label13.Text = "Questions";
			this.btnNextReadingM.Location = new global::System.Drawing.Point(16, 267);
			this.btnNextReadingM.Name = "btnNextReadingM";
			this.btnNextReadingM.Size = new global::System.Drawing.Size(96, 23);
			this.btnNextReadingM.TabIndex = 17;
			this.btnNextReadingM.Text = "Next Reading";
			this.btnNextReadingM.Click += new global::System.EventHandler(this.btnNextReadingM_Click);
			this.chkReadingF_M.Location = new global::System.Drawing.Point(88, 216);
			this.chkReadingF_M.Name = "chkReadingF_M";
			this.chkReadingF_M.Size = new global::System.Drawing.Size(40, 24);
			this.chkReadingF_M.TabIndex = 16;
			this.chkReadingF_M.Text = "F";
			this.chkReadingF_M.CheckedChanged += new global::System.EventHandler(this.chkReading_M_CheckedChanged);
			this.chkReadingE_M.Location = new global::System.Drawing.Point(88, 184);
			this.chkReadingE_M.Name = "chkReadingE_M";
			this.chkReadingE_M.Size = new global::System.Drawing.Size(40, 24);
			this.chkReadingE_M.TabIndex = 15;
			this.chkReadingE_M.Text = "E";
			this.chkReadingE_M.CheckedChanged += new global::System.EventHandler(this.chkReading_M_CheckedChanged);
			this.chkReadingD_M.Location = new global::System.Drawing.Point(88, 152);
			this.chkReadingD_M.Name = "chkReadingD_M";
			this.chkReadingD_M.Size = new global::System.Drawing.Size(40, 24);
			this.chkReadingD_M.TabIndex = 14;
			this.chkReadingD_M.Text = "D";
			this.chkReadingD_M.CheckedChanged += new global::System.EventHandler(this.chkReading_M_CheckedChanged);
			this.chkReadingC_M.Location = new global::System.Drawing.Point(88, 120);
			this.chkReadingC_M.Name = "chkReadingC_M";
			this.chkReadingC_M.Size = new global::System.Drawing.Size(40, 24);
			this.chkReadingC_M.TabIndex = 13;
			this.chkReadingC_M.Text = "C";
			this.chkReadingC_M.CheckedChanged += new global::System.EventHandler(this.chkReading_M_CheckedChanged);
			this.chkReadingB_M.Location = new global::System.Drawing.Point(88, 88);
			this.chkReadingB_M.Name = "chkReadingB_M";
			this.chkReadingB_M.Size = new global::System.Drawing.Size(40, 24);
			this.chkReadingB_M.TabIndex = 12;
			this.chkReadingB_M.Text = "B";
			this.chkReadingB_M.CheckedChanged += new global::System.EventHandler(this.chkReading_M_CheckedChanged);
			this.chkReadingA_M.Location = new global::System.Drawing.Point(88, 56);
			this.chkReadingA_M.Name = "chkReadingA_M";
			this.chkReadingA_M.Size = new global::System.Drawing.Size(40, 24);
			this.chkReadingA_M.TabIndex = 11;
			this.chkReadingA_M.Text = "A";
			this.chkReadingA_M.CheckedChanged += new global::System.EventHandler(this.chkReading_M_CheckedChanged);
			this.lstReadingQuestionM.Location = new global::System.Drawing.Point(18, 29);
			this.lstReadingQuestionM.Name = "lstReadingQuestionM";
			this.lstReadingQuestionM.Size = new global::System.Drawing.Size(46, 147);
			this.lstReadingQuestionM.TabIndex = 10;
			this.lstReadingQuestionM.SelectedIndexChanged += new global::System.EventHandler(this.lstReadingQuestionM_SelectedIndexChanged);
			this.tabPageGrammar.BackColor = global::System.Drawing.SystemColors.Control;
			this.tabPageGrammar.Controls.Add(this.panelGrammar);
			this.tabPageGrammar.Controls.Add(this.lblGrammarNumber);
			this.tabPageGrammar.Controls.Add(this.label14);
			this.tabPageGrammar.Controls.Add(this.btnNextGrammar);
			this.tabPageGrammar.Controls.Add(this.chkGrammarF);
			this.tabPageGrammar.Controls.Add(this.chkGrammarE);
			this.tabPageGrammar.Controls.Add(this.chkGrammarD);
			this.tabPageGrammar.Controls.Add(this.chkGrammarC);
			this.tabPageGrammar.Controls.Add(this.chkGrammarB);
			this.tabPageGrammar.Controls.Add(this.chkGrammarA);
			this.tabPageGrammar.Location = new global::System.Drawing.Point(4, 22);
			this.tabPageGrammar.Name = "tabPageGrammar";
			this.tabPageGrammar.Size = new global::System.Drawing.Size(917, 304);
			this.tabPageGrammar.TabIndex = 2;
			this.tabPageGrammar.Text = "Multiple Choices";
			this.tabPageGrammar.Visible = false;
			this.panelGrammar.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelGrammar.Controls.Add(this.panelMC_Text);
			this.panelGrammar.Controls.Add(this.splitterGrammar);
			this.panelGrammar.Controls.Add(this.panelPicGrammar);
			this.panelGrammar.Location = new global::System.Drawing.Point(80, 40);
			this.panelGrammar.Name = "panelGrammar";
			this.panelGrammar.Size = new global::System.Drawing.Size(827, 252);
			this.panelGrammar.TabIndex = 74;
			this.panelMC_Text.AutoScroll = true;
			this.panelMC_Text.BackColor = global::System.Drawing.Color.White;
			this.panelMC_Text.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelMC_Text.Controls.Add(this.lblMC_Text);
			this.panelMC_Text.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panelMC_Text.Location = new global::System.Drawing.Point(0, 0);
			this.panelMC_Text.Name = "panelMC_Text";
			this.panelMC_Text.Size = new global::System.Drawing.Size(213, 252);
			this.panelMC_Text.TabIndex = 3;
			this.panelMC_Text.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panelMC_Text_MouseDown);
			this.lblMC_Text.AutoSize = true;
			this.lblMC_Text.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMC_Text.Location = new global::System.Drawing.Point(4, 5);
			this.lblMC_Text.Name = "lblMC_Text";
			this.lblMC_Text.Size = new global::System.Drawing.Size(75, 16);
			this.lblMC_Text.TabIndex = 0;
			this.lblMC_Text.Text = "lblMC_Text";
			this.lblMC_Text.UseMnemonic = false;
			this.lblMC_Text.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.lblMC_Text_MouseDown);
			this.splitterGrammar.BackColor = global::System.Drawing.Color.Red;
			this.splitterGrammar.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.splitterGrammar.Location = new global::System.Drawing.Point(213, 0);
			this.splitterGrammar.Name = "splitterGrammar";
			this.splitterGrammar.Size = new global::System.Drawing.Size(5, 252);
			this.splitterGrammar.TabIndex = 2;
			this.splitterGrammar.TabStop = false;
			this.panelPicGrammar.AutoScroll = true;
			this.panelPicGrammar.AutoScrollMargin = new global::System.Drawing.Size(10, 10);
			this.panelPicGrammar.AutoScrollMinSize = new global::System.Drawing.Size(10, 10);
			this.panelPicGrammar.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelPicGrammar.Controls.Add(this.picBoxGrammar);
			this.panelPicGrammar.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panelPicGrammar.Location = new global::System.Drawing.Point(218, 0);
			this.panelPicGrammar.Name = "panelPicGrammar";
			this.panelPicGrammar.Size = new global::System.Drawing.Size(609, 252);
			this.panelPicGrammar.TabIndex = 0;
			this.picBoxGrammar.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.picBoxGrammar.Location = new global::System.Drawing.Point(0, 0);
			this.picBoxGrammar.Name = "picBoxGrammar";
			this.picBoxGrammar.Size = new global::System.Drawing.Size(600, 200);
			this.picBoxGrammar.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picBoxGrammar.TabIndex = 0;
			this.picBoxGrammar.TabStop = false;
			this.lblGrammarNumber.AutoSize = true;
			this.lblGrammarNumber.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblGrammarNumber.ForeColor = global::System.Drawing.Color.Blue;
			this.lblGrammarNumber.Location = new global::System.Drawing.Point(72, 16);
			this.lblGrammarNumber.Name = "lblGrammarNumber";
			this.lblGrammarNumber.Size = new global::System.Drawing.Size(147, 17);
			this.lblGrammarNumber.TabIndex = 73;
			this.lblGrammarNumber.Text = "lblGrammarNumber";
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Blue;
			this.label14.Location = new global::System.Drawing.Point(8, 47);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(60, 17);
			this.label14.TabIndex = 58;
			this.label14.Text = "Answer";
			this.btnNextGrammar.Location = new global::System.Drawing.Point(8, 264);
			this.btnNextGrammar.Name = "btnNextGrammar";
			this.btnNextGrammar.Size = new global::System.Drawing.Size(56, 23);
			this.btnNextGrammar.TabIndex = 14;
			this.btnNextGrammar.Text = "Next";
			this.btnNextGrammar.Click += new global::System.EventHandler(this.btnNextGrammar_Click);
			this.chkGrammarF.Location = new global::System.Drawing.Point(24, 232);
			this.chkGrammarF.Name = "chkGrammarF";
			this.chkGrammarF.Size = new global::System.Drawing.Size(40, 24);
			this.chkGrammarF.TabIndex = 13;
			this.chkGrammarF.Text = "F";
			this.chkGrammarF.CheckedChanged += new global::System.EventHandler(this.chkGrammar_CheckedChanged);
			this.chkGrammarE.Location = new global::System.Drawing.Point(24, 200);
			this.chkGrammarE.Name = "chkGrammarE";
			this.chkGrammarE.Size = new global::System.Drawing.Size(40, 24);
			this.chkGrammarE.TabIndex = 12;
			this.chkGrammarE.Text = "E";
			this.chkGrammarE.CheckedChanged += new global::System.EventHandler(this.chkGrammar_CheckedChanged);
			this.chkGrammarD.Location = new global::System.Drawing.Point(24, 168);
			this.chkGrammarD.Name = "chkGrammarD";
			this.chkGrammarD.Size = new global::System.Drawing.Size(40, 24);
			this.chkGrammarD.TabIndex = 11;
			this.chkGrammarD.Text = "D";
			this.chkGrammarD.CheckedChanged += new global::System.EventHandler(this.chkGrammar_CheckedChanged);
			this.chkGrammarC.Location = new global::System.Drawing.Point(24, 136);
			this.chkGrammarC.Name = "chkGrammarC";
			this.chkGrammarC.Size = new global::System.Drawing.Size(40, 24);
			this.chkGrammarC.TabIndex = 10;
			this.chkGrammarC.Text = "C";
			this.chkGrammarC.CheckedChanged += new global::System.EventHandler(this.chkGrammar_CheckedChanged);
			this.chkGrammarB.Location = new global::System.Drawing.Point(24, 104);
			this.chkGrammarB.Name = "chkGrammarB";
			this.chkGrammarB.Size = new global::System.Drawing.Size(40, 24);
			this.chkGrammarB.TabIndex = 9;
			this.chkGrammarB.Text = "B";
			this.chkGrammarB.CheckedChanged += new global::System.EventHandler(this.chkGrammar_CheckedChanged);
			this.chkGrammarA.Location = new global::System.Drawing.Point(24, 72);
			this.chkGrammarA.Name = "chkGrammarA";
			this.chkGrammarA.Size = new global::System.Drawing.Size(40, 24);
			this.chkGrammarA.TabIndex = 8;
			this.chkGrammarA.Text = "A";
			this.chkGrammarA.CheckedChanged += new global::System.EventHandler(this.chkGrammar_CheckedChanged);
			this.tabPageIndicateMistake.BackColor = global::System.Drawing.SystemColors.Control;
			this.tabPageIndicateMistake.Controls.Add(this.panelIndicateMistake);
			this.tabPageIndicateMistake.Controls.Add(this.lblIndicateNumber);
			this.tabPageIndicateMistake.Controls.Add(this.label15);
			this.tabPageIndicateMistake.Controls.Add(this.btnNextIndiMistake);
			this.tabPageIndicateMistake.Controls.Add(this.chkIndiMistakeF);
			this.tabPageIndicateMistake.Controls.Add(this.chkIndiMistakeE);
			this.tabPageIndicateMistake.Controls.Add(this.chkIndiMistakeD);
			this.tabPageIndicateMistake.Controls.Add(this.chkIndiMistakeC);
			this.tabPageIndicateMistake.Controls.Add(this.chkIndiMistakeB);
			this.tabPageIndicateMistake.Controls.Add(this.chkIndiMistakeA);
			this.tabPageIndicateMistake.Location = new global::System.Drawing.Point(4, 22);
			this.tabPageIndicateMistake.Name = "tabPageIndicateMistake";
			this.tabPageIndicateMistake.Size = new global::System.Drawing.Size(917, 304);
			this.tabPageIndicateMistake.TabIndex = 4;
			this.tabPageIndicateMistake.Text = "Indicate Mistake";
			this.panelIndicateMistake.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelIndicateMistake.AutoScroll = true;
			this.panelIndicateMistake.BackColor = global::System.Drawing.Color.White;
			this.panelIndicateMistake.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelIndicateMistake.Controls.Add(this.lblIndicateMistake);
			this.panelIndicateMistake.Location = new global::System.Drawing.Point(75, 36);
			this.panelIndicateMistake.Name = "panelIndicateMistake";
			this.panelIndicateMistake.Size = new global::System.Drawing.Size(827, 253);
			this.panelIndicateMistake.TabIndex = 75;
			this.panelIndicateMistake.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panelIndicateMistake_MouseDown);
			this.lblIndicateMistake.AutoSize = true;
			this.lblIndicateMistake.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblIndicateMistake.Location = new global::System.Drawing.Point(7, 3);
			this.lblIndicateMistake.Name = "lblIndicateMistake";
			this.lblIndicateMistake.Size = new global::System.Drawing.Size(119, 17);
			this.lblIndicateMistake.TabIndex = 0;
			this.lblIndicateMistake.Text = "lblIndicateMistake";
			this.lblIndicateMistake.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.lblIndicateMistake_MouseDown);
			this.lblIndicateNumber.AutoSize = true;
			this.lblIndicateNumber.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblIndicateNumber.ForeColor = global::System.Drawing.Color.Blue;
			this.lblIndicateNumber.Location = new global::System.Drawing.Point(72, 16);
			this.lblIndicateNumber.Name = "lblIndicateNumber";
			this.lblIndicateNumber.Size = new global::System.Drawing.Size(138, 17);
			this.lblIndicateNumber.TabIndex = 74;
			this.lblIndicateNumber.Text = "lblIndicateNumber";
			this.label15.AutoSize = true;
			this.label15.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label15.ForeColor = global::System.Drawing.Color.Blue;
			this.label15.Location = new global::System.Drawing.Point(8, 40);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(60, 17);
			this.label15.TabIndex = 59;
			this.label15.Text = "Answer";
			this.btnNextIndiMistake.Location = new global::System.Drawing.Point(8, 264);
			this.btnNextIndiMistake.Name = "btnNextIndiMistake";
			this.btnNextIndiMistake.Size = new global::System.Drawing.Size(56, 23);
			this.btnNextIndiMistake.TabIndex = 22;
			this.btnNextIndiMistake.Text = "Next";
			this.btnNextIndiMistake.Click += new global::System.EventHandler(this.btnNextIndiMistake_Click);
			this.chkIndiMistakeF.Location = new global::System.Drawing.Point(24, 232);
			this.chkIndiMistakeF.Name = "chkIndiMistakeF";
			this.chkIndiMistakeF.Size = new global::System.Drawing.Size(40, 24);
			this.chkIndiMistakeF.TabIndex = 21;
			this.chkIndiMistakeF.Text = "F";
			this.chkIndiMistakeF.CheckedChanged += new global::System.EventHandler(this.chkIndiMistake_CheckedChanged);
			this.chkIndiMistakeE.Location = new global::System.Drawing.Point(24, 200);
			this.chkIndiMistakeE.Name = "chkIndiMistakeE";
			this.chkIndiMistakeE.Size = new global::System.Drawing.Size(40, 24);
			this.chkIndiMistakeE.TabIndex = 20;
			this.chkIndiMistakeE.Text = "E";
			this.chkIndiMistakeE.CheckedChanged += new global::System.EventHandler(this.chkIndiMistake_CheckedChanged);
			this.chkIndiMistakeD.Location = new global::System.Drawing.Point(24, 168);
			this.chkIndiMistakeD.Name = "chkIndiMistakeD";
			this.chkIndiMistakeD.Size = new global::System.Drawing.Size(40, 24);
			this.chkIndiMistakeD.TabIndex = 19;
			this.chkIndiMistakeD.Text = "D";
			this.chkIndiMistakeD.CheckedChanged += new global::System.EventHandler(this.chkIndiMistake_CheckedChanged);
			this.chkIndiMistakeC.Location = new global::System.Drawing.Point(24, 136);
			this.chkIndiMistakeC.Name = "chkIndiMistakeC";
			this.chkIndiMistakeC.Size = new global::System.Drawing.Size(40, 24);
			this.chkIndiMistakeC.TabIndex = 18;
			this.chkIndiMistakeC.Text = "C";
			this.chkIndiMistakeC.CheckedChanged += new global::System.EventHandler(this.chkIndiMistake_CheckedChanged);
			this.chkIndiMistakeB.Location = new global::System.Drawing.Point(24, 104);
			this.chkIndiMistakeB.Name = "chkIndiMistakeB";
			this.chkIndiMistakeB.Size = new global::System.Drawing.Size(40, 24);
			this.chkIndiMistakeB.TabIndex = 17;
			this.chkIndiMistakeB.Text = "B";
			this.chkIndiMistakeB.CheckedChanged += new global::System.EventHandler(this.chkIndiMistake_CheckedChanged);
			this.chkIndiMistakeA.Location = new global::System.Drawing.Point(24, 72);
			this.chkIndiMistakeA.Name = "chkIndiMistakeA";
			this.chkIndiMistakeA.Size = new global::System.Drawing.Size(40, 24);
			this.chkIndiMistakeA.TabIndex = 16;
			this.chkIndiMistakeA.Text = "A";
			this.chkIndiMistakeA.CheckedChanged += new global::System.EventHandler(this.chkIndiMistake_CheckedChanged);
			this.tabPageMatching.BackColor = global::System.Drawing.SystemColors.Control;
			this.tabPageMatching.Controls.Add(this.panelB);
			this.tabPageMatching.Controls.Add(this.panelA);
			this.tabPageMatching.Controls.Add(this.lblLetter);
			this.tabPageMatching.Controls.Add(this.lblNumber);
			this.tabPageMatching.Controls.Add(this.txtLetter);
			this.tabPageMatching.Controls.Add(this.txtNumber);
			this.tabPageMatching.Controls.Add(this.lblMatchNumber);
			this.tabPageMatching.Controls.Add(this.lblAnswerMatch);
			this.tabPageMatching.Controls.Add(this.btnNextMaching);
			this.tabPageMatching.Controls.Add(this.btnRemoveMSolution);
			this.tabPageMatching.Controls.Add(this.btnAddMSolution);
			this.tabPageMatching.Controls.Add(this.lstAnswerMatch);
			this.tabPageMatching.Location = new global::System.Drawing.Point(4, 22);
			this.tabPageMatching.Name = "tabPageMatching";
			this.tabPageMatching.Size = new global::System.Drawing.Size(917, 304);
			this.tabPageMatching.TabIndex = 1;
			this.tabPageMatching.Text = "Matching";
			this.tabPageMatching.Visible = false;
			this.tabPageMatching.SizeChanged += new global::System.EventHandler(this.tabPageMatching_SizeChanged);
			this.panelB.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.panelB.AutoScroll = true;
			this.panelB.BackColor = global::System.Drawing.Color.White;
			this.panelB.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelB.Controls.Add(this.lblColumnB);
			this.panelB.Location = new global::System.Drawing.Point(490, 15);
			this.panelB.Name = "panelB";
			this.panelB.Size = new global::System.Drawing.Size(411, 215);
			this.panelB.TabIndex = 78;
			this.panelB.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panelB_MouseDown);
			this.lblColumnB.AutoSize = true;
			this.lblColumnB.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblColumnB.Location = new global::System.Drawing.Point(12, 12);
			this.lblColumnB.Name = "lblColumnB";
			this.lblColumnB.Size = new global::System.Drawing.Size(78, 17);
			this.lblColumnB.TabIndex = 1;
			this.lblColumnB.Text = "lblColumnB";
			this.lblColumnB.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.lblColumnB_MouseDown);
			this.panelA.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.panelA.AutoScroll = true;
			this.panelA.BackColor = global::System.Drawing.Color.White;
			this.panelA.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelA.Controls.Add(this.lblColumnA);
			this.panelA.Location = new global::System.Drawing.Point(12, 15);
			this.panelA.Name = "panelA";
			this.panelA.Size = new global::System.Drawing.Size(388, 215);
			this.panelA.TabIndex = 77;
			this.panelA.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panelA_MouseDown);
			this.lblColumnA.AutoSize = true;
			this.lblColumnA.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblColumnA.Location = new global::System.Drawing.Point(10, 12);
			this.lblColumnA.Name = "lblColumnA";
			this.lblColumnA.Size = new global::System.Drawing.Size(78, 17);
			this.lblColumnA.TabIndex = 0;
			this.lblColumnA.Text = "lblColumnA";
			this.lblColumnA.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.lblColumnA_MouseDown);
			this.lblLetter.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.lblLetter.AutoSize = true;
			this.lblLetter.Location = new global::System.Drawing.Point(490, 233);
			this.lblLetter.Name = "lblLetter";
			this.lblLetter.Size = new global::System.Drawing.Size(103, 13);
			this.lblLetter.TabIndex = 76;
			this.lblLetter.Text = "Letter (A, B, ACD,...)";
			this.lblNumber.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.lblNumber.AutoSize = true;
			this.lblNumber.Location = new global::System.Drawing.Point(346, 233);
			this.lblNumber.Name = "lblNumber";
			this.lblNumber.Size = new global::System.Drawing.Size(83, 13);
			this.lblNumber.TabIndex = 75;
			this.lblNumber.Text = "Number(1,2,3...)";
			this.txtLetter.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.txtLetter.Location = new global::System.Drawing.Point(490, 248);
			this.txtLetter.Name = "txtLetter";
			this.txtLetter.Size = new global::System.Drawing.Size(48, 20);
			this.txtLetter.TabIndex = 74;
			this.txtLetter.Enter += new global::System.EventHandler(this.txtLetter_Enter);
			this.txtLetter.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtLetter_KeyPress);
			this.txtLetter.Leave += new global::System.EventHandler(this.txtLetter_Leave);
			this.txtNumber.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.txtNumber.Location = new global::System.Drawing.Point(346, 248);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new global::System.Drawing.Size(47, 20);
			this.txtNumber.TabIndex = 73;
			this.txtNumber.Enter += new global::System.EventHandler(this.txtNumber_Enter);
			this.txtNumber.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
			this.txtNumber.Leave += new global::System.EventHandler(this.txtNumber_Leave);
			this.lblMatchNumber.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.lblMatchNumber.AutoSize = true;
			this.lblMatchNumber.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMatchNumber.ForeColor = global::System.Drawing.Color.Blue;
			this.lblMatchNumber.Location = new global::System.Drawing.Point(88, 271);
			this.lblMatchNumber.Name = "lblMatchNumber";
			this.lblMatchNumber.Size = new global::System.Drawing.Size(124, 17);
			this.lblMatchNumber.TabIndex = 72;
			this.lblMatchNumber.Text = "lblMatchNumber";
			this.lblAnswerMatch.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.lblAnswerMatch.AutoSize = true;
			this.lblAnswerMatch.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblAnswerMatch.Location = new global::System.Drawing.Point(416, 8);
			this.lblAnswerMatch.Name = "lblAnswerMatch";
			this.lblAnswerMatch.Size = new global::System.Drawing.Size(54, 17);
			this.lblAnswerMatch.TabIndex = 67;
			this.lblAnswerMatch.Text = "Answer";
			this.btnNextMaching.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnNextMaching.Location = new global::System.Drawing.Point(8, 265);
			this.btnNextMaching.Name = "btnNextMaching";
			this.btnNextMaching.Size = new global::System.Drawing.Size(75, 22);
			this.btnNextMaching.TabIndex = 23;
			this.btnNextMaching.Text = "Next";
			this.btnNextMaching.Click += new global::System.EventHandler(this.btnNextMaching_Click);
			this.btnRemoveMSolution.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.btnRemoveMSolution.Location = new global::System.Drawing.Point(442, 272);
			this.btnRemoveMSolution.Name = "btnRemoveMSolution";
			this.btnRemoveMSolution.Size = new global::System.Drawing.Size(99, 25);
			this.btnRemoveMSolution.TabIndex = 22;
			this.btnRemoveMSolution.Text = "Remove Solution";
			this.btnRemoveMSolution.Click += new global::System.EventHandler(this.btnRemoveMSolution_Click);
			this.btnAddMSolution.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAddMSolution.Location = new global::System.Drawing.Point(346, 272);
			this.btnAddMSolution.Name = "btnAddMSolution";
			this.btnAddMSolution.Size = new global::System.Drawing.Size(96, 25);
			this.btnAddMSolution.TabIndex = 21;
			this.btnAddMSolution.Text = "Add Solution";
			this.btnAddMSolution.Click += new global::System.EventHandler(this.btnAddMSolution_Click);
			this.lstAnswerMatch.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom);
			this.lstAnswerMatch.Location = new global::System.Drawing.Point(416, 32);
			this.lstAnswerMatch.Name = "lstAnswerMatch";
			this.lstAnswerMatch.Size = new global::System.Drawing.Size(56, 108);
			this.lstAnswerMatch.TabIndex = 20;
			this.tabPageFillBlank.BackColor = global::System.Drawing.SystemColors.Control;
			this.tabPageFillBlank.Controls.Add(this.panelFillBlank);
			this.tabPageFillBlank.Controls.Add(this.btnNextFillBlank);
			this.tabPageFillBlank.Location = new global::System.Drawing.Point(4, 22);
			this.tabPageFillBlank.Name = "tabPageFillBlank";
			this.tabPageFillBlank.Size = new global::System.Drawing.Size(917, 304);
			this.tabPageFillBlank.TabIndex = 6;
			this.tabPageFillBlank.Text = "Fill Blank";
			this.panelFillBlank.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelFillBlank.AutoScroll = true;
			this.panelFillBlank.AutoScrollMargin = new global::System.Drawing.Size(10, 10);
			this.panelFillBlank.AutoScrollMinSize = new global::System.Drawing.Size(10, 10);
			this.panelFillBlank.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelFillBlank.Controls.Add(this.lblFillBlankNumber);
			this.panelFillBlank.Location = new global::System.Drawing.Point(8, 8);
			this.panelFillBlank.Name = "panelFillBlank";
			this.panelFillBlank.Size = new global::System.Drawing.Size(900, 250);
			this.panelFillBlank.TabIndex = 75;
			this.lblFillBlankNumber.AutoSize = true;
			this.lblFillBlankNumber.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblFillBlankNumber.ForeColor = global::System.Drawing.SystemColors.WindowText;
			this.lblFillBlankNumber.Location = new global::System.Drawing.Point(8, 8);
			this.lblFillBlankNumber.Name = "lblFillBlankNumber";
			this.lblFillBlankNumber.Size = new global::System.Drawing.Size(121, 16);
			this.lblFillBlankNumber.TabIndex = 75;
			this.lblFillBlankNumber.Text = "lblFillBlankNumber";
			this.btnNextFillBlank.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnNextFillBlank.Location = new global::System.Drawing.Point(8, 265);
			this.btnNextFillBlank.Name = "btnNextFillBlank";
			this.btnNextFillBlank.Size = new global::System.Drawing.Size(75, 22);
			this.btnNextFillBlank.TabIndex = 39;
			this.btnNextFillBlank.Text = "Next";
			this.btnNextFillBlank.Click += new global::System.EventHandler(this.btnNextFillBlank_Click);
			this.tabPageEssay.BackColor = global::System.Drawing.SystemColors.Control;
			this.tabPageEssay.Controls.Add(this.label16);
			this.tabPageEssay.Controls.Add(this.label12);
			this.tabPageEssay.Controls.Add(this.label8);
			this.tabPageEssay.Controls.Add(this.btnRedo);
			this.tabPageEssay.Controls.Add(this.btnUndo);
			this.tabPageEssay.Controls.Add(this.label4);
			this.tabPageEssay.Controls.Add(this.btnSaveEssay);
			this.tabPageEssay.Controls.Add(this.btnWordCount);
			this.tabPageEssay.Controls.Add(this.lblWordCount);
			this.tabPageEssay.Controls.Add(this.btnEssayZoom);
			this.tabPageEssay.Controls.Add(this.btnEssayNormal);
			this.tabPageEssay.Controls.Add(this.panelEssay);
			this.tabPageEssay.Location = new global::System.Drawing.Point(4, 22);
			this.tabPageEssay.Name = "tabPageEssay";
			this.tabPageEssay.Size = new global::System.Drawing.Size(917, 304);
			this.tabPageEssay.TabIndex = 7;
			this.tabPageEssay.Text = "Writting Essay";
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(262, 8);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(398, 26);
			this.label16.TabIndex = 16;
			this.label16.Text = "Drag the red vertical line to resize the question/typing area. \r\nPress Shift+Left/Right arrow keys to select text, \"Tab\" key to insert TAB character.";
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(10, 20);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(52, 13);
			this.label12.TabIndex = 15;
			this.label12.Text = "Question:";
			this.label8.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(208, 278);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(175, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Automatically save every 2 minutes.";
			this.btnRedo.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnRedo.Location = new global::System.Drawing.Point(677, 272);
			this.btnRedo.Name = "btnRedo";
			this.btnRedo.Size = new global::System.Drawing.Size(75, 23);
			this.btnRedo.TabIndex = 13;
			this.btnRedo.Text = "Redo";
			this.btnRedo.UseVisualStyleBackColor = true;
			this.btnRedo.Click += new global::System.EventHandler(this.btnRedo_Click);
			this.btnUndo.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnUndo.Location = new global::System.Drawing.Point(597, 272);
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new global::System.Drawing.Size(75, 23);
			this.btnUndo.TabIndex = 12;
			this.btnUndo.Text = "Undo";
			this.btnUndo.UseVisualStyleBackColor = true;
			this.btnUndo.Click += new global::System.EventHandler(this.btnUndo_Click);
			this.label4.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Blue;
			this.label4.Location = new global::System.Drawing.Point(832, 18);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(74, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Typing here";
			this.btnSaveEssay.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnSaveEssay.Location = new global::System.Drawing.Point(830, 272);
			this.btnSaveEssay.Name = "btnSaveEssay";
			this.btnSaveEssay.Size = new global::System.Drawing.Size(75, 23);
			this.btnSaveEssay.TabIndex = 10;
			this.btnSaveEssay.Text = "Save";
			this.btnSaveEssay.UseVisualStyleBackColor = true;
			this.btnSaveEssay.Click += new global::System.EventHandler(this.btnSaveEssay_Click);
			this.btnWordCount.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnWordCount.Location = new global::System.Drawing.Point(395, 272);
			this.btnWordCount.Name = "btnWordCount";
			this.btnWordCount.Size = new global::System.Drawing.Size(75, 23);
			this.btnWordCount.TabIndex = 9;
			this.btnWordCount.Text = "Word count";
			this.btnWordCount.UseVisualStyleBackColor = true;
			this.btnWordCount.Click += new global::System.EventHandler(this.btnWordCount_Click);
			this.lblWordCount.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblWordCount.AutoSize = true;
			this.lblWordCount.Location = new global::System.Drawing.Point(476, 277);
			this.lblWordCount.Name = "lblWordCount";
			this.lblWordCount.Size = new global::System.Drawing.Size(71, 13);
			this.lblWordCount.TabIndex = 8;
			this.lblWordCount.Text = "lblWordCount";
			this.btnEssayZoom.Enabled = false;
			this.btnEssayZoom.Location = new global::System.Drawing.Point(182, 13);
			this.btnEssayZoom.Name = "btnEssayZoom";
			this.btnEssayZoom.Size = new global::System.Drawing.Size(75, 23);
			this.btnEssayZoom.TabIndex = 7;
			this.btnEssayZoom.Text = "Zoom out";
			this.btnEssayZoom.UseVisualStyleBackColor = true;
			this.btnEssayZoom.Click += new global::System.EventHandler(this.btnEssayZoom_Click);
			this.btnEssayNormal.Enabled = false;
			this.btnEssayNormal.Location = new global::System.Drawing.Point(89, 13);
			this.btnEssayNormal.Name = "btnEssayNormal";
			this.btnEssayNormal.Size = new global::System.Drawing.Size(75, 23);
			this.btnEssayNormal.TabIndex = 6;
			this.btnEssayNormal.Text = "Real size";
			this.btnEssayNormal.UseVisualStyleBackColor = true;
			this.btnEssayNormal.Click += new global::System.EventHandler(this.btnEssayNormal_Click);
			this.panelEssay.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelEssay.Controls.Add(this.txtWrittingEssay);
			this.panelEssay.Controls.Add(this.splitterEssay);
			this.panelEssay.Controls.Add(this.panelPicEssay);
			this.panelEssay.Location = new global::System.Drawing.Point(6, 36);
			this.panelEssay.Name = "panelEssay";
			this.panelEssay.Size = new global::System.Drawing.Size(899, 230);
			this.panelEssay.TabIndex = 5;
			this.txtWrittingEssay.AcceptsTab = true;
			this.txtWrittingEssay.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.txtWrittingEssay.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtWrittingEssay.Location = new global::System.Drawing.Point(583, 0);
			this.txtWrittingEssay.MaxLength = 1048576;
			this.txtWrittingEssay.Multiline = true;
			this.txtWrittingEssay.Name = "txtWrittingEssay";
			this.txtWrittingEssay.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.txtWrittingEssay.Size = new global::System.Drawing.Size(316, 230);
			this.txtWrittingEssay.TabIndex = 2;
			this.txtWrittingEssay.TextChanged += new global::System.EventHandler(this.txtWrittingEssay_TextChanged);
			this.txtWrittingEssay.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.txtWrittingEssay_KeyDown);
			this.splitterEssay.BackColor = global::System.Drawing.Color.Red;
			this.splitterEssay.Location = new global::System.Drawing.Point(578, 0);
			this.splitterEssay.Name = "splitterEssay";
			this.splitterEssay.Size = new global::System.Drawing.Size(5, 230);
			this.splitterEssay.TabIndex = 1;
			this.splitterEssay.TabStop = false;
			this.panelPicEssay.AutoScroll = true;
			this.panelPicEssay.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelPicEssay.Controls.Add(this.pictureBoxEssay);
			this.panelPicEssay.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panelPicEssay.Location = new global::System.Drawing.Point(0, 0);
			this.panelPicEssay.Name = "panelPicEssay";
			this.panelPicEssay.Size = new global::System.Drawing.Size(578, 230);
			this.panelPicEssay.TabIndex = 0;
			this.pictureBoxEssay.ImageLocation = "";
			this.pictureBoxEssay.Location = new global::System.Drawing.Point(3, 3);
			this.pictureBoxEssay.Name = "pictureBoxEssay";
			this.pictureBoxEssay.Size = new global::System.Drawing.Size(151, 219);
			this.pictureBoxEssay.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxEssay.TabIndex = 0;
			this.pictureBoxEssay.TabStop = false;
			this.tabPageImagePaper.BackColor = global::System.Drawing.SystemColors.Control;
			this.tabPageImagePaper.Controls.Add(this.btnRedoPaper);
			this.tabPageImagePaper.Controls.Add(this.btnUndoPaper);
			this.tabPageImagePaper.Controls.Add(this.label6);
			this.tabPageImagePaper.Controls.Add(this.lblTime_copy);
			this.tabPageImagePaper.Controls.Add(this.lblTimeLeft_Copy);
			this.tabPageImagePaper.Controls.Add(this.btnFullScreen);
			this.tabPageImagePaper.Controls.Add(this.panelAnswer);
			this.tabPageImagePaper.Controls.Add(this.label19);
			this.tabPageImagePaper.Controls.Add(this.lblPicSize);
			this.tabPageImagePaper.Controls.Add(this.trackBarPicSize);
			this.tabPageImagePaper.Controls.Add(this.panelPaper);
			this.tabPageImagePaper.Location = new global::System.Drawing.Point(4, 22);
			this.tabPageImagePaper.Name = "tabPageImagePaper";
			this.tabPageImagePaper.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPageImagePaper.Size = new global::System.Drawing.Size(917, 304);
			this.tabPageImagePaper.TabIndex = 8;
			this.tabPageImagePaper.Text = "Paper";
			this.btnRedoPaper.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnRedoPaper.Location = new global::System.Drawing.Point(587, 259);
			this.btnRedoPaper.Name = "btnRedoPaper";
			this.btnRedoPaper.Size = new global::System.Drawing.Size(75, 23);
			this.btnRedoPaper.TabIndex = 90;
			this.btnRedoPaper.Text = "Redo";
			this.btnRedoPaper.UseVisualStyleBackColor = true;
			this.btnRedoPaper.Click += new global::System.EventHandler(this.btnRedoPaper_Click);
			this.btnUndoPaper.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnUndoPaper.Location = new global::System.Drawing.Point(507, 259);
			this.btnUndoPaper.Name = "btnUndoPaper";
			this.btnUndoPaper.Size = new global::System.Drawing.Size(75, 23);
			this.btnUndoPaper.TabIndex = 89;
			this.btnUndoPaper.Text = "Undo";
			this.btnUndoPaper.UseVisualStyleBackColor = true;
			this.btnUndoPaper.Click += new global::System.EventHandler(this.btnUndoPaper_Click);
			this.label6.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.label6.AutoSize = true;
			this.label6.ForeColor = global::System.Drawing.Color.Red;
			this.label6.Location = new global::System.Drawing.Point(782, 264);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(117, 13);
			this.label6.TabIndex = 86;
			this.label6.Text = "AutoSave every minute";
			this.lblTime_copy.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblTime_copy.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 30f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTime_copy.ForeColor = global::System.Drawing.Color.Blue;
			this.lblTime_copy.Location = new global::System.Drawing.Point(329, 252);
			this.lblTime_copy.Name = "lblTime_copy";
			this.lblTime_copy.Size = new global::System.Drawing.Size(156, 46);
			this.lblTime_copy.TabIndex = 85;
			this.lblTime_copy.Text = "000:00";
			this.lblTime_copy.Visible = false;
			this.lblTimeLeft_Copy.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.lblTimeLeft_Copy.AutoSize = true;
			this.lblTimeLeft_Copy.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTimeLeft_Copy.Location = new global::System.Drawing.Point(252, 270);
			this.lblTimeLeft_Copy.Name = "lblTimeLeft_Copy";
			this.lblTimeLeft_Copy.Size = new global::System.Drawing.Size(71, 17);
			this.lblTimeLeft_Copy.TabIndex = 84;
			this.lblTimeLeft_Copy.Text = "Time Left:";
			this.lblTimeLeft_Copy.Visible = false;
			this.btnFullScreen.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnFullScreen.Location = new global::System.Drawing.Point(684, 259);
			this.btnFullScreen.Name = "btnFullScreen";
			this.btnFullScreen.Size = new global::System.Drawing.Size(90, 23);
			this.btnFullScreen.TabIndex = 83;
			this.btnFullScreen.Text = "Full Screen";
			this.btnFullScreen.UseVisualStyleBackColor = true;
			this.btnFullScreen.Click += new global::System.EventHandler(this.btnFullScreen_Click);
			this.panelAnswer.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelAnswer.AutoScroll = true;
			this.panelAnswer.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelAnswer.Location = new global::System.Drawing.Point(232, 6);
			this.panelAnswer.Name = "panelAnswer";
			this.panelAnswer.Size = new global::System.Drawing.Size(674, 243);
			this.panelAnswer.TabIndex = 36;
			this.panelAnswer.Scroll += new global::System.Windows.Forms.ScrollEventHandler(this.panelAnswer_Scroll);
			this.label19.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.label19.AutoSize = true;
			this.label19.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label19.Location = new global::System.Drawing.Point(2, 255);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(34, 13);
			this.label19.TabIndex = 26;
			this.label19.Text = "Zoom";
			this.lblPicSize.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.lblPicSize.AutoSize = true;
			this.lblPicSize.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblPicSize.Location = new global::System.Drawing.Point(202, 255);
			this.lblPicSize.Name = "lblPicSize";
			this.lblPicSize.Size = new global::System.Drawing.Size(37, 13);
			this.lblPicSize.TabIndex = 25;
			this.lblPicSize.Text = "100%";
			this.trackBarPicSize.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.trackBarPicSize.Location = new global::System.Drawing.Point(42, 255);
			this.trackBarPicSize.Maximum = 150;
			this.trackBarPicSize.Minimum = 50;
			this.trackBarPicSize.Name = "trackBarPicSize";
			this.trackBarPicSize.Size = new global::System.Drawing.Size(154, 45);
			this.trackBarPicSize.SmallChange = 10;
			this.trackBarPicSize.TabIndex = 24;
			this.trackBarPicSize.TickFrequency = 10;
			this.trackBarPicSize.Value = 100;
			this.trackBarPicSize.Scroll += new global::System.EventHandler(this.trackBarPicSize_Scroll);
			this.panelPaper.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelPaper.AutoScroll = true;
			this.panelPaper.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelPaper.Controls.Add(this.pictureBoxPaper);
			this.panelPaper.Location = new global::System.Drawing.Point(6, 6);
			this.panelPaper.Name = "panelPaper";
			this.panelPaper.Size = new global::System.Drawing.Size(220, 243);
			this.panelPaper.TabIndex = 23;
			this.pictureBoxPaper.ImageLocation = "";
			this.pictureBoxPaper.InitialImage = null;
			this.pictureBoxPaper.Location = new global::System.Drawing.Point(3, 4);
			this.pictureBoxPaper.Name = "pictureBoxPaper";
			this.pictureBoxPaper.Size = new global::System.Drawing.Size(200, 120);
			this.pictureBoxPaper.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxPaper.TabIndex = 0;
			this.pictureBoxPaper.TabStop = false;
			this.lblOver.AutoSize = true;
			this.lblOver.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblOver.ForeColor = global::System.Drawing.Color.Blue;
			this.lblOver.Location = new global::System.Drawing.Point(14, 131);
			this.lblOver.Name = "lblOver";
			this.lblOver.Size = new global::System.Drawing.Size(165, 24);
			this.lblOver.TabIndex = 72;
			this.lblOver.Text = "Examination Over!";
			this.lblExamCode.AutoSize = true;
			this.lblExamCode.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblExamCode.ForeColor = global::System.Drawing.Color.Blue;
			this.lblExamCode.Location = new global::System.Drawing.Point(291, 56);
			this.lblExamCode.Name = "lblExamCode";
			this.lblExamCode.Size = new global::System.Drawing.Size(100, 17);
			this.lblExamCode.TabIndex = 71;
			this.lblExamCode.Text = "lblExamCode";
			this.lblExamServer.AutoSize = true;
			this.lblExamServer.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblExamServer.ForeColor = global::System.Drawing.Color.Blue;
			this.lblExamServer.Location = new global::System.Drawing.Point(80, 56);
			this.lblExamServer.Name = "lblExamServer";
			this.lblExamServer.Size = new global::System.Drawing.Size(111, 17);
			this.lblExamServer.TabIndex = 70;
			this.lblExamServer.Text = "lblExamServer";
			this.lblMachine.AutoSize = true;
			this.lblMachine.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMachine.ForeColor = global::System.Drawing.Color.Blue;
			this.lblMachine.Location = new global::System.Drawing.Point(80, 31);
			this.lblMachine.Name = "lblMachine";
			this.lblMachine.Size = new global::System.Drawing.Size(85, 17);
			this.lblMachine.TabIndex = 69;
			this.lblMachine.Text = "lblMachine";
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.Location = new global::System.Drawing.Point(18, 31);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(65, 17);
			this.label11.TabIndex = 68;
			this.label11.Text = "Machine:";
			this.lblDuration.AutoSize = true;
			this.lblDuration.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblDuration.ForeColor = global::System.Drawing.Color.Blue;
			this.lblDuration.Location = new global::System.Drawing.Point(80, 81);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new global::System.Drawing.Size(70, 17);
			this.lblDuration.TabIndex = 65;
			this.lblDuration.Text = "Duration";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.Location = new global::System.Drawing.Point(17, 81);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(66, 17);
			this.label10.TabIndex = 64;
			this.label10.Text = "Duration:";
			this.lblSize.AutoSize = true;
			this.lblSize.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblSize.Location = new global::System.Drawing.Point(354, 133);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new global::System.Drawing.Size(39, 17);
			this.lblSize.TabIndex = 61;
			this.lblSize.Text = "Size:";
			this.lblMark.AutoSize = true;
			this.lblMark.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMark.ForeColor = global::System.Drawing.Color.Blue;
			this.lblMark.Location = new global::System.Drawing.Point(80, 106);
			this.lblMark.Name = "lblMark";
			this.lblMark.Size = new global::System.Drawing.Size(60, 17);
			this.lblMark.TabIndex = 60;
			this.lblMark.Text = "lblMark";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(25, 106);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(58, 17);
			this.label5.TabIndex = 59;
			this.label5.Text = "Q mark:";
			this.lblTime.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 40f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTime.ForeColor = global::System.Drawing.Color.Blue;
			this.lblTime.Location = new global::System.Drawing.Point(500, 104);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new global::System.Drawing.Size(198, 63);
			this.lblTime.TabIndex = 55;
			this.lblTime.Text = "000:00";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(434, 133);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(71, 17);
			this.label3.TabIndex = 53;
			this.label3.Text = "Time Left:";
			this.lblLogin.AutoSize = true;
			this.lblLogin.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLogin.ForeColor = global::System.Drawing.Color.Blue;
			this.lblLogin.Location = new global::System.Drawing.Point(291, 31);
			this.lblLogin.Name = "lblLogin";
			this.lblLogin.Size = new global::System.Drawing.Size(65, 17);
			this.lblLogin.TabIndex = 51;
			this.lblLogin.Text = "lblLogin";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(234, 31);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(61, 17);
			this.label1.TabIndex = 50;
			this.label1.Text = "Student:";
			this.nudFontSize.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nudFontSize.Location = new global::System.Drawing.Point(395, 131);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.nudFontSize;
			int[] array = new int[4];
			array[0] = 15;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.nudFontSize;
			int[] array2 = new int[4];
			array2[0] = 10;
			numericUpDown2.Minimum = new decimal(array2);
			this.nudFontSize.Name = "nudFontSize";
			this.nudFontSize.Size = new global::System.Drawing.Size(40, 23);
			this.nudFontSize.TabIndex = 56;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.nudFontSize;
			int[] array3 = new int[4];
			array3[0] = 10;
			numericUpDown3.Value = new decimal(array3);
			this.nudFontSize.ValueChanged += new global::System.EventHandler(this.nudFontSize_ValueChanged);
			this.chbWantFinish.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.chbWantFinish.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.chbWantFinish.ForeColor = global::System.Drawing.Color.Blue;
			this.chbWantFinish.Location = new global::System.Drawing.Point(24, 552);
			this.chbWantFinish.Name = "chbWantFinish";
			this.chbWantFinish.Size = new global::System.Drawing.Size(176, 17);
			this.chbWantFinish.TabIndex = 75;
			this.chbWantFinish.Text = "I want to finish the exam.";
			this.chbWantFinish.CheckedChanged += new global::System.EventHandler(this.chbWantFinish_CheckedChanged);
			this.lblSaveServer.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.lblSaveServer.AutoSize = true;
			this.lblSaveServer.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblSaveServer.ForeColor = global::System.Drawing.Color.Blue;
			this.lblSaveServer.Location = new global::System.Drawing.Point(118, 572);
			this.lblSaveServer.Name = "lblSaveServer";
			this.lblSaveServer.Size = new global::System.Drawing.Size(119, 20);
			this.lblSaveServer.TabIndex = 74;
			this.lblSaveServer.Text = "lblSaveServer";
			this.btnFinish.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnFinish.BackColor = global::System.Drawing.Color.FromArgb(255, 255, 192);
			this.btnFinish.Enabled = false;
			this.btnFinish.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnFinish.Location = new global::System.Drawing.Point(24, 571);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new global::System.Drawing.Size(88, 24);
			this.btnFinish.TabIndex = 73;
			this.btnFinish.Text = "Finish";
			this.btnFinish.UseVisualStyleBackColor = false;
			this.btnFinish.Click += new global::System.EventHandler(this.btnFinish_Click);
			this.btnExit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnExit.Location = new global::System.Drawing.Point(853, 571);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new global::System.Drawing.Size(88, 24);
			this.btnExit.TabIndex = 76;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new global::System.EventHandler(this.btnExit_Click);
			this.timerCountDown.Interval = 1000;
			this.timerCountDown.Tick += new global::System.EventHandler(this.timerCountDown_Tick);
			this.lblMesage.AutoSize = true;
			this.lblMesage.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMesage.ForeColor = global::System.Drawing.Color.Red;
			this.lblMesage.Location = new global::System.Drawing.Point(15, 9);
			this.lblMesage.Name = "lblMesage";
			this.lblMesage.Size = new global::System.Drawing.Size(205, 18);
			this.lblMesage.TabIndex = 77;
			this.lblMesage.Text = "24.07.20.22 (10.11)-laptop";
			this.txtGuide.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtGuide.BackColor = global::System.Drawing.Color.FromArgb(255, 255, 192);
			this.txtGuide.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtGuide.Location = new global::System.Drawing.Point(704, 8);
			this.txtGuide.Multiline = true;
			this.txtGuide.Name = "txtGuide";
			this.txtGuide.ReadOnly = true;
			this.txtGuide.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.txtGuide.Size = new global::System.Drawing.Size(238, 148);
			this.txtGuide.TabIndex = 78;
			this.txtOpenCode.Enabled = false;
			this.txtOpenCode.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtOpenCode.Location = new global::System.Drawing.Point(291, 78);
			this.txtOpenCode.Name = "txtOpenCode";
			this.txtOpenCode.Size = new global::System.Drawing.Size(117, 23);
			this.txtOpenCode.TabIndex = 79;
			this.lblOpenCode.AutoSize = true;
			this.lblOpenCode.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblOpenCode.Location = new global::System.Drawing.Point(204, 81);
			this.lblOpenCode.Name = "lblOpenCode";
			this.lblOpenCode.Size = new global::System.Drawing.Size(84, 17);
			this.lblOpenCode.TabIndex = 80;
			this.lblOpenCode.Text = "Open Code:";
			this.btnShowExam.Enabled = false;
			this.btnShowExam.Location = new global::System.Drawing.Point(412, 78);
			this.btnShowExam.Name = "btnShowExam";
			this.btnShowExam.Size = new global::System.Drawing.Size(96, 23);
			this.btnShowExam.TabIndex = 81;
			this.btnShowExam.Text = "Show Question";
			this.btnShowExam.Click += new global::System.EventHandler(this.btnShowExam_Click);
			this.timerTopMost.Interval = 200;
			this.timerTopMost.Tick += new global::System.EventHandler(this.timerTopMost_Tick);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(29, 56);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(54, 17);
			this.label2.TabIndex = 82;
			this.label2.Text = "Server:";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(205, 56);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(83, 17);
			this.label7.TabIndex = 83;
			this.label7.Text = "Exam Code:";
			this.lblTotalMarks.AutoSize = true;
			this.lblTotalMarks.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTotalMarks.ForeColor = global::System.Drawing.Color.Blue;
			this.lblTotalMarks.Location = new global::System.Drawing.Point(291, 106);
			this.lblTotalMarks.Name = "lblTotalMarks";
			this.lblTotalMarks.Size = new global::System.Drawing.Size(68, 17);
			this.lblTotalMarks.TabIndex = 67;
			this.lblTotalMarks.Text = "lblMarks";
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new global::System.Drawing.Point(202, 106);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(86, 17);
			this.label9.TabIndex = 66;
			this.label9.Text = "Total Marks:";
			this.panelQuestionList.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelQuestionList.AutoScroll = true;
			this.panelQuestionList.Location = new global::System.Drawing.Point(24, 491);
			this.panelQuestionList.Name = "panelQuestionList";
			this.panelQuestionList.Size = new global::System.Drawing.Size(913, 62);
			this.panelQuestionList.TabIndex = 86;
			this.panelQuestionList.Visible = false;
			this.chbWantFinishTop.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.chbWantFinishTop.ForeColor = global::System.Drawing.Color.Blue;
			this.chbWantFinishTop.Location = new global::System.Drawing.Point(250, 9);
			this.chbWantFinishTop.Name = "chbWantFinishTop";
			this.chbWantFinishTop.Size = new global::System.Drawing.Size(169, 20);
			this.chbWantFinishTop.TabIndex = 88;
			this.chbWantFinishTop.Text = "I want to finish the exam.";
			this.chbWantFinishTop.CheckedChanged += new global::System.EventHandler(this.chbWantFinishTop_CheckedChanged);
			this.btnFinishTop.BackColor = global::System.Drawing.Color.FromArgb(255, 255, 192);
			this.btnFinishTop.Enabled = false;
			this.btnFinishTop.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnFinishTop.Location = new global::System.Drawing.Point(420, 7);
			this.btnFinishTop.Name = "btnFinishTop";
			this.btnFinishTop.Size = new global::System.Drawing.Size(88, 24);
			this.btnFinishTop.TabIndex = 87;
			this.btnFinishTop.Text = "Finish";
			this.btnFinishTop.UseVisualStyleBackColor = false;
			this.btnFinishTop.Click += new global::System.EventHandler(this.btnFinishTop_Click);
			this.lblVol.AutoSize = true;
			this.lblVol.Enabled = false;
			this.lblVol.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblVol.Location = new global::System.Drawing.Point(360, 106);
			this.lblVol.Name = "lblVol";
			this.lblVol.Size = new global::System.Drawing.Size(32, 17);
			this.lblVol.TabIndex = 90;
			this.lblVol.Text = "Vol:";
			this.nudVol.Enabled = false;
			this.nudVol.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nudVol.Location = new global::System.Drawing.Point(394, 104);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.nudVol;
			int[] array4 = new int[4];
			array4[0] = 10;
			numericUpDown4.Maximum = new decimal(array4);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.nudVol;
			int[] array5 = new int[4];
			array5[0] = 1;
			numericUpDown5.Minimum = new decimal(array5);
			this.nudVol.Name = "nudVol";
			this.nudVol.Size = new global::System.Drawing.Size(40, 23);
			this.nudVol.TabIndex = 91;
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.nudVol;
			int[] array6 = new int[4];
			array6[0] = 8;
			numericUpDown6.Value = new decimal(array6);
			this.nudVol.ValueChanged += new global::System.EventHandler(this.nudVol_ValueChanged);
			this.domainUpDown.Location = new global::System.Drawing.Point(228, 133);
			this.domainUpDown.Name = "domainUpDown";
			this.domainUpDown.Size = new global::System.Drawing.Size(125, 20);
			this.domainUpDown.TabIndex = 94;
			this.domainUpDown.SelectedItemChanged += new global::System.EventHandler(this.domainUpDown_SelectedItemChanged);
			this.lblFont.AutoSize = true;
			this.lblFont.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblFont.Location = new global::System.Drawing.Point(186, 133);
			this.lblFont.Name = "lblFont";
			this.lblFont.Size = new global::System.Drawing.Size(40, 17);
			this.lblFont.TabIndex = 95;
			this.lblFont.Text = "Font:";
			this.timerBOTTest.Interval = 1000;
			this.timerBOTTest.Tick += new global::System.EventHandler(this.timerBOTTest_Tick);
			this.pictureBoxIcon.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBoxIcon.Image");
			this.pictureBoxIcon.Location = new global::System.Drawing.Point(523, 9);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new global::System.Drawing.Size(159, 92);
			this.pictureBoxIcon.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxIcon.TabIndex = 84;
			this.pictureBoxIcon.TabStop = false;
			this.btnSubmit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnSubmit.BackColor = global::System.Drawing.Color.Red;
			this.btnSubmit.Enabled = false;
			this.btnSubmit.Location = new global::System.Drawing.Point(747, 572);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new global::System.Drawing.Size(88, 24);
			this.btnSubmit.TabIndex = 96;
			this.btnSubmit.Text = "Submit";
			this.btnSubmit.UseVisualStyleBackColor = false;
			this.btnSubmit.Visible = false;
			this.btnSubmit.Click += new global::System.EventHandler(this.btnSubmit_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(956, 600);
			base.ControlBox = false;
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.lblFont);
			base.Controls.Add(this.domainUpDown);
			base.Controls.Add(this.nudVol);
			base.Controls.Add(this.lblVol);
			base.Controls.Add(this.chbWantFinishTop);
			base.Controls.Add(this.btnFinishTop);
			base.Controls.Add(this.panelQuestionList);
			base.Controls.Add(this.pictureBoxIcon);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnShowExam);
			base.Controls.Add(this.txtOpenCode);
			base.Controls.Add(this.lblOpenCode);
			base.Controls.Add(this.txtGuide);
			base.Controls.Add(this.lblMesage);
			base.Controls.Add(this.lblSaveServer);
			base.Controls.Add(this.lblOver);
			base.Controls.Add(this.lblExamCode);
			base.Controls.Add(this.lblExamServer);
			base.Controls.Add(this.lblMachine);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.lblDuration);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.lblSize);
			base.Controls.Add(this.lblMark);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.lblTime);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lblLogin);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnExit);
			base.Controls.Add(this.chbWantFinish);
			base.Controls.Add(this.lblTotalMarks);
			base.Controls.Add(this.btnFinish);
			base.Controls.Add(this.nudFontSize);
			base.Controls.Add(this.tabControlQuestion);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmEnglishExamClient";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmEnglishExamClient_FormClosing);
			base.Load += new global::System.EventHandler(this.frmEnglishExamClient_Load);
			base.SizeChanged += new global::System.EventHandler(this.frmEnglishExamClient_SizeChanged);
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.frmEnglishExamClient_MouseDown);
			this.tabControlQuestion.ResumeLayout(false);
			this.tabPageReadingM.ResumeLayout(false);
			this.tabPageReadingM.PerformLayout();
			this.panelReadingM.ResumeLayout(false);
			this.panelReading.ResumeLayout(false);
			this.panelReading.PerformLayout();
			this.panelPicReadingM.ResumeLayout(false);
			this.panelPicReadingM.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picBoxReadingM).EndInit();
			this.tabPageGrammar.ResumeLayout(false);
			this.tabPageGrammar.PerformLayout();
			this.panelGrammar.ResumeLayout(false);
			this.panelMC_Text.ResumeLayout(false);
			this.panelMC_Text.PerformLayout();
			this.panelPicGrammar.ResumeLayout(false);
			this.panelPicGrammar.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picBoxGrammar).EndInit();
			this.tabPageIndicateMistake.ResumeLayout(false);
			this.tabPageIndicateMistake.PerformLayout();
			this.panelIndicateMistake.ResumeLayout(false);
			this.panelIndicateMistake.PerformLayout();
			this.tabPageMatching.ResumeLayout(false);
			this.tabPageMatching.PerformLayout();
			this.panelB.ResumeLayout(false);
			this.panelB.PerformLayout();
			this.panelA.ResumeLayout(false);
			this.panelA.PerformLayout();
			this.tabPageFillBlank.ResumeLayout(false);
			this.panelFillBlank.ResumeLayout(false);
			this.panelFillBlank.PerformLayout();
			this.tabPageEssay.ResumeLayout(false);
			this.tabPageEssay.PerformLayout();
			this.panelEssay.ResumeLayout(false);
			this.panelEssay.PerformLayout();
			this.panelPicEssay.ResumeLayout(false);
			this.panelPicEssay.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxEssay).EndInit();
			this.tabPageImagePaper.ResumeLayout(false);
			this.tabPageImagePaper.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBarPicSize).EndInit();
			this.panelPaper.ResumeLayout(false);
			this.panelPaper.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPaper).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudFontSize).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudVol).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxIcon).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.TabControl tabControlQuestion;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.TabPage tabPageMatching;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Button btnNextMaching;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.Button btnRemoveMSolution;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Button btnAddMSolution;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.ListBox lstAnswerMatch;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.TabPage tabPageGrammar;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.Button btnNextGrammar;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.Label lblOver;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.Label lblExamCode;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.Label lblExamServer;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.Label lblMachine;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.Label lblDuration;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.Label lblSize;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.Label lblMark;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.Label lblTime;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.Label lblLogin;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.NumericUpDown nudFontSize;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.CheckBox chbWantFinish;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Label lblSaveServer;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Button btnFinish;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Button btnExit;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.Timer timerCountDown;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.CheckBox chkGrammarF;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.CheckBox chkGrammarE;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.CheckBox chkGrammarD;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.CheckBox chkGrammarC;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.CheckBox chkGrammarB;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.CheckBox chkGrammarA;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.TabPage tabPageReadingM;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.TabPage tabPageIndicateMistake;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.CheckBox chkReadingF_M;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.CheckBox chkReadingE_M;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.CheckBox chkReadingD_M;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.CheckBox chkReadingC_M;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.CheckBox chkReadingB_M;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.CheckBox chkReadingA_M;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Button btnNextIndiMistake;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.CheckBox chkIndiMistakeF;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.CheckBox chkIndiMistakeE;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.CheckBox chkIndiMistakeD;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.CheckBox chkIndiMistakeC;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.CheckBox chkIndiMistakeB;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.CheckBox chkIndiMistakeA;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Button btnNextReadingM;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.ListBox lstReadingQuestionM;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Button btnNextQuestionM;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Label lblAnswerMatch;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.Label lblMatchNumber;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.Label lblGrammarNumber;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.Label lblIndicateNumber;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.TabPage tabPageFillBlank;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.Button btnNextFillBlank;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.Label lblReading;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.Panel panelFillBlank;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.Label lblFillBlankNumber;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Panel panelReadingM;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Splitter splitterPic;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.Panel panelPicReadingM;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.PictureBox picBoxReadingM;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.Panel panelGrammar;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Splitter splitterGrammar;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Panel panelPicGrammar;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.PictureBox picBoxGrammar;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.Label lblMesage;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.TextBox txtGuide;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.Button btnShowExam;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.Label lblOpenCode;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.TextBox txtOpenCode;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.Timer timerTopMost;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.TextBox txtNumber;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.TextBox txtLetter;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Label lblNumber;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.Label lblLetter;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.Label lblTotalMarks;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.PictureBox pictureBoxIcon;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.TabPage tabPageEssay;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.Button btnWordCount;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.Label lblWordCount;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.Button btnEssayZoom;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.Button btnEssayNormal;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.Panel panelEssay;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.TextBox txtWrittingEssay;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.Splitter splitterEssay;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.Panel panelPicEssay;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.PictureBox pictureBoxEssay;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.Button btnSaveEssay;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.Button btnUndo;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.Button btnRedo;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.Panel panelQuestionList;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.Panel panelMC_Text;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Label lblMC_Text;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.CheckBox chbWantFinishTop;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.Button btnFinishTop;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.Label lblVol;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.NumericUpDown nudVol;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.Button btnReadingZoomIn;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.Button btnReadingRealSize;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.Button btnReadingZoomOut;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.DomainUpDown domainUpDown;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.Label lblFont;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.Panel panelIndicateMistake;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.Label lblIndicateMistake;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.Panel panelReading;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Label lblReadingContent;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Panel panelB;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.Label lblColumnB;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.Panel panelA;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.Label lblColumnA;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.Timer timerBOTTest;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.TabPage tabPageImagePaper;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.Label label19;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.Label lblPicSize;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.TrackBar trackBarPicSize;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.Panel panelPaper;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.PictureBox pictureBoxPaper;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.Panel panelAnswer;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.Button btnFullScreen;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.Label lblTime_copy;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.Label lblTimeLeft_Copy;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.Button btnSubmit;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.Button btnRedoPaper;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.Button btnUndoPaper;

		// Token: 0x04000134 RID: 308
		private global::System.ComponentModel.IContainer components;
	}
}
