using System;
using System.Management;

namespace EF
{
	// Token: 0x02000007 RID: 7
	internal class ComputerSystem : BaseWin32Entity
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000287C File Offset: 0x0000187C
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002884 File Offset: 0x00001884
		public string OEMStringArray { get; set; }

		// Token: 0x06000031 RID: 49 RVA: 0x00002890 File Offset: 0x00001890
		public ComputerSystem(ManagementBaseObject obj) : base(obj)
		{
			object obj2 = obj["OEMStringArray"];
			bool flag = obj2 != null;
			if (flag)
			{
				this.OEMStringArray = base.ToJSON(obj2).ToLower();
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000028D0 File Offset: 0x000018D0
		public override string ToString()
		{
			return base.PrintProperties();
		}
	}
}
