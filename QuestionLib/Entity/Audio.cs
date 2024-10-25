using System;

namespace QuestionLib.Entity
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	public class Audio
	{
		// Token: 0x06000084 RID: 132 RVA: 0x00003586 File Offset: 0x00002586
		public Audio()
		{
			this._audioData = null;
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00003598 File Offset: 0x00002598
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000035B0 File Offset: 0x000025B0
		public int AuID
		{
			get
			{
				return this._auID;
			}
			set
			{
				this._auID = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000035BC File Offset: 0x000025BC
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000035D4 File Offset: 0x000025D4
		public int ChID
		{
			get
			{
				return this._chID;
			}
			set
			{
				this._chID = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000035E0 File Offset: 0x000025E0
		// (set) Token: 0x0600008A RID: 138 RVA: 0x000035F8 File Offset: 0x000025F8
		public string AudioFile
		{
			get
			{
				return this._audioFile;
			}
			set
			{
				this._audioFile = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00003604 File Offset: 0x00002604
		// (set) Token: 0x0600008C RID: 140 RVA: 0x0000361C File Offset: 0x0000261C
		public int AudioSize
		{
			get
			{
				return this._audioSize;
			}
			set
			{
				this._audioSize = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00003628 File Offset: 0x00002628
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00003640 File Offset: 0x00002640
		public byte[] AudioData
		{
			get
			{
				return this._audioData;
			}
			set
			{
				this._audioData = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000364C File Offset: 0x0000264C
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00003664 File Offset: 0x00002664
		public int AudioLength
		{
			get
			{
				return this._audioLength;
			}
			set
			{
				this._audioLength = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003670 File Offset: 0x00002670
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00003688 File Offset: 0x00002688
		public byte RepeatTime
		{
			get
			{
				return this._repeatTime;
			}
			set
			{
				this._repeatTime = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00003694 File Offset: 0x00002694
		// (set) Token: 0x06000094 RID: 148 RVA: 0x000036AC File Offset: 0x000026AC
		public int PaddingTime
		{
			get
			{
				return this._paddingTime;
			}
			set
			{
				this._paddingTime = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000036B8 File Offset: 0x000026B8
		// (set) Token: 0x06000096 RID: 150 RVA: 0x000036D0 File Offset: 0x000026D0
		public byte PlayOrder
		{
			get
			{
				return this._playOrder;
			}
			set
			{
				this._playOrder = value;
			}
		}

		// Token: 0x04000049 RID: 73
		private int _auID;

		// Token: 0x0400004A RID: 74
		private int _chID;

		// Token: 0x0400004B RID: 75
		private string _audioFile;

		// Token: 0x0400004C RID: 76
		private int _audioSize;

		// Token: 0x0400004D RID: 77
		private byte[] _audioData;

		// Token: 0x0400004E RID: 78
		private int _audioLength;

		// Token: 0x0400004F RID: 79
		private byte _repeatTime;

		// Token: 0x04000050 RID: 80
		private int _paddingTime;

		// Token: 0x04000051 RID: 81
		private byte _playOrder;
	}
}
