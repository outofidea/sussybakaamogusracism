﻿using System;
using NAudio.Utils;

namespace NAudio.Wave
{
    public class BufferedWaveProvider : IWaveProvider
    {
        public BufferedWaveProvider(WaveFormat waveFormat)
        {
            this.waveFormat = waveFormat;
            this.BufferLength = waveFormat.AverageBytesPerSecond * 5;
        }

        public int BufferLength { get; set; }

        public TimeSpan BufferDuration
        {
            get
            {
                return TimeSpan.FromSeconds((double)this.BufferLength / (double)this.WaveFormat.AverageBytesPerSecond);
            }
            set
            {
                this.BufferLength = (int)(value.TotalSeconds * (double)this.WaveFormat.AverageBytesPerSecond);
            }
        }

        public bool DiscardOnBufferOverflow { get; set; }

        public int BufferedBytes
        {
            get
            {
                if (this.circularBuffer != null)
                {
                    return this.circularBuffer.Count;
                }
                return 0;
            }
        }

        public TimeSpan BufferedDuration
        {
            get
            {
                return TimeSpan.FromSeconds((double)this.BufferedBytes / (double)this.WaveFormat.AverageBytesPerSecond);
            }
        }

        public WaveFormat WaveFormat
        {
            get
            {
                return this.waveFormat;
            }
        }

        public void AddSamples(byte[] buffer, int offset, int count)
        {
            if (this.circularBuffer == null)
            {
                this.circularBuffer = new CircularBuffer(this.BufferLength);
            }
            int num = this.circularBuffer.Write(buffer, offset, count);
            if (num < count && !this.DiscardOnBufferOverflow)
            {
                throw new InvalidOperationException("Buffer full");
            }
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            int num = 0;
            if (this.circularBuffer != null)
            {
                num = this.circularBuffer.Read(buffer, offset, count);
            }
            if (num < count)
            {
                Array.Clear(buffer, offset + num, count - num);
            }
            return count;
        }

        public void ClearBuffer()
        {
            if (this.circularBuffer != null)
            {
                this.circularBuffer.Reset();
            }
        }

        private CircularBuffer circularBuffer;

        private readonly WaveFormat waveFormat;
    }
}
