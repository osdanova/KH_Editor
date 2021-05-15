using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_inventory
{
    class DDD_inventory_CommandFile
    {
        // DATA

        public static readonly int ENTRY_SIZE = 8;
        public static readonly int ENTRY_COUNT = 500;

        public ObservableCollection<DDD_inventory_Command> entries { get; set; }

        // CONSTRUCTORS

        public DDD_inventory_CommandFile()
        {
            entries = new ObservableCollection<DDD_inventory_Command>();
        }
        public DDD_inventory_CommandFile(List<byte> byteFile)
        {
            entries = new ObservableCollection<DDD_inventory_Command>();

            for (int i = 0; i < ENTRY_COUNT; i++)
            {
                List<byte> byteEntry = byteFile.GetRange(i * ENTRY_SIZE, ENTRY_SIZE);
                DDD_inventory_Command entry = BinaryMapper.toObject<DDD_inventory_Command>(byteEntry);
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();
            foreach (DDD_inventory_Command entry in entries)
            {
                byteFile.AddRange(BinaryMapper.toBytes(entry));
            }
            return byteFile;
        }

        public static int getTotalByteSize()
        {
            return ENTRY_SIZE * ENTRY_COUNT;
        }
    }
}
