using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomAutoScrollPanel
{
    // Token: 0x02000013 RID: 19
    public class ScrollablePanel : Panel
    {
        // Token: 0x14000001 RID: 1
        // (add) Token: 0x0600005E RID: 94 RVA: 0x000032E8 File Offset: 0x000022E8
        // (remove) Token: 0x0600005F RID: 95 RVA: 0x00003320 File Offset: 0x00002320
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public event ScrollEventHandler ScrollHorizontal;

        // Token: 0x14000002 RID: 2
        // (add) Token: 0x06000060 RID: 96 RVA: 0x00003358 File Offset: 0x00002358
        // (remove) Token: 0x06000061 RID: 97 RVA: 0x00003390 File Offset: 0x00002390
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public event ScrollEventHandler ScrollVertical;

        // Token: 0x14000003 RID: 3
        // (add) Token: 0x06000062 RID: 98 RVA: 0x000033C8 File Offset: 0x000023C8
        // (remove) Token: 0x06000063 RID: 99 RVA: 0x00003400 File Offset: 0x00002400
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public event MouseEventHandler ScrollMouseWheel;

        // Token: 0x06000064 RID: 100 RVA: 0x00003438 File Offset: 0x00002438
        public ScrollablePanel()
        {
            base.Click += this.ScrollablePanel_Click;
            this.AutoScroll = true;
        }

        // Token: 0x17000016 RID: 22
        // (get) Token: 0x06000065 RID: 101 RVA: 0x000034A4 File Offset: 0x000024A4
        // (set) Token: 0x06000066 RID: 102 RVA: 0x000034C2 File Offset: 0x000024C2
        public int AutoScrollHPos
        {
            get
            {
                return ScrollablePanel.GetScrollPos(base.Handle, 0);
            }
            set
            {
                ScrollablePanel.SetScrollPos(base.Handle, 0, value, true);
            }
        }

        // Token: 0x17000017 RID: 23
        // (get) Token: 0x06000067 RID: 103 RVA: 0x000034D4 File Offset: 0x000024D4
        // (set) Token: 0x06000068 RID: 104 RVA: 0x000034F2 File Offset: 0x000024F2
        public int AutoScrollVPos
        {
            get
            {
                return ScrollablePanel.GetScrollPos(base.Handle, 1);
            }
            set
            {
                ScrollablePanel.SetScrollPos(base.Handle, 1, value, true);
            }
        }

        // Token: 0x17000018 RID: 24
        // (get) Token: 0x06000069 RID: 105 RVA: 0x00003504 File Offset: 0x00002504
        // (set) Token: 0x0600006A RID: 106 RVA: 0x0000351C File Offset: 0x0000251C
        public int AutoScrollHorizontalMinimum
        {
            get
            {
                return this.autoScrollHorizontalMinimum;
            }
            set
            {
                this.autoScrollHorizontalMinimum = value;
                ScrollablePanel.SetScrollRange(base.Handle, 0, this.autoScrollHorizontalMinimum, this.autoScrollHorizontalMaximum, true);
            }
        }

        // Token: 0x17000019 RID: 25
        // (get) Token: 0x0600006B RID: 107 RVA: 0x00003540 File Offset: 0x00002540
        // (set) Token: 0x0600006C RID: 108 RVA: 0x00003558 File Offset: 0x00002558
        public int AutoScrollHorizontalMaximum
        {
            get
            {
                return this.autoScrollHorizontalMaximum;
            }
            set
            {
                this.autoScrollHorizontalMaximum = value;
                ScrollablePanel.SetScrollRange(base.Handle, 0, this.autoScrollHorizontalMinimum, this.autoScrollHorizontalMaximum, true);
            }
        }

        // Token: 0x1700001A RID: 26
        // (get) Token: 0x0600006D RID: 109 RVA: 0x0000357C File Offset: 0x0000257C
        // (set) Token: 0x0600006E RID: 110 RVA: 0x00003594 File Offset: 0x00002594
        public int AutoScrollVerticalMinimum
        {
            get
            {
                return this.autoScrollVerticalMinimum;
            }
            set
            {
                this.autoScrollVerticalMinimum = value;
                ScrollablePanel.SetScrollRange(base.Handle, 1, this.autoScrollHorizontalMinimum, this.autoScrollHorizontalMaximum, true);
            }
        }

        // Token: 0x1700001B RID: 27
        // (get) Token: 0x0600006F RID: 111 RVA: 0x000035B8 File Offset: 0x000025B8
        // (set) Token: 0x06000070 RID: 112 RVA: 0x000035D0 File Offset: 0x000025D0
        public int AutoScrollVerticalMaximum
        {
            get
            {
                return this.autoScrollVerticalMaximum;
            }
            set
            {
                this.autoScrollVerticalMaximum = value;
                ScrollablePanel.SetScrollRange(base.Handle, 1, this.autoScrollHorizontalMinimum, this.autoScrollHorizontalMaximum, true);
            }
        }

        // Token: 0x1700001C RID: 28
        // (get) Token: 0x06000071 RID: 113 RVA: 0x000035F4 File Offset: 0x000025F4
        // (set) Token: 0x06000072 RID: 114 RVA: 0x0000360C File Offset: 0x0000260C
        public bool EnableAutoScrollHorizontal
        {
            get
            {
                return this.enableAutoHorizontal;
            }
            set
            {
                this.enableAutoHorizontal = value;
                if (value)
                {
                    ScrollablePanel.EnableScrollBar(base.Handle, 0U, 0U);
                }
                else
                {
                    ScrollablePanel.EnableScrollBar(base.Handle, 0U, 3U);
                }
            }
        }

        // Token: 0x1700001D RID: 29
        // (get) Token: 0x06000073 RID: 115 RVA: 0x00003644 File Offset: 0x00002644
        // (set) Token: 0x06000074 RID: 116 RVA: 0x0000365C File Offset: 0x0000265C
        public bool EnableAutoScrollVertical
        {
            get
            {
                return this.enableAutoVertical;
            }
            set
            {
                this.enableAutoVertical = value;
                if (value)
                {
                    ScrollablePanel.EnableScrollBar(base.Handle, 1U, 0U);
                }
                else
                {
                    ScrollablePanel.EnableScrollBar(base.Handle, 1U, 3U);
                }
            }
        }

        // Token: 0x1700001E RID: 30
        // (get) Token: 0x06000075 RID: 117 RVA: 0x00003694 File Offset: 0x00002694
        // (set) Token: 0x06000076 RID: 118 RVA: 0x000036AC File Offset: 0x000026AC
        public bool VisibleAutoScrollHorizontal
        {
            get
            {
                return this.visibleAutoHorizontal;
            }
            set
            {
                this.visibleAutoHorizontal = value;
                ScrollablePanel.ShowScrollBar(base.Handle, 0, value);
            }
        }

        // Token: 0x1700001F RID: 31
        // (get) Token: 0x06000077 RID: 119 RVA: 0x000036C4 File Offset: 0x000026C4
        // (set) Token: 0x06000078 RID: 120 RVA: 0x000036DC File Offset: 0x000026DC
        public bool VisibleAutoScrollVertical
        {
            get
            {
                return this.visibleAutoVertical;
            }
            set
            {
                this.visibleAutoVertical = value;
                ScrollablePanel.ShowScrollBar(base.Handle, 1, value);
            }
        }

        // Token: 0x06000079 RID: 121 RVA: 0x000036F4 File Offset: 0x000026F4
        private int getSBFromScrollEventType(ScrollEventType type)
        {
            int result = -1;
            switch (type)
            {
                case ScrollEventType.SmallDecrement:
                    result = 0;
                    break;
                case ScrollEventType.SmallIncrement:
                    result = 1;
                    break;
                case ScrollEventType.LargeDecrement:
                    result = 2;
                    break;
                case ScrollEventType.LargeIncrement:
                    result = 3;
                    break;
                case ScrollEventType.ThumbPosition:
                    result = 4;
                    break;
                case ScrollEventType.ThumbTrack:
                    result = 5;
                    break;
                case ScrollEventType.First:
                    result = 6;
                    break;
                case ScrollEventType.Last:
                    result = 7;
                    break;
                case ScrollEventType.EndScroll:
                    result = 8;
                    break;
            }
            return result;
        }

        // Token: 0x0600007A RID: 122 RVA: 0x00003760 File Offset: 0x00002760
        private ScrollEventType getScrollEventType(IntPtr wParam)
        {
            ScrollEventType result;
            switch (ScrollablePanel.LoWord((int)wParam))
            {
                case 0:
                    result = ScrollEventType.SmallDecrement;
                    break;
                case 1:
                    result = ScrollEventType.SmallIncrement;
                    break;
                case 2:
                    result = ScrollEventType.LargeDecrement;
                    break;
                case 3:
                    result = ScrollEventType.LargeIncrement;
                    break;
                case 4:
                    result = ScrollEventType.ThumbPosition;
                    break;
                case 5:
                    result = ScrollEventType.ThumbTrack;
                    break;
                case 6:
                    result = ScrollEventType.First;
                    break;
                case 7:
                    result = ScrollEventType.Last;
                    break;
                case 8:
                    result = ScrollEventType.EndScroll;
                    break;
                default:
                    result = ScrollEventType.EndScroll;
                    break;
            }
            return result;
        }

        // Token: 0x0600007B RID: 123 RVA: 0x000037D8 File Offset: 0x000027D8
        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            bool flag = msg.HWnd != base.Handle;
            if (!flag)
            {
                int msg2 = msg.Msg;
                if (msg2 != 276)
                {
                    if (msg2 != 277)
                    {
                        if (msg2 == 522)
                        {
                            bool flag2 = !this.VisibleAutoScrollVertical;
                            if (!flag2)
                            {
                                try
                                {
                                    int delta = ScrollablePanel.HiWord((int)msg.WParam);
                                    int y = ScrollablePanel.HiWord((int)msg.LParam);
                                    int x = ScrollablePanel.LoWord((int)msg.LParam);
                                    int num = ScrollablePanel.LoWord((int)msg.WParam);
                                    MouseButtons button;
                                    if (num <= 2)
                                    {
                                        if (num == 1)
                                        {
                                            button = MouseButtons.Left;
                                            goto IL_109;
                                        }
                                        if (num == 2)
                                        {
                                            button = MouseButtons.Right;
                                            goto IL_109;
                                        }
                                    }
                                    else
                                    {
                                        if (num == 16)
                                        {
                                            button = MouseButtons.Middle;
                                            goto IL_109;
                                        }
                                        if (num == 32)
                                        {
                                            button = MouseButtons.XButton1;
                                            goto IL_109;
                                        }
                                        if (num == 64)
                                        {
                                            button = MouseButtons.XButton2;
                                            goto IL_109;
                                        }
                                    }
                                    button = MouseButtons.None;
                                IL_109:
                                    MouseEventArgs e = new MouseEventArgs(button, 1, x, y, delta);
                                    this.ScrollMouseWheel(this, e);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            ScrollEventType scrollEventType = this.getScrollEventType(msg.WParam);
                            ScrollEventArgs e2 = new ScrollEventArgs(scrollEventType, ScrollablePanel.GetScrollPos(base.Handle, 1));
                            this.ScrollVertical(this, e2);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else
                {
                    try
                    {
                        ScrollEventType scrollEventType2 = this.getScrollEventType(msg.WParam);
                        ScrollEventArgs e3 = new ScrollEventArgs(scrollEventType2, ScrollablePanel.GetScrollPos(base.Handle, 0));
                        this.ScrollHorizontal(this, e3);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        // Token: 0x0600007C RID: 124 RVA: 0x000039BC File Offset: 0x000029BC
        public void performScrollHorizontal(ScrollEventType type)
        {
            int sbfromScrollEventType = this.getSBFromScrollEventType(type);
            bool flag = sbfromScrollEventType == -1;
            if (!flag)
            {
                ScrollablePanel.SendMessage(base.Handle, 276U, (UIntPtr)((ulong)((long)sbfromScrollEventType)), (IntPtr)0);
            }
        }

        // Token: 0x0600007D RID: 125 RVA: 0x000039FC File Offset: 0x000029FC
        public void performScrollVertical(ScrollEventType type)
        {
            int sbfromScrollEventType = this.getSBFromScrollEventType(type);
            bool flag = sbfromScrollEventType == -1;
            if (!flag)
            {
                ScrollablePanel.SendMessage(base.Handle, 277U, (UIntPtr)((ulong)((long)sbfromScrollEventType)), (IntPtr)0);
            }
        }

        // Token: 0x0600007E RID: 126 RVA: 0x00003A3A File Offset: 0x00002A3A
        private void ScrollablePanel_Click(object sender, EventArgs e)
        {
            base.Focus();
        }

        // Token: 0x0600007F RID: 127
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetSystemMetrics(int code);

        // Token: 0x06000080 RID: 128
        [DllImport("user32.dll")]
        public static extern bool EnableScrollBar(IntPtr hWnd, uint wSBflags, uint wArrows);

        // Token: 0x06000081 RID: 129
        [DllImport("user32.dll")]
        public static extern int SetScrollRange(IntPtr hWnd, int nBar, int nMinPos, int nMaxPos, bool bRedraw);

        // Token: 0x06000082 RID: 130
        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        // Token: 0x06000083 RID: 131
        [DllImport("user32.dll")]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        // Token: 0x06000084 RID: 132
        [DllImport("user32.dll")]
        public static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        // Token: 0x06000085 RID: 133
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

        // Token: 0x06000086 RID: 134
        [DllImport("user32.dll")]
        private static extern int HIWORD(IntPtr wParam);

        // Token: 0x06000087 RID: 135 RVA: 0x00003A44 File Offset: 0x00002A44
        private static int MakeLong(int LoWord, int HiWord)
        {
            return HiWord << 16 | (LoWord & 65535);
        }

        // Token: 0x06000088 RID: 136 RVA: 0x00003A64 File Offset: 0x00002A64
        private static IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return (IntPtr)(HiWord << 16 | (LoWord & 65535));
        }

        // Token: 0x06000089 RID: 137 RVA: 0x00003A88 File Offset: 0x00002A88
        private static int HiWord(int number)
        {
            unchecked
            {
                bool flag = (number & (long)(ulong)int.MinValue) == (long)(ulong)int.MinValue;
                int result;
                if (flag)
                {
                    result = number >> 16;
                }
                else
                {
                    result = (number >> 16 & 65535);
                }
                return result;
            };
        }

        // Token: 0x0600008A RID: 138 RVA: 0x00003AC0 File Offset: 0x00002AC0
        private static int LoWord(int number)
        {
            return number & 65535;
        }

        // Token: 0x04000053 RID: 83
        private const int SB_LINEUP = 0;

        // Token: 0x04000054 RID: 84
        private const int SB_LINEDOWN = 1;

        // Token: 0x04000055 RID: 85
        private const int SB_PAGEUP = 2;

        // Token: 0x04000056 RID: 86
        private const int SB_PAGEDOWN = 3;

        // Token: 0x04000057 RID: 87
        private const int SB_THUMBPOSITION = 4;

        // Token: 0x04000058 RID: 88
        private const int SB_THUMBTRACK = 5;

        // Token: 0x04000059 RID: 89
        private const int SB_TOP = 6;

        // Token: 0x0400005A RID: 90
        private const int SB_BOTTOM = 7;

        // Token: 0x0400005B RID: 91
        private const int SB_ENDSCROLL = 8;

        // Token: 0x0400005C RID: 92
        private const int WM_HSCROLL = 276;

        // Token: 0x0400005D RID: 93
        private const int WM_VSCROLL = 277;

        // Token: 0x0400005E RID: 94
        private const int WM_MOUSEWHEEL = 522;

        // Token: 0x0400005F RID: 95
        private const int WM_NCCALCSIZE = 131;

        // Token: 0x04000060 RID: 96
        private const int WM_PAINT = 15;

        // Token: 0x04000061 RID: 97
        private const int WM_SIZE = 5;

        // Token: 0x04000062 RID: 98
        private const uint SB_HORZ = 0U;

        // Token: 0x04000063 RID: 99
        private const uint SB_VERT = 1U;

        // Token: 0x04000064 RID: 100
        private const uint SB_CTL = 2U;

        // Token: 0x04000065 RID: 101
        private const uint SB_BOTH = 3U;

        // Token: 0x04000066 RID: 102
        private const uint ESB_DISABLE_BOTH = 3U;

        // Token: 0x04000067 RID: 103
        private const uint ESB_ENABLE_BOTH = 0U;

        // Token: 0x04000068 RID: 104
        private const int MK_LBUTTON = 1;

        // Token: 0x04000069 RID: 105
        private const int MK_RBUTTON = 2;

        // Token: 0x0400006A RID: 106
        private const int MK_SHIFT = 4;

        // Token: 0x0400006B RID: 107
        private const int MK_CONTROL = 8;

        // Token: 0x0400006C RID: 108
        private const int MK_MBUTTON = 16;

        // Token: 0x0400006D RID: 109
        private const int MK_XBUTTON1 = 32;

        // Token: 0x0400006E RID: 110
        private const int MK_XBUTTON2 = 64;

        // Token: 0x0400006F RID: 111
        private bool enableAutoHorizontal = true;

        // Token: 0x04000070 RID: 112
        private bool enableAutoVertical = true;

        // Token: 0x04000071 RID: 113
        private bool visibleAutoHorizontal = true;

        // Token: 0x04000072 RID: 114
        private bool visibleAutoVertical = true;

        // Token: 0x04000073 RID: 115
        private int autoScrollHorizontalMinimum = 0;

        // Token: 0x04000074 RID: 116
        private int autoScrollHorizontalMaximum = 100;

        // Token: 0x04000075 RID: 117
        private int autoScrollVerticalMinimum = 0;

        // Token: 0x04000076 RID: 118
        private int autoScrollVerticalMaximum = 100;
    }
}
