using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_techprm
{
    class DDD_techprm_File
    {
        // DATA
        public static readonly string HEX_EOF = FormatHelper.repeatString("CD", 8);

        public ObservableCollection<DDD_techprm_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_techprm_File() { entries = new ObservableCollection<DDD_techprm_Entry>(); }
        public DDD_techprm_File(List<byte> byteFile)
        {
            entries = new ObservableCollection<DDD_techprm_Entry>();
            for (int i = 0; i < (byteFile.Count / DDD_techprm_Entry.SIZE); i++)
            {
                List<byte> byteEntry = byteFile.GetRange(i * DDD_techprm_Entry.SIZE, DDD_techprm_Entry.SIZE);
                DDD_techprm_Entry entry = BinaryWrapper.toObject<DDD_techprm_Entry>(byteEntry);
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();

            foreach (DDD_techprm_Entry entry in entries)
            {
                byteFile.AddRange(BinaryWrapper.toBytes(entry));
            }

            byteFile.AddRange(BinaryHelper.hexStringAsBytes(HEX_EOF));

            return byteFile;
        }
    }
}
