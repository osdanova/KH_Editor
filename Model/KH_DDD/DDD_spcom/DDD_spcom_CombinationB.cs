using System;
using System.Collections.Generic;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_spcom
{
    [Serializable]
    class DDD_spcom_CombinationB
    {
        public static readonly int SIZE = 16;

        [Data(Count=16)] public List<byte> unk { get; set; }
    }
}
