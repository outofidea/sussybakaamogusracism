using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using System.Web.Script.Serialization;

namespace EF
{
	// Token: 0x02000004 RID: 4
	internal abstract class BaseWin32Entity
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000236F File Offset: 0x0000136F
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002377 File Offset: 0x00001377
		public Dictionary<string, object> Properties { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002380 File Offset: 0x00001380
		// (set) Token: 0x0600001A RID: 26 RVA: 0x00002388 File Offset: 0x00001388
		public string Caption { get; protected set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002391 File Offset: 0x00001391
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002399 File Offset: 0x00001399
		public string Name { get; protected set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000023A2 File Offset: 0x000013A2
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000023AA File Offset: 0x000013AA
		public string Manufacturer { get; protected set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000023B3 File Offset: 0x000013B3
		// (set) Token: 0x06000020 RID: 32 RVA: 0x000023BB File Offset: 0x000013BB
		public string Model { get; protected set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000023C4 File Offset: 0x000013C4
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000023CC File Offset: 0x000013CC
		public string Description { get; protected set; }

		// Token: 0x06000023 RID: 35 RVA: 0x000023D8 File Offset: 0x000013D8
		public BaseWin32Entity(ManagementBaseObject obj)
		{
			this.Properties = new Dictionary<string, object>();
			foreach (PropertyData propertyData in obj.Properties)
			{
				this.Properties.Add(propertyData.Name, propertyData.Value);
			}
			this.Caption = this.ParseValue<string>(obj, "Caption");
			this.Name = this.ParseValue<string>(obj, "Name");
			this.Manufacturer = this.ParseValue<string>(obj, "Manufacturer");
			this.Model = this.ParseValue<string>(obj, "Model");
			this.Description = this.ParseValue<string>(obj, "Description");
			bool flag = !string.IsNullOrEmpty(this.Caption);
			if (flag)
			{
				this.Caption = this.Caption.ToLower();
			}
			bool flag2 = !string.IsNullOrEmpty(this.Name);
			if (flag2)
			{
				this.Name = this.Name.ToLower();
			}
			bool flag3 = !string.IsNullOrEmpty(this.Manufacturer);
			if (flag3)
			{
				this.Manufacturer = this.Manufacturer.ToLower();
			}
			bool flag4 = !string.IsNullOrEmpty(this.Model);
			if (flag4)
			{
				this.Model = this.Model.ToLower();
			}
			bool flag5 = !string.IsNullOrEmpty(this.Description);
			if (flag5)
			{
				this.Description = this.Description.ToLower();
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002570 File Offset: 0x00001570
		public override string ToString()
		{
			return string.Format("manufacturer={0}, name={1}, model={2}, caption={3}, description={4}", new object[]
			{
				this.Manufacturer,
				this.Name,
				this.Model,
				this.Caption,
				this.Description
			});
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000025C0 File Offset: 0x000015C0
		protected string PrintProperties()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text in this.Properties.Keys)
			{
				stringBuilder.AppendLine(string.Format("{0} = {1}", text, this.GetValue(this.Properties[text])));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002648 File Offset: 0x00001648
		private object GetValue(object value)
		{
			bool flag = value == null;
			object result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				bool isArray = value.GetType().IsArray;
				bool flag2 = isArray;
				if (flag2)
				{
					result = this.ToJSON(value);
				}
				else
				{
					result = value;
				}
			}
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002688 File Offset: 0x00001688
		protected string ToJSON(object value)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			return javaScriptSerializer.Serialize(value);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000026A8 File Offset: 0x000016A8
		protected T ParseValue<T>(ManagementBaseObject obj, string key)
		{
			object obj2 = null;
			try
			{
				obj2 = obj[key];
			}
			catch
			{
			}
			bool flag = obj2 == null;
			T result;
			if (flag)
			{
				bool flag2 = typeof(T) == typeof(string);
				if (flag2)
				{
					result = (T)((object)Convert.ChangeType(string.Empty, typeof(T)));
				}
				else
				{
					result = default(T);
				}
			}
			else
			{
				result = (T)((object)Convert.ChangeType(obj2, typeof(T)));
			}
			return result;
		}
	}
}
