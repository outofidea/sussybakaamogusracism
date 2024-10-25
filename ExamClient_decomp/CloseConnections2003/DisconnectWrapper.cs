using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace CloseConnections2003
{
	// Token: 0x0200001E RID: 30
	public class DisconnectWrapper
	{
		// Token: 0x06000187 RID: 391
		[DllImport("iphlpapi.dll")]
		private static extern int GetTcpTable(IntPtr pTcpTable, ref int pdwSize, bool bOrder);

		// Token: 0x06000188 RID: 392
		[DllImport("iphlpapi.dll")]
		private static extern int SetTcpEntry(IntPtr pTcprow);

		// Token: 0x06000189 RID: 393
		[DllImport("wsock32.dll")]
		private static extern int ntohs(int netshort);

		// Token: 0x0600018A RID: 394
		[DllImport("wsock32.dll")]
		private static extern int htons(int netshort);

		// Token: 0x0600018B RID: 395 RVA: 0x00012E98 File Offset: 0x00011E98
		public static void CloseRemoteIP(string IP)
		{
			DisconnectWrapper.ConnectionInfo[] tcpTable = DisconnectWrapper.getTcpTable();
			for (int i = 0; i < tcpTable.Length; i++)
			{
				bool flag = tcpTable[i].dwRemoteAddr == DisconnectWrapper.IPStringToInt(IP);
				if (flag)
				{
					tcpTable[i].dwState = 12;
					IntPtr ptrToNewObject = DisconnectWrapper.GetPtrToNewObject(tcpTable[i]);
					int num = DisconnectWrapper.SetTcpEntry(ptrToNewObject);
				}
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00012F04 File Offset: 0x00011F04
		public static void CloseLocalIP(string IP)
		{
			DisconnectWrapper.ConnectionInfo[] tcpTable = DisconnectWrapper.getTcpTable();
			for (int i = 0; i < tcpTable.Length; i++)
			{
				bool flag = tcpTable[i].dwLocalAddr == DisconnectWrapper.IPStringToInt(IP);
				if (flag)
				{
					tcpTable[i].dwState = 12;
					IntPtr ptrToNewObject = DisconnectWrapper.GetPtrToNewObject(tcpTable[i]);
					int num = DisconnectWrapper.SetTcpEntry(ptrToNewObject);
				}
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00012F70 File Offset: 0x00011F70
		public static void CloseRemotePort(int port)
		{
			DisconnectWrapper.ConnectionInfo[] tcpTable = DisconnectWrapper.getTcpTable();
			for (int i = 0; i < tcpTable.Length; i++)
			{
				bool flag = port == DisconnectWrapper.ntohs(tcpTable[i].dwRemotePort);
				if (flag)
				{
					tcpTable[i].dwState = 12;
					IntPtr ptrToNewObject = DisconnectWrapper.GetPtrToNewObject(tcpTable[i]);
					int num = DisconnectWrapper.SetTcpEntry(ptrToNewObject);
				}
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00012FDC File Offset: 0x00011FDC
		public static void CloseLocalPort(int port)
		{
			DisconnectWrapper.ConnectionInfo[] tcpTable = DisconnectWrapper.getTcpTable();
			for (int i = 0; i < tcpTable.Length; i++)
			{
				bool flag = port == DisconnectWrapper.ntohs(tcpTable[i].dwLocalPort);
				if (flag)
				{
					tcpTable[i].dwState = 12;
					IntPtr ptrToNewObject = DisconnectWrapper.GetPtrToNewObject(tcpTable[i]);
					int num = DisconnectWrapper.SetTcpEntry(ptrToNewObject);
				}
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00013048 File Offset: 0x00012048
		public static void CloseConnection(string connectionstring)
		{
			try
			{
				string[] array = connectionstring.Split(new char[]
				{
					'-'
				});
				bool flag = array.Length != 4;
				if (flag)
				{
					throw new Exception("Invalid connectionstring - use the one provided by Connections.");
				}
				string[] array2 = array[0].Split(new char[]
				{
					':'
				});
				string[] array3 = array[1].Split(new char[]
				{
					':'
				});
				string[] array4 = array2[0].Split(new char[]
				{
					'.'
				});
				string[] array5 = array3[0].Split(new char[]
				{
					'.'
				});
				DisconnectWrapper.ConnectionInfo connectionInfo = default(DisconnectWrapper.ConnectionInfo);
				connectionInfo.dwState = 12;
				byte[] value = new byte[]
				{
					byte.Parse(array4[0]),
					byte.Parse(array4[1]),
					byte.Parse(array4[2]),
					byte.Parse(array4[3])
				};
				byte[] value2 = new byte[]
				{
					byte.Parse(array5[0]),
					byte.Parse(array5[1]),
					byte.Parse(array5[2]),
					byte.Parse(array5[3])
				};
				connectionInfo.dwLocalAddr = BitConverter.ToInt32(value, 0);
				connectionInfo.dwRemoteAddr = BitConverter.ToInt32(value2, 0);
				connectionInfo.dwLocalPort = DisconnectWrapper.htons(int.Parse(array2[1]));
				connectionInfo.dwRemotePort = DisconnectWrapper.htons(int.Parse(array3[1]));
				IntPtr ptrToNewObject = DisconnectWrapper.GetPtrToNewObject(connectionInfo);
				int num = DisconnectWrapper.SetTcpEntry(ptrToNewObject);
				bool flag2 = num == -1;
				if (flag2)
				{
					throw new Exception("Unsuccessful");
				}
				bool flag3 = num == 65;
				if (flag3)
				{
					throw new Exception("User has no sufficient privilege to execute this API successfully");
				}
				bool flag4 = num == 87;
				if (flag4)
				{
					throw new Exception("Specified port is not in state to be closed down");
				}
				bool flag5 = num != 0;
				if (flag5)
				{
					throw new Exception("Unknown error (" + num + ")");
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00013240 File Offset: 0x00012240
		public static string[] Connections()
		{
			return DisconnectWrapper.Connections(DisconnectWrapper.ConnectionState.All);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00013258 File Offset: 0x00012258
		public static string[] Connections(DisconnectWrapper.ConnectionState state)
		{
			DisconnectWrapper.ConnectionInfo[] tcpTable = DisconnectWrapper.getTcpTable();
			ArrayList arrayList = new ArrayList();
			foreach (DisconnectWrapper.ConnectionInfo connectionInfo in tcpTable)
			{
				bool flag = state == DisconnectWrapper.ConnectionState.All || state == (DisconnectWrapper.ConnectionState)connectionInfo.dwState;
				if (flag)
				{
					string text = DisconnectWrapper.IPIntToString(connectionInfo.dwLocalAddr) + ":" + DisconnectWrapper.ntohs(connectionInfo.dwLocalPort);
					string text2 = DisconnectWrapper.IPIntToString(connectionInfo.dwRemoteAddr) + ":" + DisconnectWrapper.ntohs(connectionInfo.dwRemotePort);
					ArrayList arrayList2 = arrayList;
					object[] array2 = new object[7];
					array2[0] = text;
					array2[1] = "-";
					array2[2] = text2;
					array2[3] = "-";
					int num = 4;
					DisconnectWrapper.ConnectionState dwState = (DisconnectWrapper.ConnectionState)connectionInfo.dwState;
					array2[num] = dwState.ToString();
					array2[5] = "-";
					array2[6] = connectionInfo.dwState;
					arrayList2.Add(string.Concat(array2));
				}
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00013378 File Offset: 0x00012378
		private static DisconnectWrapper.ConnectionInfo[] getTcpTable()
		{
			IntPtr intPtr = IntPtr.Zero;
			bool flag = false;
			DisconnectWrapper.ConnectionInfo[] result;
			try
			{
				int cb = 0;
				DisconnectWrapper.GetTcpTable(IntPtr.Zero, ref cb, false);
				intPtr = Marshal.AllocCoTaskMem(cb);
				flag = true;
				DisconnectWrapper.GetTcpTable(intPtr, ref cb, false);
				int num = Marshal.ReadInt32(intPtr);
				IntPtr intPtr2 = (IntPtr)((int)intPtr + 4);
				DisconnectWrapper.ConnectionInfo[] array = new DisconnectWrapper.ConnectionInfo[num];
				int num2 = Marshal.SizeOf(default(DisconnectWrapper.ConnectionInfo));
				for (int i = 0; i < num; i++)
				{
					array[i] = (DisconnectWrapper.ConnectionInfo)Marshal.PtrToStructure(intPtr2, typeof(DisconnectWrapper.ConnectionInfo));
					intPtr2 = (IntPtr)((int)intPtr2 + num2);
				}
				result = array;
			}
			catch (Exception ex)
			{
				throw new Exception(string.Concat(new string[]
				{
					"getTcpTable failed! [",
					ex.GetType().ToString(),
					",",
					ex.Message,
					"]"
				}));
			}
			finally
			{
				bool flag2 = flag;
				if (flag2)
				{
					Marshal.FreeCoTaskMem(intPtr);
				}
			}
			return result;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000134AC File Offset: 0x000124AC
		private static IntPtr GetPtrToNewObject(object obj)
		{
			IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(obj));
			Marshal.StructureToPtr(obj, intPtr, false);
			return intPtr;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000134D4 File Offset: 0x000124D4
		private static int IPStringToInt(string IP)
		{
			bool flag = IP.IndexOf(".") < 0;
			if (flag)
			{
				throw new Exception("Invalid IP address");
			}
			string[] array = IP.Split(new char[]
			{
				'.'
			});
			bool flag2 = array.Length != 4;
			if (flag2)
			{
				throw new Exception("Invalid IP address");
			}
			byte[] value = new byte[]
			{
				byte.Parse(array[0]),
				byte.Parse(array[1]),
				byte.Parse(array[2]),
				byte.Parse(array[3])
			};
			return BitConverter.ToInt32(value, 0);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0001356C File Offset: 0x0001256C
		private static string IPIntToString(int IP)
		{
			byte[] bytes = BitConverter.GetBytes(IP);
			return string.Concat(new object[]
			{
				bytes[0],
				".",
				bytes[1],
				".",
				bytes[2],
				".",
				bytes[3]
			});
		}

		// Token: 0x02000030 RID: 48
		public enum ConnectionState
		{
			// Token: 0x040001AA RID: 426
			All,
			// Token: 0x040001AB RID: 427
			Closed,
			// Token: 0x040001AC RID: 428
			Listen,
			// Token: 0x040001AD RID: 429
			Syn_Sent,
			// Token: 0x040001AE RID: 430
			Syn_Rcvd,
			// Token: 0x040001AF RID: 431
			Established,
			// Token: 0x040001B0 RID: 432
			Fin_Wait1,
			// Token: 0x040001B1 RID: 433
			Fin_Wait2,
			// Token: 0x040001B2 RID: 434
			Close_Wait,
			// Token: 0x040001B3 RID: 435
			Closing,
			// Token: 0x040001B4 RID: 436
			Last_Ack,
			// Token: 0x040001B5 RID: 437
			Time_Wait,
			// Token: 0x040001B6 RID: 438
			Delete_TCB
		}

		// Token: 0x02000031 RID: 49
		private struct ConnectionInfo
		{
			// Token: 0x040001B7 RID: 439
			public int dwState;

			// Token: 0x040001B8 RID: 440
			public int dwLocalAddr;

			// Token: 0x040001B9 RID: 441
			public int dwLocalPort;

			// Token: 0x040001BA RID: 442
			public int dwRemoteAddr;

			// Token: 0x040001BB RID: 443
			public int dwRemotePort;
		}
	}
}
