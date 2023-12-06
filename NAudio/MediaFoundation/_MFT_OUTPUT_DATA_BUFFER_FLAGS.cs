﻿using System;

namespace NAudio.MediaFoundation
{
    [Flags]
    public enum _MFT_OUTPUT_DATA_BUFFER_FLAGS
    {
        None = 0,
        MFT_OUTPUT_DATA_BUFFER_INCOMPLETE = 16777216,
        MFT_OUTPUT_DATA_BUFFER_FORMAT_CHANGE = 256,
        MFT_OUTPUT_DATA_BUFFER_STREAM_END = 512,
        MFT_OUTPUT_DATA_BUFFER_NO_SAMPLE = 768
    }
}
