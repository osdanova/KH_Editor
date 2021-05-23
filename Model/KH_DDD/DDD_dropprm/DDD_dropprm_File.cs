using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_dropprm
{
    class DDD_dropprm_File
    {
        // DATA
        public static readonly string HEX_EOF = FormatHelper.repeatString("CD", 8);

        public ObservableCollection<DDD_dropprm_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_dropprm_File() { entries = new ObservableCollection<DDD_dropprm_Entry>(); }
        public DDD_dropprm_File(List<byte> byteFile)
        {
            entries = new ObservableCollection<DDD_dropprm_Entry>();
            for (int i = 0; i < (byteFile.Count / DDD_dropprm_Entry.SIZE); i++)
            {
                List<byte> byteEntry = byteFile.GetRange(i * DDD_dropprm_Entry.SIZE, DDD_dropprm_Entry.SIZE);
                DDD_dropprm_Entry entry = BinaryWrapper.toObject<DDD_dropprm_Entry>(byteEntry);
                entry.Id = i;
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();

            foreach (DDD_dropprm_Entry entry in entries)
            {
                byteFile.AddRange(BinaryWrapper.toBytes(entry));
            }

            byteFile.AddRange(BinaryHelper.hexStringAsBytes(HEX_EOF));

            return byteFile;
        }
    }
}
