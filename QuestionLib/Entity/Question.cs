using System;
using System.Collections;
using NHibernate;
using QuestionLib.Business;

namespace QuestionLib.Entity
{
	// Token: 0x02000015 RID: 21
	[Serializable]
	public class Question
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00003D08 File Offset: 0x00002D08
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x00003D20 File Offset: 0x00002D20
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

		// Token: 0x060000F1 RID: 241 RVA: 0x00003D2A File Offset: 0x00002D2A
		public Question()
		{
			this._questionAnswers = new ArrayList();
			this._questionLOs = new ArrayList();
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00003D4C File Offset: 0x00002D4C
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00003D64 File Offset: 0x00002D64
		public int QID
		{
			get
			{
				return this._qid;
			}
			set
			{
				this._qid = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00003D70 File Offset: 0x00002D70
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00003D88 File Offset: 0x00002D88
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

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00003D94 File Offset: 0x00002D94
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00003DAC File Offset: 0x00002DAC
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

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00003DB8 File Offset: 0x00002DB8
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00003DD0 File Offset: 0x00002DD0
		public int PID
		{
			get
			{
				return this._pid;
			}
			set
			{
				this._pid = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00003DDC File Offset: 0x00002DDC
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00003DF4 File Offset: 0x00002DF4
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				this._text = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00003E00 File Offset: 0x00002E00
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00003E18 File Offset: 0x00002E18
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

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00003E24 File Offset: 0x00002E24
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00003E3C File Offset: 0x00002E3C
		public ArrayList QuestionAnswers
		{
			get
			{
				return this._questionAnswers;
			}
			set
			{
				this._questionAnswers = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00003E48 File Offset: 0x00002E48
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00003E60 File Offset: 0x00002E60
		public QuestionType QType
		{
			get
			{
				return this._qType;
			}
			set
			{
				this._qType = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00003E6C File Offset: 0x00002E6C
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00003E84 File Offset: 0x00002E84
		public bool Lock
		{
			get
			{
				return this._lock;
			}
			set
			{
				this._lock = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00003E90 File Offset: 0x00002E90
		// (set) Token: 0x06000105 RID: 261 RVA: 0x00003EA8 File Offset: 0x00002EA8
		public byte[] ImageData
		{
			get
			{
				return this._imageData;
			}
			set
			{
				this._imageData = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00003EB4 File Offset: 0x00002EB4
		// (set) Token: 0x06000107 RID: 263 RVA: 0x00003ECC File Offset: 0x00002ECC
		public int ImageSize
		{
			get
			{
				return this._imageSize;
			}
			set
			{
				this._imageSize = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00003ED8 File Offset: 0x00002ED8
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00003EF0 File Offset: 0x00002EF0
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

		// Token: 0x0600010A RID: 266 RVA: 0x00003EFC File Offset: 0x00002EFC
		public override string ToString()
		{
			return this._text;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00003F14 File Offset: 0x00002F14
		public void LoadAnswers(ISessionFactory sessionFactory)
		{
			BOQuestionAnswer boquestionAnswer = new BOQuestionAnswer(sessionFactory);
			this._questionAnswers = (ArrayList)boquestionAnswer.LoadAnswer(this._qid);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00003F40 File Offset: 0x00002F40
		public void Preapare2Submit()
		{
			this.Text = null;
			this.CourseId = null;
			this.ImageData = null;
			this.ImageSize = 0;
			bool flag = this.QType == QuestionType.FILL_BLANK_ALL;
			if (!flag)
			{
				bool flag2 = this.QType == QuestionType.FILL_BLANK_GROUP;
				if (!flag2)
				{
					bool flag3 = this.QType == QuestionType.FILL_BLANK_EMPTY;
					if (!flag3)
					{
						foreach (object obj in this.QuestionAnswers)
						{
							QuestionAnswer questionAnswer = (QuestionAnswer)obj;
							questionAnswer.Text = null;
						}
					}
				}
			}
		}

		// Token: 0x0400007E RID: 126
		private int _qid;

		// Token: 0x0400007F RID: 127
		private string _courseId;

		// Token: 0x04000080 RID: 128
		private int _chapterId;

		// Token: 0x04000081 RID: 129
		private int _pid;

		// Token: 0x04000082 RID: 130
		private string _text;

		// Token: 0x04000083 RID: 131
		private float _mark;

		// Token: 0x04000084 RID: 132
		private ArrayList _questionAnswers;

		// Token: 0x04000085 RID: 133
		private QuestionType _qType;

		// Token: 0x04000086 RID: 134
		private bool _lock;

		// Token: 0x04000087 RID: 135
		private byte[] _imageData;

		// Token: 0x04000088 RID: 136
		private int _imageSize;

		// Token: 0x04000089 RID: 137
		private ArrayList _questionLOs;

		// Token: 0x0400008A RID: 138
		private int _QBID;
	}
}
