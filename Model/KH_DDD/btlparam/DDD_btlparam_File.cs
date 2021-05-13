using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.btlparam
{
    class DDD_btlparam_File
    {
        // DATA

        public static readonly int ENTRY_SIZE = 72;
        public static readonly string HEX_EOF = "CDCDCDCDCDCDCDCD";

        public ObservableCollection<DDD_btlparam_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_btlparam_File() { entries = new ObservableCollection<DDD_btlparam_Entry>(); }
        public DDD_btlparam_File(List<byte> byteFile)
        {
            entries = new ObservableCollection<DDD_btlparam_Entry>();
            int entryCount = byteFile.Count / ENTRY_SIZE;
            for (int i = 0; i < entryCount; i++)
            {
                List<byte> byteEntry = byteFile.GetRange(i * ENTRY_SIZE, ENTRY_SIZE);
                DDD_btlparam_Entry entry = BinaryMapper.toObject<DDD_btlparam_Entry>(byteEntry);
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();
            foreach (DDD_btlparam_Entry entry in entries)
            {
                byteFile.AddRange(BinaryMapper.toBytes(entry));
            }
            byteFile.AddRange(BinaryHelper.hexStringAsBytes(HEX_EOF));
            return byteFile;
        }
    }
}
