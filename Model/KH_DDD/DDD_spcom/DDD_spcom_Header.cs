using System;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_spcom
{
    [Serializable]
    class DDD_spcom_Header
    {
        public static readonly int SIZE = 32;

        [Data(Count = 8)] public string version { get; set; }
        [Data] public int spiritCount { get; set; }
        [Data] public int tableACount { get; set; }
        [Data] public int countsOffset  { get; set; }
        [Data] public int tableAOffset { get; set; }
        [Data] public int tableBOffset { get; set; }
        [Data] public int tableBCount { get; set; }

        public int getFileSize()
        {
            return tableBOffset + (tableBCount * DDD_spcom_CombinationB.SIZE);
        }
    }
}
