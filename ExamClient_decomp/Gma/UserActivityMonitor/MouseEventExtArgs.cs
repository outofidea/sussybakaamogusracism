using System;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
	// Token: 0x02000015 RID: 21
	public class MouseEventExtArgs : MouseEventArgs
	{
		// Token: 0x060000C9 RID: 201 RVA: 0x00004853 File Offset: 0x00003853
		public MouseEventExtArgs(MouseButtons buttons, int clicks, int x, int y, int delta) : base(buttons, clicks, x, y, delta)
		{
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004864 File Offset: 0x00003864
		internal MouseEventExtArgs(MouseEventArgs e) : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
		{
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000CB RID: 203 RVA: 0x0000488C File Offset: 0x0000388C
		// (set) Token: 0x060000CC RID: 204 RVA: 0x000048A4 File Offset: 0x000038A4
		public bool Handled
		{
			get
			{
				return this.m_Handled;
			}
			set
			{
				this.m_Handled = value;
			}
		}

		// Token: 0x040000A0 RID: 160
		private bool m_Handled;
	}
}
