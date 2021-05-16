using System;
using Xe.BinaryMapper;

namespace KH_Editor.Model.KH_DDD.DDD_itemdata
{
    [Serializable]
    class DDD_itemdata_FileHeader
    {
        [Data(Count = 4)] public string fileName { get; set; }
        [Data] public int fileType { get; set; }
        [Data] public short keybladeCount { get; set; }
        [Data] public short recipeCount { get; set; }
        [Data] public short keyItemCount { get; set; }
        [Data] public short glossaryCount { get; set; }
        [Data] public short dreamPieceCount { get; set; }
        [Data] public short treatCount { get; set; }
        [Data] public short trainingToyCount { get; set; }
        [Data] public short mementoCount { get; set; }
        [Data] public short unknownCount { get; set; }
        [Data] public short padding { get; set; }

        public int getEntryCount()
        {
            return keybladeCount + recipeCount + keyItemCount + glossaryCount + dreamPieceCount + treatCount + trainingToyCount + mementoCount + unknownCount;
        }
    }
}
