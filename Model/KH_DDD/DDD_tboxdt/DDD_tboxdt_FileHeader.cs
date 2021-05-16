using System;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_tboxdt
{
    [Serializable]
    class DDD_tboxdt_FileHeader
    {
        [Data(Count = 4)] public string fileName { get; set; }
        [Data] public int fileType { get; set; }
        [Data] public int totalCount { get; set; }
        [Data] public byte DIcount { get; set; }
        [Data] public byte YTcount { get; set; }
        [Data] public byte TWcount { get; set; }
        [Data] public byte TMcount { get; set; }
        [Data] public byte FAcount { get; set; }
        [Data] public byte PIcount { get; set; }
        [Data] public byte RGcount { get; set; }
        [Data] public byte NDcount { get; set; }
        [Data] public byte TLcount { get; set; }
        [Data] public byte EHcount { get; set; }
        [Data] public byte WMcount { get; set; }
        [Data] public byte DEcount { get; set; }

        public void recalcTotal()
        {
            totalCount = (byte)(DIcount +
                                YTcount +
                                TWcount +
                                TMcount +
                                FAcount +
                                PIcount +
                                RGcount +
                                NDcount +
                                TLcount +
                                EHcount +
                                WMcount +
                                DEcount);
        }
    }
}
