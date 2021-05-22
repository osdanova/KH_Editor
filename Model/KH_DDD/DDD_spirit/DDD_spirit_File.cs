using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_spirit
{
    class DDD_spirit_File
    {
        // DATA

        public static readonly int ENTRY_COUNT = 50;
        public static readonly int ENTRY_SIZE = 256;

        public ObservableCollection<DDD_spirit_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_spirit_File() { entries = new ObservableCollection<DDD_spirit_Entry>(); }
        public DDD_spirit_File(List<byte> byteFile)
        {
            entries = new ObservableCollection<DDD_spirit_Entry>();
            for (int i = 0; i < ENTRY_COUNT; i++)
            {
                List<byte> byteEntry = byteFile.GetRange(i * ENTRY_SIZE, ENTRY_SIZE);
                DDD_spirit_Entry entry = BinaryWrapper.toObject<DDD_spirit_Entry>(byteEntry);
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();

            foreach (DDD_spirit_Entry entry in entries)
            {
                byteFile.AddRange(BinaryWrapper.toBytes(entry));
            }
            return byteFile;
        }
    }
}
