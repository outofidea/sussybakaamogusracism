﻿using System;

namespace NAudio.MediaFoundation
{
    [Flags]
    public enum _MFT_ENUM_FLAG
    {
        None = 0,
        MFT_ENUM_FLAG_SYNCMFT = 1,
        MFT_ENUM_FLAG_ASYNCMFT = 2,
        MFT_ENUM_FLAG_HARDWARE = 4,
        MFT_ENUM_FLAG_FIELDOFUSE = 8,
        MFT_ENUM_FLAG_LOCALMFT = 16,
        MFT_ENUM_FLAG_TRANSCODE_ONLY = 32,
        MFT_ENUM_FLAG_SORTANDFILTER = 64,
        MFT_ENUM_FLAG_ALL = 63
    }
}
