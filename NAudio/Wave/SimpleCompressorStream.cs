﻿using System;
using NAudio.Dsp;

namespace NAudio.Wave
{
    public class SimpleCompressorStream : WaveStream
    {
        public SimpleCompressorStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.channels = sourceStream.WaveFormat.Channels;
            this.bytesPerSample = sourceStream.WaveFormat.BitsPerSample / 8;
            this.simpleCompressor = new SimpleCompressor(5.0, 10.0, (double)sourceStream.WaveFormat.SampleRate);
            this.simpleCompressor.Threshold = 16.0;
            this.simpleCompressor.Ratio = 6.0;
            this.simpleCompressor.MakeUpGain = 16.0;
        }

        public double MakeUpGain
        {
            get
            {
                return this.simpleCompressor.MakeUpGain;
            }
            set
            {
                lock (this.lockObject)
                {
                    this.simpleCompressor.MakeUpGain = value;
                }
            }
        }

        public double Threshold
        {
            get
            {
                return this.simpleCompressor.Threshold;
            }
            set
            {
                lock (this.lockObject)
                {
                    this.simpleCompressor.Threshold = value;
                }
            }
        }

        public double Ratio
        {
            get
            {
                return this.simpleCompressor.Ratio;
            }
            set
            {
                lock (this.lockObject)
                {
                    this.simpleCompressor.Ratio = value;
                }
            }
        }

        public double Attack
        {
            get
            {
                return this.simpleCompressor.Attack;
            }
            set
            {
                lock (this.lockObject)
                {
                    this.simpleCompressor.Attack = value;
                }
            }
        }

        public double Release
        {
            get
            {
                return this.simpleCompressor.Release;
            }
            set
            {
                lock (this.lockObject)
                {
                    this.simpleCompressor.Release = value;
                }
            }
        }

        public override bool HasData(int count)
        {
            return this.sourceStream.HasData(count);
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        public override long Length
        {
            get
            {
                return this.sourceStream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return this.sourceStream.Position;
            }
            set
            {
                lock (this.lockObject)
                {
                    this.sourceStream.Position = value;
                }
            }
        }

        public override WaveFormat WaveFormat
        {
            get
            {
                return this.sourceStream.WaveFormat;
            }
        }

        private void ReadSamples(byte[] buffer, int start, out double left, out double right)
        {
            if (this.bytesPerSample == 4)
            {
                left = (double)BitConverter.ToSingle(buffer, start);
                if (this.channels > 1)
                {
                    right = (double)BitConverter.ToSingle(buffer, start + this.bytesPerSample);
                    return;
                }
                right = left;
                return;
            }
            else
            {
                if (this.bytesPerSample != 2)
                {
                    throw new InvalidOperationException(string.Format("Unsupported bytes per sample: {0}", this.bytesPerSample));
                }
                left = (double)BitConverter.ToInt16(buffer, start) / 32768.0;
                if (this.channels > 1)
                {
                    right = (double)BitConverter.ToInt16(buffer, start + this.bytesPerSample) / 32768.0;
                    return;
                }
                right = left;
                return;
            }
        }

        private void WriteSamples(byte[] buffer, int start, double left, double right)
        {
            if (this.bytesPerSample == 4)
            {
                Array.Copy(BitConverter.GetBytes((float)left), 0, buffer, start, this.bytesPerSample);
                if (this.channels > 1)
                {
                    Array.Copy(BitConverter.GetBytes((float)right), 0, buffer, start + this.bytesPerSample, this.bytesPerSample);
                    return;
                }
            }
            else if (this.bytesPerSample == 2)
            {
                Array.Copy(BitConverter.GetBytes((short)(left * 32768.0)), 0, buffer, start, this.bytesPerSample);
                if (this.channels > 1)
                {
                    Array.Copy(BitConverter.GetBytes((short)(right * 32768.0)), 0, buffer, start + this.bytesPerSample, this.bytesPerSample);
                }
            }
        }

        public override int Read(byte[] array, int offset, int count)
        {
            int result;
            lock (this.lockObject)
            {
                if (this.Enabled)
                {
                    if (this.sourceBuffer == null || this.sourceBuffer.Length < count)
                    {
                        this.sourceBuffer = new byte[count];
                    }
                    int num = this.sourceStream.Read(this.sourceBuffer, 0, count);
                    int num2 = num / (this.bytesPerSample * this.channels);
                    for (int i = 0; i < num2; i++)
                    {
                        int num3 = i * this.bytesPerSample * this.channels;
                        double left;
                        double right;
                        this.ReadSamples(this.sourceBuffer, num3, out left, out right);
                        this.simpleCompressor.Process(ref left, ref right);
                        this.WriteSamples(array, offset + num3, left, right);
                    }
                    result = count;
                }
                else
                {
                    result = this.sourceStream.Read(array, offset, count);
                }
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.sourceStream != null)
            {
                this.sourceStream.Dispose();
                this.sourceStream = null;
            }
            base.Dispose(disposing);
        }

        public override int BlockAlign
        {
            get
            {
                return this.sourceStream.BlockAlign;
            }
        }

        private WaveStream sourceStream;

        private readonly SimpleCompressor simpleCompressor;

        private byte[] sourceBuffer;

        private bool enabled;

        private readonly int channels;

        private readonly int bytesPerSample;

        private readonly object lockObject = new object();
    }
}
