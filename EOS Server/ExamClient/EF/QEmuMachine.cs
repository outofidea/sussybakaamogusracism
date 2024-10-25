using System;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
	// Token: 0x0200000E RID: 14
	internal class QEmuMachine : BaseVirtualEnvironment
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002F0C File Offset: 0x00001F0C
		public override string Name
		{
			get
			{
				return "QEMU";
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002F24 File Offset: 0x00001F24
		public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
		{
			return disks.Any((DiskDrive d) => d.Name.IndexOf("qemu") >= 0);
		}
	}
}
