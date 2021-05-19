using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_lboard
{
    [Serializable]
    class DDD_lboard_Entry
    {
        public static readonly int SIZE = 16;

        // 16 bytes total
        [Data] public byte Position { get; set; }
        [Data] public byte NodeFlags { get; set; }
        [Data] public byte unk2 { get; set; }
        [Data] public byte Connections { get; set; }
        [Data] public byte dispositionMaybe { get; set; }
        [Data] public short unk5 { get; set; }
        [Data] public byte unk7 { get; set; }
        [Data] public short cost { get; set; }
        [Data] public byte reward { get; set; }
        [Data] public byte unk11 { get; set; }
        [Data(Count = 4)] public byte padding { get; set; }
    }
}
