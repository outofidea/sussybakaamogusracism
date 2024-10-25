using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace EF
{
	// Token: 0x02000006 RID: 6
	internal class BIOS : BaseWin32Entity
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002740 File Offset: 0x00001740
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002748 File Offset: 0x00001748
		public IEnumerable<BiosCharacteristics> Characteristics { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002751 File Offset: 0x00001751
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002759 File Offset: 0x00001759
		public string SerialNumber { get; private set; }

		// Token: 0x0600002D RID: 45 RVA: 0x00002764 File Offset: 0x00001764
		public BIOS(ManagementBaseObject obj) : base(obj)
		{
			ushort[] source = (ushort[])obj["BiosCharacteristics"];
			this.Characteristics = (from c in source
			select (BiosCharacteristics)c).ToArray<BiosCharacteristics>();
			this.SerialNumber = base.ParseValue<string>(obj, "SerialNumber");
			bool flag = !string.IsNullOrEmpty(this.SerialNumber);
			if (flag)
			{
				this.SerialNumber = this.SerialNumber.ToLower();
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000027F4 File Offset: 0x000017F4
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(base.PrintProperties());
			foreach (BiosCharacteristics biosCharacteristics in this.Characteristics)
			{
				string name = Enum.GetName(typeof(BiosCharacteristics), biosCharacteristics);
				stringBuilder.AppendLine(name);
			}
			return stringBuilder.ToString();
		}
	}
}
