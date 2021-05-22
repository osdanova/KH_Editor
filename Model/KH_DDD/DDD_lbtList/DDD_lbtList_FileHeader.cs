using System;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_lbtList
{
    [Serializable]
    class DDD_lbtList_FileHeader
    {
        [Data(Count = 8)] public string magic { get; set; }
        [Data] public long boardCount { get; set; }
    }
}
