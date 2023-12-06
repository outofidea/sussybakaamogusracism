﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NAudio.Utils;

namespace NAudio.Midi
{
    public class MidiFile
    {
        public MidiFile(string filename) : this(filename, true)
        {
        }

        public int FileFormat
        {
            get
            {
                return (int)this.fileFormat;
            }
        }

        public MidiFile(string filename, bool strictChecking)
        {
            this.strictChecking = strictChecking;
            BinaryReader binaryReader = new BinaryReader(File.OpenRead(filename));
            using (binaryReader)
            {
                string @string = Encoding.UTF8.GetString(binaryReader.ReadBytes(4));
                if (@string != "MThd")
                {
                    throw new FormatException("Not a MIDI file - header chunk missing");
                }
                uint num = MidiFile.SwapUInt32(binaryReader.ReadUInt32());
                if (num != 6u)
                {
                    throw new FormatException("Unexpected header chunk length");
                }
                this.fileFormat = MidiFile.SwapUInt16(binaryReader.ReadUInt16());
                int num2 = (int)MidiFile.SwapUInt16(binaryReader.ReadUInt16());
                this.deltaTicksPerQuarterNote = MidiFile.SwapUInt16(binaryReader.ReadUInt16());
                this.events = new MidiEventCollection((this.fileFormat == 0) ? 0 : 1, (int)this.deltaTicksPerQuarterNote);
                for (int i = 0; i < num2; i++)
                {
                    this.events.AddTrack();
                }
                long num3 = 0L;
                for (int j = 0; j < num2; j++)
                {
                    if (this.fileFormat == 1)
                    {
                        num3 = 0L;
                    }
                    @string = Encoding.UTF8.GetString(binaryReader.ReadBytes(4));
                    if (@string != "MTrk")
                    {
                        throw new FormatException("Invalid chunk header");
                    }
                    num = MidiFile.SwapUInt32(binaryReader.ReadUInt32());
                    long position = binaryReader.BaseStream.Position;
                    MidiEvent midiEvent = null;
                    List<NoteOnEvent> list = new List<NoteOnEvent>();
                    while (binaryReader.BaseStream.Position < position + (long)((ulong)num))
                    {
                        midiEvent = MidiEvent.ReadNextEvent(binaryReader, midiEvent);
                        num3 += (long)midiEvent.DeltaTime;
                        midiEvent.AbsoluteTime = num3;
                        this.events[j].Add(midiEvent);
                        if (midiEvent.CommandCode == MidiCommandCode.NoteOn)
                        {
                            NoteEvent noteEvent = (NoteEvent)midiEvent;
                            if (noteEvent.Velocity > 0)
                            {
                                list.Add((NoteOnEvent)noteEvent);
                            }
                            else
                            {
                                this.FindNoteOn(noteEvent, list);
                            }
                        }
                        else if (midiEvent.CommandCode == MidiCommandCode.NoteOff)
                        {
                            this.FindNoteOn((NoteEvent)midiEvent, list);
                        }
                        else if (midiEvent.CommandCode == MidiCommandCode.MetaEvent)
                        {
                            MetaEvent metaEvent = (MetaEvent)midiEvent;
                            if (metaEvent.MetaEventType == MetaEventType.EndTrack && strictChecking && binaryReader.BaseStream.Position < position + (long)((ulong)num))
                            {
                                throw new FormatException(string.Format("End Track event was not the last MIDI event on track {0}", j));
                            }
                        }
                    }
                    if (list.Count > 0 && strictChecking)
                    {
                        throw new FormatException(string.Format("Note ons without note offs {0} (file format {1})", list.Count, this.fileFormat));
                    }
                    if (binaryReader.BaseStream.Position != position + (long)((ulong)num))
                    {
                        throw new FormatException(string.Format("Read too far {0}+{1}!={2}", num, position, binaryReader.BaseStream.Position));
                    }
                }
            }
        }

        public MidiEventCollection Events
        {
            get
            {
                return this.events;
            }
        }

        public int Tracks
        {
            get
            {
                return this.events.Tracks;
            }
        }

        public int DeltaTicksPerQuarterNote
        {
            get
            {
                return (int)this.deltaTicksPerQuarterNote;
            }
        }

        private void FindNoteOn(NoteEvent offEvent, List<NoteOnEvent> outstandingNoteOns)
        {
            bool flag = false;
            foreach (NoteOnEvent noteOnEvent in outstandingNoteOns)
            {
                if (noteOnEvent.Channel == offEvent.Channel && noteOnEvent.NoteNumber == offEvent.NoteNumber)
                {
                    noteOnEvent.OffEvent = offEvent;
                    outstandingNoteOns.Remove(noteOnEvent);
                    flag = true;
                    break;
                }
            }
            if (!flag && this.strictChecking)
            {
                throw new FormatException(string.Format("Got an off without an on {0}", offEvent));
            }
        }

        private static uint SwapUInt32(uint i)
        {
            return (i & 4278190080u) >> 24 | (i & 16711680u) >> 8 | (i & 65280u) << 8 | (i & 255u) << 24;
        }

        private static ushort SwapUInt16(ushort i)
        {
            return (ushort)((i & 65280) >> 8 | (int)(i & 255) << 8);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Format {0}, Tracks {1}, Delta Ticks Per Quarter Note {2}\r\n", this.fileFormat, this.Tracks, this.deltaTicksPerQuarterNote);
            for (int i = 0; i < this.Tracks; i++)
            {
                foreach (MidiEvent arg in this.events[i])
                {
                    stringBuilder.AppendFormat("{0}\r\n", arg);
                }
            }
            return stringBuilder.ToString();
        }

        public static void Export(string filename, MidiEventCollection events)
        {
            if (events.MidiFileType == 0 && events.Tracks > 1)
            {
                throw new ArgumentException("Can't export more than one track to a type 0 file");
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(filename)))
            {
                binaryWriter.Write(Encoding.UTF8.GetBytes("MThd"));
                binaryWriter.Write(MidiFile.SwapUInt32(6u));
                binaryWriter.Write(MidiFile.SwapUInt16((ushort)events.MidiFileType));
                binaryWriter.Write(MidiFile.SwapUInt16((ushort)events.Tracks));
                binaryWriter.Write(MidiFile.SwapUInt16((ushort)events.DeltaTicksPerQuarterNote));
                for (int i = 0; i < events.Tracks; i++)
                {
                    IList<MidiEvent> list = events[i];
                    binaryWriter.Write(Encoding.UTF8.GetBytes("MTrk"));
                    long position = binaryWriter.BaseStream.Position;
                    binaryWriter.Write(MidiFile.SwapUInt32(0u));
                    long startAbsoluteTime = events.StartAbsoluteTime;
                    MergeSort.Sort<MidiEvent>(list, new MidiEventComparer());
                    int count = list.Count;
                    foreach (MidiEvent midiEvent in list)
                    {
                        midiEvent.Export(ref startAbsoluteTime, binaryWriter);
                    }
                    uint num = (uint)(binaryWriter.BaseStream.Position - position) - 4u;
                    binaryWriter.BaseStream.Position = position;
                    binaryWriter.Write(MidiFile.SwapUInt32(num));
                    binaryWriter.BaseStream.Position += (long)((ulong)num);
                }
            }
        }

        private MidiEventCollection events;

        private ushort fileFormat;

        private ushort deltaTicksPerQuarterNote;

        private bool strictChecking;
    }
}
