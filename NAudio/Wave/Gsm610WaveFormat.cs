﻿using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public class Gsm610WaveFormat : WaveFormat
    {
        public Gsm610WaveFormat()
        {
            this.waveFormatTag = WaveFormatEncoding.Gsm610;
            this.channels = 1;
            this.averageBytesPerSecond = 1625;
            this.bitsPerSample = 0;
            this.blockAlign = 65;
            this.sampleRate = 8000;
            this.extraSize = 2;
            this.samplesPerBlock = 320;
        }

        public short SamplesPerBlock
        {
            get
            {
                return this.samplesPerBlock;
            }
        }

        public override void Serialize(BinaryWriter writer)
        {
            base.Serialize(writer);
            writer.Write(this.samplesPerBlock);
        }

        private short samplesPerBlock;
    }
}
