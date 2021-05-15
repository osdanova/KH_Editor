using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using KH_Editor.Enums.MemoryPointers;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_inventory
{
    class DDD_inventory_File
    {
        // DATA

        public static readonly int ENTRY_SIZE = 2;
        public static readonly int ENTRY_SIZE_STACK = 4;

        public static readonly int COUNT_TOTAL = 246;
        public static readonly int COUNT_KEYBLADES = 32;
        public static readonly int COUNT_KEY_ITEMS = 40;
        public static readonly int COUNT_RECIPES = 60;
        public static readonly int COUNT_GLOSSARY = 20;
        public static readonly int COUNT_MEMENTO = 40;
        public static readonly int COUNT_UNKNOWN = 54;

        public static readonly int COUNT_TOTAL_STACK = 77;
        public static readonly int COUNT_DREAM_PIECES = 37;
        public static readonly int COUNT_TREATS = 20;
        public static readonly int COUNT_TRAINING_TOYS = 20;

        public ObservableCollection<DDD_inventory_Entry> entries { get; set; }
        public ObservableCollection<DDD_inventory_EntryStack> entriesStack { get; set; }

        // CONSTRUCTORS

        public DDD_inventory_File()
        {
            entries = new ObservableCollection<DDD_inventory_Entry>();
            entriesStack = new ObservableCollection<DDD_inventory_EntryStack>();
        }
        public DDD_inventory_File(List<byte> byteFile)
        {
            entries = new ObservableCollection<DDD_inventory_Entry>();
            entriesStack = new ObservableCollection<DDD_inventory_EntryStack>();

            // ITEMS

            int currentOffset = 0;
            currentOffset = loadCategory(byteFile, currentOffset, (int)DDD_ItemCategories.KEYBLADE);
            currentOffset = loadCategory(byteFile, currentOffset, (int)DDD_ItemCategories.KEY_ITEM);
            currentOffset = loadCategory(byteFile, currentOffset, (int)DDD_ItemCategories.RECIPE);
            currentOffset = loadCategory(byteFile, currentOffset, (int)DDD_ItemCategories.GLOSSARY);
            currentOffset = loadCategory(byteFile, currentOffset, (int)DDD_ItemCategories.MEMENTO);
            currentOffset = loadCategory(byteFile, currentOffset, (int)DDD_ItemCategories.UNKNOWN);
            currentOffset = loadStackCategory(byteFile, currentOffset, (int)DDD_ItemCategories.DREAM_PIECE);
            currentOffset = loadStackCategory(byteFile, currentOffset, (int)DDD_ItemCategories.TREAT);
            currentOffset = loadStackCategory(byteFile, currentOffset, (int)DDD_ItemCategories.TRAINING_TOY);
        }

        private int loadCategory(List<byte> byteFile, int currentOffset, byte category)
        {
            int count = 0;
            switch (category)
            {
                case (int)DDD_ItemCategories.KEYBLADE:
                    count = COUNT_KEYBLADES;
                    break;
                case (int)DDD_ItemCategories.RECIPE:
                    count = COUNT_RECIPES;
                    break;
                case (int)DDD_ItemCategories.KEY_ITEM:
                    count = COUNT_KEY_ITEMS;
                    break;
                case (int)DDD_ItemCategories.GLOSSARY:
                    count = COUNT_GLOSSARY;
                    break;
                case (int)DDD_ItemCategories.MEMENTO:
                    count = COUNT_MEMENTO;
                    break;
                case (int)DDD_ItemCategories.UNKNOWN:
                    count = COUNT_UNKNOWN;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < count; i++)
            {
                List<byte> byteEntry = byteFile.GetRange(currentOffset, ENTRY_SIZE);
                DDD_inventory_Entry entry = BinaryMapper.toObject<DDD_inventory_Entry>(byteEntry);
                entry.categoryId = category;
                entry.typeId = (byte)i;
                entries.Add(entry);
                currentOffset += ENTRY_SIZE;
            }

            return currentOffset;
        }
        private int loadStackCategory(List<byte> byteFile, int currentOffset, byte category)
        {
            int count = 0;
            switch(category)
            {
                case (int)DDD_ItemCategories.DREAM_PIECE:
                    count = COUNT_DREAM_PIECES;
                    break;
                case (int)DDD_ItemCategories.TREAT:
                    count = COUNT_TREATS;
                    break;
                case (int)DDD_ItemCategories.TRAINING_TOY:
                    count = COUNT_TRAINING_TOYS;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < count; i++)
            {
                List<byte> byteEntry = byteFile.GetRange(currentOffset, ENTRY_SIZE_STACK);
                DDD_inventory_EntryStack entry = BinaryMapper.toObject<DDD_inventory_EntryStack>(byteEntry);
                entry.categoryId = category;
                entry.typeId = (byte)i;
                entriesStack.Add(entry);
                currentOffset += ENTRY_SIZE_STACK;
            }

            return currentOffset;
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();
            foreach (DDD_inventory_Entry entry in entries)
            {
                byteFile.AddRange(BinaryMapper.toBytes(entry));
            }
            foreach (DDD_inventory_EntryStack entry in entriesStack)
            {
                byteFile.AddRange(BinaryMapper.toBytes(entry));
            }
            return byteFile;
        }

        public static int getTotalByteSize()
        {
            return (COUNT_TOTAL * ENTRY_SIZE) + (COUNT_TOTAL_STACK * ENTRY_SIZE_STACK);
        }
    }
}
