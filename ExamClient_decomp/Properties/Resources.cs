using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ExamClient.Properties
{
	// Token: 0x0200001D RID: 29
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000180 RID: 384 RVA: 0x00012D94 File Offset: 0x00011D94
		internal Resources()
		{
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00012DA0 File Offset: 0x00011DA0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("ExamClient.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00012DE8 File Offset: 0x00011DE8
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00012DFF File Offset: 0x00011DFF
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00012E08 File Offset: 0x00011E08
		internal static Bitmap Test
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Test", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00012E38 File Offset: 0x00011E38
		internal static Bitmap VN
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("VN", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00012E68 File Offset: 0x00011E68
		internal static Bitmap VN1
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("VN1", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x04000179 RID: 377
		private static ResourceManager resourceMan;

		// Token: 0x0400017A RID: 378
		private static CultureInfo resourceCulture;
	}
}
