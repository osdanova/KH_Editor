using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_itemdata
{
    class DDD_itemdata_File
    {
        // DATA

        public static readonly int HEADER_SIZE = 28;
        public static readonly int ENTRY_SIZE = 4;
        public static readonly string HEX_EOF = FormatHelper.repeatString("CD",8);

        public DDD_itemdata_FileHeader header { get; set; }
        public ObservableCollection<DDD_itemdata_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_itemdata_File() { header = new DDD_itemdata_FileHeader();  entries = new ObservableCollection<DDD_itemdata_Entry>(); }
        public DDD_itemdata_File(List<byte> byteFile)
        {
            // Header
            header = BinaryMapper.toObject<DDD_itemdata_FileHeader>(byteFile.GetRange(0,HEADER_SIZE));

            // Entries
            entries = new ObservableCollection<DDD_itemdata_Entry>();
            for (int i = 0; i < header.getEntryCount(); i++)
            {
                List<byte> byteEntry = byteFile.GetRange(HEADER_SIZE + (i * ENTRY_SIZE), ENTRY_SIZE);
                DDD_itemdata_Entry entry = BinaryMapper.toObject<DDD_itemdata_Entry>(byteEntry);
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();

            recalcCounts();
            byteFile.AddRange(BinaryMapper.toBytes(header));

            foreach (DDD_itemdata_Entry entry in entries)
            {
                byteFile.AddRange(BinaryMapper.toBytes(entry));
            }
            byteFile.AddRange(BinaryHelper.hexStringAsBytes(HEX_EOF));
            return byteFile;
        }

        public void recalcCounts()
        {
            header.keybladeCount = 0;
            header.recipeCount = 0;
            header.keyItemCount = 0;
            header.glossaryCount = 0;
            header.dreamPieceCount = 0;
            header.treatCount = 0;
            header.trainingToyCount = 0;
            header.mementoCount = 0;
            header.unknownCount = 0;

            foreach (DDD_itemdata_Entry entry in entries)
            {
                switch(entry.category)
                {
                    case (int)DDD_ItemCategories.KEYBLADE: header.keybladeCount++; break;
                    case (int)DDD_ItemCategories.RECIPE: header.recipeCount++; break;
                    case (int)DDD_ItemCategories.KEY_ITEM: header.keyItemCount++; break;
                    case (int)DDD_ItemCategories.GLOSSARY: header.glossaryCount++; break;
                    case (int)DDD_ItemCategories.DREAM_PIECE: header.dreamPieceCount++; break;
                    case (int)DDD_ItemCategories.TREAT: header.treatCount++; break;
                    case (int)DDD_ItemCategories.TRAINING_TOY: header.trainingToyCount++; break;
                    case (int)DDD_ItemCategories.MEMENTO: header.mementoCount++; break;
                    case (int)DDD_ItemCategories.UNKNOWN: header.unknownCount++; break;
                    default: break;
                }
            }
        }
    }
}
