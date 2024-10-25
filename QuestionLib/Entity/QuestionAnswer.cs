using System;

namespace QuestionLib.Entity
{
	// Token: 0x02000016 RID: 22
	[Serializable]
	public class QuestionAnswer
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00003FF4 File Offset: 0x00002FF4
		// (set) Token: 0x0600010E RID: 270 RVA: 0x0000400C File Offset: 0x0000300C
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

		// Token: 0x0600010F RID: 271 RVA: 0x000036DA File Offset: 0x000026DA
		public QuestionAnswer()
		{
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00004016 File Offset: 0x00003016
		public QuestionAnswer(string text, bool chosen)
		{
			this._text = text;
			this._chosen = chosen;
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00004030 File Offset: 0x00003030
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00004048 File Offset: 0x00003048
		public int QAID
		{
			get
			{
				return this._qaid;
			}
			set
			{
				this._qaid = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00004054 File Offset: 0x00003054
		// (set) Token: 0x06000114 RID: 276 RVA: 0x0000406C File Offset: 0x0000306C
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00004078 File Offset: 0x00003078
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00004090 File Offset: 0x00003090
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

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000117 RID: 279 RVA: 0x0000409C File Offset: 0x0000309C
		// (set) Token: 0x06000118 RID: 280 RVA: 0x000040B4 File Offset: 0x000030B4
		public bool Chosen
		{
			get
			{
				return this._chosen;
			}
			set
			{
				this._chosen = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000119 RID: 281 RVA: 0x000040C0 File Offset: 0x000030C0
		// (set) Token: 0x0600011A RID: 282 RVA: 0x000040D8 File Offset: 0x000030D8
		public bool Selected
		{
			get
			{
				return this._selected;
			}
			set
			{
				this._selected = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600011B RID: 283 RVA: 0x000040E4 File Offset: 0x000030E4
		// (set) Token: 0x0600011C RID: 284 RVA: 0x000040FC File Offset: 0x000030FC
		public bool Done
		{
			get
			{
				return this._done;
			}
			set
			{
				this._done = value;
			}
		}

		// Token: 0x0400008B RID: 139
		private int _qaid;

		// Token: 0x0400008C RID: 140
		private int _qid;

		// Token: 0x0400008D RID: 141
		private string _text;

		// Token: 0x0400008E RID: 142
		private bool _chosen;

		// Token: 0x0400008F RID: 143
		private bool _selected;

		// Token: 0x04000090 RID: 144
		private bool _done;

		// Token: 0x04000091 RID: 145
		private int _QBID;
	}
}
