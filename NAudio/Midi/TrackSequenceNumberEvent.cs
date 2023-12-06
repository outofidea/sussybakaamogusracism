﻿using System;
using System.IO;

namespace NAudio.Midi
{
    public class TrackSequenceNumberEvent : MetaEvent
    {
        public TrackSequenceNumberEvent(BinaryReader br, int length)
        {
            if (length != 2)
            {
                throw new FormatException("Invalid sequence number length");
            }
            this.sequenceNumber = (ushort)(((int)br.ReadByte() << 8) + (int)br.ReadByte());
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), this.sequenceNumber);
        }

        public override void Export(ref long absoluteTime, BinaryWriter writer)
        {
            base.Export(ref absoluteTime, writer);
            writer.Write((byte)(this.sequenceNumber >> 8 & 255));
            writer.Write((byte)(this.sequenceNumber & 255));
        }

        private ushort sequenceNumber;
    }
}
