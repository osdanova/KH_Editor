using System;
using System.Collections.Generic;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_lboard
{
    [Serializable]
    class DDD_lboard_Header
    {
        public static readonly int SIZE = 240;

        // 240 bytes total
        [Data(Count = 8)] public string magic { get; set; }
        [Data] public long boardCount { get; set; }
        [Data(Count = 55)] public List<int> boardOffsets { get; set; }
        [Data] public int padding { get; set; }

        public void resetCounts()
        {
            for (int i = 0; i < boardOffsets.Count; i++) boardOffsets[i] = 0;
        }
    }
}
