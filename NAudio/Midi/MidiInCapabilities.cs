﻿using System;
using System.Runtime.InteropServices;

namespace NAudio.Midi
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MidiInCapabilities
    {
        public Manufacturers Manufacturer
        {
            get
            {
                return (Manufacturers)this.manufacturerId;
            }
        }

        public int ProductId
        {
            get
            {
                return (int)this.productId;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
        }

        private const int MaxProductNameLength = 32;

        private ushort manufacturerId;

        private ushort productId;

        private uint driverVersion;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        private string productName;

        private int support;
    }
}
