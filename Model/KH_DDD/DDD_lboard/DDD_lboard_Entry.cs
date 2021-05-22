using System;
using System.Collections.Generic;
using KH_Editor.Dictionaries.KH_DDD;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_lboard
{
    [Serializable]
    class DDD_lboard_Entry
    {
        public static readonly int SIZE = 16;

        // 16 bytes total
        [Data] public byte Position { get; set; }
        [Data] public byte NodeType { get; set; }
        [Data] public byte secretRedUnlock { get; set; }
        [Data] public byte Links { get; set; }
        [Data] public byte disposition { get; set; }
        [Data] public short unk5 { get; set; }
        [Data] public byte secretUnlock { get; set; }
        [Data] public short cost { get; set; }
        [Data] public byte reward { get; set; }
        [Data] public byte secretRedUnlock2 { get; set; }
        [Data(Count = 4)] public List<byte> padding { get; set; }

        public byte posX
        {
            get { return (byte)(Position & 0xF); }
            set { Position = (byte)(value | (posY << 4)); }
        }
        public byte posY
        {
            get { return (byte) ((Position >> 4) & 0xF); }
            set { Position = (byte)(posX | (value << 4)); }
        }

        public string nodeTypeName { get { return DDD_Lboard.getNodeById(NodeType); } }

        public string linkRightName { get { return DDD_Lboard.getLinkById(linkRight); } }
        public byte linkRight
        {
            get { return (byte)(Links & 0x3); }
            set { Links = (byte)(value | (linkDown << 2)); }
        }
        public string linkDownName { get { return DDD_Lboard.getLinkById(linkDown); } }
        public byte linkDown
        {
            get { return (byte)((Links >> 2) & 0x3); }
            set { Links = (byte)(linkRight | (value << 2)); }
        }
    }
}
