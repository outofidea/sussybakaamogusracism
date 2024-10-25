using System;
using System.Collections.Generic;

namespace EF
{
	// Token: 0x0200000B RID: 11
	internal interface IVirtualEnvironment
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003F RID: 63
		string Name { get; }

		// Token: 0x06000040 RID: 64
		bool IsVirtual(ComputerSystem computer);

		// Token: 0x06000041 RID: 65
		bool IsVirtual(BIOS bios);

		// Token: 0x06000042 RID: 66
		bool ContainsDisk(IEnumerable<DiskDrive> disks);

		// Token: 0x06000043 RID: 67
		bool ContainsDevice(IEnumerable<PnPEntity> devices);

		// Token: 0x06000044 RID: 68
		bool ContainsProcess(IEnumerable<string> processes);

		// Token: 0x06000045 RID: 69
		bool ContainsService(IEnumerable<WindowsService> services);

		// Token: 0x06000046 RID: 70
		bool Assert(ComputerSystem computer, BIOS bios, IEnumerable<DiskDrive> disks, IEnumerable<PnPEntity> devices, IEnumerable<string> processes, IEnumerable<WindowsService> services);
	}
}
