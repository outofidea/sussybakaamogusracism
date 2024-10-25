using System;
using System.Management;

namespace EF
{
	// Token: 0x0200000C RID: 12
	internal class MotherboardDevice : BaseWin32Entity
	{
		// Token: 0x06000047 RID: 71 RVA: 0x000028E8 File Offset: 0x000018E8
		public MotherboardDevice(ManagementBaseObject obj) : base(obj)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002EF4 File Offset: 0x00001EF4
		public override string ToString()
		{
			return base.PrintProperties();
		}
	}
}
