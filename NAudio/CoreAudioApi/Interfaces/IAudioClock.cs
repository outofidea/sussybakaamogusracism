﻿using System;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi.Interfaces
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CD63314F-3FBA-4a1b-812C-EF96358728E7")]
    internal interface IAudioClock
    {
        [PreserveSig]
        int GetFrequency(out ulong frequency);

        [PreserveSig]
        int GetPosition(out ulong devicePosition, out ulong qpcPosition);

        [PreserveSig]
        int GetCharacteristics(out uint characteristics);
    }
}
