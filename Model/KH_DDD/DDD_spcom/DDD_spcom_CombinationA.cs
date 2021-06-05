using System;
using KH_Editor.Dictionaries.KH_DDD;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_spcom
{
    [Serializable]
    class DDD_spcom_CombinationA
    {
        public static readonly int SIZE = 16;

        [Data] public short spirit1Id { get; set; }
        [Data] public short spirit2Id { get; set; }
        [Data] public byte piece1Id { get; set; }
        [Data] public byte piece1Category { get; set; }
        [Data] public byte piece2Id { get; set; }
        [Data] public byte piece2Category { get; set; }
        [Data] public byte chance { get; set; }
        [Data] public byte piece1Amount { get; set; }
        [Data] public byte piece2Amount { get; set; }
        [Data] public byte unk11 { get; set; }
        [Data] public byte rank { get; set; }
        [Data] public byte unk13 { get; set; }
        [Data] public byte unk14 { get; set; }
        [Data] public byte padding { get; set; }

        public string spirit1Name { get { return DDD_Spirits.getSpiritById((byte)spirit1Id); } }
        public string spirit2Name { get { return DDD_Spirits.getSpiritById((byte)spirit2Id); } }

        public string piece1Name { get { return DDD_Items.getItemNameById(piece1Id, piece1Category); } }
        public string piece2Name { get { return DDD_Items.getItemNameById(piece2Id, piece2Category); } }
    }
}
