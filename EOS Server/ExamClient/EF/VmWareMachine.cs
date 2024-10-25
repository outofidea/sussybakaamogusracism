using System;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
	// Token: 0x02000011 RID: 17
	internal abstract class VmWareMachine : BaseVirtualEnvironment
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00003020 File Offset: 0x00002020
		public override string Name
		{
			get
			{
				return "VMware";
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003038 File Offset: 0x00002038
		public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
		{
			return disks.Any((DiskDrive d) => d.Name.Contains("vmware"));
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003070 File Offset: 0x00002070
		public override bool IsVirtual(ComputerSystem computer)
		{
			return computer.Manufacturer.Contains("vmware") && computer.Model.Contains("virtual");
		}
	}
}
