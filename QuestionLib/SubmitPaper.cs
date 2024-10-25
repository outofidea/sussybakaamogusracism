using System;

namespace QuestionLib
{
	// Token: 0x0200000C RID: 12
	[Serializable]
	public class SubmitPaper
	{
		// Token: 0x06000082 RID: 130 RVA: 0x0000353C File Offset: 0x0000253C
		public override bool Equals(object obj)
		{
			SubmitPaper submitPaper = (SubmitPaper)obj;
			return this.ID.Equals(submitPaper.ID) && this.SPaper.ExamCode.Equals(submitPaper.SPaper.ExamCode);
		}

		// Token: 0x0400003D RID: 61
		public string LoginId;

		// Token: 0x0400003E RID: 62
		public int TimeLeft;

		// Token: 0x0400003F RID: 63
		public int IndexFill;

		// Token: 0x04000040 RID: 64
		public int IndexReading;

		// Token: 0x04000041 RID: 65
		public int IndexG;

		// Token: 0x04000042 RID: 66
		public int IndexIndiM;

		// Token: 0x04000043 RID: 67
		public int IndexMatch;

		// Token: 0x04000044 RID: 68
		public bool Finish;

		// Token: 0x04000045 RID: 69
		public Paper SPaper;

		// Token: 0x04000046 RID: 70
		public int TabIndex;

		// Token: 0x04000047 RID: 71
		public DateTime SubmitTime;

		// Token: 0x04000048 RID: 72
		public string ID;
	}
}
