﻿using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
    public sealed class WaveFormatCustomMarshaler : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string cookie)
        {
            if (WaveFormatCustomMarshaler.marshaler == null)
            {
                WaveFormatCustomMarshaler.marshaler = new WaveFormatCustomMarshaler();
            }
            return WaveFormatCustomMarshaler.marshaler;
        }

        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            Marshal.FreeHGlobal(pNativeData);
        }

        public int GetNativeDataSize()
        {
            throw new NotImplementedException();
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            return WaveFormat.MarshalToPtr((WaveFormat)ManagedObj);
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return WaveFormat.MarshalFromPtr(pNativeData);
        }

        private static WaveFormatCustomMarshaler marshaler;
    }
}
