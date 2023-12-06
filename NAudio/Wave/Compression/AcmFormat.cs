﻿using System;

namespace NAudio.Wave.Compression
{
    public class AcmFormat
    {
        internal AcmFormat(AcmFormatDetails formatDetails)
        {
            this.formatDetails = formatDetails;
            this.waveFormat = WaveFormat.MarshalFromPtr(formatDetails.waveFormatPointer);
        }

        public int FormatIndex
        {
            get
            {
                return this.formatDetails.formatIndex;
            }
        }

        public WaveFormatEncoding FormatTag
        {
            get
            {
                return (WaveFormatEncoding)this.formatDetails.formatTag;
            }
        }

        public AcmDriverDetailsSupportFlags SupportFlags
        {
            get
            {
                return this.formatDetails.supportFlags;
            }
        }

        public WaveFormat WaveFormat
        {
            get
            {
                return this.waveFormat;
            }
        }

        public int WaveFormatByteSize
        {
            get
            {
                return this.formatDetails.waveFormatByteSize;
            }
        }

        public string FormatDescription
        {
            get
            {
                return this.formatDetails.formatDescription;
            }
        }

        private readonly AcmFormatDetails formatDetails;

        private readonly WaveFormat waveFormat;
    }
}
