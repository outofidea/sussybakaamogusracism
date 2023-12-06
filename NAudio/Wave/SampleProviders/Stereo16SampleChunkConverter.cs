﻿using System;
using NAudio.Utils;

namespace NAudio.Wave.SampleProviders
{
    internal class Stereo16SampleChunkConverter : ISampleChunkConverter
    {
        public bool Supports(WaveFormat waveFormat)
        {
            return waveFormat.Encoding == WaveFormatEncoding.Pcm && waveFormat.BitsPerSample == 16 && waveFormat.Channels == 2;
        }

        public void LoadNextChunk(IWaveProvider source, int samplePairsRequired)
        {
            int num = samplePairsRequired * 4;
            this.sourceBuffer = BufferHelpers.Ensure(this.sourceBuffer, num);
            this.sourceWaveBuffer = new WaveBuffer(this.sourceBuffer);
            this.sourceSamples = source.Read(this.sourceBuffer, 0, num) / 2;
            this.sourceSample = 0;
        }

        public bool GetNextSample(out float sampleLeft, out float sampleRight)
        {
            if (this.sourceSample < this.sourceSamples)
            {
                sampleLeft = (float)this.sourceWaveBuffer.ShortBuffer[this.sourceSample++] / 32768f;
                sampleRight = (float)this.sourceWaveBuffer.ShortBuffer[this.sourceSample++] / 32768f;
                return true;
            }
            sampleLeft = 0f;
            sampleRight = 0f;
            return false;
        }

        private int sourceSample;

        private byte[] sourceBuffer;

        private WaveBuffer sourceWaveBuffer;

        private int sourceSamples;
    }
}
