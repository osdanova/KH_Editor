using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_tboxdt
{
    class DDD_tboxdt_File
    {
        // DATA

        public static readonly int HEADER_SIZE = 24;
        public static readonly int ENTRY_SIZE = 8;

        // True for Sora, false for Riku
        public bool isSora { get; set; }
        public DDD_tboxdt_FileHeader header { get; set; }
        public ObservableCollection<DDD_tboxdt_Entry> entries { get; set; }

        // CONSTRUCTORS

        public DDD_tboxdt_File() { header = new DDD_tboxdt_FileHeader(); entries = new ObservableCollection<DDD_tboxdt_Entry>(); }
        public DDD_tboxdt_File(List<byte> byteFile)
        {
            // Header
            header = BinaryMapper.toObject<DDD_tboxdt_FileHeader>(byteFile.GetRange(0, HEADER_SIZE));

            // Entries
            entries = new ObservableCollection<DDD_tboxdt_Entry>();
            for (int i = 0; i < header.totalCount; i++)
            {
                List<byte> byteEntry = byteFile.GetRange(HEADER_SIZE + (i * ENTRY_SIZE), ENTRY_SIZE);
                DDD_tboxdt_Entry entry = BinaryMapper.toObject<DDD_tboxdt_Entry>(byteEntry);
                entries.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();

            recalcCounts();
            byteFile.AddRange(BinaryMapper.toBytes(header));

            foreach (DDD_tboxdt_Entry entry in entries)
            {
                byteFile.AddRange(BinaryMapper.toBytes(entry));
            }
            return byteFile;
        }

        public void recalcCounts()
        {
            header.totalCount = 0;
            header.DIcount = 0;
            header.YTcount = 0;
            header.TWcount = 0;
            header.TMcount = 0;
            header.FAcount = 0;
            header.PIcount = 0;
            header.RGcount = 0;
            header.NDcount = 0;
            header.TLcount = 0;
            header.EHcount = 0;
            header.WMcount = 0;
            header.DEcount = 0;

            foreach (DDD_tboxdt_Entry entry in entries)
            {
                switch (entry.worldId)
                {
                    case (int)DDD_WorldAreas.DESTINY_ISLANDS: header.DIcount++; break;
                    case (int)DDD_WorldAreas.MYSTERIOUS_TOWER: header.YTcount++; break;
                    case (int)DDD_WorldAreas.TRAVERSE_TOWN: header.TWcount++; break;
                    case (int)DDD_WorldAreas.COUNTRY_MUSKETEERS: header.TMcount++; break;
                    case (int)DDD_WorldAreas.PRANKSTERS_PARADISE: header.FAcount++; break;
                    case (int)DDD_WorldAreas.SYMPHONY_SORCERY: header.PIcount++; break;
                    case (int)DDD_WorldAreas.RADIANT_GARDEN: header.RGcount++; break;
                    case (int)DDD_WorldAreas.CITE_DES_CLOCHES: header.NDcount++; break;
                    case (int)DDD_WorldAreas.THE_GRID: header.TLcount++; break;
                    case (int)DDD_WorldAreas.TWTNW: header.EHcount++; break;
                    case (int)DDD_WorldAreas.WORLD_MAP: header.WMcount++; break;
                    case (int)DDD_WorldAreas.DREAM_EATER: header.DEcount++; break;
                    default: break;
                }
            }

            header.recalcTotal();
        }
    }
}
