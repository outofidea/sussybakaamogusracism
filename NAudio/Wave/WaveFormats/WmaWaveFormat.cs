﻿using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave.WaveFormats
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal class WmaWaveFormat : WaveFormat
    {
        public WmaWaveFormat(int sampleRate, int bitsPerSample, int channels) : base(sampleRate, bitsPerSample, channels)
        {
            this.wValidBitsPerSample = (short)bitsPerSample;
            if (channels == 1)
            {
                this.dwChannelMask = 1;
            }
            else if (channels == 2)
            {
                this.dwChannelMask = 3;
            }
            this.waveFormatTag = WaveFormatEncoding.WindowsMediaAudio;
        }

        private short wValidBitsPerSample;

        private int dwChannelMask;

        private int dwReserved1;

        private int dwReserved2;

        private short wEncodeOptions;

        private short wReserved3;
    }
}
