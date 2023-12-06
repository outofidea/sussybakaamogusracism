﻿using System;
using NAudio.Utils;

namespace NAudio.Wave
{
    public class StereoToMonoProvider16 : IWaveProvider
    {
        public StereoToMonoProvider16(IWaveProvider sourceProvider)
        {
            if (sourceProvider.WaveFormat.Encoding != WaveFormatEncoding.Pcm)
            {
                throw new ArgumentException("Source must be PCM");
            }
            if (sourceProvider.WaveFormat.Channels != 2)
            {
                throw new ArgumentException("Source must be stereo");
            }
            if (sourceProvider.WaveFormat.BitsPerSample != 16)
            {
                throw new ArgumentException("Source must be 16 bit");
            }
            this.sourceProvider = sourceProvider;
            this.outputFormat = new WaveFormat(sourceProvider.WaveFormat.SampleRate, 1);
        }

        public float LeftVolume { get; set; }

        public float RightVolume { get; set; }

        public WaveFormat WaveFormat
        {
            get
            {
                return this.outputFormat;
            }
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            int num = count * 2;
            this.sourceBuffer = BufferHelpers.Ensure(this.sourceBuffer, num);
            WaveBuffer waveBuffer = new WaveBuffer(this.sourceBuffer);
            WaveBuffer waveBuffer2 = new WaveBuffer(buffer);
            int num2 = this.sourceProvider.Read(this.sourceBuffer, 0, num);
            int num3 = num2 / 2;
            int num4 = offset / 2;
            for (int i = 0; i < num3; i += 2)
            {
                short num5 = waveBuffer.ShortBuffer[i];
                short num6 = waveBuffer.ShortBuffer[i + 1];
                float num7 = (float)num5 * this.LeftVolume + (float)num6 * this.RightVolume;
                if (num7 > 32767f)
                {
                    num7 = 32767f;
                }
                if (num7 < -32768f)
                {
                    num7 = -32768f;
                }
                waveBuffer2.ShortBuffer[num4++] = (short)num7;
            }
            return num2 / 2;
        }

        private IWaveProvider sourceProvider;

        private WaveFormat outputFormat;

        private byte[] sourceBuffer;
    }
}
