using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Dictionaries.KH_DDD;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_lboard
{
    class DDD_lboard_Board
    {
        // DATA

        public int spiritType { get; set; }
        public string spiritTypeName { get { return DDD_Spirits.getSpiritById(spiritType); } }
        public static readonly string HEX_EOF = "0008" + FormatHelper.repeatString("00",14);

        public ObservableCollection<DDD_lboard_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_lboard_Board() { entries = new ObservableCollection<DDD_lboard_Entry>(); }
        public DDD_lboard_Board(List<byte> byteFile) { construct(byteFile); }
        public DDD_lboard_Board(List<byte> byteFile, int type) { construct(byteFile); spiritType = type; }

        private void construct(List<byte> byteFile)
        {
            entries = new ObservableCollection<DDD_lboard_Entry>();
            int entryCount = byteFile.Count / DDD_lboard_Entry.SIZE;
            for (int i = 0; i < entryCount; i++)
            {
                List<byte> byteEntry = byteFile.GetRange(i * DDD_lboard_Entry.SIZE, DDD_lboard_Entry.SIZE);
                DDD_lboard_Entry entry = BinaryWrapper.toObject<DDD_lboard_Entry>(byteEntry);
                entries.Add(entry);
            }
        }

            // FUNCTIONS

            public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();
            foreach (DDD_lboard_Entry entry in entries)
            {
                byteFile.AddRange(BinaryWrapper.toBytes(entry));
            }
            //byteFile.AddRange(BinaryHelper.hexStringAsBytes(HEX_EOF));
            return byteFile;
        }
    }
}
