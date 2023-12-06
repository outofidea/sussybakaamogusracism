﻿using System;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
    public class AudioEndpointVolumeVolumeRange
    {
        internal AudioEndpointVolumeVolumeRange(IAudioEndpointVolume parent)
        {
            Marshal.ThrowExceptionForHR(parent.GetVolumeRange(out this.volumeMinDecibels, out this.volumeMaxDecibels, out this.volumeIncrementDecibels));
        }

        public float MinDecibels
        {
            get
            {
                return this.volumeMinDecibels;
            }
        }

        public float MaxDecibels
        {
            get
            {
                return this.volumeMaxDecibels;
            }
        }

        public float IncrementDecibels
        {
            get
            {
                return this.volumeIncrementDecibels;
            }
        }

        private readonly float volumeMinDecibels;

        private readonly float volumeMaxDecibels;

        private readonly float volumeIncrementDecibels;
    }
}
