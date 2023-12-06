﻿using System;
using System.Runtime.InteropServices;

namespace NAudio.MediaFoundation
{
    [StructLayout(LayoutKind.Sequential)]
    public class MFT_REGISTER_TYPE_INFO
    {
        public Guid guidMajorType;

        public Guid guidSubtype;
    }
}
