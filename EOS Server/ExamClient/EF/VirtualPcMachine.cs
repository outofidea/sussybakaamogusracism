using System;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
	// Token: 0x02000010 RID: 16
	internal class VirtualPcMachine : BaseVirtualEnvironment
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002FCC File Offset: 0x00001FCC
		public override string Name
		{
			get
			{
				return "Microsoft Virtual PC";
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002FE4 File Offset: 0x00001FE4
		public override bool ContainsProcess(IEnumerable<string> services)
		{
			return (services.Contains("vpcmap") && services.Contains("vmsrvc")) || services.Contains("vmusrvc");
		}
	}
}
