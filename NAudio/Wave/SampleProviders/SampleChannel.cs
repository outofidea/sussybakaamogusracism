﻿using System;

namespace NAudio.Wave.SampleProviders
{
    public class SampleChannel : ISampleProvider
    {
        public SampleChannel(IWaveProvider waveProvider) : this(waveProvider, false)
        {
        }

        public SampleChannel(IWaveProvider waveProvider, bool forceStereo)
        {
            ISampleProvider sampleProvider = SampleProviderConverters.ConvertWaveProviderIntoSampleProvider(waveProvider);
            if (sampleProvider.WaveFormat.Channels == 1 && forceStereo)
            {
                sampleProvider = new MonoToStereoSampleProvider(sampleProvider);
            }
            this.waveFormat = sampleProvider.WaveFormat;
            this.preVolumeMeter = new MeteringSampleProvider(sampleProvider);
            this.volumeProvider = new VolumeSampleProvider(this.preVolumeMeter);
        }

        public int Read(float[] buffer, int offset, int sampleCount)
        {
            return this.volumeProvider.Read(buffer, offset, sampleCount);
        }

        public WaveFormat WaveFormat
        {
            get
            {
                return this.waveFormat;
            }
        }

        public float Volume
        {
            get
            {
                return this.volumeProvider.Volume;
            }
            set
            {
                this.volumeProvider.Volume = value;
            }
        }

        public event EventHandler<StreamVolumeEventArgs> PreVolumeMeter
        {
            add
            {
                this.preVolumeMeter.StreamVolume += value;
            }
            remove
            {
                this.preVolumeMeter.StreamVolume -= value;
            }
        }

        private readonly VolumeSampleProvider volumeProvider;

        private readonly MeteringSampleProvider preVolumeMeter;

        private readonly WaveFormat waveFormat;
    }
}
