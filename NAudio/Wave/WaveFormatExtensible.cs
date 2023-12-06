﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using NAudio.Dmo;

namespace NAudio.Wave
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public class WaveFormatExtensible : WaveFormat
    {
        private WaveFormatExtensible()
        {
        }

        public WaveFormatExtensible(int rate, int bits, int channels) : base(rate, bits, channels)
        {
            this.waveFormatTag = WaveFormatEncoding.Extensible;
            this.extraSize = 22;
            this.wValidBitsPerSample = (short)bits;
            for (int i = 0; i < channels; i++)
            {
                this.dwChannelMask |= 1 << i;
            }
            if (bits == 32)
            {
                this.subFormat = AudioMediaSubtypes.MEDIASUBTYPE_IEEE_FLOAT;
                return;
            }
            this.subFormat = AudioMediaSubtypes.MEDIASUBTYPE_PCM;
        }

        public WaveFormat ToStandardWaveFormat()
        {
            if (this.subFormat == AudioMediaSubtypes.MEDIASUBTYPE_IEEE_FLOAT && this.bitsPerSample == 32)
            {
                return WaveFormat.CreateIeeeFloatWaveFormat(this.sampleRate, (int)this.channels);
            }
            if (this.subFormat == AudioMediaSubtypes.MEDIASUBTYPE_PCM)
            {
                return new WaveFormat(this.sampleRate, (int)this.bitsPerSample, (int)this.channels);
            }
            throw new InvalidOperationException("Not a recognised PCM or IEEE float format");
        }

        public Guid SubFormat
        {
            get
            {
                return this.subFormat;
            }
        }

        public override void Serialize(BinaryWriter writer)
        {
            base.Serialize(writer);
            writer.Write(this.wValidBitsPerSample);
            writer.Write(this.dwChannelMask);
            byte[] array = this.subFormat.ToByteArray();
            writer.Write(array, 0, array.Length);
        }

        public override string ToString()
        {
            return string.Format("{0} wBitsPerSample:{1} dwChannelMask:{2} subFormat:{3} extraSize:{4}", new object[]
            {
                base.ToString(),
                this.wValidBitsPerSample,
                this.dwChannelMask,
                this.subFormat,
                this.extraSize
            });
        }

        private short wValidBitsPerSample;

        private int dwChannelMask;

        private Guid subFormat;
    }
}
