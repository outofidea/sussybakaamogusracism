using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CloseConnections2003;
using EF;
using EncryptData;
using GetProcesses;
using Gma.UserActivityMonitor;
using IRemote;
using NAudio.Wave;
using QuestionLib;
using QuestionLib.Entity;
using ScreenShot;
//using WebEye.Controls.WinForms.WebCameraControl;

namespace ExamClient
{
    // Token: 0x02000019 RID: 25
    public partial class frmEnglishExamClient : Form, IExamclient
    {
        // Token: 0x060000D9 RID: 217 RVA: 0x0000492C File Offset: 0x0000392C
        public frmEnglishExamClient()
        {
            this.InitializeComponent();
        }

        // Token: 0x060000DA RID: 218 RVA: 0x00004B2D File Offset: 0x00003B2D
        public void SetExamData(EOSData ed)
        {
            this.examData = ed;
        }

        // Token: 0x060000DD RID: 221 RVA: 0x0000ACA4 File Offset: 0x00009CA4
        private List<string> getValidIPs(string ip_range_wlan)
        {
            List<string> list = new List<string>();
            char[] separator = new char[]
            {
                ';'
            };
            char[] separator2 = new char[]
            {
                '.'
            };
            char[] separator3 = new char[]
            {
                '/'
            };
            bool flag = ip_range_wlan != null && ip_range_wlan.Trim().Length > 0;
            if (flag)
            {
                string[] array = ip_range_wlan.Split(separator);
                foreach (string text in array)
                {
                    try
                    {
                        string[] array3 = text.Split(separator2);
                        bool flag2 = array3.Length == 4;
                        if (flag2)
                        {
                            string[] array4 = array3[3].Split(separator3);
                            bool flag3 = array4.Length == 2;
                            if (flag3)
                            {
                                int num = Convert.ToInt32(array4[0]);
                                int num2 = Convert.ToInt32(array4[1]);
                                for (int j = num; j <= num2; j++)
                                {
                                    string text2 = string.Concat(new object[]
                                    {
                                        array3[0],
                                        ".",
                                        array3[1],
                                        ".",
                                        array3[2],
                                        ".",
                                        j
                                    });
                                    list.Add(text2.Trim());
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return list;
        }

        // Token: 0x060000DE RID: 222 RVA: 0x0000AE0C File Offset: 0x00009E0C
        private void ControlManager()
        {
            this.timerCountDown.Enabled = true;
            this.timerTopMost.Enabled = true;
            this.btnExit.Enabled = false;
            this.tabControlQuestion.Enabled = true;
            this.nudFontSize.Enabled = true;
            this.btnFinish.Enabled = false;
            base.KeyPreview = true;
        }

        // Token: 0x060000DF RID: 223 RVA: 0x0000AE70 File Offset: 0x00009E70
        private void TimerTopMost_FirstDisplay()
        {
            bool flag = this.tabControlQuestion.SelectedTab == this.tabPageFillBlank;
            if (flag)
            {
                Question question = (Question)this.paper.FillBlankQuestions[this.indexFill];
                bool flag2 = question.QType == QuestionType.FILL_BLANK_EMPTY;
                if (flag2)
                {
                    this.timerTopMost.Enabled = true;
                }
                else
                {
                    this.timerTopMost.Enabled = false;
                }
            }
            else
            {
                this.timerTopMost.Enabled = true;
            }
        }

        // Token: 0x060000E0 RID: 224 RVA: 0x0000AEF0 File Offset: 0x00009EF0
        private void DisplayStudentGuide()
        {
            bool flag = this.paper.StudentGuide.Equals("");
            if (flag)
            {
                this.txtGuide.Visible = false;
            }
            else
            {
                this.txtGuide.Text = this.paper.StudentGuide;
                this.txtGuide.Visible = true;
            }
        }

        // Token: 0x060000E1 RID: 225 RVA: 0x0000AF4C File Offset: 0x00009F4C
        private void RemoveTabPages()
        {
            this.tabControlQuestion.SelectedIndexChanged -= this.tabControlQuestion_SelectedIndexChanged;
            bool flag = this.paper.FillBlankQuestions == null || this.paper.FillBlankQuestions.Count == 0;
            if (flag)
            {
                this.tabControlQuestion.TabPages.Remove(this.tabPageFillBlank);
            }
            bool flag2 = this.paper.GrammarQuestions == null || this.paper.GrammarQuestions.Count == 0;
            if (flag2)
            {
                this.tabControlQuestion.TabPages.Remove(this.tabPageGrammar);
            }
            bool flag3 = this.paper.IndicateMQuestions == null || this.paper.IndicateMQuestions.Count == 0;
            if (flag3)
            {
                this.tabControlQuestion.TabPages.Remove(this.tabPageIndicateMistake);
            }
            bool flag4 = this.paper.MatchQuestions == null || this.paper.MatchQuestions.Count == 0;
            if (flag4)
            {
                this.tabControlQuestion.TabPages.Remove(this.tabPageMatching);
            }
            bool flag5 = this.paper.ReadingQuestions == null || this.paper.ReadingQuestions.Count == 0;
            if (flag5)
            {
                this.tabControlQuestion.TabPages.Remove(this.tabPageReadingM);
            }
            bool flag6 = this.paper.EssayQuestion == null;
            if (flag6)
            {
                this.tabControlQuestion.TabPages.Remove(this.tabPageEssay);
            }
            bool flag7 = this.paper.ImgPaper == null;
            if (flag7)
            {
                this.tabControlQuestion.TabPages.Remove(this.tabPageImagePaper);
            }
            this.tabControlQuestion.SelectedIndexChanged += this.tabControlQuestion_SelectedIndexChanged;
        }

        // Token: 0x060000E2 RID: 226 RVA: 0x0000B118 File Offset: 0x0000A118
        private bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        // Token: 0x060000E3 RID: 227 RVA: 0x0000B14C File Offset: 0x0000A14C
        private ArrayList ShuffleList(ArrayList list)
        {
            ArrayList arrayList = new ArrayList();
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                int index = this.ran.Next(list.Count);
                arrayList.Add(list[index]);
                list.RemoveAt(index);
                list.TrimToSize();
            }
            return arrayList;
        }

        // Token: 0x060000E4 RID: 228 RVA: 0x0000B1B4 File Offset: 0x0000A1B4
        private bool checkFont(string fontName)
        {
            bool result;
            using (Font font = new Font(fontName, 12f, FontStyle.Regular))
            {
                bool flag = font.Name.Equals(fontName);
                if (flag)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        // Token: 0x060000E5 RID: 229 RVA: 0x0000B204 File Offset: 0x0000A204
        public void LoadFont()
        {
            List<string> list = new List<string>();
            list.Add("Microsoft Sans Serif");
            list.Add("KaiTi");
            list.Add("Ms Mincho");
            list.Add("HGSeikai");
            list.Add("NtMotoya");
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] families = installedFontCollection.Families;
            foreach (FontFamily fontFamily in families)
            {
                string text = fontFamily.GetName(0).Trim().ToUpper();
                foreach (string text2 in list)
                {
                    string value = text2.ToUpper();
                    bool flag = text.StartsWith(value);
                    if (flag)
                    {
                        this.domainUpDown.Items.Add(fontFamily.GetName(0));
                        break;
                    }
                }
            }
            Font font = this.lblMC_Text.Font;
            string name = font.FontFamily.GetName(0);
            for (int j = 0; j < this.domainUpDown.Items.Count; j++)
            {
                bool flag2 = name.StartsWith(this.domainUpDown.Items[j].ToString());
                if (flag2)
                {
                    this.domainUpDown.SelectedIndex = j;
                    break;
                }
            }
        }

        // Token: 0x060000E6 RID: 230 RVA: 0x0000B388 File Offset: 0x0000A388
        private void panelAnswer_MouseWheel(object sender, MouseEventArgs e)
        {
            this.btnFullScreen.Focus();
        }

        // Token: 0x060000E7 RID: 231
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        // Token: 0x060000E8 RID: 232 RVA: 0x0000B398 File Offset: 0x0000A398
        private void frmEnglishExamClient_Load(object sender, EventArgs e)
        {
            Label label = this.lblMesage;
            label.Text = label.Text + "(" + this.clientType.ToString() + ")";
            try
            {
                bool flag = !this.IsAdministrator();
                if (flag)
                {
                    MessageBox.Show("You must login Windows as System Administrator or Run [EOS Client] as Administrator.", "Run as Administrator!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Application.Exit();
                }
                bool flag2 = this.blockVM;
                if (flag2)
                {
                    string text = "";
                    string text2 = "";
                    bool flag3 = ExamMachine.Assert() || ExamMachine.Assert(out text, out text2);
                    if (flag3)
                    {
                        MessageBox.Show("EOS cannot run under a virtual machine?", "Virtual machine!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Application.Exit();
                    }
                }
            }
            catch
            {
            }
            try
            {
                bool flag4 = this.examData == null;
                if (flag4)
                {
                    MessageBox.Show("Get exam data error. Re-assign and Try again!", "Start exam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.paper = this.examData.ExamPaper;
                    bool flag5 = this.paper == null;
                    if (flag5)
                    {
                        MessageBox.Show("Get exam paper error. Re-assign and Try again!", "Start exam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        bool flag6 = this.paper.ListAudio != null;
                        if (flag6)
                        {
                            int num = 0;
                            int num2 = 0;
                            foreach (AudioInPaper audioInPaper in this.paper.ListAudio)
                            {
                                num += audioInPaper.AudioData.Length;
                                num2 += audioInPaper.AudioSize;
                            }
                            bool flag7 = num != num2;
                            if (flag7)
                            {
                                MessageBox.Show("Get exam audio error. Re-assign and Try again!", "Start exam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        bool flag8 = this.paper.TestType == TestTypeEnum.WRITING_JP || this.paper.TestType == TestTypeEnum.WRITING_CN;
                        if (flag8)
                        {
                            bool flag9 = !this.checkFont("MS Mincho");
                            if (flag9)
                            {
                                MessageBox.Show("Cannot find the Japanese/Chinese 'MS Mincho' font! Install the font and start the exam again.", "Start exam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Application.Exit();
                            }
                            this.nudFontSize.Value = 12m;
                        }
                        frmEnglishExamClient.SetWindowDisplayAffinity(base.Handle, 1U);
                        bool flag10 = this.paper.TestType == TestTypeEnum.WRITING_VN || this.paper.TestType == TestTypeEnum.WRITING_EN;
                        if (flag10)
                        {
                            this.txtWrittingEssay.Font = this.lblMC_Text.Font;
                            this.nudFontSize.Value = 10m;
                        }
                        this.lblMachine.Text = Environment.MachineName;
                        this.loginId = this.examData.RegData.Login;
                        this.lblLogin.Text = this.loginId;
                        this.lblExamServer.Text = this.examData.ServerInfomation.ServerAlias;
                        bool flag11 = this.examData.RegData.ExamCode.Length >= 6;
                        if (flag11)
                        {
                            this.lblExamCode.Text = this.examData.RegData.ExamCode.Substring(0, 6);
                        }
                        else
                        {
                            this.lblExamCode.Text = this.examData.RegData.ExamCode;
                        }
                        this.remotingURL = string.Concat(new object[]
                        {
                            "tcp://",
                            this.examData.ServerInfomation.IP,
                            ":",
                            this.examData.ServerInfomation.Port,
                            "/Server"
                        });
                        this.monitorURL = string.Concat(new object[]
                        {
                            "tcp://",
                            this.examData.ServerInfomation.MonitorServer_IP,
                            ":",
                            this.examData.ServerInfomation.MonitorServer_Port,
                            "/RemoteMonitorServer"
                        });
                        this.nudFontSize.Enabled = false;
                        this.btnFinish.Enabled = false;
                        this.lblMark.Text = "";
                        this.lblSaveServer.Text = "";
                        this.lblTotalMarks.Text = "";
                        this.lblWordCount.Text = "0 word";
                        this.lblTime.Text = "";
                        this.lblDuration.Text = "";
                        this.lblOver.Text = "";
                        this.lblReading.Text = "";
                        this.lblGrammarNumber.Text = "";
                        this.lblIndicateNumber.Text = "";
                        this.lblMatchNumber.Text = "";
                        this.lblColumnA.Text = "";
                        this.lblColumnB.Text = "";
                        this.lblMC_Text.Text = "";
                        this.lblIndicateMistake.Text = "";
                        this.lblReadingContent.Text = "";
                        this.chkReadingM = new CheckBox[6];
                        this.chkReadingM[0] = this.chkReadingA_M;
                        this.chkReadingM[1] = this.chkReadingB_M;
                        this.chkReadingM[2] = this.chkReadingC_M;
                        this.chkReadingM[3] = this.chkReadingD_M;
                        this.chkReadingM[4] = this.chkReadingE_M;
                        this.chkReadingM[5] = this.chkReadingF_M;
                        this.chkGrammar = new CheckBox[6];
                        this.chkGrammar[0] = this.chkGrammarA;
                        this.chkGrammar[1] = this.chkGrammarB;
                        this.chkGrammar[2] = this.chkGrammarC;
                        this.chkGrammar[3] = this.chkGrammarD;
                        this.chkGrammar[4] = this.chkGrammarE;
                        this.chkGrammar[5] = this.chkGrammarF;
                        this.chkIndiMistake = new CheckBox[6];
                        this.chkIndiMistake[0] = this.chkIndiMistakeA;
                        this.chkIndiMistake[1] = this.chkIndiMistakeB;
                        this.chkIndiMistake[2] = this.chkIndiMistakeC;
                        this.chkIndiMistake[3] = this.chkIndiMistakeD;
                        this.chkIndiMistake[4] = this.chkIndiMistakeE;
                        this.chkIndiMistake[5] = this.chkIndiMistakeF;
                        this.ResetFillBlank();
                        this.LoadFont();
                        this.DisplayPaper();
                        bool flag12 = this.clientType == EnumClientType.STUDENT_LAPTOP;
                        if (flag12)
                        {
                            this.listValidIPs = this.getValidIPs(this.examData.ServerInfomation.IP_Range_WLAN);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Display Paper\n" + ex.ToString() + ex.StackTrace);
            }
        }

        // Token: 0x060000E9 RID: 233 RVA: 0x0000BA78 File Offset: 0x0000AA78
        private void DisplayPaper()
        {
            bool flag = this.paper.ListAudio != null;
            if (flag)
            {
                this.lblVol.Enabled = true;
                this.nudVol.Enabled = true;
            }
            bool flag2 = this.paper.TestType == TestTypeEnum.NOT_WRITING || this.paper.TestType == TestTypeEnum.WRITING_EN;
            if (flag2)
            {
                bool flag3 = this.examData.Status == RegisterStatus.NEW;
                if (flag3)
                {
                    this.lblDuration.Text = this.paper.Duration.ToString() + " minutes";
                    this.timeLeft = this.paper.Duration * 60;
                    this.lastSave = this.timeLeft;
                    this.lastSaveImagePaper = this.timeLeft;
                    this.DisplayTimeLeft();
                    this.DisplayStudentGuide();
                    this.RemoveTabPages();
                    bool flag4 = this.paper.ListenCode.Trim().Equals("");
                    if (flag4)
                    {
                        this.ControlManager();
                        this.Shuffle();
                        this.DisplayReading(this.indexReading);
                        this.DisplayMatching(this.indexMatching);
                        this.DisplayGrammar(this.indexGrammar);
                        this.DisplayIndiMistake(this.indexIndicateMistake);
                        this.DisplayFillBlankQuestion(this.indexFill);
                        this.DisplayEssay();
                        this.DisplayImagePaper();
                        this.TimerTopMost_FirstDisplay();
                        this.DisableAllKeyBoard();
                        bool flag5 = this.paper.EssayQuestion != null;
                        if (flag5)
                        {
                            this.undoStack.Add("");
                        }
                    }
                    else
                    {
                        this.txtOpenCode.Enabled = true;
                        this.btnShowExam.Enabled = true;
                        this.chbWantFinish.Enabled = (this.chbWantFinishTop.Enabled = false);
                    }
                    this.StartCloseTCPConnectionsThread();
                    this.DisableMouse();
                    this.lblTotalMarks.Text = this.paper.Mark.ToString();
                }
                bool flag6 = this.examData.Status == RegisterStatus.RE_ASSIGN;
                if (flag6)
                {
                    this.lblDuration.Text = this.paper.Duration.ToString() + " minutes";
                    this.DisplayStudentGuide();
                    this.ControlManager();
                    this.sPaper = this.examData.StudentSubmitPaper;
                    bool flag7 = EnumClientType.STUDENT_LAPTOP == this.clientType;
                    if (flag7)
                    {
                        string text = this.examData.RegData.ExamCode + "\\" + this.examData.RegData.Login + ".dat";
                        SubmitPaper submitPaper = null;
                        bool flag8 = File.Exists(text);
                        if (flag8)
                        {
                            try
                            {
                                submitPaper = QuestionHelper.LoadSubmitPaper(text);
                            }
                            catch
                            {
                            }
                        }
                        bool flag9 = submitPaper != null && submitPaper.TimeLeft < this.sPaper.TimeLeft;
                        if (flag9)
                        {
                            bool flag10 = this.sPaper.Equals(submitPaper);
                            if (flag10)
                            {
                                this.sPaper = submitPaper;
                            }
                        }
                    }
                    this.timeLeft = this.sPaper.TimeLeft;
                    this.DisplayTimeLeft();
                    this.indexReading = this.sPaper.IndexReading;
                    this.indexMatching = this.sPaper.IndexMatch;
                    this.indexGrammar = this.sPaper.IndexG;
                    this.indexIndicateMistake = this.sPaper.IndexIndiM;
                    this.indexFill = this.sPaper.IndexFill;
                    this.paper = QuestionHelper.Re_ConstructPaper(this.paper, this.sPaper);
                    this.RemoveTabPages();
                    this.DisplayReading(this.indexReading);
                    this.DisplayMatching(this.indexMatching);
                    this.DisplayGrammar(this.indexGrammar);
                    this.DisplayIndiMistake(this.indexIndicateMistake);
                    this.DisplayFillBlankQuestion(this.indexFill);
                    this.DisplayEssay();
                    this.DisplayImagePaper();
                    this.txtOpenCode.Enabled = false;
                    this.btnShowExam.Enabled = false;
                    this.DisableMouse();
                    this.DisableAllKeyBoard();
                    this.TimerTopMost_FirstDisplay();
                    this.StartCloseTCPConnectionsThread();
                    this.paper.Mark = this.sPaper.SPaper.Mark;
                    this.lblTotalMarks.Text = this.paper.Mark.ToString();
                    bool flag11 = this.paper.EssayQuestion != null;
                    if (flag11)
                    {
                        this.undoStack.Add(this.paper.EssayQuestion.Development);
                    }
                    bool flag12 = this.paper.ListAudio != null;
                    if (flag12)
                    {
                        this.timeLeft += 10;
                        bool flag13 = this.timeLeft > 60 * this.paper.Duration;
                        if (flag13)
                        {
                            this.timeLeft -= 10;
                        }
                        byte[] array = this.CreateAudioData();
                        bool flag14 = array != null && array.Length != 0;
                        if (flag14)
                        {
                            int num = 60 * this.paper.Duration - this.timeLeft;
                            num = ((num > 0) ? num : 0);
                            this.PlayFromBuf(array, num);
                        }
                    }
                    this.lastSave = this.timeLeft;
                }
                bool flag15 = this.tabControlQuestion.SelectedTab == this.tabPageGrammar;
                if (flag15)
                {
                    bool flag16 = this.paper.GrammarQuestions.Count > 0;
                    if (flag16)
                    {
                        this.AddQuestionButon(this.paper.GrammarQuestions.Count);
                        this.panelQuestionList.Visible = true;
                    }
                    bool flag17 = this.examData.Status == RegisterStatus.RE_ASSIGN;
                    if (flag17)
                    {
                        for (int i = 0; i < this.paper.GrammarQuestions.Count; i++)
                        {
                            Question q = (Question)this.paper.GrammarQuestions[i];
                            bool flag18 = this.IsQuestionAnswered(q);
                            if (flag18)
                            {
                                this.SetButtonColor(i + 1, Color.GreenYellow);
                            }
                            else
                            {
                                this.SetButtonColor(i + 1, this.BackColor);
                            }
                        }
                    }
                }
                bool flag19 = this.tabControlQuestion.SelectedTab == this.tabPageIndicateMistake;
                if (flag19)
                {
                    bool flag20 = this.paper.IndicateMQuestions.Count > 0;
                    if (flag20)
                    {
                        this.AddQuestionButon(this.paper.IndicateMQuestions.Count);
                        this.panelQuestionList.Visible = true;
                    }
                    bool flag21 = this.examData.Status == RegisterStatus.RE_ASSIGN;
                    if (flag21)
                    {
                        for (int j = 0; j < this.paper.IndicateMQuestions.Count; j++)
                        {
                            Question q2 = (Question)this.paper.IndicateMQuestions[j];
                            bool flag22 = this.IsQuestionAnswered(q2);
                            if (flag22)
                            {
                                this.SetButtonColor(j + 1, Color.GreenYellow);
                            }
                            else
                            {
                                this.SetButtonColor(j + 1, this.BackColor);
                            }
                        }
                    }
                }
            }
            else
            {
                base.WindowState = FormWindowState.Maximized;
                base.ControlBox = true;
                base.MinimizeBox = true;
                base.MaximizeBox = true;
                bool flag23 = this.examData.Status == RegisterStatus.NEW;
                if (flag23)
                {
                    this.lblDuration.Text = this.paper.Duration.ToString() + " minutes";
                    this.lblTotalMarks.Text = "";
                    this.timeLeft = this.paper.Duration * 60;
                    this.DisplayTimeLeft();
                    this.DisplayStudentGuide();
                    this.RemoveTabPages();
                    this.ControlManager();
                    base.TopMost = false;
                    bool flag24 = this.paper.EssayQuestion != null;
                    if (flag24)
                    {
                        this.DisplayEssay();
                        this.undoStack.Add("");
                    }
                    this.DisplayImagePaper();
                    this.StartCloseTCPConnectionsThread();
                }
                bool flag25 = this.examData.Status == RegisterStatus.RE_ASSIGN;
                if (flag25)
                {
                    this.lblDuration.Text = this.paper.Duration.ToString() + " minutes";
                    this.lblTotalMarks.Text = "";
                    this.DisplayStudentGuide();
                    this.ControlManager();
                    this.sPaper = this.examData.StudentSubmitPaper;
                    bool flag26 = EnumClientType.STUDENT_LAPTOP == this.clientType;
                    if (flag26)
                    {
                        string text2 = this.examData.RegData.ExamCode + "\\" + this.examData.RegData.Login + ".dat";
                        SubmitPaper submitPaper2 = null;
                        bool flag27 = File.Exists(text2);
                        if (flag27)
                        {
                            try
                            {
                                submitPaper2 = QuestionHelper.LoadSubmitPaper(text2);
                            }
                            catch
                            {
                            }
                        }
                        bool flag28 = submitPaper2 != null && submitPaper2.TimeLeft < this.sPaper.TimeLeft;
                        if (flag28)
                        {
                            bool flag29 = this.sPaper.Equals(submitPaper2);
                            if (flag29)
                            {
                                this.sPaper = submitPaper2;
                            }
                        }
                    }
                    this.timeLeft = this.sPaper.TimeLeft;
                    this.DisplayTimeLeft();
                    this.paper = QuestionHelper.Re_ConstructPaper(this.paper, this.sPaper);
                    this.RemoveTabPages();
                    base.TopMost = true;
                    this.DisplayEssay();
                    this.DisplayImagePaper();
                    this.StartCloseTCPConnectionsThread();
                    bool flag30 = this.paper.EssayQuestion != null;
                    if (flag30)
                    {
                        this.undoStack.Add(this.paper.EssayQuestion.Development);
                    }
                }
            }
            bool flag31 = (EnumClientType.STUDENT_LAPTOP == this.clientType && this.paper.TestType == TestTypeEnum.NOT_WRITING) || this.paper.TestType == TestTypeEnum.WRITING_EN;
            if (flag31)
            {
                try
                {
                    ThreadStart start = new ThreadStart(this.CloseApps);
                    Thread thread = new Thread(start);
                    thread.Start();
                }
                catch
                {
                }
            }
        }

        // Token: 0x060000EA RID: 234 RVA: 0x0000C48C File Offset: 0x0000B48C
        private byte[] CreateAudioData()
        {
            byte[] oneSecSilence = this.paper.OneSecSilence;
            this.paper.ListAudio.Sort();
            int num = 0;
            foreach (AudioInPaper audioInPaper in this.paper.ListAudio)
            {
                num += (audioInPaper.AudioSize + audioInPaper.PaddingTime * oneSecSilence.Length) * (int)audioInPaper.RepeatTime;
            }
            num += this.paper.AudioHeadPadding * oneSecSilence.Length;
            bool flag = num == 0;
            byte[] result;
            if (flag)
            {
                result = null;
            }
            else
            {
                byte[] array = new byte[num];
                int num2 = 0;
                for (int i = 0; i < this.paper.AudioHeadPadding; i++)
                {
                    Array.Copy(oneSecSilence, 0, array, num2, oneSecSilence.Length);
                    num2 += oneSecSilence.Length;
                }
                foreach (AudioInPaper audioInPaper2 in this.paper.ListAudio)
                {
                    for (int j = 0; j < (int)audioInPaper2.RepeatTime; j++)
                    {
                        Array.Copy(audioInPaper2.AudioData, 0, array, num2, audioInPaper2.AudioData.Length);
                        num2 += audioInPaper2.AudioData.Length;
                        for (int k = 0; k < audioInPaper2.PaddingTime; k++)
                        {
                            Array.Copy(oneSecSilence, 0, array, num2, oneSecSilence.Length);
                            num2 += oneSecSilence.Length;
                        }
                    }
                }
                result = array;
            }
            return result;
        }

        // Token: 0x060000EB RID: 235 RVA: 0x0000C648 File Offset: 0x0000B648
        private void DisplayTimeLeft()
        {
            int num = this.timeLeft / 60;
            int num2 = this.timeLeft % 60;
            string text = "0" + num.ToString();
            bool flag = num >= 100;
            if (flag)
            {
                text = text.Substring(text.Length - 3, 3);
            }
            else
            {
                text = text.Substring(text.Length - 2, 2);
            }
            string text2 = "0" + num2.ToString();
            text2 = text2.Substring(text2.Length - 2, 2);
            string text3 = text + ":" + text2;
            this.lblTime.Text = text3;
            this.lblTime_copy.Text = text3;
        }

        // Token: 0x060000EC RID: 236 RVA: 0x0000C6F8 File Offset: 0x0000B6F8
        private bool isOutOfWifi()
        {
            bool flag = this.listValidIPs == null || this.listValidIPs.Count == 0;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                try
                {
                    IPHostEntry hostByName = Dns.GetHostByName(Environment.MachineName);
                    IPAddress[] addressList = hostByName.AddressList;
                    string item = addressList[0].ToString().Trim();
                    bool flag2 = this.listValidIPs == null || this.listValidIPs.Count == 0 || this.listValidIPs.Contains(item);
                    if (flag2)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                catch
                {
                    result = true;
                }
            }
            return result;
        }

        // Token: 0x060000ED RID: 237 RVA: 0x0000C794 File Offset: 0x0000B794
        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            this.timeLeft--;
            this.DisplayTimeLeft();
            bool flag = this.timeLeft == 0;
            if (flag)
            {
                this.timerCountDown.Enabled = false;
                this.btnFinish.Enabled = true;
                this.chbWantFinish.Checked = true;
                this.btnFinish.PerformClick();
            }
            else
            {
                bool flag2 = this.finishClick;
                if (flag2)
                {
                    this.timerCountDown.Enabled = false;
                }
                else
                {
                    bool flag3 = this.paper.TestType == TestTypeEnum.NOT_WRITING || this.paper.TestType == TestTypeEnum.WRITING_EN;
                    if (flag3)
                    {
                        bool flag4 = this.clientType == EnumClientType.LAB_VDI || this.clientType == EnumClientType.STUDENT_LAPTOP;
                        if (flag4)
                        {
                            int foregroundWindow = Win32.GetForegroundWindow();
                            bool flag5 = base.Handle.ToInt32() != foregroundWindow;
                            if (flag5)
                            {
                                Win32.SendMessage(foregroundWindow, 274U, 61472, 0);
                            }
                            Win32.SetActiveWindow(base.Handle.ToInt32());
                        }
                    }
                    bool flag6 = this.paper.EssayQuestion != null;
                    if (flag6)
                    {
                        bool flag7 = this.timeLeft % this.autoSaveInteval == 0;
                        if (flag7)
                        {
                            this.btnSaveEssay.PerformClick();
                        }
                    }
                    bool flag8 = this.paper.ListAudio != null && this.paper.ImgPaper == null;
                    if (flag8)
                    {
                        bool flag9 = this.lastSave - this.timeLeft >= 30;
                        if (flag9)
                        {
                            bool flag10 = this.sPaper == null;
                            if (flag10)
                            {
                                this.sPaper = this.CreateSubmitPaper(false);
                                this.SaveAtServer();
                            }
                            this.sPaper = this.CreateSubmitPaper(false);
                            this.SaveAtClient();
                            this.lastSave = this.timeLeft;
                        }
                    }
                    else
                    {
                        bool flag11 = !this.submitFirstTime;
                        if (flag11)
                        {
                            this.submitFirstTime = true;
                            this.Submit2Server_SaveAtClient();
                        }
                    }
                    bool flag12 = this.paper.ImgPaper != null;
                    if (flag12)
                    {
                        bool flag13 = this.lastSaveImagePaper - this.timeLeft >= 60;
                        if (flag13)
                        {
                            this.Submit2Server_SaveAtClient();
                        }
                    }
                    bool flag14 = this.clientType == EnumClientType.STUDENT_LAPTOP && !this.isDistanceLearning;
                    if (flag14)
                    {
                        this.countCheckWifi++;
                        bool flag15 = this.countCheckWifi >= 5;
                        if (flag15)
                        {
                            this.countCheckWifi = 0;
                            bool flag16 = this.isOutOfWifi();
                            if (flag16)
                            {
                                this.BackColor = Color.Red;
                            }
                            else
                            {
                                this.BackColor = SystemColors.Control;
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x060000EE RID: 238 RVA: 0x0000CA2C File Offset: 0x0000BA2C
        public void SendScreenImage()
        {
            this.closeConnection = false;
            this.keepConnection = true;
            ScreenCapture screenCapture = new ScreenCapture();
            Image image = screenCapture.CaptureScreen();
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            try
            {
                IRemoteMonitorServer remoteMonitorServer = (IRemoteMonitorServer)Activator.GetObject(typeof(IRemoteMonitorServer), this.monitorURL);
                IRemoteMonitorServer remoteMonitorServer2 = remoteMonitorServer;
                byte[] buffer = memoryStream.GetBuffer();
                int num = this.imageIndex;
                this.imageIndex = num + 1;
                this.captureScreenInterval = remoteMonitorServer2.SaveScreenImage(buffer, num, this.examData.RegData.ExamCode, this.loginId);
                bool flag = this.listMissScreenImages.Count > 0;
                if (flag)
                {
                    ThreadStart start = new ThreadStart(this.SendOneMissScreenImage);
                    Thread thread = new Thread(start);
                    thread.Start();
                }
            }
            catch
            {
                this.listMissScreenImages.Add(memoryStream.GetBuffer());
            }
            this.keepConnection = false;
            this.closeConnection = true;
        }

        // Token: 0x060000EF RID: 239 RVA: 0x0000CB30 File Offset: 0x0000BB30
        private void DisplayReading(int index)
        {
            bool flag = this.paper.ReadingQuestions == null || this.paper.ReadingQuestions.Count == 0;
            if (!flag)
            {
                this.btnNextReadingM.Enabled = true;
                this.ResetReading();
                Passage passage = (Passage)this.paper.ReadingQuestions[index];
                this.lblReadingContent.Text = passage.Text + "\r\n\r\n";
                int num = 0;
                float num2 = 0f;
                this.lstReadingQuestionM.SelectedIndexChanged -= this.lstReadingQuestionM_SelectedIndexChanged;
                bool flag2 = passage.PassageQuestions.Count == 0;
                if (!flag2)
                {
                    foreach (object obj in passage.PassageQuestions)
                    {
                        Question question = (Question)obj;
                        num++;
                        Label label = this.lblReadingContent;
                        label.Text = string.Concat(new object[]
                        {
                            label.Text,
                            num,
                            ") ",
                            question.Text,
                            "\r\n"
                        });
                        int num3 = -1;
                        foreach (object obj2 in question.QuestionAnswers)
                        {
                            QuestionAnswer questionAnswer = (QuestionAnswer)obj2;
                            num3++;
                            label = this.lblReadingContent;
                            label.Text = string.Concat(new string[]
                            {
                                label.Text,
                                this.qaNo[num3],
                                ".  ",
                                questionAnswer.Text,
                                "\r\n"
                            });
                        }
                        Label label2 = this.lblReadingContent;
                        label2.Text += "\r\n";
                        this.lstReadingQuestionM.Items.Add(new QuestionInListBox(question, num));
                        num2 += question.Mark;
                    }
                    this.DisplayImageOnLabel(this.panelReading, this.lblReadingContent, this.lblReadingContent.Text);
                    this.lstReadingQuestionM.SelectedIndexChanged += this.lstReadingQuestionM_SelectedIndexChanged;
                    this.lblMark.Text = num2.ToString();
                    this.lblReading.Text = string.Concat(new object[]
                    {
                        "Reading ",
                        index + 1,
                        "/",
                        this.paper.ReadingQuestions.Count,
                        ":"
                    });
                    this.lstReadingQuestionM.SelectedIndex = this.indexReadingQuestion;
                    this.DisableNonFunctionKeys();
                }
            }
        }

        // Token: 0x060000F0 RID: 240 RVA: 0x0000CE40 File Offset: 0x0000BE40
        private void ResetReading()
        {
            this.lblReadingContent.Text = "";
            this.lstReadingQuestionM.Items.Clear();
            foreach (CheckBox checkBox in this.chkReadingM)
            {
                checkBox.Tag = null;
                checkBox.Checked = false;
                checkBox.Visible = false;
            }
        }

        // Token: 0x060000F1 RID: 241 RVA: 0x0000CEA4 File Offset: 0x0000BEA4
        private void DisplayMatching(int index)
        {
            bool flag = this.paper.MatchQuestions == null || this.paper.MatchQuestions.Count == 0;
            if (!flag)
            {
                this.btnNextMaching.Enabled = true;
                this.ResetMatching();
                MatchQuestion matchQuestion = (MatchQuestion)this.paper.MatchQuestions[index];
                this.DisplayImageOnLabel(this.panelA, this.lblColumnA, matchQuestion.ColumnA);
                this.DisplayImageOnLabel(this.panelB, this.lblColumnB, matchQuestion.ColumnB);
                char[] separator = new char[]
                {
                    ';'
                };
                bool flag2 = matchQuestion.SudentAnswer != null;
                if (flag2)
                {
                    string[] items = matchQuestion.SudentAnswer.Split(separator);
                    this.lstAnswerMatch.Items.AddRange(items);
                }
                this.lblMark.Text = matchQuestion.Mark.ToString();
                this.lblMatchNumber.Text = string.Concat(new object[]
                {
                    "Match question ",
                    index + 1,
                    "/",
                    this.paper.MatchQuestions.Count
                });
                string[] array = matchQuestion.Solution.Split(separator);
                this.matchingAnswerCount = array.Length;
                this.DisableNonFunctionKeys();
            }
        }

        // Token: 0x060000F2 RID: 242 RVA: 0x0000CFFE File Offset: 0x0000BFFE
        private void ResetMatching()
        {
            this.lblColumnA.Text = "";
            this.lblColumnB.Text = "";
            this.lstAnswerMatch.Items.Clear();
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x0000D034 File Offset: 0x0000C034
        private void DisplayFillBlankQuestion(int index)
        {
            bool flag = this.paper.FillBlankQuestions == null || this.paper.FillBlankQuestions.Count == 0;
            if (!flag)
            {
                this.oldFillBlankAnswer = "";
                this.btnNextFillBlank.Enabled = true;
                this.ResetFillBlank();
                Question question = (Question)this.paper.FillBlankQuestions[index];
                this.lblMark.Text = question.Mark.ToString();
                this.lblFillBlankNumber.Text = string.Concat(new object[]
                {
                    "Fill Blank question ",
                    index + 1,
                    "/",
                    this.paper.FillBlankQuestions.Count,
                    ":"
                });
                int left = this.lblFillBlankNumber.Left;
                int num = left;
                int num2 = this.lblFillBlankNumber.Top + 2 * this.lblFillBlankNumber.Height;
                char[] separator = new char[]
                {
                    '\n'
                };
                string[] array = question.Text.Trim().Split(separator);
                this.lblList = new ArrayList();
                bool flag2 = question.QType == QuestionType.FILL_BLANK_ALL || question.QType == QuestionType.FILL_BLANK_GROUP;
                if (flag2)
                {
                    this.cboList = new ArrayList();
                    this.txtList = null;
                    this.timerTopMost.Enabled = false;
                    this.DisableNonFunctionKeys();
                }
                else
                {
                    this.txtList = new ArrayList();
                    this.cboList = null;
                    this.timerTopMost.Enabled = true;
                    this.EnableNonFunctionKeys();
                }
                int num3 = 0;
                foreach (string input in array)
                {
                    string fillBlank_Pattern = QuestionHelper.fillBlank_Pattern;
                    Regex regex = new Regex(fillBlank_Pattern, RegexOptions.ExplicitCapture);
                    MatchCollection matchCollection = regex.Matches(input);
                    string[] array3 = regex.Split(input);
                    for (int j = 0; j < array3.Length; j++)
                    {
                        Label label = new Label();
                        label.Visible = true;
                        label.AutoSize = true;
                        label.Text = array3[j].Replace("&", "&&");
                        this.lblList.Add(label);
                        bool flag3 = num + label.Width > base.Width;
                        if (flag3)
                        {
                            num = left;
                            num2 += 2 * label.Height;
                        }
                        label.Left = num;
                        label.Top = num2;
                        this.panelFillBlank.Controls.Add(label);
                        num += label.Width;
                        bool flag4 = question.QType == QuestionType.FILL_BLANK_EMPTY && j < array3.Length - 1;
                        if (flag4)
                        {
                            TextBox textBox = new TextBox();
                            textBox.Visible = true;
                            textBox.Width = 100;
                            this.txtList.Add(textBox);
                            bool flag5 = num + textBox.Width > this.panelFillBlank.Width;
                            if (flag5)
                            {
                                num = left;
                                num2 += 2 * this.lblFillBlankNumber.Height;
                            }
                            textBox.Left = num;
                            textBox.Top = num2;
                            this.panelFillBlank.Controls.Add(textBox);
                            num += textBox.Width;
                            QuestionAnswer questionAnswer = (QuestionAnswer)question.QuestionAnswers[this.txtList.Count - 1];
                            textBox.Text = questionAnswer.Text;
                            textBox.Tag = questionAnswer;
                            textBox.TextChanged += this.ans_TextChanged;
                            textBox.Leave += this.ans_Leave;
                            this.oldFillBlankAnswer += textBox.Text;
                        }
                        bool flag6 = question.QType == QuestionType.FILL_BLANK_ALL && j < array3.Length - 1;
                        if (flag6)
                        {
                            NoScrollComboBox noScrollComboBox = new NoScrollComboBox();
                            noScrollComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                            noScrollComboBox.Visible = true;
                            noScrollComboBox.Width = 100;
                            foreach (object obj in question.QuestionAnswers)
                            {
                                QuestionAnswer questionAnswer2 = (QuestionAnswer)obj;
                                noScrollComboBox.Items.Add(questionAnswer2.Text);
                            }
                            this.cboList.Add(noScrollComboBox);
                            bool flag7 = num + noScrollComboBox.Width > this.panelFillBlank.Width;
                            if (flag7)
                            {
                                num = left;
                                num2 += 2 * this.lblFillBlankNumber.Height;
                            }
                            noScrollComboBox.Left = num;
                            noScrollComboBox.Top = num2;
                            this.panelFillBlank.Controls.Add(noScrollComboBox);
                            num += noScrollComboBox.Width;
                            QuestionAnswer questionAnswer3 = (QuestionAnswer)question.QuestionAnswers[this.cboList.Count - 1];
                            noScrollComboBox.Text = questionAnswer3.Text;
                            noScrollComboBox.Tag = questionAnswer3;
                            noScrollComboBox.SelectedIndexChanged += this.ans_TextChanged;
                            noScrollComboBox.Leave += this.ans_Leave;
                            this.oldFillBlankAnswer += noScrollComboBox.Text;
                        }
                        bool flag8 = question.QType == QuestionType.FILL_BLANK_GROUP && j < array3.Length - 1;
                        if (flag8)
                        {
                            NoScrollComboBox noScrollComboBox2 = new NoScrollComboBox();
                            noScrollComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                            noScrollComboBox2.Visible = true;
                            noScrollComboBox2.Width = 100;
                            noScrollComboBox2.Items.AddRange(this.GetFilledWord_Group(question.Text, num3));
                            num3++;
                            this.cboList.Add(noScrollComboBox2);
                            bool flag9 = num + noScrollComboBox2.Width > this.panelFillBlank.Width;
                            if (flag9)
                            {
                                num = left;
                                num2 += 2 * this.lblFillBlankNumber.Height;
                            }
                            noScrollComboBox2.Left = num;
                            noScrollComboBox2.Top = num2;
                            this.panelFillBlank.Controls.Add(noScrollComboBox2);
                            num += noScrollComboBox2.Width;
                            QuestionAnswer questionAnswer4 = (QuestionAnswer)question.QuestionAnswers[this.cboList.Count - 1];
                            noScrollComboBox2.Text = questionAnswer4.Text;
                            noScrollComboBox2.Tag = questionAnswer4;
                            noScrollComboBox2.SelectedIndexChanged += this.ans_TextChanged;
                            noScrollComboBox2.Leave += this.ans_Leave;
                            this.oldFillBlankAnswer += noScrollComboBox2.Text;
                        }
                    }
                    num2 += 2 * this.lblFillBlankNumber.Height;
                    num = left;
                }
            }
        }

        // Token: 0x060000F4 RID: 244 RVA: 0x0000D700 File Offset: 0x0000C700
        private void ResetFillBlank()
        {
            bool flag = this.lblList != null;
            if (flag)
            {
                for (int i = 0; i < this.lblList.Count; i++)
                {
                    this.panelFillBlank.Controls.Remove((Label)this.lblList[i]);
                }
                this.lblList = null;
            }
            bool flag2 = this.txtList != null;
            if (flag2)
            {
                for (int j = 0; j < this.txtList.Count; j++)
                {
                    this.panelFillBlank.Controls.Remove((TextBox)this.txtList[j]);
                }
                this.txtList = null;
            }
            bool flag3 = this.cboList != null;
            if (flag3)
            {
                for (int k = 0; k < this.cboList.Count; k++)
                {
                    this.panelFillBlank.Controls.Remove((ComboBox)this.cboList[k]);
                }
                this.cboList = null;
            }
        }

        // Token: 0x060000F5 RID: 245 RVA: 0x0000D81C File Offset: 0x0000C81C
        private void DisplayGrammar(int index)
        {
            bool flag = this.paper.GrammarQuestions == null || this.paper.GrammarQuestions.Count == 0;
            if (!flag)
            {
                this.btnNextGrammar.Enabled = true;
                this.ResetGrammar();
                Question question = (Question)this.paper.GrammarQuestions[index];
                bool flag2 = question.ImageSize != 0;
                if (flag2)
                {
                    this.panelPicGrammar.Visible = true;
                    MemoryStream stream = new MemoryStream(question.ImageData);
                    Image image = Image.FromStream(stream);
                    this.picBoxGrammar.Image = image;
                }
                else
                {
                    this.panelPicGrammar.Visible = false;
                    this.picBoxGrammar.Image = null;
                }
                char[] trimChars = new char[1];
                Label label = this.lblMC_Text;
                label.Text = label.Text + question.Text.Trim(trimChars) + "\r\n\r\n";
                int num = -1;
                this.oldGrammarChoice = "";
                foreach (object obj in question.QuestionAnswers)
                {
                    QuestionAnswer questionAnswer = (QuestionAnswer)obj;
                    num++;
                    bool flag3 = !questionAnswer.Text.Equals("");
                    if (flag3)
                    {
                        Label label2 = this.lblMC_Text;
                        label2.Text = string.Concat(new string[]
                        {
                            label2.Text,
                            this.qaNo[num],
                            ".  ",
                            questionAnswer.Text,
                            "\r\n\r\n"
                        });
                    }
                    this.chkGrammar[num].Visible = true;
                    this.chkGrammar[num].Tag = questionAnswer;
                    this.chkGrammar[num].Checked = questionAnswer.Selected;
                    this.oldGrammarChoice += this.chkGrammar[num].Checked.ToString();
                }
                this.DisplayImageOnLabel(this.panelMC_Text, this.lblMC_Text, this.lblMC_Text.Text);
                this.lblMark.Text = question.Mark.ToString();
                this.lblGrammarNumber.Text = string.Concat(new object[]
                {
                    "Multiple choices ",
                    index + 1,
                    "/",
                    this.paper.GrammarQuestions.Count
                });
                this.DisableNonFunctionKeys();
            }
        }

        // Token: 0x060000F6 RID: 246 RVA: 0x0000DAC4 File Offset: 0x0000CAC4
        private void ResetGrammar()
        {
            this.lblMC_Text.Text = "";
            foreach (CheckBox checkBox in this.chkGrammar)
            {
                checkBox.Tag = null;
                checkBox.Checked = false;
                checkBox.Visible = false;
            }
        }

        // Token: 0x060000F7 RID: 247 RVA: 0x0000DB18 File Offset: 0x0000CB18
        private void DisplayIndiMistake(int index)
        {
            bool flag = this.paper.IndicateMQuestions == null || this.paper.IndicateMQuestions.Count == 0;
            if (!flag)
            {
                this.btnNextIndiMistake.Enabled = true;
                this.ResetIndiMistake();
                Question question = (Question)this.paper.IndicateMQuestions[index];
                Label label = this.lblIndicateMistake;
                label.Text = label.Text + question.Text + "\r\n\r\n";
                int num = -1;
                this.oldIndiMistakeChoice = "";
                foreach (object obj in question.QuestionAnswers)
                {
                    QuestionAnswer questionAnswer = (QuestionAnswer)obj;
                    num++;
                    Label label2 = this.lblIndicateMistake;
                    label2.Text = string.Concat(new string[]
                    {
                        label2.Text,
                        this.qaNo[num],
                        ".  ",
                        questionAnswer.Text,
                        "\r\n\r\n"
                    });
                    this.chkIndiMistake[num].Visible = true;
                    this.chkIndiMistake[num].Tag = questionAnswer;
                    this.chkIndiMistake[num].Checked = questionAnswer.Selected;
                    this.oldIndiMistakeChoice += this.chkIndiMistake[num].Checked.ToString();
                }
                this.DisplayImageOnLabel(this.panelIndicateMistake, this.lblIndicateMistake, this.lblIndicateMistake.Text);
                this.lblMark.Text = question.Mark.ToString();
                this.lblIndicateNumber.Text = string.Concat(new object[]
                {
                    "Indicate Mistake question ",
                    index + 1,
                    "/",
                    this.paper.IndicateMQuestions.Count
                });
                this.DisableNonFunctionKeys();
            }
        }

        // Token: 0x060000F8 RID: 248 RVA: 0x0000DD38 File Offset: 0x0000CD38
        private void ResetIndiMistake()
        {
            this.lblIndicateMistake.Text = "";
            foreach (CheckBox checkBox in this.chkIndiMistake)
            {
                checkBox.Tag = null;
                checkBox.Checked = false;
                checkBox.Visible = false;
            }
        }

        // Token: 0x060000F9 RID: 249 RVA: 0x0000DD8C File Offset: 0x0000CD8C
        private void DisplayEssay()
        {
            bool flag = this.paper.EssayQuestion == null;
            if (!flag)
            {
                this.ResetEssay();
                EssayQuestion essayQuestion = this.paper.EssayQuestion;
                MemoryStream stream = new MemoryStream(essayQuestion.Question);
                Image image = Image.FromStream(stream);
                this.pictureBoxEssay.Image = image;
                this.btnEssayZoom.Enabled = true;
                this.btnEssayNormal.Enabled = true;
                bool flag2 = essayQuestion.Development == null || essayQuestion.Development.Equals("");
                if (flag2)
                {
                    this.txtWrittingEssay.Text = "<Typing here>";
                }
                else
                {
                    this.txtWrittingEssay.Text = essayQuestion.Development;
                }
                this.lblMark.Text = "N/A";
                bool flag3 = this.paper.TestType == TestTypeEnum.WRITING_EN;
                if (flag3)
                {
                    this.EnableNonFunctionKeys();
                    this.EnableMouse();
                }
            }
        }

        // Token: 0x060000FA RID: 250 RVA: 0x0000DE7C File Offset: 0x0000CE7C
        private void ResetEssay()
        {
            this.txtWrittingEssay.Text = "<Typing here>";
            this.pictureBoxEssay.Image = null;
            this.lblWordCount.Text = "";
        }

        // Token: 0x060000FB RID: 251 RVA: 0x0000DEB0 File Offset: 0x0000CEB0
        private void DisplayImagePaper()
        {
            int num = 0;
            bool flag = this.paper.ImgPaper == null;
            if (!flag)
            {
                this.panelAnswer.MouseWheel += this.panelAnswer_MouseWheel;
                List<PaperSection> sections = this.paper.ImgPaper.Sections;
                this.ResetImagePaper();
                ImagePaper imgPaper = this.paper.ImgPaper;
                this.pictureBoxPaper.Top = this.panelPaper.Top;
                this.pictureBoxPaper.Left = this.panelPaper.Left;
                this.pictureBoxPaper.BackColor = Color.White;
                this.pictureBoxPaper.SizeMode = PictureBoxSizeMode.StretchImage;
                MemoryStream stream = new MemoryStream(imgPaper.Image);
                this.NumberOfPage = imgPaper.NumberOfPage;
                Image image = Image.FromStream(stream);
                this.pictureBoxPaper.Image = image;
                this.pictureBoxPaper.Width = this.CentimeterToPixel(21.0);
                this.pictureBoxPaper.Height = this.CentimeterToPixel(29.7 * (double)this.NumberOfPage);
                this.trackBarPicSize.Value = 100;
                bool flag2 = this.paper.TestType > TestTypeEnum.NOT_WRITING;
                if (flag2)
                {
                    this.EnableNonFunctionKeys();
                    this.EnableMouse();
                }
                int num2 = 0;
                int num3 = 0;
                foreach (PaperSection paperSection in sections)
                {
                    num3 += paperSection.GetAnswerCount();
                }
                this.arrTBAnswers = new TextBox[num3];
                this.arrLBLAnswers = new Label[num3];
                int num4 = 0;
                Label label = new Label();
                label.Text = "ANSWER SHEET";
                label.Top = num4 * (label.Height + 10);
                label.Left = 10;
                this.panelAnswer.Controls.Add(label);
                label.AutoSize = true;
                num4++;
                foreach (PaperSection paperSection2 in sections)
                {
                    for (int i = 0; i < paperSection2.Answers.Count; i++)
                    {
                        bool flag3 = i == 0;
                        if (flag3)
                        {
                            Label label2 = new Label();
                            label2.Text = string.Concat(new object[]
                            {
                                "SECTION ",
                                paperSection2.SectionNo,
                                " (Questions ",
                                paperSection2.QFrom,
                                "-",
                                paperSection2.QTo,
                                ")"
                            });
                            label2.Top = num4 * (label2.Height + 10) + num;
                            label2.Left = 10;
                            this.panelAnswer.Controls.Add(label2);
                            label2.AutoSize = true;
                            num4++;
                        }
                        Label label3 = new Label();
                        this.arrLBLAnswers[num2] = label3;
                        string text = "   " + (num2 + 1);
                        text = text.Substring(text.Length - 3, 3);
                        label3.Text = text + ")";
                        label3.Top = num4 * (label3.Height + 10) + num;
                        label3.Left = 10;
                        this.panelAnswer.Controls.Add(label3);
                        label3.AutoSize = true;
                        TextBox textBox = new TextBox();
                        textBox.TextChanged += this.txtPaperLongAnswer_TextChanged;
                        textBox.Enter += this.txtPaperLongAnswer_Enter;
                        List<string> list = new List<string>();
                        list.Add("");
                        this.hashUndoPaper.Add(textBox, list);
                        this.hashRedoPaper.Add(textBox, new List<string>());
                        textBox.MaxLength = 1024;
                        this.arrTBAnswers[num2] = textBox;
                        ImagePaperAnswer imagePaperAnswer = this.GetImagePaperAnswer(num2 + 1);
                        textBox.Text = imagePaperAnswer.Answer;
                        int num5 = 20;
                        bool isLongAnswer = imagePaperAnswer.IsLongAnswer;
                        if (isLongAnswer)
                        {
                            textBox.Multiline = true;
                            textBox.ScrollBars = ScrollBars.Both;
                            num += textBox.Height * (num5 - 1);
                            textBox.Height *= num5;
                            textBox.MaxLength = 32767;
                        }
                        textBox.Width = this.panelAnswer.Width - 100;
                        textBox.Top = label3.Top;
                        textBox.Left = label3.Width + 10;
                        this.panelAnswer.Controls.Add(textBox);
                        num2++;
                        num4++;
                        bool flag4 = imagePaperAnswer.PartCount > 1;
                        if (flag4)
                        {
                            Label label4 = new Label();
                            string text2 = "";
                            for (int j = 0; j < imagePaperAnswer.PartCount; j++)
                            {
                                bool flag5 = j == imagePaperAnswer.PartCount - 1;
                                if (flag5)
                                {
                                    text2 += "______";
                                }
                                else
                                {
                                    text2 += "______ ; ";
                                }
                            }
                            label4.Text = string.Concat(new object[]
                            {
                                text2,
                                " [There are ",
                                imagePaperAnswer.PartCount,
                                " parts. Parts are separated by semi-colon (;)]"
                            });
                            label4.Width = textBox.Width;
                            label4.Top = num4 * (label4.Height + 10) - 10 + num;
                            label4.Left = textBox.Left;
                            this.panelAnswer.Controls.Add(label4);
                            label3.AutoSize = true;
                            num4++;
                        }
                    }
                }
            }
        }

        // Token: 0x060000FC RID: 252 RVA: 0x0000E4D4 File Offset: 0x0000D4D4
        private void ResetImagePaper()
        {
            this.pictureBoxPaper.Image = null;
            this.lblFont.Visible = true;
            this.domainUpDown.Visible = true;
            this.lblSize.Visible = true;
            this.nudFontSize.Visible = true;
            this.LoadFont();
        }

        // Token: 0x060000FD RID: 253 RVA: 0x0000E52C File Offset: 0x0000D52C
        private ImagePaperAnswer GetImagePaperAnswer(int qNo)
        {
            List<PaperSection> sections = this.paper.ImgPaper.Sections;
            int num = 0;
            foreach (PaperSection paperSection in sections)
            {
                foreach (ImagePaperAnswer result in paperSection.Answers)
                {
                    num++;
                    bool flag = num == qNo;
                    if (flag)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        // Token: 0x060000FE RID: 254 RVA: 0x0000E5E8 File Offset: 0x0000D5E8
        private void SetImagePaperAnswer(int qNo, string ansValue)
        {
            List<PaperSection> sections = this.paper.ImgPaper.Sections;
            int num = 0;
            foreach (PaperSection paperSection in sections)
            {
                for (int i = 0; i < paperSection.Answers.Count; i++)
                {
                    num++;
                    bool flag = num == qNo;
                    if (flag)
                    {
                        paperSection.Answers[i].Answer = ansValue;
                        return;
                    }
                }
            }
        }

        // Token: 0x060000FF RID: 255 RVA: 0x0000E690 File Offset: 0x0000D690
        private void Submit2Server_SaveAtClient()
        {
            this.lastSave = this.timeLeft;
            this.lastSaveImagePaper = this.timeLeft;
            bool flag = this.timeLeft == 0 || this.finishClick;
            if (!flag)
            {
                this.sPaper = this.CreateSubmitPaper(false);
                Thread thread = new Thread(new ThreadStart(this.SaveAtServer));
                thread.Start();
                this.SaveAtClient();
            }
        }

        // Token: 0x06000100 RID: 256 RVA: 0x0000E6FC File Offset: 0x0000D6FC
        private void Set_lblSaveServerText(string text)
        {
            bool invokeRequired = this.lblSaveServer.InvokeRequired;
            if (invokeRequired)
            {
                frmEnglishExamClient.SetTextCallback method = new frmEnglishExamClient.SetTextCallback(this.Set_lblSaveServerText);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                this.lblSaveServer.Text = text;
            }
        }

        // Token: 0x06000101 RID: 257 RVA: 0x0000E74C File Offset: 0x0000D74C
        private void Set_lblMesageText(string text)
        {
            bool invokeRequired = this.lblSaveServer.InvokeRequired;
            if (invokeRequired)
            {
                frmEnglishExamClient.SetTextCallback method = new frmEnglishExamClient.SetTextCallback(this.Set_lblMesageText);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                this.lblMesage.Text = text;
            }
        }

        // Token: 0x06000102 RID: 258 RVA: 0x0000E79C File Offset: 0x0000D79C
        private void SaveAtServer()
        {
            bool flag = this.timeLeft == 0 || this.finishClick;
            if (!flag)
            {
                try
                {
                    try
                    {
                        string text = this.NotValidDNS("HN");
                        bool flag2 = text != null;
                        if (flag2)
                        {
                            text = "DNS-EOS " + text;
                            this.sPaper.SPaper.Password = this.addLog(this.sPaper.SPaper.Password, text);
                        }
                    }
                    catch
                    {
                    }
                    this.closeConnection = false;
                    IRemoteServer remoteServer = (IRemoteServer)Activator.GetObject(typeof(IRemoteServer), this.remotingURL);
                    string lblMesageText = "";
                    SubmitStatus submitStatus = remoteServer.Submit(this.sPaper, ref lblMesageText);
                    this.closeConnection = true;
                    this.Set_lblMesageText(lblMesageText);
                    bool flag3 = submitStatus == SubmitStatus.OK;
                    if (flag3)
                    {
                        this.lblSaveServer.Text = "";
                    }
                    bool flag4 = submitStatus == SubmitStatus.SUBMIT_ERROR;
                    if (flag4)
                    {
                        bool flag5 = this.timeLeft == 0 || this.finishClick;
                        if (flag5)
                        {
                            return;
                        }
                        this.Set_lblSaveServerText("Save at server failed(Server Ready)!. Please inform the supervisor and continue the exam.");
                    }
                    bool flag6 = submitStatus == SubmitStatus.EXAM_NOT_AVAILABLE;
                    if (flag6)
                    {
                        bool flag7 = this.timeLeft == 0 || this.finishClick;
                        if (!flag7)
                        {
                            this.Set_lblSaveServerText("Save at server failed!. The exam is not available.");
                        }
                    }
                }
                catch
                {
                    this.closeConnection = true;
                    bool flag8 = this.timeLeft == 0 || this.finishClick;
                    if (!flag8)
                    {
                        this.Set_lblSaveServerText("Save at server failed!. Please inform the supervisor and continue the exam.");
                    }
                }
            }
        }

        // Token: 0x06000103 RID: 259 RVA: 0x0000E950 File Offset: 0x0000D950
        private void SaveAtClient()
        {
            bool flag = this.clientType == EnumClientType.LAB_VDI;
            if (!flag)
            {
                try
                {
                    string text = this.paper.ExamCode.Trim() + "\\";
                    bool flag2 = !Directory.Exists(text);
                    if (flag2)
                    {
                        Directory.CreateDirectory(text);
                    }
                    QuestionHelper.SaveSubmitPaper(text, this.sPaper);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        // Token: 0x06000104 RID: 260 RVA: 0x0000E9D4 File Offset: 0x0000D9D4
        private void btnNextReadingM_Click(object sender, EventArgs e)
        {
            bool flag = this.paper.ReadingQuestions.Count > 0;
            if (flag)
            {
                this.indexReadingQuestion = 0;
                this.indexReading++;
                this.indexReading %= this.paper.ReadingQuestions.Count;
                this.DisplayReading(this.indexReading);
            }
        }

        // Token: 0x06000105 RID: 261 RVA: 0x0000EA3C File Offset: 0x0000DA3C
        private void lstReadingQuestionM_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = this.lstReadingQuestionM.SelectedIndex >= 0;
            if (flag)
            {
                foreach (CheckBox checkBox in this.chkReadingM)
                {
                    checkBox.Tag = null;
                    checkBox.Visible = false;
                    checkBox.Checked = false;
                }
                QuestionInListBox questionInListBox = (QuestionInListBox)this.lstReadingQuestionM.SelectedItem;
                Question question = questionInListBox.GetQuestion();
                bool flag2 = question.ImageSize != 0;
                if (flag2)
                {
                    this.panelPicReadingM.Visible = true;
                    this.btnReadingRealSize.Visible = true;
                    this.btnReadingZoomIn.Visible = true;
                    this.btnReadingZoomOut.Visible = true;
                    MemoryStream stream = new MemoryStream(question.ImageData);
                    Image image = Image.FromStream(stream);
                    this.picBoxReadingM.Image = image;
                }
                else
                {
                    this.panelPicReadingM.Visible = false;
                    this.btnReadingRealSize.Visible = false;
                    this.btnReadingZoomIn.Visible = false;
                    this.btnReadingZoomOut.Visible = false;
                    this.picBoxReadingM.Image = null;
                }
                this.oldMultipleChoice = "";
                for (int j = 0; j < question.QuestionAnswers.Count; j++)
                {
                    QuestionAnswer questionAnswer = (QuestionAnswer)question.QuestionAnswers[j];
                    this.chkReadingM[j].Visible = true;
                    this.chkReadingM[j].Tag = questionAnswer;
                    this.chkReadingM[j].Checked = questionAnswer.Selected;
                    this.oldMultipleChoice += this.chkReadingM[j].Checked.ToString();
                }
            }
        }

        // Token: 0x06000106 RID: 262 RVA: 0x0000EC0C File Offset: 0x0000DC0C
        private void chkReading_M_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool flag = checkBox.Tag == null;
            if (!flag)
            {
                QuestionAnswer questionAnswer = (QuestionAnswer)checkBox.Tag;
                questionAnswer.Selected = checkBox.Checked;
            }
        }

        // Token: 0x06000107 RID: 263 RVA: 0x0000EC4C File Offset: 0x0000DC4C
        private bool IsNeedSaveMultiple()
        {
            bool flag = this.lstReadingQuestionM.SelectedItem == null;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                QuestionInListBox questionInListBox = (QuestionInListBox)this.lstReadingQuestionM.SelectedItem;
                Question question = questionInListBox.GetQuestion();
                string text = "";
                for (int i = 0; i < question.QuestionAnswers.Count; i++)
                {
                    text += this.chkReadingM[i].Checked.ToString();
                }
                bool flag2 = this.oldMultipleChoice.Equals(text);
                result = !flag2;
            }
            return result;
        }

        // Token: 0x06000108 RID: 264 RVA: 0x0000ECF0 File Offset: 0x0000DCF0
        private void btnNextMaching_Click(object sender, EventArgs e)
        {
            bool flag = this.paper.MatchQuestions.Count > 0;
            if (flag)
            {
                this.indexMatching++;
                this.indexMatching %= this.paper.MatchQuestions.Count;
                this.DisplayMatching(this.indexMatching);
            }
        }

        // Token: 0x06000109 RID: 265 RVA: 0x0000ED50 File Offset: 0x0000DD50
        private void btnAddMSolution_Click(object sender, EventArgs e)
        {
            bool flag = this.txtNumber.Text.Trim().Equals("") || this.txtLetter.Text.Trim().Equals("");
            if (!flag)
            {
                for (int i = 0; i < this.lstAnswerMatch.Items.Count; i++)
                {
                    bool flag2 = this.lstAnswerMatch.Items[i].ToString().StartsWith(this.txtNumber.Text + " -");
                    if (flag2)
                    {
                        return;
                    }
                }
                string item = this.txtNumber.Text + " - " + this.txtLetter.Text.ToUpper();
                bool flag3 = this.lstAnswerMatch.Items.Count < this.matchingAnswerCount;
                if (flag3)
                {
                    this.lstAnswerMatch.Items.Add(item);
                    MatchQuestion matchQuestion = (MatchQuestion)this.paper.MatchQuestions[this.indexMatching];
                    matchQuestion.SudentAnswer = this.GetMatchAnswer();
                    this.Submit2Server_SaveAtClient();
                    this.txtNumber.Text = "";
                    this.txtLetter.Text = "";
                }
            }
        }

        // Token: 0x0600010A RID: 266 RVA: 0x0000EEAC File Offset: 0x0000DEAC
        private string GetMatchAnswer()
        {
            string text = "";
            for (int i = 0; i < this.lstAnswerMatch.Items.Count; i++)
            {
                text = text + this.lstAnswerMatch.Items[i].ToString().Trim() + ";";
            }
            bool flag = text.Length > 0;
            if (flag)
            {
                text = text.Remove(text.Length - 1, 1);
            }
            return text;
        }

        // Token: 0x0600010B RID: 267 RVA: 0x0000EF2C File Offset: 0x0000DF2C
        private void btnRemoveMSolution_Click(object sender, EventArgs e)
        {
            bool flag = this.lstAnswerMatch.SelectedItem != null;
            if (flag)
            {
                this.lstAnswerMatch.Items.Remove(this.lstAnswerMatch.SelectedItem);
                MatchQuestion matchQuestion = (MatchQuestion)this.paper.MatchQuestions[this.indexMatching];
                matchQuestion.SudentAnswer = this.GetMatchAnswer();
                this.Submit2Server_SaveAtClient();
            }
        }

        // Token: 0x0600010C RID: 268 RVA: 0x0000EF9C File Offset: 0x0000DF9C
        private void btnNextGrammar_Click(object sender, EventArgs e)
        {
            bool flag = this.paper.GrammarQuestions.Count > 0;
            if (flag)
            {
                bool flag2 = this.IsNeedSaveGrammar();
                if (flag2)
                {
                    this.Submit2Server_SaveAtClient();
                }
                this.indexGrammar++;
                this.indexGrammar %= this.paper.GrammarQuestions.Count;
                this.DisplayGrammar(this.indexGrammar);
            }
        }

        // Token: 0x0600010D RID: 269 RVA: 0x0000F010 File Offset: 0x0000E010
        private bool IsNeedSaveGrammar()
        {
            string text = "";
            foreach (CheckBox checkBox in this.chkGrammar)
            {
                bool visible = checkBox.Visible;
                if (visible)
                {
                    text += checkBox.Checked.ToString();
                }
            }
            bool flag = this.oldGrammarChoice.Equals(text);
            return !flag;
        }

        // Token: 0x0600010E RID: 270 RVA: 0x0000F084 File Offset: 0x0000E084
        private void chkGrammar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool flag = checkBox.Tag == null;
            if (!flag)
            {
                QuestionAnswer questionAnswer = (QuestionAnswer)checkBox.Tag;
                questionAnswer.Selected = checkBox.Checked;
                Question q = (Question)this.paper.GrammarQuestions[this.indexGrammar];
                bool flag2 = this.IsQuestionAnswered(q);
                if (flag2)
                {
                    this.SetButtonColor(this.indexGrammar + 1, Color.GreenYellow);
                }
                else
                {
                    this.SetButtonColor(this.indexGrammar + 1, this.BackColor);
                }
            }
        }

        // Token: 0x0600010F RID: 271 RVA: 0x0000F11C File Offset: 0x0000E11C
        private void btnNextIndiMistake_Click(object sender, EventArgs e)
        {
            bool flag = this.paper.IndicateMQuestions.Count > 0;
            if (flag)
            {
                bool flag2 = this.IsNeedSaveIndiMistake();
                if (flag2)
                {
                    this.Submit2Server_SaveAtClient();
                }
                this.indexIndicateMistake++;
                this.indexIndicateMistake %= this.paper.IndicateMQuestions.Count;
                this.DisplayIndiMistake(this.indexIndicateMistake);
            }
        }

        // Token: 0x06000110 RID: 272 RVA: 0x0000F190 File Offset: 0x0000E190
        private bool IsNeedSaveIndiMistake()
        {
            string text = "";
            foreach (CheckBox checkBox in this.chkIndiMistake)
            {
                bool visible = checkBox.Visible;
                if (visible)
                {
                    text += checkBox.Checked.ToString();
                }
            }
            bool flag = this.oldIndiMistakeChoice.Equals(text);
            return !flag;
        }

        // Token: 0x06000111 RID: 273 RVA: 0x0000F204 File Offset: 0x0000E204
        private void chkIndiMistake_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool flag = checkBox.Tag == null;
            if (!flag)
            {
                QuestionAnswer questionAnswer = (QuestionAnswer)checkBox.Tag;
                questionAnswer.Selected = checkBox.Checked;
                Question q = (Question)this.paper.IndicateMQuestions[this.indexIndicateMistake];
                bool flag2 = this.IsQuestionAnswered(q);
                if (flag2)
                {
                    this.SetButtonColor(this.indexIndicateMistake + 1, Color.GreenYellow);
                }
                else
                {
                    this.SetButtonColor(this.indexIndicateMistake + 1, this.BackColor);
                }
            }
        }

        // Token: 0x06000112 RID: 274 RVA: 0x0000F29C File Offset: 0x0000E29C
        private bool IsQuestionAnswered(Question q)
        {
            foreach (object obj in q.QuestionAnswers)
            {
                QuestionAnswer questionAnswer = (QuestionAnswer)obj;
                bool selected = questionAnswer.Selected;
                if (selected)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000113 RID: 275 RVA: 0x0000F30C File Offset: 0x0000E30C
        private void tabControlQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelQuestionList.Visible = false;
            this.panelQuestionList.Controls.Clear();
            bool flag = this.tabControlQuestion.SelectedTab == this.tabPageReadingM;
            if (flag)
            {
                Passage passage = (Passage)this.paper.ReadingQuestions[this.indexReading];
                float num = 0f;
                foreach (object obj in passage.PassageQuestions)
                {
                    Question question = (Question)obj;
                    num += question.Mark;
                }
                this.lblMark.Text = num.ToString();
                this.timerTopMost.Enabled = true;
                this.DisableNonFunctionKeys();
            }
            bool flag2 = this.tabControlQuestion.SelectedTab == this.tabPageGrammar;
            if (flag2)
            {
                Question question2 = (Question)this.paper.GrammarQuestions[this.indexGrammar];
                this.lblMark.Text = question2.Mark.ToString();
                this.timerTopMost.Enabled = true;
                this.DisableNonFunctionKeys();
                this.panelQuestionList.Visible = true;
                this.AddQuestionButon(this.paper.GrammarQuestions.Count);
                int num2 = 0;
                foreach (object obj2 in this.paper.GrammarQuestions)
                {
                    Question q = (Question)obj2;
                    num2++;
                    bool flag3 = this.IsQuestionAnswered(q);
                    if (flag3)
                    {
                        this.SetButtonColor(num2, Color.GreenYellow);
                    }
                }
            }
            bool flag4 = this.tabControlQuestion.SelectedTab == this.tabPageMatching;
            if (flag4)
            {
                MatchQuestion matchQuestion = (MatchQuestion)this.paper.MatchQuestions[this.indexMatching];
                this.lblMark.Text = matchQuestion.Mark.ToString();
                this.timerTopMost.Enabled = true;
                this.EnableNonFunctionKeys();
            }
            bool flag5 = this.tabControlQuestion.SelectedTab == this.tabPageIndicateMistake;
            if (flag5)
            {
                Question question3 = (Question)this.paper.IndicateMQuestions[this.indexIndicateMistake];
                this.lblMark.Text = question3.Mark.ToString();
                this.timerTopMost.Enabled = true;
                this.DisableNonFunctionKeys();
                this.panelQuestionList.Visible = true;
                this.AddQuestionButon(this.paper.IndicateMQuestions.Count);
                int num3 = 0;
                foreach (object obj3 in this.paper.IndicateMQuestions)
                {
                    Question q2 = (Question)obj3;
                    num3++;
                    bool flag6 = this.IsQuestionAnswered(q2);
                    if (flag6)
                    {
                        this.SetButtonColor(num3, Color.GreenYellow);
                    }
                }
            }
            bool flag7 = this.tabControlQuestion.SelectedTab == this.tabPageFillBlank;
            if (flag7)
            {
                float num4 = 0f;
                foreach (object obj4 in this.paper.FillBlankQuestions)
                {
                    Question question4 = (Question)obj4;
                    num4 += question4.Mark;
                }
                this.lblMark.Text = num4.ToString();
                Question question5 = (Question)this.paper.FillBlankQuestions[this.indexFill];
                bool flag8 = question5.QType == QuestionType.FILL_BLANK_EMPTY;
                if (flag8)
                {
                    this.timerTopMost.Enabled = true;
                    this.EnableNonFunctionKeys();
                }
                else
                {
                    this.DisableNonFunctionKeys();
                    this.timerTopMost.Enabled = false;
                }
            }
        }

        // Token: 0x06000114 RID: 276 RVA: 0x0000F760 File Offset: 0x0000E760
        private SubmitPaper CreateSubmitPaper(bool finish)
        {
            SubmitPaper result;
            try
            {
                bool flag = this.paper.ImgPaper != null;
                if (flag)
                {
                    this.UpdateAnswerImagePaper();
                }
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, this.paper);
                memoryStream.Seek(0L, SeekOrigin.Begin);
                Paper paper = (Paper)binaryFormatter.Deserialize(memoryStream);
                bool flag2 = paper.ReadingQuestions != null;
                if (flag2)
                {
                    foreach (object obj in paper.ReadingQuestions)
                    {
                        Passage passage = (Passage)obj;
                        passage.Preapare2Submit();
                    }
                }
                bool flag3 = paper.MatchQuestions != null;
                if (flag3)
                {
                    foreach (object obj2 in paper.MatchQuestions)
                    {
                        MatchQuestion matchQuestion = (MatchQuestion)obj2;
                        matchQuestion.Preapare2Submit();
                    }
                }
                bool flag4 = paper.GrammarQuestions != null;
                if (flag4)
                {
                    foreach (object obj3 in paper.GrammarQuestions)
                    {
                        Question question = (Question)obj3;
                        question.Preapare2Submit();
                    }
                }
                bool flag5 = paper.IndicateMQuestions != null;
                if (flag5)
                {
                    foreach (object obj4 in paper.IndicateMQuestions)
                    {
                        Question question2 = (Question)obj4;
                        question2.Preapare2Submit();
                    }
                }
                bool flag6 = paper.FillBlankQuestions != null;
                if (flag6)
                {
                    foreach (object obj5 in paper.FillBlankQuestions)
                    {
                        Question question3 = (Question)obj5;
                        question3.Preapare2Submit();
                    }
                }
                bool flag7 = paper.EssayQuestion != null;
                if (flag7)
                {
                    paper.EssayQuestion.Preapare2Submit();
                    paper.EssayQuestion.Development = this.txtWrittingEssay.Text;
                }
                bool flag8 = paper.ImgPaper != null;
                if (flag8)
                {
                    paper.ImgPaper.Preapare2Submit();
                }
                paper.ListAudio = null;
                paper.OneSecSilence = null;
                SubmitPaper submitPaper = new SubmitPaper();
                submitPaper.LoginId = this.loginId;
                submitPaper.SPaper = paper;
                submitPaper.TimeLeft = this.timeLeft;
                submitPaper.IndexG = this.indexGrammar;
                submitPaper.IndexReading = this.indexReading;
                submitPaper.IndexIndiM = this.indexIndicateMistake;
                submitPaper.IndexMatch = this.indexMatching;
                submitPaper.TabIndex = this.tabControlQuestion.SelectedIndex;
                submitPaper.IndexFill = this.indexFill;
                submitPaper.Finish = finish;
                submitPaper.ID = EncryptSupport.GetMD5(this.examData.RegData.Login + this.examData.RegData.Password);
                List<DesktopWindow> desktopWindows = User32Helper.GetDesktopWindows();
                List<string> list = new List<string>();
                bool flag9 = this.sPaper != null;
                if (flag9)
                {
                    submitPaper.SPaper.Password = this.sPaper.SPaper.Password;
                }
                foreach (DesktopWindow desktopWindow in desktopWindows)
                {
                    bool isVisible = desktopWindow.IsVisible;
                    if (isVisible)
                    {
                        submitPaper.SPaper.Password = this.addLog(submitPaper.SPaper.Password, desktopWindow.Title);
                    }
                }
                result = submitPaper;
            }
            catch
            {
                result = null;
            }
            return result;
        }

        // Token: 0x06000115 RID: 277 RVA: 0x0000FBE0 File Offset: 0x0000EBE0
        private string addLog(string logStr, string title)
        {
            try
            {
                bool flag = title == null || title.Trim().Equals("");
                if (flag)
                {
                    return logStr;
                }
                title = title.Replace("[", "|");
                title = title.Replace("]", "|");
                bool flag2 = logStr == null || logStr.Equals("");
                if (flag2)
                {
                    logStr = title + "[1]";
                }
                else
                {
                    char[] separator = new char[]
                    {
                        ';'
                    };
                    string[] array = logStr.Split(separator);
                    bool flag3 = true;
                    foreach (string text in array)
                    {
                        string text2 = text.Substring(0, text.IndexOf("["));
                        bool flag4 = text2.Equals(title);
                        if (flag4)
                        {
                            int num = text.IndexOf('[');
                            int num2 = text.IndexOf("]");
                            string s = text.Substring(num + 1, num2 - num - 1);
                            int num3 = 0;
                            bool flag5 = int.TryParse(s, out num3);
                            if (flag5)
                            {
                                string newValue = text.Substring(0, num + 1) + (num3 + 1) + "]";
                                logStr = logStr.Replace(text, newValue);
                                flag3 = false;
                                break;
                            }
                        }
                    }
                    bool flag6 = flag3;
                    if (flag6)
                    {
                        logStr = logStr + ";" + title + "[1]";
                    }
                }
            }
            catch
            {
            }
            return logStr;
        }

        // Token: 0x06000116 RID: 278 RVA: 0x0000FD7C File Offset: 0x0000ED7C
        private void btnNextQuestionM_Click(object sender, EventArgs e)
        {
            bool flag = this.lstReadingQuestionM.Items.Count > 0;
            if (flag)
            {
                bool flag2 = this.IsNeedSaveMultiple();
                if (flag2)
                {
                    this.Submit2Server_SaveAtClient();
                }
                this.indexReadingQuestion = this.lstReadingQuestionM.SelectedIndex;
                this.indexReadingQuestion++;
                this.indexReadingQuestion %= this.lstReadingQuestionM.Items.Count;
                this.lstReadingQuestionM.SelectedIndex = this.indexReadingQuestion;
            }
        }

        // Token: 0x06000117 RID: 279 RVA: 0x0000FE04 File Offset: 0x0000EE04
        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.EnableAllKeyBoard();
            this.EnableMouse();
            bool flag = this.timeLeft != 0;
            if (flag)
            {
                bool flag2 = !this.chbWantFinish.Checked;
                if (flag2)
                {
                    return;
                }
                bool flag3 = !this.chbWantFinishTop.Checked;
                if (flag3)
                {
                    return;
                }
            }
            this.lblSaveServer.Text = "";
            this.finishClick = true;
            this.chbWantFinish.Enabled = false;
            this.chbWantFinishTop.Enabled = false;
            this.FinishExam();
            this.tabControlQuestion.Visible = false;
            this.panelQuestionList.Visible = false;
            bool flag4 = this.waveOut != null && this.waveOut.PlaybackState > PlaybackState.Stopped;
            if (flag4)
            {
                this.waveOut.Stop();
            }
        }

        // Token: 0x06000118 RID: 280 RVA: 0x0000FED8 File Offset: 0x0000EED8
        private void SendAllMissScreenImages()
        {
            int i = 3;
            bool flag = this.listMissScreenImages.Count > 0;
            if (flag)
            {
                while (i > 0)
                {
                    try
                    {
                        IRemoteMonitorServer remoteMonitorServer = (IRemoteMonitorServer)Activator.GetObject(typeof(IRemoteMonitorServer), this.monitorURL);
                        while (this.listMissScreenImages.Count > 0)
                        {
                            byte[] array = (byte[])this.listMissScreenImages[0];
                            this.listMissScreenImages.RemoveAt(0);
                            IRemoteMonitorServer remoteMonitorServer2 = remoteMonitorServer;
                            byte[] img = array;
                            int num = this.imageIndex;
                            this.imageIndex = num + 1;
                            this.captureScreenInterval = remoteMonitorServer2.SaveScreenImage(img, num, this.examData.RegData.ExamCode, this.loginId);
                        }
                        i = 0;
                    }
                    catch
                    {
                        i--;
                    }
                }
            }
            bool flag2 = this.exitButtonClicked;
            if (flag2)
            {
                Application.Exit();
            }
        }

        // Token: 0x06000119 RID: 281 RVA: 0x0000FFD0 File Offset: 0x0000EFD0
        private void SendOneMissScreenImage()
        {
            bool flag = this.listMissScreenImages.Count > 0;
            if (flag)
            {
                try
                {
                    IRemoteMonitorServer remoteMonitorServer = (IRemoteMonitorServer)Activator.GetObject(typeof(IRemoteMonitorServer), this.monitorURL);
                    byte[] array = (byte[])this.listMissScreenImages[0];
                    IRemoteMonitorServer remoteMonitorServer2 = remoteMonitorServer;
                    byte[] img = array;
                    int num = this.imageIndex;
                    this.imageIndex = num + 1;
                    this.captureScreenInterval = remoteMonitorServer2.SaveScreenImage(img, num, this.examData.RegData.ExamCode, this.loginId);
                    ArrayList obj = this.listMissScreenImages;
                    lock (obj)
                    {
                        this.listMissScreenImages.RemoveAt(0);
                    }
                }
                catch
                {
                }
            }
        }

        // Token: 0x0600011A RID: 282 RVA: 0x000100A8 File Offset: 0x0000F0A8
        private bool SaveAtServerWhenFinish()
        {
            this.lblSaveServer.Text = "";
            bool result;
            try
            {
                IRemoteServer remoteServer = (IRemoteServer)Activator.GetObject(typeof(IRemoteServer), this.remotingURL);
                string text = "";
                bool flag = remoteServer.Submit(this.sPaper, ref text) == SubmitStatus.OK;
                if (flag)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0600011B RID: 283 RVA: 0x00010120 File Offset: 0x0000F120
        private void FinishExam()
        {
            this.sPaper = this.CreateSubmitPaper(true);
            this.SaveAtClient();
            bool flag = !this.finishClick;
            if (flag)
            {
                this.timerCountDown.Enabled = false;
                this.timerTopMost.Enabled = false;
                this.tabControlQuestion.TabPages.Remove(this.tabPageGrammar);
                this.tabControlQuestion.TabPages.Remove(this.tabPageIndicateMistake);
                this.tabControlQuestion.TabPages.Remove(this.tabPageMatching);
                this.tabControlQuestion.TabPages.Remove(this.tabPageReadingM);
                this.tabControlQuestion.TabPages.Remove(this.tabPageFillBlank);
                this.nudFontSize.Enabled = false;
                this.btnFinish.Enabled = false;
                this.lblOver.Text = "Examination Over!";
            }
            bool flag2 = this.SaveAtServerWhenFinish();
            bool flag3 = flag2;
            if (flag3)
            {
                this.btnFinish.Enabled = false;
                this.btnFinishTop.Enabled = false;
                this.btnExit.Enabled = true;
                this.lblSaveServer.Text = "Exam finished successfully.";
            }
            else
            {
                this.btnFinish.Enabled = true;
                this.btnFinishTop.Enabled = true;
                this.btnExit.Enabled = false;
                this.lblSaveServer.Text = "Save at server failed! Check internet connection then click Finish button again.";
            }
            base.TopMost = false;
            base.WindowState = FormWindowState.Normal;
            base.ControlBox = true;
            base.MinimizeBox = true;
            base.MaximizeBox = true;
        }

        // Token: 0x0600011C RID: 284 RVA: 0x000102B8 File Offset: 0x0000F2B8
        private void chbWantFinish_CheckedChanged(object sender, EventArgs e)
        {
            this.btnFinish.Enabled = this.chbWantFinish.Checked;
            this.btnFinishTop.Enabled = this.chbWantFinish.Checked;
            this.chbWantFinishTop.Checked = this.chbWantFinish.Checked;
        }

        // Token: 0x0600011D RID: 285 RVA: 0x0001030C File Offset: 0x0000F30C
        private void tabPageMatching_SizeChanged(object sender, EventArgs e)
        {
            int num = this.tabControlQuestion.Width;
            int num2 = 10;
            num = num - 5 * num2 - this.lstAnswerMatch.Width;
            this.panelA.Left = num2;
            this.panelA.Width = num / 2;
            this.lstAnswerMatch.Left = num2 + this.panelA.Width + num2;
            this.lblAnswerMatch.Left = this.lstAnswerMatch.Left;
            this.panelB.Left = num2 + this.panelA.Width + num2 + this.lstAnswerMatch.Width + num2;
            this.panelB.Width = num / 2;
            this.txtNumber.Left = num2 + this.panelA.Width - this.txtNumber.Width;
            this.lblNumber.Left = this.txtNumber.Left;
            this.txtLetter.Left = this.panelB.Left;
            this.lblLetter.Left = this.txtLetter.Left;
            this.btnAddMSolution.Left = this.tabControlQuestion.Width / 2 - this.btnAddMSolution.Width - num2;
            this.btnRemoveMSolution.Left = this.btnAddMSolution.Left + this.btnAddMSolution.Width + num2;
        }

        // Token: 0x0600011E RID: 286 RVA: 0x00010478 File Offset: 0x0000F478
        private void nudFontSize_ValueChanged(object sender, EventArgs e)
        {
            Font font = new Font(this.domainUpDown.Text, (float)this.nudFontSize.Value);
            this.lblColumnA.Font = font;
            this.lblColumnB.Font = font;
            this.lblMC_Text.Font = font;
            this.lblIndicateMistake.Font = font;
            this.lblReadingContent.Font = font;
            font = new Font(this.txtWrittingEssay.Font.Name, (float)this.nudFontSize.Value);
            this.txtWrittingEssay.Font = font;
            foreach (object obj in this.panelAnswer.Controls)
            {
                Control control = (Control)obj;
                bool flag = control is TextBox;
                if (flag)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Font = font;
                }
            }
            this.UpdateFontOnImageDisplay();
        }

        // Token: 0x0600011F RID: 287 RVA: 0x00010598 File Offset: 0x0000F598
        private void UpdateFontOnImageDisplay()
        {
            bool flag = this.tabControlQuestion.Contains(this.tabPageIndicateMistake);
            if (flag)
            {
                this.DisplayIndiMistake(this.indexIndicateMistake);
            }
            bool flag2 = this.tabControlQuestion.Contains(this.tabPageGrammar);
            if (flag2)
            {
                this.DisplayGrammar(this.indexGrammar);
            }
            bool flag3 = this.tabControlQuestion.Contains(this.tabPageReadingM);
            if (flag3)
            {
                this.DisplayReading(this.indexReading);
            }
            bool flag4 = this.tabControlQuestion.Contains(this.tabPageMatching);
            if (flag4)
            {
                this.DisplayMatching(this.indexMatching);
            }
        }

        // Token: 0x06000120 RID: 288 RVA: 0x00010630 File Offset: 0x0000F630
        private ArrayList GetRandomFromList(ArrayList list, int n)
        {
            Random random = new Random((int)(DateTime.Now.Ticks % 2147483647L));
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < n; i++)
            {
                int index = random.Next(list.Count) % list.Count;
                arrayList.Add(list[index]);
                list.RemoveAt(index);
                list.TrimToSize();
            }
            return arrayList;
        }

        // Token: 0x06000121 RID: 289 RVA: 0x000106B0 File Offset: 0x0000F6B0
        private void Shuffle()
        {
            bool flag = this.paper.EssayQuestion != null;
            if (!flag)
            {
                bool isShuffleReading = this.paper.IsShuffleReading;
                if (isShuffleReading)
                {
                    this.paper.ReadingQuestions = this.ShuffleList(this.paper.ReadingQuestions);
                }
                foreach (object obj in this.paper.ReadingQuestions)
                {
                    Passage passage = (Passage)obj;
                    bool isShuffleReading2 = this.paper.IsShuffleReading;
                    if (isShuffleReading2)
                    {
                        passage.PassageQuestions = this.ShuffleList(passage.PassageQuestions);
                    }
                    foreach (object obj2 in passage.PassageQuestions)
                    {
                        Question question = (Question)obj2;
                        bool flag2 = !question.Lock;
                        if (flag2)
                        {
                            question.QuestionAnswers = this.ShuffleList(question.QuestionAnswers);
                        }
                    }
                }
                bool flag3 = this.paper.QD != null;
                if (flag3)
                {
                    bool flag4 = this.paper.GrammarQuestions.Count > this.paper.QD.MultipleChoices;
                    if (flag4)
                    {
                        Hashtable hashtable = new Hashtable();
                        foreach (object obj3 in this.paper.GrammarQuestions)
                        {
                            Question question2 = (Question)obj3;
                            bool flag5 = hashtable.ContainsKey(question2.ChapterId);
                            if (flag5)
                            {
                                ((ArrayList)hashtable[question2.ChapterId]).Add(question2);
                            }
                            else
                            {
                                ArrayList arrayList = new ArrayList();
                                arrayList.Add(question2);
                                hashtable[question2.ChapterId] = arrayList;
                            }
                        }
                        float num = (float)this.paper.QD.MultipleChoices / (float)this.paper.GrammarQuestions.Count;
                        int num2 = 0;
                        ArrayList arrayList2 = new ArrayList();
                        ArrayList arrayList3 = new ArrayList();
                        foreach (object obj4 in hashtable.Keys)
                        {
                            int num3 = (int)obj4;
                            int num4 = (int)(num * (float)((ArrayList)hashtable[num3]).Count);
                            num2 += num4;
                            ArrayList randomFromList = this.GetRandomFromList((ArrayList)hashtable[num3], num4);
                            arrayList2.AddRange(randomFromList);
                            arrayList3.AddRange((ArrayList)hashtable[num3]);
                        }
                        int n = this.paper.QD.MultipleChoices - num2;
                        arrayList2.AddRange(this.GetRandomFromList(arrayList3, n));
                        this.paper.Mark = this.paper.Mark - (float)(this.paper.GrammarQuestions.Count - arrayList2.Count);
                        this.paper.GrammarQuestions = arrayList2;
                    }
                }
                bool isShuffleGrammer = this.paper.IsShuffleGrammer;
                if (isShuffleGrammer)
                {
                    this.paper.GrammarQuestions = this.ShuffleList(this.paper.GrammarQuestions);
                }
                foreach (object obj5 in this.paper.GrammarQuestions)
                {
                    Question question3 = (Question)obj5;
                    bool flag6 = !question3.Lock;
                    if (flag6)
                    {
                        question3.QuestionAnswers = this.ShuffleList(question3.QuestionAnswers);
                    }
                }
                bool isShuffleIndicateMistake = this.paper.IsShuffleIndicateMistake;
                if (isShuffleIndicateMistake)
                {
                    this.paper.IndicateMQuestions = this.ShuffleList(this.paper.IndicateMQuestions);
                }
                foreach (object obj6 in this.paper.IndicateMQuestions)
                {
                    Question question4 = (Question)obj6;
                    bool flag7 = !question4.Lock;
                    if (flag7)
                    {
                        question4.QuestionAnswers = this.ShuffleList(question4.QuestionAnswers);
                    }
                }
                bool isShuffleFillBlank = this.paper.IsShuffleFillBlank;
                if (isShuffleFillBlank)
                {
                    this.paper.FillBlankQuestions = this.ShuffleList(this.paper.FillBlankQuestions);
                }
            }
        }

        // Token: 0x06000122 RID: 290 RVA: 0x00010BC8 File Offset: 0x0000FBC8
        private void btnExit_Click(object sender, EventArgs e)
        {
            bool flag = this.examData == null;
            if (flag)
            {
                base.Close();
            }
            else
            {
                this.exitButtonClicked = true;
                bool flag2 = this.listMissScreenImages.Count > 0;
                if (flag2)
                {
                    base.Hide();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // Token: 0x06000123 RID: 291 RVA: 0x00010C18 File Offset: 0x0000FC18
        private void frmEnglishExamClient_SizeChanged(object sender, EventArgs e)
        {
            bool topMost = base.TopMost;
            if (topMost)
            {
                base.WindowState = FormWindowState.Maximized;
            }
        }

        // Token: 0x06000124 RID: 292 RVA: 0x00010C3C File Offset: 0x0000FC3C
        private void btnNextFillBlank_Click(object sender, EventArgs e)
        {
            bool flag = this.paper.FillBlankQuestions.Count > 0;
            if (flag)
            {
                bool flag2 = this.txtList != null;
                if (flag2)
                {
                    Question question = (Question)this.paper.FillBlankQuestions[this.indexFill];
                    for (int i = 0; i < this.txtList.Count; i++)
                    {
                        QuestionAnswer questionAnswer = (QuestionAnswer)question.QuestionAnswers[i];
                        questionAnswer.Text = ((TextBox)this.txtList[i]).Text;
                    }
                }
                bool flag3 = this.cboList != null;
                if (flag3)
                {
                    Question question2 = (Question)this.paper.FillBlankQuestions[this.indexFill];
                    for (int j = 0; j < this.cboList.Count; j++)
                    {
                        QuestionAnswer questionAnswer2 = (QuestionAnswer)question2.QuestionAnswers[j];
                        questionAnswer2.Text = ((ComboBox)this.cboList[j]).Text;
                    }
                }
                bool flag4 = this.IsNeedSaveFillBlank();
                if (flag4)
                {
                    this.Submit2Server_SaveAtClient();
                }
                this.indexFill++;
                this.indexFill %= this.paper.FillBlankQuestions.Count;
                this.DisplayFillBlankQuestion(this.indexFill);
            }
        }

        // Token: 0x06000125 RID: 293 RVA: 0x00010DB4 File Offset: 0x0000FDB4
        private string[] GetFilledWord(string qLine)
        {
            string fillBlank_Pattern = QuestionHelper.fillBlank_Pattern;
            Regex regex = new Regex(fillBlank_Pattern);
            MatchCollection matchCollection = regex.Matches(qLine);
            string[] array = new string[matchCollection.Count];
            for (int i = 0; i < matchCollection.Count; i++)
            {
                string text = matchCollection[i].Value.Remove(0, 1);
                text = text.Remove(text.Length - 1, 1);
                array[i] = text.Trim().ToLower();
            }
            Array.Sort<string>(array);
            return array;
        }

        // Token: 0x06000126 RID: 294 RVA: 0x00010E50 File Offset: 0x0000FE50
        private string[] GetFilledWord_Group(string qLine, int groupNo)
        {
            string fillBlank_Pattern = QuestionHelper.fillBlank_Pattern;
            Regex regex = new Regex(fillBlank_Pattern);
            MatchCollection matchCollection = regex.Matches(qLine);
            string text = matchCollection[groupNo].Value.Remove(0, 1);
            text = text.Trim().Remove(0, 1);
            text = text.Remove(text.Length - 1, 1);
            text = text.Trim();
            text = text.ToLower();
            char[] separator = new char[]
            {
                '~'
            };
            string[] array = text.Split(separator);
            bool flag = array == null;
            string[] result;
            if (flag)
            {
                result = null;
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array[i].Trim();
                    bool flag2 = array[i].StartsWith("=");
                    if (flag2)
                    {
                        array[i] = array[i].Remove(0, 1);
                    }
                }
                Array.Sort<string>(array);
                result = array;
            }
            return result;
        }

        // Token: 0x06000127 RID: 295 RVA: 0x00010F44 File Offset: 0x0000FF44
        private void ans_TextChanged(object sender, EventArgs e)
        {
            bool flag = sender is TextBox;
            if (flag)
            {
                TextBox textBox = (TextBox)sender;
                QuestionAnswer questionAnswer = (QuestionAnswer)textBox.Tag;
                questionAnswer.Text = textBox.Text;
            }
            bool flag2 = sender is ComboBox;
            if (flag2)
            {
                ComboBox comboBox = (ComboBox)sender;
                QuestionAnswer questionAnswer2 = (QuestionAnswer)comboBox.Tag;
                questionAnswer2.Text = comboBox.Text;
            }
        }

        // Token: 0x06000128 RID: 296 RVA: 0x00010FB8 File Offset: 0x0000FFB8
        private void ans_Leave(object sender, EventArgs e)
        {
            bool flag = this.IsNeedSaveFillBlank();
            if (flag)
            {
                this.Submit2Server_SaveAtClient();
            }
        }

        // Token: 0x06000129 RID: 297 RVA: 0x00010FDC File Offset: 0x0000FFDC
        private bool IsNeedSaveFillBlank()
        {
            string text = "";
            bool flag = this.txtList != null;
            if (flag)
            {
                foreach (object obj in this.txtList)
                {
                    TextBox textBox = (TextBox)obj;
                    text += textBox.Text;
                }
            }
            bool flag2 = this.cboList != null;
            if (flag2)
            {
                foreach (object obj2 in this.cboList)
                {
                    ComboBox comboBox = (ComboBox)obj2;
                    text += comboBox.Text;
                }
            }
            bool flag3 = this.oldFillBlankAnswer.Equals(text);
            return !flag3;
        }

        // Token: 0x0600012A RID: 298 RVA: 0x000110E0 File Offset: 0x000100E0
        private void txtFill_Validated(object sender, EventArgs e)
        {
            bool flag = !(sender is TextBox);
            if (!flag)
            {
                TextBox textBox = (TextBox)sender;
                bool flag2 = textBox.Tag != null;
                if (flag2)
                {
                    QuestionAnswer questionAnswer = (QuestionAnswer)textBox.Tag;
                    textBox.Text = QuestionHelper.RemoveSpaces(textBox.Text);
                    questionAnswer.Text = textBox.Text;
                }
            }
        }

        // Token: 0x0600012B RID: 299 RVA: 0x00011144 File Offset: 0x00010144
        private void txtReadingM_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            int x = this.btnNextReadingM.Left + this.tabControlQuestion.Left;
            int y = this.btnNextReadingM.Top + this.tabControlQuestion.Top;
            Cursor.Position = new Point(x, y);
        }

        // Token: 0x0600012C RID: 300 RVA: 0x000111A8 File Offset: 0x000101A8
        private void btnShowExam_Click(object sender, EventArgs e)
        {
            bool flag = this.txtOpenCode.Text.Trim().Equals(this.paper.ListenCode);
            if (flag)
            {
                this.ControlManager();
                this.Shuffle();
                this.RemoveTabPages();
                this.DisplayReading(this.indexReading);
                this.DisplayMatching(this.indexMatching);
                this.DisplayGrammar(this.indexGrammar);
                this.DisplayIndiMistake(this.indexIndicateMistake);
                this.DisplayFillBlankQuestion(this.indexFill);
                this.DisplayEssay();
                this.DisplayImagePaper();
                this.txtOpenCode.Enabled = false;
                this.btnShowExam.Enabled = false;
                this.TimerTopMost_FirstDisplay();
                this.DisableAllKeyBoard();
                bool flag2 = this.paper.ListAudio != null;
                if (flag2)
                {
                    byte[] array = this.CreateAudioData();
                    bool flag3 = array != null && array.Length != 0;
                    if (flag3)
                    {
                        this.PlayFromBuf(array, 0);
                    }
                }
                this.showQuestionClicked = true;
                this.chbWantFinish.Enabled = (this.chbWantFinishTop.Enabled = true);
            }
            else
            {
                MessageBox.Show("Open Code is invalid!", "Show Question", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Token: 0x0600012D RID: 301 RVA: 0x000112DC File Offset: 0x000102DC
        public void PlayFromBuf(byte[] audioData, int pos)
        {
            Stream inputStream = new MemoryStream(audioData);
            this.reader = new Mp3FileReader(inputStream);
            bool flag = (double)pos < this.reader.TotalTime.TotalSeconds;
            if (flag)
            {
                this.waveOut = new WaveOut();
                this.waveOut.Init(this.reader);
                this.reader.Position = (long)(this.reader.WaveFormat.AverageBytesPerSecond * pos);
                this.waveOut.Volume = (float)this.nudVol.Value * 0.1f;
                this.waveOut.Play();
            }
        }

        // Token: 0x0600012E RID: 302 RVA: 0x00011388 File Offset: 0x00010388
        private void CloseApps()
        {
            bool flag = this.isDistanceLearning;
            if (!flag)
            {
                bool flag2 = EnumClientType.DEVELOPPING == this.clientType;
                if (!flag2)
                {
                    bool flag3 = !this.examData.ServerInfomation.Public_IP.Trim().Equals("");
                    if (!flag3)
                    {
                        while (this.timerCountDown.Enabled)
                        {
                            try
                            {
                                foreach (Process process in Process.GetProcesses())
                                {
                                    bool flag4 = process.MainWindowTitle.Equals("EOS Login Form");
                                    if (!flag4)
                                    {
                                        bool flag5 = !process.MainWindowTitle.Equals("");
                                        if (flag5)
                                        {
                                            process.Kill();
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
        }

        // Token: 0x0600012F RID: 303 RVA: 0x0001147C File Offset: 0x0001047C
        private void timerTopMost_Tick(object sender, EventArgs e)
        {
            bool flag = EnumClientType.DEVELOPPING == this.clientType;
            if (!flag)
            {
                bool flag2 = this.paper.TestType == TestTypeEnum.NOT_WRITING || this.paper.TestType == TestTypeEnum.WRITING_EN;
                if (flag2)
                {
                    base.TopMost = true;
                }
                try
                {
                    Clipboard.Clear();
                }
                catch
                {
                }
            }
        }

        // Token: 0x06000130 RID: 304 RVA: 0x000114E8 File Offset: 0x000104E8
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string value = e.KeyChar.ToString();
            string text = "0123456789\b";
            bool flag = text.IndexOf(value) >= 0;
            if (flag)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        // Token: 0x06000131 RID: 305 RVA: 0x00011530 File Offset: 0x00010530
        private void txtLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = e.KeyChar.ToString();
            string text2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\b";
            bool flag = text2.IndexOf(text.ToUpper()) >= 0;
            if (flag)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        // Token: 0x06000132 RID: 306 RVA: 0x00011580 File Offset: 0x00010580
        private void run()
        {
            bool flag = EnumClientType.DEVELOPPING == this.clientType;
            if (!flag)
            {
                while (!this.finishClick)
                {
                    bool flag2 = this.exitButtonClicked;
                    if (flag2)
                    {
                        break;
                    }
                    bool flag3 = this.closeConnection && !this.keepConnection;
                    if (flag3)
                    {
                        try
                        {
                            string[] array = DisconnectWrapper.Connections(DisconnectWrapper.ConnectionState.Established);
                            foreach (string connectionstring in array)
                            {
                                DisconnectWrapper.CloseConnection(connectionstring);
                            }
                            Thread.Sleep(this.closeTCPInterval);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        // Token: 0x06000133 RID: 307 RVA: 0x0001162C File Offset: 0x0001062C
        private void StartCloseTCPConnectionsThread()
        {
            bool flag = this.isDistanceLearning;
            if (!flag)
            {
                bool flag2 = this.clientType == EnumClientType.LAB_VDI || EnumClientType.DEVELOPPING == this.clientType;
                if (!flag2)
                {
                    ThreadStart start = new ThreadStart(this.run);
                    Thread thread = new Thread(start);
                    thread.Start();
                }
            }
        }

        // Token: 0x06000134 RID: 308 RVA: 0x0001167C File Offset: 0x0001067C
        private void DisableMouse()
        {
            bool flag = this.mouseEnabled;
            if (flag)
            {
                HookManager.MouseClickExt += this.HookManager_MouseMoveExt;
                this.mouseEnabled = false;
            }
        }

        // Token: 0x06000135 RID: 309 RVA: 0x000116B0 File Offset: 0x000106B0
        private void EnableMouse()
        {
            bool flag = !this.mouseEnabled;
            if (flag)
            {
                HookManager.MouseClickExt -= this.HookManager_MouseMoveExt;
                this.mouseEnabled = true;
            }
        }

        // Token: 0x06000136 RID: 310 RVA: 0x000116E8 File Offset: 0x000106E8
        private void DisableAllKeyBoard()
        {
            bool flag = this.keyboardEnabled;
            if (flag)
            {
                HookManager.KeyDown += this.HookManager_KeyDown;
                HookManager.KeyUp += this.HookManager_KeyUp;
                HookManager.KeyPress += this.HookManager_KeyPress;
                this.keyboardEnabled = false;
            }
        }

        // Token: 0x06000137 RID: 311 RVA: 0x00011740 File Offset: 0x00010740
        private void EnableAllKeyBoard()
        {
            bool flag = !this.keyboardEnabled;
            if (flag)
            {
                HookManager.KeyDown -= this.HookManager_KeyDown;
                HookManager.KeyUp -= this.HookManager_KeyUp;
                HookManager.KeyPress -= this.HookManager_KeyPress;
                this.keyboardEnabled = true;
            }
        }

        // Token: 0x06000138 RID: 312 RVA: 0x0001179A File Offset: 0x0001079A
        private void EnableNonFunctionKeys()
        {
            this.nonFunctionKeysEnabled = true;
        }

        // Token: 0x06000139 RID: 313 RVA: 0x000117A4 File Offset: 0x000107A4
        private void DisableNonFunctionKeys()
        {
            this.nonFunctionKeysEnabled = false;
        }

        // Token: 0x0600013A RID: 314 RVA: 0x000117B0 File Offset: 0x000107B0
        private bool IsAllowKey(Keys kCode)
        {
            bool flag = kCode == Keys.LShiftKey || kCode == Keys.RShiftKey;
            bool result;
            if (flag)
            {
                result = true;
            }
            else
            {
                bool flag2 = kCode == Keys.Oemtilde;
                if (flag2)
                {
                    result = true;
                }
                else
                {
                    bool flag3 = kCode == Keys.OemMinus;
                    if (flag3)
                    {
                        result = true;
                    }
                    else
                    {
                        bool flag4 = kCode == Keys.Oemplus;
                        if (flag4)
                        {
                            result = true;
                        }
                        else
                        {
                            bool flag5 = kCode == Keys.OemOpenBrackets;
                            if (flag5)
                            {
                                result = true;
                            }
                            else
                            {
                                bool flag6 = kCode == Keys.OemCloseBrackets;
                                if (flag6)
                                {
                                    result = true;
                                }
                                else
                                {
                                    bool flag7 = kCode == Keys.OemPipe;
                                    if (flag7)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        bool flag8 = kCode == Keys.OemSemicolon;
                                        if (flag8)
                                        {
                                            result = true;
                                        }
                                        else
                                        {
                                            bool flag9 = kCode == Keys.OemQuotes;
                                            if (flag9)
                                            {
                                                result = true;
                                            }
                                            else
                                            {
                                                bool flag10 = kCode == Keys.Oemcomma;
                                                if (flag10)
                                                {
                                                    result = true;
                                                }
                                                else
                                                {
                                                    bool flag11 = kCode == Keys.OemPeriod;
                                                    if (flag11)
                                                    {
                                                        result = true;
                                                    }
                                                    else
                                                    {
                                                        bool flag12 = kCode == Keys.OemQuestion;
                                                        if (flag12)
                                                        {
                                                            result = true;
                                                        }
                                                        else
                                                        {
                                                            bool flag13 = kCode == Keys.Back;
                                                            if (flag13)
                                                            {
                                                                result = true;
                                                            }
                                                            else
                                                            {
                                                                bool flag14 = kCode == Keys.Space;
                                                                if (flag14)
                                                                {
                                                                    result = true;
                                                                }
                                                                else
                                                                {
                                                                    bool flag15 = kCode >= Keys.D0 && kCode <= Keys.D9;
                                                                    if (flag15)
                                                                    {
                                                                        result = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        bool flag16 = kCode >= Keys.NumPad0 && kCode <= Keys.NumPad9;
                                                                        if (flag16)
                                                                        {
                                                                            result = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            bool flag17 = kCode >= Keys.A && kCode <= Keys.Z;
                                                                            if (flag17)
                                                                            {
                                                                                result = true;
                                                                            }
                                                                            else
                                                                            {
                                                                                bool flag18 = kCode == Keys.Up || kCode == Keys.Down || kCode == Keys.Left || kCode == Keys.Right;
                                                                                if (flag18)
                                                                                {
                                                                                    result = true;
                                                                                }
                                                                                else
                                                                                {
                                                                                    bool flag19 = kCode == Keys.Return;
                                                                                    if (flag19)
                                                                                    {
                                                                                        result = true;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        bool flag20 = this.paper.EssayQuestion != null && kCode == Keys.Delete;
                                                                                        if (flag20)
                                                                                        {
                                                                                            result = true;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            bool flag21 = this.paper.EssayQuestion != null && kCode == Keys.Tab;
                                                                                            if (flag21)
                                                                                            {
                                                                                                result = true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                bool flag22 = this.paper.EssayQuestion != null && kCode == Keys.End;
                                                                                                if (flag22)
                                                                                                {
                                                                                                    result = true;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    bool flag23 = this.paper.EssayQuestion != null && kCode == Keys.Home;
                                                                                                    result = flag23;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // Token: 0x0600013B RID: 315 RVA: 0x000119F0 File Offset: 0x000109F0
        private bool IsAllowKey(int kChar)
        {
            string text = "QWERTYUIOPASDFGHJKLZXCVBNM`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./~!@#$%^&*()_+{}|:\"<>?";
            string value = ((char)kChar).ToString();
            bool flag = text.Contains(value);
            bool result;
            if (flag)
            {
                result = true;
            }
            else
            {
                bool flag2 = kChar == 8;
                if (flag2)
                {
                    result = true;
                }
                else
                {
                    bool flag3 = kChar == 32;
                    if (flag3)
                    {
                        result = true;
                    }
                    else
                    {
                        bool flag4 = kChar == 13;
                        if (flag4)
                        {
                            result = true;
                        }
                        else
                        {
                            bool flag5 = this.paper.EssayQuestion != null && kChar == 9;
                            result = flag5;
                        }
                    }
                }
            }
            return result;
        }

        // Token: 0x0600013C RID: 316 RVA: 0x00011A75 File Offset: 0x00010A75
        private void txtNumber_Enter(object sender, EventArgs e)
        {
            this.EnableNonFunctionKeys();
        }

        // Token: 0x0600013D RID: 317 RVA: 0x00011A7F File Offset: 0x00010A7F
        private void txtNumber_Leave(object sender, EventArgs e)
        {
            this.DisableNonFunctionKeys();
        }

        // Token: 0x0600013E RID: 318 RVA: 0x00011A7F File Offset: 0x00010A7F
        private void txtLetter_Leave(object sender, EventArgs e)
        {
            this.DisableNonFunctionKeys();
        }

        // Token: 0x0600013F RID: 319 RVA: 0x00011A75 File Offset: 0x00010A75
        private void txtLetter_Enter(object sender, EventArgs e)
        {
            this.EnableNonFunctionKeys();
        }

        // Token: 0x06000140 RID: 320 RVA: 0x00011A8C File Offset: 0x00010A8C
        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            bool flag = this.nonFunctionKeysEnabled && this.IsAllowKey(e.KeyCode);
            if (!flag)
            {
                e.Handled = true;
            }
        }

        // Token: 0x06000141 RID: 321 RVA: 0x00011AC4 File Offset: 0x00010AC4
        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = this.nonFunctionKeysEnabled && this.IsAllowKey(e.KeyCode);
            if (!flag)
            {
                e.Handled = true;
            }
        }

        // Token: 0x06000142 RID: 322 RVA: 0x00011AFC File Offset: 0x00010AFC
        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool flag = this.nonFunctionKeysEnabled && this.IsAllowKey((int)e.KeyChar);
            if (!flag)
            {
                e.Handled = true;
            }
        }

        // Token: 0x06000143 RID: 323 RVA: 0x00011B34 File Offset: 0x00010B34
        private void HookManager_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (!flag)
            {
                e.Handled = true;
            }
        }

        // Token: 0x06000144 RID: 324 RVA: 0x00011B5F File Offset: 0x00010B5F
        private void btnEssayNormal_Click(object sender, EventArgs e)
        {
            this.pictureBoxEssay.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        // Token: 0x06000145 RID: 325 RVA: 0x00011B70 File Offset: 0x00010B70
        private void btnEssayZoom_Click(object sender, EventArgs e)
        {
            this.pictureBoxEssay.Top = this.panelPicEssay.Top;
            this.pictureBoxEssay.Left = this.panelPicEssay.Left;
            this.pictureBoxEssay.Width = this.panelPicEssay.Width;
            this.pictureBoxEssay.Height = this.panelPicEssay.Height;
            this.pictureBoxEssay.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Token: 0x06000146 RID: 326 RVA: 0x00011BE8 File Offset: 0x00010BE8
        private void btnWordCount_Click(object sender, EventArgs e)
        {
            string text = this.txtWrittingEssay.Text.Trim();
            char[] separator = new char[]
            {
                ' ',
                ',',
                '.',
                ':',
                ';',
                '=',
                '\n',
                '\r',
                '-'
            };
            string[] array = text.Split(separator);
            int num = 0;
            foreach (string text2 in array)
            {
                bool flag = text2.Trim().Length > 0;
                if (flag)
                {
                    num++;
                }
            }
            this.lblWordCount.Text = num + " words";
        }

        // Token: 0x06000147 RID: 327 RVA: 0x00011C79 File Offset: 0x00010C79
        private void btnSaveEssay_Click(object sender, EventArgs e)
        {
            this.paper.EssayQuestion.Development = this.txtWrittingEssay.Text;
            this.Submit2Server_SaveAtClient();
        }

        // Token: 0x06000148 RID: 328 RVA: 0x00011CA0 File Offset: 0x00010CA0
        private void txtWrittingEssay_TextChanged(object sender, EventArgs e)
        {
            bool flag = this.undoStack.Count == 0 || !this.undoStack[this.undoStack.Count - 1].Equals(this.txtWrittingEssay.Text);
            if (flag)
            {
                this.undoStack.Add(this.txtWrittingEssay.Text);
                bool flag2 = this.undoStack.Count > this.depth;
                if (flag2)
                {
                    this.undoStack.RemoveAt(0);
                }
            }
        }

        // Token: 0x06000149 RID: 329 RVA: 0x00011D2C File Offset: 0x00010D2C
        private void btnUndo_Click(object sender, EventArgs e)
        {
            bool flag = this.undoStack.Count > 1;
            if (flag)
            {
                this.redoStack.Add(this.undoStack[this.undoStack.Count - 1]);
                this.undoStack.RemoveAt(this.undoStack.Count - 1);
                bool flag2 = this.undoStack.Count != 0;
                if (flag2)
                {
                    this.txtWrittingEssay.Text = this.undoStack[this.undoStack.Count - 1];
                }
            }
        }

        // Token: 0x0600014A RID: 330 RVA: 0x00011DC4 File Offset: 0x00010DC4
        private void btnRedo_Click(object sender, EventArgs e)
        {
            bool flag = this.redoStack.Count > 0;
            if (flag)
            {
                bool flag2 = this.redoStack.Count != 0;
                if (flag2)
                {
                    this.txtWrittingEssay.Text = this.redoStack[this.redoStack.Count - 1];
                }
                this.redoStack.RemoveAt(this.redoStack.Count - 1);
            }
        }

        // Token: 0x0600014B RID: 331 RVA: 0x00011E38 File Offset: 0x00010E38
        private void questionButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int num = Convert.ToInt32(button.Text);
            bool flag = this.tabControlQuestion.SelectedTab == this.tabPageGrammar;
            if (flag)
            {
                this.indexGrammar = num - 1;
                this.DisplayGrammar(this.indexGrammar);
            }
            bool flag2 = this.tabControlQuestion.SelectedTab == this.tabPageIndicateMistake;
            if (flag2)
            {
                this.indexIndicateMistake = num - 1;
                this.DisplayIndiMistake(this.indexIndicateMistake);
            }
        }

        // Token: 0x0600014C RID: 332 RVA: 0x00011EB8 File Offset: 0x00010EB8
        private void SetButtonColor(int qNo, Color clr)
        {
            foreach (object obj in this.panelQuestionList.Controls)
            {
                Button button = (Button)obj;
                int num = Convert.ToInt32(button.Text);
                bool flag = qNo == num;
                if (flag)
                {
                    button.BackColor = clr;
                }
            }
        }

        // Token: 0x0600014D RID: 333 RVA: 0x00011F34 File Offset: 0x00010F34
        private void AddQuestionButon(int n)
        {
            int num = 0;
            int num2 = 10;
            for (int i = 1; i <= n; i++)
            {
                Button button = new Button();
                button.Text = i.ToString();
                button.Width = 34;
                button.Height = 23;
                button.Left = button.Width * num;
                button.Top = num2;
                num++;
                bool flag = button.Left + button.Width >= this.panelQuestionList.Width - button.Width;
                if (flag)
                {
                    num = 0;
                    button.Left = button.Width * num;
                    num2 = num2 + button.Height + 5;
                    button.Top = num2;
                    num++;
                }
                this.panelQuestionList.Controls.Add(button);
                button.Visible = true;
                button.Click += this.questionButton_Click;
            }
        }

        // Token: 0x0600014E RID: 334 RVA: 0x00012028 File Offset: 0x00011028
        private void chbWantFinishTop_CheckedChanged(object sender, EventArgs e)
        {
            this.btnFinish.Enabled = this.chbWantFinishTop.Checked;
            this.btnFinishTop.Enabled = this.chbWantFinishTop.Checked;
            this.chbWantFinish.Checked = this.chbWantFinishTop.Checked;
        }

        // Token: 0x0600014F RID: 335 RVA: 0x0001207B File Offset: 0x0001107B
        private void btnFinishTop_Click(object sender, EventArgs e)
        {
            this.btnFinish.PerformClick();
        }

        // Token: 0x06000150 RID: 336 RVA: 0x0001208C File Offset: 0x0001108C
        private void txtWrittingEssay_KeyDown(object sender, KeyEventArgs e)
        {
            bool flag = e.Control && e.KeyCode == Keys.C;
            if (flag)
            {
                this.buf = this.txtWrittingEssay.SelectedText;
            }
            bool flag2 = e.Control && e.KeyCode == Keys.V;
            if (flag2)
            {
                this.txtWrittingEssay.Text = this.txtWrittingEssay.Text.Insert(this.txtWrittingEssay.SelectionStart, this.buf);
            }
        }

        // Token: 0x06000151 RID: 337 RVA: 0x00012110 File Offset: 0x00011110
        private void frmEnglishExamClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flag = !this.btnExit.Enabled;
            if (flag)
            {
                e.Cancel = true;
            }
        }

        // Token: 0x06000152 RID: 338 RVA: 0x00012138 File Offset: 0x00011138
        private void CloseAppsTest()
        {
            foreach (Process process in Process.GetProcesses())
            {
                bool flag = process.MainWindowTitle.StartsWith("ExamClient_ENG");
                if (!flag)
                {
                    bool flag2 = process.MainWindowTitle.Equals("EOS Login Form");
                    if (!flag2)
                    {
                        bool flag3 = process.ProcessName.StartsWith("explo");
                        if (!flag3)
                        {
                            bool flag4 = !process.MainWindowTitle.Equals("");
                            if (flag4)
                            {
                                process.Kill();
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06000153 RID: 339 RVA: 0x000121C8 File Offset: 0x000111C8
        private void nudVol_ValueChanged(object sender, EventArgs e)
        {
            bool flag = this.waveOut != null;
            if (flag)
            {
                this.waveOut.Volume = (float)this.nudVol.Value * 0.1f;
            }
        }

        // Token: 0x06000154 RID: 340 RVA: 0x00012206 File Offset: 0x00011206
        private void btnReadingRealSize_Click(object sender, EventArgs e)
        {
            this.picBoxReadingM.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        // Token: 0x06000155 RID: 341 RVA: 0x00012218 File Offset: 0x00011218
        private void btnReadingZoomIn_Click(object sender, EventArgs e)
        {
            this.picBoxReadingM.SizeMode = PictureBoxSizeMode.StretchImage;
            int width = (int)((double)this.picBoxReadingM.Width * 1.1);
            int height = (int)((double)this.picBoxReadingM.Height * 1.1);
            this.picBoxReadingM.Size = new Size(width, height);
        }

        // Token: 0x06000156 RID: 342 RVA: 0x00012278 File Offset: 0x00011278
        private void btnReadingZoomOut_Click(object sender, EventArgs e)
        {
            this.picBoxReadingM.SizeMode = PictureBoxSizeMode.StretchImage;
            int width = (int)((double)this.picBoxReadingM.Width * 0.9);
            int height = (int)((double)this.picBoxReadingM.Height * 0.9);
            this.picBoxReadingM.Size = new Size(width, height);
        }

        // Token: 0x06000157 RID: 343 RVA: 0x000122D8 File Offset: 0x000112D8
        private void domainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            Font font = new Font(this.domainUpDown.Text, (float)this.nudFontSize.Value);
            bool flag = this.paper.ImgPaper != null;
            if (flag)
            {
                foreach (object obj in this.panelAnswer.Controls)
                {
                    Control control = (Control)obj;
                    bool flag2 = control is TextBox;
                    if (flag2)
                    {
                        control.Font = font;
                    }
                }
            }
            else
            {
                this.lblColumnA.Font = font;
                this.lblColumnB.Font = font;
                this.lblMC_Text.Font = font;
                this.lblIndicateMistake.Font = font;
                this.lblReadingContent.Font = font;
                this.txtWrittingEssay.Font = font;
                bool flag3 = this.paper.ListenCode.Trim().Equals("") || this.showQuestionClicked;
                if (flag3)
                {
                    this.UpdateFontOnImageDisplay();
                }
            }
        }

        // Token: 0x06000158 RID: 344 RVA: 0x00012410 File Offset: 0x00011410
        private Bitmap ConvertTextToImage(string txt, Font font, Color bgcolor, Color fcolor, int width, int Height)
        {
            Bitmap bitmap = new Bitmap(width, Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString(txt, font, new SolidBrush(fcolor), 0f, 0f);
                graphics.Flush();
                font.Dispose();
                graphics.Dispose();
            }
            return bitmap;
        }

        // Token: 0x06000159 RID: 345 RVA: 0x000124A0 File Offset: 0x000114A0
        private void DisplayImageOnLabel(Panel panel, Label lbl, string text)
        {
            int num = 100;
            int num2 = panel.ClientSize.Width - (lbl.Left + num);
            char[] separator = new char[]
            {
                ' '
            };
            string[] array = text.Split(separator);
            text = "";
            string text2 = "";
            Font font = new Font(lbl.Font.FontFamily, lbl.Font.Size);
            foreach (string text3 in array)
            {
                text2 = text2 + text3 + " ";
                bool flag = TextRenderer.MeasureText(text2, font, lbl.Size, TextFormatFlags.ExternalLeading).Width >= num2;
                if (flag)
                {
                    text = text + " \n" + text3 + " ";
                    text2 = text3 + " ";
                }
                else
                {
                    text = text + text3 + " ";
                }
            }
            Size size = TextRenderer.MeasureText(text, font, lbl.Size, TextFormatFlags.ExternalLeading);
            Color foreColor = lbl.ForeColor;
            Color white = Color.White;
            lbl.AutoSize = true;
            lbl.Visible = false;
            int width = size.Width + num;
            int height = size.Height;
            Bitmap image = this.ConvertTextToImage(text, font, white, foreColor, width, height);
            lbl.Text = "";
            lbl.AutoSize = false;
            lbl.Image = image;
            lbl.Size = new Size(width, height);
            lbl.Visible = true;
        }

        // Token: 0x0600015A RID: 346 RVA: 0x0001262C File Offset: 0x0001162C
        private void frmEnglishExamClient_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x0600015B RID: 347 RVA: 0x0001262C File Offset: 0x0001162C
        private void lblMC_Text_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x0600015C RID: 348 RVA: 0x00012636 File Offset: 0x00011636
        private void MoveMouse2ZeroZero()
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(0, 0);
        }

        // Token: 0x0600015D RID: 349 RVA: 0x0001262C File Offset: 0x0001162C
        private void lblIndicateMistake_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x0600015E RID: 350 RVA: 0x00012636 File Offset: 0x00011636
        private void lblReadingContent_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(0, 0);
        }

        // Token: 0x0600015F RID: 351 RVA: 0x0001262C File Offset: 0x0001162C
        private void lblReadingContent_MouseDown_1(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x06000160 RID: 352 RVA: 0x0001262C File Offset: 0x0001162C
        private void lblColumnA_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x06000161 RID: 353 RVA: 0x0001262C File Offset: 0x0001162C
        private void lblColumnB_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x06000162 RID: 354 RVA: 0x0001262C File Offset: 0x0001162C
        private void panelReading_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x06000163 RID: 355 RVA: 0x0001262C File Offset: 0x0001162C
        private void panelMC_Text_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x06000164 RID: 356 RVA: 0x0001262C File Offset: 0x0001162C
        private void panelIndicateMistake_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x06000165 RID: 357 RVA: 0x0001262C File Offset: 0x0001162C
        private void panelA_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x06000166 RID: 358 RVA: 0x0001262C File Offset: 0x0001162C
        private void panelB_MouseDown(object sender, MouseEventArgs e)
        {
            this.MoveMouse2ZeroZero();
        }

        // Token: 0x06000167 RID: 359 RVA: 0x0001265C File Offset: 0x0001165C
        private void timerBOTTest_Tick(object sender, EventArgs e)
        {
        }

        // Token: 0x06000168 RID: 360 RVA: 0x00012660 File Offset: 0x00011660
        private int CentimeterToPixel(double Centimeter)
        {
            double num = -1.0;
            using (Graphics graphics = base.CreateGraphics())
            {
                num = Centimeter * (double)graphics.DpiY / 2.54;
            }
            return (int)num;
        }

        // Token: 0x06000169 RID: 361 RVA: 0x000126B8 File Offset: 0x000116B8
        private void trackBarPicSize_Scroll(object sender, EventArgs e)
        {
            this.lblPicSize.Text = this.trackBarPicSize.Value + "%";
            this.pictureBoxPaper.Width = this.CentimeterToPixel((double)(21 * this.trackBarPicSize.Value / 100));
            this.pictureBoxPaper.Height = this.CentimeterToPixel(29.7 * (double)this.NumberOfPage * (double)this.trackBarPicSize.Value / 100.0);
            this.pictureBoxPaper.Refresh();
        }

        // Token: 0x0600016A RID: 362 RVA: 0x0000B388 File Offset: 0x0000A388
        private void panelAnswer_Scroll(object sender, ScrollEventArgs e)
        {
            this.btnFullScreen.Focus();
        }

        // Token: 0x0600016B RID: 363 RVA: 0x00012758 File Offset: 0x00011758
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.btnSubmit.Enabled = false;
            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    bool flag = process.MainWindowTitle.Equals("EOS Login Form");
                    if (!flag)
                    {
                        bool flag2 = this.clientType == EnumClientType.DEVELOPPING && process.MainWindowTitle.Contains("EOS Server");
                        if (flag2)
                        {
                        }
                    }
                }
            }
            catch
            {
            }
            this.lblSaveServer.Text = "Exam finished successfully.";
            this.btnExit.Enabled = true;
        }

        // Token: 0x0600016C RID: 364 RVA: 0x00012800 File Offset: 0x00011800
        private void UpdateAnswerImagePaper()
        {
            for (int i = 0; i < this.arrTBAnswers.Length; i++)
            {
                this.SetImagePaperAnswer(i + 1, this.arrTBAnswers[i].Text);
            }
        }

        // Token: 0x0600016D RID: 365 RVA: 0x00012840 File Offset: 0x00011840
        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            bool flag = this.btnFullScreen.Text.Equals("Full Screen");
            if (flag)
            {
                this.tabControlQuestion.BringToFront();
                this.tabTop = this.tabControlQuestion.Top;
                this.tabLeft = this.tabControlQuestion.Left;
                this.tabHeight = this.tabControlQuestion.Height;
                this.tabWidth = this.tabControlQuestion.Width;
                this.tabControlQuestion.Top = 0;
                this.tabControlQuestion.Left = 0;
                this.tabControlQuestion.Height = base.Height;
                this.tabControlQuestion.Width = base.Width;
                this.btnFullScreen.Text = "Restore Screen";
                this.lblTimeLeft_Copy.Visible = true;
                this.lblTime_copy.Visible = true;
            }
            else
            {
                this.tabControlQuestion.Top = this.tabTop;
                this.tabControlQuestion.Left = this.tabLeft;
                this.tabControlQuestion.Height = this.tabHeight;
                this.tabControlQuestion.Width = this.tabWidth;
                this.btnFullScreen.Text = "Full Screen";
                this.lblTimeLeft_Copy.Visible = false;
                this.lblTime_copy.Visible = false;
            }
        }

        // Token: 0x0600016E RID: 366 RVA: 0x0001299C File Offset: 0x0001199C
        private Bitmap GetWebCamImage()
        {
            Bitmap bmp = new Bitmap(1080, 720);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
            }
            //WebCameraControl webCameraControl = new WebCameraControl();
            //WebCameraId webCameraId = null;
            //foreach (WebCameraId webCameraId2 in webCameraControl.GetVideoCaptureDevices())
            //{
            //	bool flag = webCameraId2 != null;
            //	if (flag)
            //	{
            //		webCameraId = webCameraId2;
            //		break;
            //	}
            //}
            //bool flag2 = webCameraId != null;
            //if (flag2)
            //{
            //	webCameraControl.StartCapture(webCameraId);
            //	Thread.Sleep(2000);
            //	result = webCameraControl.GetCurrentImage();
            //	Thread.Sleep(250);
            //	webCameraControl.StopCapture();
            //}
            return bmp;
        }

        // Token: 0x0600016F RID: 367 RVA: 0x00012A48 File Offset: 0x00011A48
        private byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        // Token: 0x06000170 RID: 368 RVA: 0x00012A74 File Offset: 0x00011A74
        private void txtPaperLongAnswer_Enter(object sender, EventArgs e)
        {
            TextBox key = (TextBox)sender;
            this.undoStack = (List<string>)this.hashUndoPaper[key];
            this.redoStack = (List<string>)this.hashRedoPaper[key];
            this.txtCurrentLongAnswer = key;
        }

        // Token: 0x06000171 RID: 369 RVA: 0x00012AC0 File Offset: 0x00011AC0
        private void txtPaperLongAnswer_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            bool flag = this.undoStack.Count == 0 || !this.undoStack[this.undoStack.Count - 1].Equals(textBox.Text);
            if (flag)
            {
                this.undoStack.Add(textBox.Text);
                bool flag2 = this.undoStack.Count > this.depth;
                if (flag2)
                {
                    this.undoStack.RemoveAt(0);
                }
            }
        }

        // Token: 0x06000172 RID: 370 RVA: 0x00012B4C File Offset: 0x00011B4C
        private void btnUndoPaper_Click(object sender, EventArgs e)
        {
            bool flag = this.undoStack.Count > 1;
            if (flag)
            {
                this.redoStack.Add(this.undoStack[this.undoStack.Count - 1]);
                this.undoStack.RemoveAt(this.undoStack.Count - 1);
                bool flag2 = this.undoStack.Count != 0;
                if (flag2)
                {
                    this.txtCurrentLongAnswer.Text = this.undoStack[this.undoStack.Count - 1];
                }
            }
        }

        // Token: 0x06000173 RID: 371 RVA: 0x00012BE4 File Offset: 0x00011BE4
        private void btnRedoPaper_Click(object sender, EventArgs e)
        {
            bool flag = this.redoStack.Count > 0;
            if (flag)
            {
                bool flag2 = this.redoStack.Count != 0;
                if (flag2)
                {
                    this.txtCurrentLongAnswer.Text = this.redoStack[this.redoStack.Count - 1];
                }
                this.redoStack.RemoveAt(this.redoStack.Count - 1);
            }
        }

        // Token: 0x06000174 RID: 372 RVA: 0x00012C58 File Offset: 0x00011C58
        public string NotValidDNS(string campus)
        {
            string result = null;
            bool flag = this.EOSPing("8.8.8.8") || this.EOSPing("8.8.4.4");
            if (flag)
            {
                result = "internet";
            }
            return result;
        }

        // Token: 0x06000175 RID: 373 RVA: 0x00012C94 File Offset: 0x00011C94
        public bool EOSPing(string ip)
        {
            Ping ping = new Ping();
            PingOptions pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            string s = "0123456789-0123456789-0123456789";
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            int timeout = 120;
            PingReply pingReply = ping.Send(ip, timeout, bytes, pingOptions);
            return pingReply.Status == IPStatus.Success;
        }

        // Token: 0x04000135 RID: 309
        private EnumClientType clientType = EnumClientType.STUDENT_LAPTOP;

        // Token: 0x04000136 RID: 310
        private bool isDistanceLearning = false;

        // Token: 0x04000137 RID: 311
        private bool blockVM = false;

        // Token: 0x04000138 RID: 312
        private EOSData examData = null;

        // Token: 0x04000139 RID: 313
        private string remotingURL = null;

        // Token: 0x0400013A RID: 314
        private string monitorURL = null;

        // Token: 0x0400013B RID: 315
        public string loginId;

        // Token: 0x0400013C RID: 316
        private int timeLeft;

        // Token: 0x0400013D RID: 317
        private Paper paper = null;

        // Token: 0x0400013E RID: 318
        private bool finishClick = false;

        // Token: 0x0400013F RID: 319
        private CheckBox[] chkReadingM;

        // Token: 0x04000140 RID: 320
        private CheckBox[] chkGrammar;

        // Token: 0x04000141 RID: 321
        private CheckBox[] chkIndiMistake;

        // Token: 0x04000142 RID: 322
        private int indexReading = 0;

        // Token: 0x04000143 RID: 323
        private int indexReadingQuestion = 0;

        // Token: 0x04000144 RID: 324
        private int indexMatching = 0;

        // Token: 0x04000145 RID: 325
        private int indexGrammar = 0;

        // Token: 0x04000146 RID: 326
        private int indexIndicateMistake = 0;

        // Token: 0x04000147 RID: 327
        private int indexFill = 0;

        // Token: 0x04000148 RID: 328
        private List<string> listValidIPs = null;

        // Token: 0x04000149 RID: 329
        private Random ran = new Random((int)DateTime.Now.Ticks);

        // Token: 0x0400014A RID: 330
        private int autoSaveInteval = 120;

        // Token: 0x0400014B RID: 331
        private bool submitFirstTime = false;

        // Token: 0x0400014C RID: 332
        private int countCheckWifi = 0;

        // Token: 0x0400014D RID: 333
        private bool keepConnection = false;

        // Token: 0x0400014E RID: 334
        private ArrayList listMissScreenImages = new ArrayList();

        // Token: 0x0400014F RID: 335
        private string[] qaNo = new string[]
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"
        };

        // Token: 0x04000150 RID: 336
        private bool closeConnection = true;

        // Token: 0x04000151 RID: 337
        private int closeTCPInterval = 500;

        // Token: 0x04000152 RID: 338
        private int captureScreenInterval = 10;

        // Token: 0x04000153 RID: 339
        private int imageIndex = 0;

        // Token: 0x04000154 RID: 340
        private string oldMultipleChoice = "";

        // Token: 0x04000155 RID: 341
        private int matchingAnswerCount = 0;

        // Token: 0x04000156 RID: 342
        private string oldFillBlankAnswer = "";

        // Token: 0x04000157 RID: 343
        private string oldGrammarChoice = "";

        // Token: 0x04000158 RID: 344
        private string oldIndiMistakeChoice = "";

        // Token: 0x04000159 RID: 345
        private TextBox[] arrTBAnswers = null;

        // Token: 0x0400015A RID: 346
        private Label[] arrLBLAnswers = null;

        // Token: 0x0400015B RID: 347
        private SubmitPaper sPaper;

        // Token: 0x0400015C RID: 348
        private int lastSave = 0;

        // Token: 0x0400015D RID: 349
        private int lastSaveImagePaper = 0;

        // Token: 0x0400015E RID: 350
        private bool exitButtonClicked = false;

        // Token: 0x0400015F RID: 351
        private ArrayList lblList = null;

        // Token: 0x04000160 RID: 352
        private ArrayList txtList = null;

        // Token: 0x04000161 RID: 353
        private ArrayList cboList = null;

        // Token: 0x04000162 RID: 354
        private Mp3FileReader reader = null;

        // Token: 0x04000163 RID: 355
        private WaveOut waveOut = null;

        // Token: 0x04000164 RID: 356
        private bool keyboardEnabled = true;

        // Token: 0x04000165 RID: 357
        private bool nonFunctionKeysEnabled = true;

        // Token: 0x04000166 RID: 358
        private bool mouseEnabled = true;

        // Token: 0x04000167 RID: 359
        private List<string> undoStack = new List<string>();

        // Token: 0x04000168 RID: 360
        private List<string> redoStack = new List<string>();

        // Token: 0x04000169 RID: 361
        private int depth = 20;

        // Token: 0x0400016A RID: 362
        private string buf = null;

        // Token: 0x0400016B RID: 363
        private bool showQuestionClicked = false;

        // Token: 0x0400016C RID: 364
        private int NumberOfPage = 0;

        // Token: 0x0400016D RID: 365
        private int tabTop;

        // Token: 0x0400016E RID: 366
        private int tabLeft;

        // Token: 0x0400016F RID: 367
        private int tabHeight;

        // Token: 0x04000170 RID: 368
        private int tabWidth;

        // Token: 0x04000171 RID: 369
        private Hashtable hashUndoPaper = new Hashtable();

        // Token: 0x04000172 RID: 370
        private Hashtable hashRedoPaper = new Hashtable();

        // Token: 0x04000173 RID: 371
        private TextBox txtCurrentLongAnswer = null;

        // Token: 0x0200002F RID: 47
        // (Invoke) Token: 0x060001CA RID: 458
        private delegate void SetTextCallback(string text);
    }
}
