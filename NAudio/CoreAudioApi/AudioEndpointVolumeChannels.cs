﻿using System;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
    public class AudioEndpointVolumeChannels
    {
        public int Count
        {
            get
            {
                int result;
                Marshal.ThrowExceptionForHR(this.audioEndPointVolume.GetChannelCount(out result));
                return result;
            }
        }

        public AudioEndpointVolumeChannel this[int index]
        {
            get
            {
                return this.channels[index];
            }
        }

        internal AudioEndpointVolumeChannels(IAudioEndpointVolume parent)
        {
            this.audioEndPointVolume = parent;
            int count = this.Count;
            this.channels = new AudioEndpointVolumeChannel[count];
            for (int i = 0; i < count; i++)
            {
                this.channels[i] = new AudioEndpointVolumeChannel(this.audioEndPointVolume, i);
            }
        }

        private readonly IAudioEndpointVolume audioEndPointVolume;

        private readonly AudioEndpointVolumeChannel[] channels;
    }
}
