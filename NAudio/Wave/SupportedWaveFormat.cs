﻿using System;

namespace NAudio.Wave
{
    [Flags]
    public enum SupportedWaveFormat
    {
        WAVE_FORMAT_1M08 = 1,
        WAVE_FORMAT_1S08 = 2,
        WAVE_FORMAT_1M16 = 4,
        WAVE_FORMAT_1S16 = 8,
        WAVE_FORMAT_2M08 = 16,
        WAVE_FORMAT_2S08 = 32,
        WAVE_FORMAT_2M16 = 64,
        WAVE_FORMAT_2S16 = 128,
        WAVE_FORMAT_4M08 = 256,
        WAVE_FORMAT_4S08 = 512,
        WAVE_FORMAT_4M16 = 1024,
        WAVE_FORMAT_4S16 = 2048,
        WAVE_FORMAT_44M08 = 256,
        WAVE_FORMAT_44S08 = 512,
        WAVE_FORMAT_44M16 = 1024,
        WAVE_FORMAT_44S16 = 2048,
        WAVE_FORMAT_48M08 = 4096,
        WAVE_FORMAT_48S08 = 8192,
        WAVE_FORMAT_48M16 = 16384,
        WAVE_FORMAT_48S16 = 32768,
        WAVE_FORMAT_96M08 = 65536,
        WAVE_FORMAT_96S08 = 131072,
        WAVE_FORMAT_96M16 = 262144,
        WAVE_FORMAT_96S16 = 524288
    }
}
