using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_lboard
{
    class DDD_lboard_Board
    {
        // DATA

        public static readonly string HEX_EOF = "0008" + FormatHelper.repeatString("00",14);

        public ObservableCollection<DDD_lboard_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_lboard_Board() { entries = new ObservableCollection<DDD_lboard_Entry>(); }
        public DDD_lboard_Board(List<byte> byteFile)
        {
            Debug.WriteLine("--------------------------");
            Debug.WriteLine("BOARD");
            entries = new ObservableCollection<DDD_lboard_Entry>();
            int entryCount = byteFile.Count / DDD_lboard_Entry.SIZE;
            for (int i = 0; i < entryCount; i++)
            {
                Debug.WriteLine("Entry");
                List<byte> byteEntry = byteFile.GetRange(i * DDD_lboard_Entry.SIZE, DDD_lboard_Entry.SIZE);
                DDD_lboard_Entry entry = BinaryMapper.toObject<DDD_lboard_Entry>(byteEntry);
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();
            foreach (DDD_lboard_Entry entry in entries)
            {
                byteFile.AddRange(BinaryMapper.toBytes(entry));
            }
            byteFile.AddRange(BinaryHelper.hexStringAsBytes(HEX_EOF));
            return byteFile;
        }
    }
}
