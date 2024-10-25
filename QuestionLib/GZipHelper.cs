using System;
using System.IO;
using System.IO.Compression;

namespace QuestionLib
{
	// Token: 0x02000002 RID: 2
	public class GZipHelper
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public static byte[] Compress(byte[] bytData)
		{
			byte[] result;
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				Stream stream = new GZipStream(memoryStream, CompressionMode.Compress);
				stream.Write(bytData, 0, bytData.Length);
				stream.Close();
				byte[] array = memoryStream.ToArray();
				result = array;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020A4 File Offset: 0x000010A4
		public static byte[] DeCompress(byte[] bytInput, int originSize)
		{
			Stream stream = new GZipStream(new MemoryStream(bytInput), CompressionMode.Decompress);
			byte[] array = new byte[originSize];
			stream.Read(array, 0, originSize);
			return array;
		}
	}
}
