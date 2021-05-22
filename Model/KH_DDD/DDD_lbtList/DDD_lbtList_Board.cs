using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Dictionaries.KH_DDD;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_lbtList
{
    class DDD_lbtList_Board
    {
        // DATA

        public static readonly int ENTRY_COUNT = 16;
        public static readonly int SIZE = ENTRY_COUNT * DDD_lbtList_Entry.SIZE;
        public int spiritType { get; set; }
        public string spiritTypeName { get { return DDD_Spirits.getSpiritById(spiritType); } }

        public ObservableCollection<DDD_lbtList_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_lbtList_Board() => entries = new ObservableCollection<DDD_lbtList_Entry>();
        public DDD_lbtList_Board(List<byte> byteFile) { construct(byteFile); }
        public DDD_lbtList_Board(List<byte> byteFile, int type) { construct(byteFile); spiritType = type; }

        private void construct(List<byte> byteFile)
        {
            entries = new ObservableCollection<DDD_lbtList_Entry>();
            for (int i = 0; i < ENTRY_COUNT; i++)
            {
                List<byte> byteEntry = byteFile.GetRange(i * DDD_lbtList_Entry.SIZE, DDD_lbtList_Entry.SIZE);
                DDD_lbtList_Entry entry = BinaryWrapper.toObject<DDD_lbtList_Entry>(byteEntry);
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();
            foreach (DDD_lbtList_Entry entry in entries)
            {
                byteFile.AddRange(BinaryWrapper.toBytes(entry));
            }
            return byteFile;
        }
    }
}
