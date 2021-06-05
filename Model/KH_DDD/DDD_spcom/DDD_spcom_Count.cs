using System;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_spcom
{
    [Serializable]
    class DDD_spcom_Count
    {
        public static readonly int SIZE = 4;

        [Data] public short offset{ get; set; }
        [Data] public short count { get; set; }
    }
}
