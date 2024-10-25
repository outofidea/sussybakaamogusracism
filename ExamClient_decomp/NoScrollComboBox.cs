using System;
using System.Windows.Forms;

namespace ExamClient
{
	// Token: 0x0200001A RID: 26
	public class NoScrollComboBox : ComboBox
	{
		// Token: 0x06000176 RID: 374 RVA: 0x00012CF8 File Offset: 0x00011CF8
		protected override void WndProc(ref Message m)
		{
			bool flag = m.HWnd != base.Handle;
			if (!flag)
			{
				bool flag2 = m.Msg == 522;
				if (!flag2)
				{
					base.WndProc(ref m);
				}
			}
		}
	}
}
