using System;

namespace QuestionLib
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class AudioInPaper : IComparable<AudioInPaper>
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000026AC File Offset: 0x000016AC
		// (set) Token: 0x06000063 RID: 99 RVA: 0x000026C4 File Offset: 0x000016C4
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

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000026D0 File Offset: 0x000016D0
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000026E8 File Offset: 0x000016E8
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

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000026F4 File Offset: 0x000016F4
		// (set) Token: 0x06000067 RID: 103 RVA: 0x0000270C File Offset: 0x0000170C
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

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002718 File Offset: 0x00001718
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002730 File Offset: 0x00001730
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

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000273C File Offset: 0x0000173C
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002754 File Offset: 0x00001754
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

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002760 File Offset: 0x00001760
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002778 File Offset: 0x00001778
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

		// Token: 0x0600006E RID: 110 RVA: 0x00002784 File Offset: 0x00001784
		public int CompareTo(AudioInPaper aip)
		{
			return this.PlayOrder.CompareTo(aip.PlayOrder);
		}

		// Token: 0x04000032 RID: 50
		private int _audioSize;

		// Token: 0x04000033 RID: 51
		private byte[] _audioData;

		// Token: 0x04000034 RID: 52
		private int _audioLength;

		// Token: 0x04000035 RID: 53
		private byte _repeatTime;

		// Token: 0x04000036 RID: 54
		private int _paddingTime;

		// Token: 0x04000037 RID: 55
		private byte _playOrder;
	}
}
