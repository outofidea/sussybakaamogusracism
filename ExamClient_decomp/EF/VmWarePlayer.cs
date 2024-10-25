using System;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
	// Token: 0x02000012 RID: 18
	internal class VmWarePlayer : VmWareMachine
	{
		// Token: 0x06000058 RID: 88 RVA: 0x000030A8 File Offset: 0x000020A8
		public override bool IsVirtual(BIOS bios)
		{
			return bios.SerialNumber.Contains("vmware");
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000030CC File Offset: 0x000020CC
		public override bool IsVirtual(ComputerSystem computer)
		{
			return computer.Manufacturer.Contains("vmware") || computer.Model.Contains("vmware") || computer.OEMStringArray.Contains("virtual");
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003118 File Offset: 0x00002118
		public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
		{
			return disks.Any((DiskDrive d) => d.Model.Contains("vmware"));
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003150 File Offset: 0x00002150
		public override bool ContainsDevice(IEnumerable<PnPEntity> devices)
		{
			if (!devices.Any((PnPEntity d) => d.Name.Equals("vmware pointing device")))
			{
				if (!devices.Any((PnPEntity d) => d.Name.Contains("vmware sata")))
				{
					if (!devices.Any((PnPEntity d) => d.Name.Equals("vmware usb pointing device")))
					{
						if (!devices.Any((PnPEntity d) => d.Name.Equals("vmware vmci bus device")))
						{
							if (!devices.Any((PnPEntity d) => d.Name.Equals("vmware virtual s scsi disk device")))
							{
								return devices.Any((PnPEntity d) => d.Name.StartsWith("vmware svga"));
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003254 File Offset: 0x00002254
		public override bool ContainsService(IEnumerable<WindowsService> services)
		{
			if (!services.Any((WindowsService s) => s.CommandLine.Contains("vmware") && s.Name.Equals("vmtools")))
			{
				if (!services.Any((WindowsService s) => s.CommandLine.Contains("vmware") && s.Name.Equals("tpvcgateway")))
				{
					return services.Any((WindowsService s) => s.CommandLine.Contains("vmware") && s.Name.Equals("tpautoconnsvc"));
				}
			}
			return true;
		}
	}
}
