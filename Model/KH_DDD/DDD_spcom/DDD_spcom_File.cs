using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_spcom
{
    class DDD_spcom_File
    {
        public DDD_spcom_Header header { get; set; }
        public ObservableCollection<DDD_spcom_Count> counts { get; set; }
        public ObservableCollection<DDD_spcom_CombinationA> entriesA { get; set; }
        public ObservableCollection<DDD_spcom_CombinationB> entriesB { get; set; }

        // CONSTRUCTORS

        public DDD_spcom_File()
        {
            counts = new ObservableCollection<DDD_spcom_Count>();
            entriesA = new ObservableCollection<DDD_spcom_CombinationA>();
            entriesB = new ObservableCollection<DDD_spcom_CombinationB>();
        }
        public DDD_spcom_File(List<byte> byteFile)
        {
            counts = new ObservableCollection<DDD_spcom_Count>();
            entriesA = new ObservableCollection<DDD_spcom_CombinationA>();
            entriesB = new ObservableCollection<DDD_spcom_CombinationB>();

            header = BinaryWrapper.toObject<DDD_spcom_Header>(byteFile.GetRange(0, DDD_spcom_Header.SIZE));

            // COUNTS
            int countsCount = header.spiritCount + 1; // + padding?
            for (int i = 0; i < countsCount; i++) { counts.Add(BinaryWrapper.toObject<DDD_spcom_Count>(byteFile.GetRange(header.countsOffset + i * DDD_spcom_Count.SIZE, DDD_spcom_Count.SIZE)));  }

            //TABLE A
            for (int i = 0; i < header.tableACount; i++) { entriesA.Add(BinaryWrapper.toObject<DDD_spcom_CombinationA>(byteFile.GetRange(header.tableAOffset + i * DDD_spcom_CombinationA.SIZE, DDD_spcom_CombinationA.SIZE))); }

            // TABLE B
            for (int i = 0; i < header.tableBCount; i++) { entriesB.Add(BinaryWrapper.toObject<DDD_spcom_CombinationB>(byteFile.GetRange(header.tableBOffset + i * DDD_spcom_CombinationB.SIZE, DDD_spcom_CombinationB.SIZE))); }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();

            byteFile.AddRange(BinaryWrapper.toBytes(header));

            foreach (DDD_spcom_Count count in counts) { byteFile.AddRange(BinaryWrapper.toBytes(count)); Console.WriteLine("count"); }
            foreach (DDD_spcom_CombinationA entry in entriesA) { byteFile.AddRange(BinaryWrapper.toBytes(entry)); Console.WriteLine("entryA"); }
            foreach (DDD_spcom_CombinationB entry in entriesB) { byteFile.AddRange(BinaryWrapper.toBytes(entry)); Console.WriteLine("entryB"); }

            return byteFile;
        }
    }
}
