using System;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
	// Token: 0x0200000F RID: 15
	internal class VirtualBoxMachine : BaseVirtualEnvironment
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002F5C File Offset: 0x00001F5C
		public override string Name
		{
			get
			{
				return "VirtualBox";
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002F74 File Offset: 0x00001F74
		public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
		{
			return disks.Any((DiskDrive d) => d.Model.Contains("vbox"));
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002FAC File Offset: 0x00001FAC
		public override bool ContainsProcess(IEnumerable<string> services)
		{
			return services.Contains("vboxservice");
		}
	}
}
