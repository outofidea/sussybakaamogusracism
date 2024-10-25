using System;

namespace QuestionLib.Entity
{
	// Token: 0x02000018 RID: 24
	public class Test
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00004198 File Offset: 0x00003198
		// (set) Token: 0x06000128 RID: 296 RVA: 0x000041B0 File Offset: 0x000031B0
		public string TestId
		{
			get
			{
				return this._testId;
			}
			set
			{
				this._testId = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000129 RID: 297 RVA: 0x000041BC File Offset: 0x000031BC
		// (set) Token: 0x0600012A RID: 298 RVA: 0x000041D4 File Offset: 0x000031D4
		public string CourseId
		{
			get
			{
				return this._courseId;
			}
			set
			{
				this._courseId = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600012B RID: 299 RVA: 0x000041E0 File Offset: 0x000031E0
		// (set) Token: 0x0600012C RID: 300 RVA: 0x000041F8 File Offset: 0x000031F8
		public string Questions
		{
			get
			{
				return this._questions;
			}
			set
			{
				this._questions = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00004204 File Offset: 0x00003204
		// (set) Token: 0x0600012E RID: 302 RVA: 0x0000421C File Offset: 0x0000321C
		public int NumOfQuestion
		{
			get
			{
				return this._numOfQuestion;
			}
			set
			{
				this._numOfQuestion = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00004228 File Offset: 0x00003228
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00004240 File Offset: 0x00003240
		public float Mark
		{
			get
			{
				return this._mark;
			}
			set
			{
				this._mark = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000131 RID: 305 RVA: 0x0000424C File Offset: 0x0000324C
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00004264 File Offset: 0x00003264
		public string StudentGuide
		{
			get
			{
				return this._studentGuide;
			}
			set
			{
				this._studentGuide = value;
			}
		}

		// Token: 0x04000096 RID: 150
		private string _testId;

		// Token: 0x04000097 RID: 151
		private string _courseId;

		// Token: 0x04000098 RID: 152
		private string _questions;

		// Token: 0x04000099 RID: 153
		private int _numOfQuestion;

		// Token: 0x0400009A RID: 154
		private float _mark;

		// Token: 0x0400009B RID: 155
		private string _studentGuide;
	}
}
