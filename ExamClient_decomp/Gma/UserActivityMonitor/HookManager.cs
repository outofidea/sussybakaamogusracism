using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
	// Token: 0x02000014 RID: 20
	public static class HookManager
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00003ADC File Offset: 0x00002ADC
		private static int MouseHookProc(int nCode, int wParam, IntPtr lParam)
		{
			bool flag = nCode >= 0;
			if (flag)
			{
				HookManager.MouseLLHookStruct mouseLLHookStruct = (HookManager.MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(HookManager.MouseLLHookStruct));
				MouseButtons buttons = MouseButtons.None;
				short num = 0;
				int num2 = 0;
				bool flag2 = false;
				bool flag3 = false;
				switch (wParam)
				{
				case 513:
					flag2 = true;
					buttons = MouseButtons.Left;
					num2 = 1;
					break;
				case 514:
					flag3 = true;
					buttons = MouseButtons.Left;
					num2 = 1;
					break;
				case 515:
					buttons = MouseButtons.Left;
					num2 = 2;
					break;
				case 516:
					flag2 = true;
					buttons = MouseButtons.Right;
					num2 = 1;
					break;
				case 517:
					flag3 = true;
					buttons = MouseButtons.Right;
					num2 = 1;
					break;
				case 518:
					buttons = MouseButtons.Right;
					num2 = 2;
					break;
				case 522:
					num = (short)(mouseLLHookStruct.MouseData >> 16 & 65535);
					break;
				}
				MouseEventExtArgs mouseEventExtArgs = new MouseEventExtArgs(buttons, num2, mouseLLHookStruct.Point.X, mouseLLHookStruct.Point.Y, (int)num);
				bool flag4 = HookManager.s_MouseUp != null && flag3;
				if (flag4)
				{
					HookManager.s_MouseUp(null, mouseEventExtArgs);
				}
				bool flag5 = HookManager.s_MouseDown != null && flag2;
				if (flag5)
				{
					HookManager.s_MouseDown(null, mouseEventExtArgs);
				}
				bool flag6 = HookManager.s_MouseClick != null && num2 > 0;
				if (flag6)
				{
					HookManager.s_MouseClick(null, mouseEventExtArgs);
				}
				bool flag7 = HookManager.s_MouseClickExt != null && num2 > 0;
				if (flag7)
				{
					HookManager.s_MouseClickExt(null, mouseEventExtArgs);
				}
				bool flag8 = HookManager.s_MouseDoubleClick != null && num2 == 2;
				if (flag8)
				{
					HookManager.s_MouseDoubleClick(null, mouseEventExtArgs);
				}
				bool flag9 = HookManager.s_MouseWheel != null && num != 0;
				if (flag9)
				{
					HookManager.s_MouseWheel(null, mouseEventExtArgs);
				}
				bool flag10 = (HookManager.s_MouseMove != null || HookManager.s_MouseMoveExt != null) && (HookManager.m_OldX != mouseLLHookStruct.Point.X || HookManager.m_OldY != mouseLLHookStruct.Point.Y);
				if (flag10)
				{
					HookManager.m_OldX = mouseLLHookStruct.Point.X;
					HookManager.m_OldY = mouseLLHookStruct.Point.Y;
					bool flag11 = HookManager.s_MouseMove != null;
					if (flag11)
					{
						HookManager.s_MouseMove(null, mouseEventExtArgs);
					}
					bool flag12 = HookManager.s_MouseMoveExt != null;
					if (flag12)
					{
						HookManager.s_MouseMoveExt(null, mouseEventExtArgs);
					}
				}
				bool handled = mouseEventExtArgs.Handled;
				if (handled)
				{
					return -1;
				}
			}
			return HookManager.CallNextHookEx(HookManager.s_MouseHookHandle, nCode, wParam, lParam);
		}

		// Token: 0x0600008C RID: 140
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x0600008D RID: 141 RVA: 0x00003D74 File Offset: 0x00002D74
		private static void EnsureSubscribedToGlobalMouseEvents()
		{
			bool flag = HookManager.s_MouseHookHandle == 0;
			if (flag)
			{
				HookManager.s_MouseDelegate = new HookManager.HookProc(HookManager.MouseHookProc);
				Process currentProcess = Process.GetCurrentProcess();
				ProcessModule mainModule = currentProcess.MainModule;
				IntPtr moduleHandle = HookManager.GetModuleHandle(mainModule.ModuleName);
				HookManager.s_MouseHookHandle = HookManager.SetWindowsHookEx(14, HookManager.s_MouseDelegate, moduleHandle, 0);
				bool flag2 = HookManager.s_MouseHookHandle == 0;
				if (flag2)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
				}
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003DE4 File Offset: 0x00002DE4
		private static void TryUnsubscribeFromGlobalMouseEvents()
		{
			bool flag = HookManager.s_MouseClick == null && HookManager.s_MouseDown == null && HookManager.s_MouseMove == null && HookManager.s_MouseUp == null && HookManager.s_MouseClickExt == null && HookManager.s_MouseMoveExt == null && HookManager.s_MouseWheel == null;
			if (flag)
			{
				HookManager.ForceUnsunscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003E34 File Offset: 0x00002E34
		private static void ForceUnsunscribeFromGlobalMouseEvents()
		{
			bool flag = HookManager.s_MouseHookHandle != 0;
			if (flag)
			{
				int num = HookManager.UnhookWindowsHookEx(HookManager.s_MouseHookHandle);
				HookManager.s_MouseHookHandle = 0;
				HookManager.s_MouseDelegate = null;
				bool flag2 = num == 0;
				if (flag2)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
				}
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003E78 File Offset: 0x00002E78
		private static int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
		{
			bool flag = false;
			bool flag2 = nCode >= 0;
			if (flag2)
			{
				HookManager.KeyboardHookStruct keyboardHookStruct = (HookManager.KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(HookManager.KeyboardHookStruct));
				bool flag3 = HookManager.s_KeyDown != null && (wParam == 256 || wParam == 260);
				if (flag3)
				{
					Keys virtualKeyCode = (Keys)keyboardHookStruct.VirtualKeyCode;
					KeyEventArgs keyEventArgs = new KeyEventArgs(virtualKeyCode);
					HookManager.s_KeyDown(null, keyEventArgs);
					flag = keyEventArgs.Handled;
				}
				bool flag4 = HookManager.s_KeyPress != null && wParam == 256;
				if (flag4)
				{
					bool flag5 = (HookManager.GetKeyState(16) & 128) == 128;
					bool keyState = HookManager.GetKeyState(20) != 0;
					byte[] array = new byte[256];
					HookManager.GetKeyboardState(array);
					byte[] array2 = new byte[2];
					bool flag6 = HookManager.ToAscii(keyboardHookStruct.VirtualKeyCode, keyboardHookStruct.ScanCode, array, array2, keyboardHookStruct.Flags) == 1;
					if (flag6)
					{
						char c = (char)array2[0];
						bool flag7 = (keyState ^ flag5) && char.IsLetter(c);
						if (flag7)
						{
							c = char.ToUpper(c);
						}
						KeyPressEventArgs keyPressEventArgs = new KeyPressEventArgs(c);
						HookManager.s_KeyPress(null, keyPressEventArgs);
						flag = (flag || keyPressEventArgs.Handled);
					}
				}
				bool flag8 = HookManager.s_KeyUp != null && (wParam == 257 || wParam == 261);
				if (flag8)
				{
					Keys virtualKeyCode2 = (Keys)keyboardHookStruct.VirtualKeyCode;
					KeyEventArgs keyEventArgs2 = new KeyEventArgs(virtualKeyCode2);
					HookManager.s_KeyUp(null, keyEventArgs2);
					flag = (flag || keyEventArgs2.Handled);
				}
			}
			bool flag9 = flag;
			int result;
			if (flag9)
			{
				result = -1;
			}
			else
			{
				result = HookManager.CallNextHookEx(HookManager.s_KeyboardHookHandle, nCode, wParam, lParam);
			}
			return result;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000403C File Offset: 0x0000303C
		private static void EnsureSubscribedToGlobalKeyboardEvents()
		{
			bool flag = HookManager.s_KeyboardHookHandle == 0;
			if (flag)
			{
				HookManager.s_KeyboardDelegate = new HookManager.HookProc(HookManager.KeyboardHookProc);
				Process currentProcess = Process.GetCurrentProcess();
				ProcessModule mainModule = currentProcess.MainModule;
				IntPtr moduleHandle = HookManager.GetModuleHandle(mainModule.ModuleName);
				HookManager.s_KeyboardHookHandle = HookManager.SetWindowsHookEx(13, HookManager.s_KeyboardDelegate, moduleHandle, 0);
				bool flag2 = HookManager.s_KeyboardHookHandle == 0;
				if (flag2)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
				}
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000040AC File Offset: 0x000030AC
		private static void TryUnsubscribeFromGlobalKeyboardEvents()
		{
			bool flag = HookManager.s_KeyDown == null && HookManager.s_KeyUp == null && HookManager.s_KeyPress == null;
			if (flag)
			{
				HookManager.ForceUnsunscribeFromGlobalKeyboardEvents();
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000040E0 File Offset: 0x000030E0
		private static void ForceUnsunscribeFromGlobalKeyboardEvents()
		{
			bool flag = HookManager.s_KeyboardHookHandle != 0;
			if (flag)
			{
				int num = HookManager.UnhookWindowsHookEx(HookManager.s_KeyboardHookHandle);
				HookManager.s_KeyboardHookHandle = 0;
				HookManager.s_KeyboardDelegate = null;
				bool flag2 = num == 0;
				if (flag2)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
				}
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000094 RID: 148 RVA: 0x00004124 File Offset: 0x00003124
		// (remove) Token: 0x06000095 RID: 149 RVA: 0x00004158 File Offset: 0x00003158
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event MouseEventHandler s_MouseMove;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000096 RID: 150 RVA: 0x0000418B File Offset: 0x0000318B
		// (remove) Token: 0x06000097 RID: 151 RVA: 0x0000419B File Offset: 0x0000319B
		public static event MouseEventHandler MouseMove
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseMove += value;
			}
			remove
			{
				HookManager.s_MouseMove -= value;
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000098 RID: 152 RVA: 0x000041AC File Offset: 0x000031AC
		// (remove) Token: 0x06000099 RID: 153 RVA: 0x000041E0 File Offset: 0x000031E0
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event EventHandler<MouseEventExtArgs> s_MouseMoveExt;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600009A RID: 154 RVA: 0x00004213 File Offset: 0x00003213
		// (remove) Token: 0x0600009B RID: 155 RVA: 0x00004223 File Offset: 0x00003223
		public static event EventHandler<MouseEventExtArgs> MouseMoveExt
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseMoveExt += value;
			}
			remove
			{
				HookManager.s_MouseMoveExt -= value;
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600009C RID: 156 RVA: 0x00004234 File Offset: 0x00003234
		// (remove) Token: 0x0600009D RID: 157 RVA: 0x00004268 File Offset: 0x00003268
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event MouseEventHandler s_MouseClick;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600009E RID: 158 RVA: 0x0000429B File Offset: 0x0000329B
		// (remove) Token: 0x0600009F RID: 159 RVA: 0x000042AB File Offset: 0x000032AB
		public static event MouseEventHandler MouseClick
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseClick += value;
			}
			remove
			{
				HookManager.s_MouseClick -= value;
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060000A0 RID: 160 RVA: 0x000042BC File Offset: 0x000032BC
		// (remove) Token: 0x060000A1 RID: 161 RVA: 0x000042F0 File Offset: 0x000032F0
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event EventHandler<MouseEventExtArgs> s_MouseClickExt;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060000A2 RID: 162 RVA: 0x00004323 File Offset: 0x00003323
		// (remove) Token: 0x060000A3 RID: 163 RVA: 0x00004333 File Offset: 0x00003333
		public static event EventHandler<MouseEventExtArgs> MouseClickExt
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseClickExt += value;
			}
			remove
			{
				HookManager.s_MouseClickExt -= value;
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060000A4 RID: 164 RVA: 0x00004344 File Offset: 0x00003344
		// (remove) Token: 0x060000A5 RID: 165 RVA: 0x00004378 File Offset: 0x00003378
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event MouseEventHandler s_MouseDown;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000A6 RID: 166 RVA: 0x000043AB File Offset: 0x000033AB
		// (remove) Token: 0x060000A7 RID: 167 RVA: 0x000043BB File Offset: 0x000033BB
		public static event MouseEventHandler MouseDown
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseDown += value;
			}
			remove
			{
				HookManager.s_MouseDown -= value;
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000A8 RID: 168 RVA: 0x000043CC File Offset: 0x000033CC
		// (remove) Token: 0x060000A9 RID: 169 RVA: 0x00004400 File Offset: 0x00003400
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event MouseEventHandler s_MouseUp;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060000AA RID: 170 RVA: 0x00004433 File Offset: 0x00003433
		// (remove) Token: 0x060000AB RID: 171 RVA: 0x00004443 File Offset: 0x00003443
		public static event MouseEventHandler MouseUp
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseUp += value;
			}
			remove
			{
				HookManager.s_MouseUp -= value;
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060000AC RID: 172 RVA: 0x00004454 File Offset: 0x00003454
		// (remove) Token: 0x060000AD RID: 173 RVA: 0x00004488 File Offset: 0x00003488
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event MouseEventHandler s_MouseWheel;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060000AE RID: 174 RVA: 0x000044BB File Offset: 0x000034BB
		// (remove) Token: 0x060000AF RID: 175 RVA: 0x000044CB File Offset: 0x000034CB
		public static event MouseEventHandler MouseWheel
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseWheel += value;
			}
			remove
			{
				HookManager.s_MouseWheel -= value;
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060000B0 RID: 176 RVA: 0x000044DC File Offset: 0x000034DC
		// (remove) Token: 0x060000B1 RID: 177 RVA: 0x00004510 File Offset: 0x00003510
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event MouseEventHandler s_MouseDoubleClick;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060000B2 RID: 178 RVA: 0x00004544 File Offset: 0x00003544
		// (remove) Token: 0x060000B3 RID: 179 RVA: 0x000045B4 File Offset: 0x000035B4
		public static event MouseEventHandler MouseDoubleClick
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				bool flag = HookManager.s_MouseDoubleClick == null;
				if (flag)
				{
					HookManager.s_DoubleClickTimer = new Timer
					{
						Interval = HookManager.GetDoubleClickTime(),
						Enabled = false
					};
					HookManager.s_DoubleClickTimer.Tick += HookManager.DoubleClickTimeElapsed;
					HookManager.MouseUp += HookManager.OnMouseUp;
				}
				HookManager.s_MouseDoubleClick += value;
			}
			remove
			{
				bool flag = HookManager.s_MouseDoubleClick != null;
				if (flag)
				{
					HookManager.s_MouseDoubleClick -= value;
					bool flag2 = HookManager.s_MouseDoubleClick == null;
					if (flag2)
					{
						HookManager.MouseUp -= HookManager.OnMouseUp;
						HookManager.s_DoubleClickTimer.Tick -= HookManager.DoubleClickTimeElapsed;
						HookManager.s_DoubleClickTimer = null;
					}
				}
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000461A File Offset: 0x0000361A
		private static void DoubleClickTimeElapsed(object sender, EventArgs e)
		{
			HookManager.s_DoubleClickTimer.Enabled = false;
			HookManager.s_PrevClickedButton = MouseButtons.None;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004630 File Offset: 0x00003630
		private static void OnMouseUp(object sender, MouseEventArgs e)
		{
			bool flag = e.Clicks < 1;
			if (!flag)
			{
				bool flag2 = e.Button.Equals(HookManager.s_PrevClickedButton);
				if (flag2)
				{
					bool flag3 = HookManager.s_MouseDoubleClick != null;
					if (flag3)
					{
						HookManager.s_MouseDoubleClick(null, e);
					}
					HookManager.s_DoubleClickTimer.Enabled = false;
					HookManager.s_PrevClickedButton = MouseButtons.None;
				}
				else
				{
					HookManager.s_DoubleClickTimer.Enabled = true;
					HookManager.s_PrevClickedButton = e.Button;
				}
			}
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060000B6 RID: 182 RVA: 0x000046BC File Offset: 0x000036BC
		// (remove) Token: 0x060000B7 RID: 183 RVA: 0x000046F0 File Offset: 0x000036F0
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event KeyPressEventHandler s_KeyPress;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060000B8 RID: 184 RVA: 0x00004723 File Offset: 0x00003723
		// (remove) Token: 0x060000B9 RID: 185 RVA: 0x00004733 File Offset: 0x00003733
		public static event KeyPressEventHandler KeyPress
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalKeyboardEvents();
				HookManager.s_KeyPress += value;
			}
			remove
			{
				HookManager.s_KeyPress -= value;
				HookManager.TryUnsubscribeFromGlobalKeyboardEvents();
			}
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060000BA RID: 186 RVA: 0x00004744 File Offset: 0x00003744
		// (remove) Token: 0x060000BB RID: 187 RVA: 0x00004778 File Offset: 0x00003778
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event KeyEventHandler s_KeyUp;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060000BC RID: 188 RVA: 0x000047AB File Offset: 0x000037AB
		// (remove) Token: 0x060000BD RID: 189 RVA: 0x000047BB File Offset: 0x000037BB
		public static event KeyEventHandler KeyUp
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalKeyboardEvents();
				HookManager.s_KeyUp += value;
			}
			remove
			{
				HookManager.s_KeyUp -= value;
				HookManager.TryUnsubscribeFromGlobalKeyboardEvents();
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060000BE RID: 190 RVA: 0x000047CC File Offset: 0x000037CC
		// (remove) Token: 0x060000BF RID: 191 RVA: 0x00004800 File Offset: 0x00003800
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static event KeyEventHandler s_KeyDown;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060000C0 RID: 192 RVA: 0x00004833 File Offset: 0x00003833
		// (remove) Token: 0x060000C1 RID: 193 RVA: 0x00004843 File Offset: 0x00003843
		public static event KeyEventHandler KeyDown
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalKeyboardEvents();
				HookManager.s_KeyDown += value;
			}
			remove
			{
				HookManager.s_KeyDown -= value;
				HookManager.TryUnsubscribeFromGlobalKeyboardEvents();
			}
		}

		// Token: 0x060000C2 RID: 194
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		private static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

		// Token: 0x060000C3 RID: 195
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int SetWindowsHookEx(int idHook, HookManager.HookProc lpfn, IntPtr hMod, int dwThreadId);

		// Token: 0x060000C4 RID: 196
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int UnhookWindowsHookEx(int idHook);

		// Token: 0x060000C5 RID: 197
		[DllImport("user32")]
		public static extern int GetDoubleClickTime();

		// Token: 0x060000C6 RID: 198
		[DllImport("user32")]
		private static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

		// Token: 0x060000C7 RID: 199
		[DllImport("user32")]
		private static extern int GetKeyboardState(byte[] pbKeyState);

		// Token: 0x060000C8 RID: 200
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		private static extern short GetKeyState(int vKey);

		// Token: 0x04000077 RID: 119
		private static HookManager.HookProc s_MouseDelegate;

		// Token: 0x04000078 RID: 120
		private static int s_MouseHookHandle;

		// Token: 0x04000079 RID: 121
		private static int m_OldX;

		// Token: 0x0400007A RID: 122
		private static int m_OldY;

		// Token: 0x0400007B RID: 123
		private static HookManager.HookProc s_KeyboardDelegate;

		// Token: 0x0400007C RID: 124
		private static int s_KeyboardHookHandle;

		// Token: 0x04000085 RID: 133
		private static MouseButtons s_PrevClickedButton;

		// Token: 0x04000086 RID: 134
		private static Timer s_DoubleClickTimer;

		// Token: 0x0400008A RID: 138
		private const int WH_MOUSE_LL = 14;

		// Token: 0x0400008B RID: 139
		private const int WH_KEYBOARD_LL = 13;

		// Token: 0x0400008C RID: 140
		private const int WH_MOUSE = 7;

		// Token: 0x0400008D RID: 141
		private const int WH_KEYBOARD = 2;

		// Token: 0x0400008E RID: 142
		private const int WM_MOUSEMOVE = 512;

		// Token: 0x0400008F RID: 143
		private const int WM_LBUTTONDOWN = 513;

		// Token: 0x04000090 RID: 144
		private const int WM_RBUTTONDOWN = 516;

		// Token: 0x04000091 RID: 145
		private const int WM_MBUTTONDOWN = 519;

		// Token: 0x04000092 RID: 146
		private const int WM_LBUTTONUP = 514;

		// Token: 0x04000093 RID: 147
		private const int WM_RBUTTONUP = 517;

		// Token: 0x04000094 RID: 148
		private const int WM_MBUTTONUP = 520;

		// Token: 0x04000095 RID: 149
		private const int WM_LBUTTONDBLCLK = 515;

		// Token: 0x04000096 RID: 150
		private const int WM_RBUTTONDBLCLK = 518;

		// Token: 0x04000097 RID: 151
		private const int WM_MBUTTONDBLCLK = 521;

		// Token: 0x04000098 RID: 152
		private const int WM_MOUSEWHEEL = 522;

		// Token: 0x04000099 RID: 153
		private const int WM_KEYDOWN = 256;

		// Token: 0x0400009A RID: 154
		private const int WM_KEYUP = 257;

		// Token: 0x0400009B RID: 155
		private const int WM_SYSKEYDOWN = 260;

		// Token: 0x0400009C RID: 156
		private const int WM_SYSKEYUP = 261;

		// Token: 0x0400009D RID: 157
		private const byte VK_SHIFT = 16;

		// Token: 0x0400009E RID: 158
		private const byte VK_CAPITAL = 20;

		// Token: 0x0400009F RID: 159
		private const byte VK_NUMLOCK = 144;

		// Token: 0x02000029 RID: 41
		// (Invoke) Token: 0x060001C0 RID: 448
		private delegate int HookProc(int nCode, int wParam, IntPtr lParam);

		// Token: 0x0200002A RID: 42
		private struct Point
		{
			// Token: 0x0400019C RID: 412
			public int X;

			// Token: 0x0400019D RID: 413
			public int Y;
		}

		// Token: 0x0200002B RID: 43
		private struct MouseLLHookStruct
		{
			// Token: 0x0400019E RID: 414
			public HookManager.Point Point;

			// Token: 0x0400019F RID: 415
			public int MouseData;

			// Token: 0x040001A0 RID: 416
			public int Flags;

			// Token: 0x040001A1 RID: 417
			public int Time;

			// Token: 0x040001A2 RID: 418
			public int ExtraInfo;
		}

		// Token: 0x0200002C RID: 44
		private struct KeyboardHookStruct
		{
			// Token: 0x040001A3 RID: 419
			public int VirtualKeyCode;

			// Token: 0x040001A4 RID: 420
			public int ScanCode;

			// Token: 0x040001A5 RID: 421
			public int Flags;

			// Token: 0x040001A6 RID: 422
			public int Time;

			// Token: 0x040001A7 RID: 423
			public int ExtraInfo;
		}
	}
}
