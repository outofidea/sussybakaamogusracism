﻿using System;
using System.Runtime.InteropServices;

namespace NAudio.Dmo
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct DmoOutputDataBuffer : IDisposable
    {
        public DmoOutputDataBuffer(int maxBufferSize)
        {
            this.pBuffer = new MediaBuffer(maxBufferSize);
            this.dwStatus = DmoOutputDataBufferFlags.None;
            this.rtTimestamp = 0L;
            this.referenceTimeDuration = 0L;
        }

        public void Dispose()
        {
            if (this.pBuffer != null)
            {
                ((MediaBuffer)this.pBuffer).Dispose();
                this.pBuffer = null;
                GC.SuppressFinalize(this);
            }
        }

        public IMediaBuffer MediaBuffer
        {
            get
            {
                return this.pBuffer;
            }
            internal set
            {
                this.pBuffer = value;
            }
        }

        public int Length
        {
            get
            {
                return ((MediaBuffer)this.pBuffer).Length;
            }
        }

        public DmoOutputDataBufferFlags StatusFlags
        {
            get
            {
                return this.dwStatus;
            }
            internal set
            {
                this.dwStatus = value;
            }
        }

        public long Timestamp
        {
            get
            {
                return this.rtTimestamp;
            }
            internal set
            {
                this.rtTimestamp = value;
            }
        }

        public long Duration
        {
            get
            {
                return this.referenceTimeDuration;
            }
            internal set
            {
                this.referenceTimeDuration = value;
            }
        }

        public void RetrieveData(byte[] data, int offset)
        {
            ((MediaBuffer)this.pBuffer).RetrieveData(data, offset);
        }

        public bool MoreDataAvailable
        {
            get
            {
                return (this.StatusFlags & DmoOutputDataBufferFlags.Incomplete) == DmoOutputDataBufferFlags.Incomplete;
            }
        }

        [MarshalAs(UnmanagedType.Interface)]
        private IMediaBuffer pBuffer;

        private DmoOutputDataBufferFlags dwStatus;

        private long rtTimestamp;

        private long referenceTimeDuration;
    }
}
