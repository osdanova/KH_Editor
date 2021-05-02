using System;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.btlparam
{
    [Serializable]
    class DDD_btlparam_Entry
    {
        // 72 bytes total
        [Data(Count = 8)] public string entity { get; set; }
        [Data] public short unk8 { get; set; }
        [Data] public short unk10 { get; set; }
        [Data] public byte unk12 { get; set; }
        [Data] public byte unk13 { get; set; }
        [Data] public short unk14 { get; set; }
        [Data] public short ele_physical { get; set; }
        [Data] public short ele_fire { get; set; }
        [Data] public short ele_blizzard { get; set; }
        [Data] public short ele_thunder { get; set; }
        [Data] public short ele_water { get; set; }
        [Data] public short ele_dark { get; set; }
        [Data] public short ele_light { get; set; }
        [Data] public short unk30 { get; set; }
        [Data] public short unk32 { get; set; }
        [Data] public short unk34 { get; set; }
        [Data(Count = 8)] public byte[] unk36 { get; set; }
        [Data] public short hp { get; set; }
        [Data] public short attack { get; set; }
        [Data] public short magic { get; set; }
        [Data] public short defense { get; set; }
        [Data(Count = 4)] public byte[] unk52 { get; set; }
        [Data(Count = 3)] public byte[] statusFlags { get; set; }
        [Data(Count = 13)] public byte[] runtimeReserved { get; set; }
    }
}
