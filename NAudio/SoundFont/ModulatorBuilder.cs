﻿using System;
using System.IO;

namespace NAudio.SoundFont
{
    internal class ModulatorBuilder : StructureBuilder<Modulator>
    {
        public override Modulator Read(BinaryReader br)
        {
            Modulator modulator = new Modulator();
            modulator.SourceModulationData = new ModulatorType(br.ReadUInt16());
            modulator.DestinationGenerator = (GeneratorEnum)br.ReadUInt16();
            modulator.Amount = br.ReadInt16();
            modulator.SourceModulationAmount = new ModulatorType(br.ReadUInt16());
            modulator.SourceTransform = (TransformEnum)br.ReadUInt16();
            this.data.Add(modulator);
            return modulator;
        }

        public override void Write(BinaryWriter bw, Modulator o)
        {
        }

        public override int Length
        {
            get
            {
                return 10;
            }
        }

        public Modulator[] Modulators
        {
            get
            {
                return this.data.ToArray();
            }
        }
    }
}
