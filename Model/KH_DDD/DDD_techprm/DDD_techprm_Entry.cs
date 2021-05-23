using System;
using System.Collections.Generic;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_techprm
{
    [Serializable]
    class DDD_techprm_Entry
    {
        public static readonly int SIZE = 20;

        [Data] public short unk0 { get; set; }
        [Data] public short power { get; set; }
        [Data] public byte unk4 { get; set; }
        [Data] public byte unk5 { get; set; }
        [Data] public byte unk6 { get; set; }
        [Data] public byte bitfield7 { get; set; }
        [Data] public byte element { get; set; }
        [Data] public byte unk9 { get; set; }
        [Data] public byte unk10 { get; set; }
        [Data] public byte unk11 { get; set; }
        [Data] public byte unk12 { get; set; }
        [Data] public byte unk13 { get; set; }
        [Data] public byte unk14 { get; set; }
        [Data] public byte unk15 { get; set; }
        [Data] public byte target { get; set; }
        [Data(Count = 3)] public List<byte> padding { get; set; }
    }
}
