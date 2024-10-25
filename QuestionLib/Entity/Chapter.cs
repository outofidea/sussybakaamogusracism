using System;

namespace QuestionLib.Entity
{
	// Token: 0x0200000E RID: 14
	public class Chapter
	{
		// Token: 0x06000097 RID: 151 RVA: 0x000036DA File Offset: 0x000026DA
		public Chapter()
		{
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000036E4 File Offset: 0x000026E4
		public Chapter(int _chid, string _cid, string _name)
		{
			this._chid = _chid;
			this._cid = _cid;
			this._name = _name;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00003704 File Offset: 0x00002704
		// (set) Token: 0x0600009A RID: 154 RVA: 0x0000371C File Offset: 0x0000271C
		public int ChID
		{
			get
			{
				return this._chid;
			}
			set
			{
				this._chid = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00003728 File Offset: 0x00002728
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00003740 File Offset: 0x00002740
		public string CID
		{
			get
			{
				return this._cid;
			}
			set
			{
				this._cid = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600009D RID: 157 RVA: 0x0000374C File Offset: 0x0000274C
		// (set) Token: 0x0600009E RID: 158 RVA: 0x00003764 File Offset: 0x00002764
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003770 File Offset: 0x00002770
		public override string ToString()
		{
			return this._name;
		}

		// Token: 0x04000052 RID: 82
		private int _chid;

		// Token: 0x04000053 RID: 83
		private string _cid;

		// Token: 0x04000054 RID: 84
		private string _name;
	}
}
