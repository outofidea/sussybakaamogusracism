using System;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
	// Token: 0x0200000A RID: 10
	internal class HyperVMachine : BaseVirtualEnvironment
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002E64 File Offset: 0x00001E64
		public override string Name
		{
			get
			{
				return "Microsoft Hyper-V";
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002E7C File Offset: 0x00001E7C
		public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
		{
			return disks.Any((DiskDrive d) => d.Caption.Contains("virtual"));
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002EB4 File Offset: 0x00001EB4
		public override bool IsVirtual(ComputerSystem computer)
		{
			return computer.Manufacturer.Contains("microsoft") && computer.Model.Contains("virtual");
		}
	}
}
