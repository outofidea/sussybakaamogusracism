using System;
using System.Collections.Generic;

namespace EF
{
	// Token: 0x02000003 RID: 3
	internal abstract class BaseVirtualEnvironment : IVirtualEnvironment
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14
		public abstract string Name { get; }

		// Token: 0x0600000F RID: 15 RVA: 0x00002298 File Offset: 0x00001298
		public virtual bool ContainsDevice(IEnumerable<PnPEntity> devices)
		{
			return false;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000022AC File Offset: 0x000012AC
		public virtual bool ContainsDisk(IEnumerable<DiskDrive> disks)
		{
			return false;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022C0 File Offset: 0x000012C0
		public virtual bool ContainsProcess(IEnumerable<string> processes)
		{
			return false;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022D4 File Offset: 0x000012D4
		public virtual bool ContainsService(IEnumerable<WindowsService> services)
		{
			return false;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022E8 File Offset: 0x000012E8
		public virtual bool IsVirtual(BIOS bios)
		{
			return false;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022FC File Offset: 0x000012FC
		public virtual bool IsVirtual(ComputerSystem computer)
		{
			return false;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002310 File Offset: 0x00001310
		public virtual bool Assert(ComputerSystem computer, BIOS bios, IEnumerable<DiskDrive> disks, IEnumerable<PnPEntity> devices, IEnumerable<string> processes, IEnumerable<WindowsService> services)
		{
			bool flag = this.IsVirtual(computer);
			bool flag2 = this.IsVirtual(bios);
			bool flag3 = this.ContainsDisk(disks);
			bool flag4 = this.ContainsDevice(devices);
			bool flag5 = this.ContainsProcess(processes);
			bool flag6 = this.ContainsService(services);
			return flag || flag2 || flag3 || flag4 || flag5 || flag6;
		}
	}
}
