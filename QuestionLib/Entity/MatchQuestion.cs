using System;
using System.Collections;

namespace QuestionLib.Entity
{
	// Token: 0x02000012 RID: 18
	[Serializable]
	public class MatchQuestion
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x000039A4 File Offset: 0x000029A4
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x000039BC File Offset: 0x000029BC
		public int QBID
		{
			get
			{
				return this._QBID;
			}
			set
			{
				this._QBID = value;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000039C6 File Offset: 0x000029C6
		public MatchQuestion()
		{
			this._questionLOs = new ArrayList();
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000CB RID: 203 RVA: 0x000039DC File Offset: 0x000029DC
		// (set) Token: 0x060000CC RID: 204 RVA: 0x000039F4 File Offset: 0x000029F4
		public int MID
		{
			get
			{
				return this._mid;
			}
			set
			{
				this._mid = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00003A00 File Offset: 0x00002A00
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00003A18 File Offset: 0x00002A18
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

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00003A24 File Offset: 0x00002A24
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00003A3C File Offset: 0x00002A3C
		public int ChapterId
		{
			get
			{
				return this._chapterId;
			}
			set
			{
				this._chapterId = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00003A48 File Offset: 0x00002A48
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00003A60 File Offset: 0x00002A60
		public string ColumnA
		{
			get
			{
				return this._columnA;
			}
			set
			{
				this._columnA = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00003A6C File Offset: 0x00002A6C
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00003A84 File Offset: 0x00002A84
		public string ColumnB
		{
			get
			{
				return this._columnB;
			}
			set
			{
				this._columnB = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00003A90 File Offset: 0x00002A90
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00003AA8 File Offset: 0x00002AA8
		public string Solution
		{
			get
			{
				return this._solution;
			}
			set
			{
				this._solution = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00003AB4 File Offset: 0x00002AB4
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00003ACC File Offset: 0x00002ACC
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

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00003AD8 File Offset: 0x00002AD8
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00003AF0 File Offset: 0x00002AF0
		public string SudentAnswer
		{
			get
			{
				return this._studentAnswer;
			}
			set
			{
				this._studentAnswer = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00003AFC File Offset: 0x00002AFC
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00003B14 File Offset: 0x00002B14
		public ArrayList QuestionLOs
		{
			get
			{
				return this._questionLOs;
			}
			set
			{
				this._questionLOs = value;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00003B20 File Offset: 0x00002B20
		public override string ToString()
		{
			return this._mid.ToString();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003B3D File Offset: 0x00002B3D
		public void Preapare2Submit()
		{
			this.Solution = null;
			this.ColumnA = null;
			this.ColumnB = null;
			this.CourseId = null;
		}

		// Token: 0x04000066 RID: 102
		private int _mid;

		// Token: 0x04000067 RID: 103
		private string _courseId;

		// Token: 0x04000068 RID: 104
		private int _chapterId;

		// Token: 0x04000069 RID: 105
		private string _columnA;

		// Token: 0x0400006A RID: 106
		private string _columnB;

		// Token: 0x0400006B RID: 107
		private string _solution;

		// Token: 0x0400006C RID: 108
		private float _mark;

		// Token: 0x0400006D RID: 109
		private string _studentAnswer;

		// Token: 0x0400006E RID: 110
		private ArrayList _questionLOs;

		// Token: 0x0400006F RID: 111
		private int _QBID;
	}
}
