using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_lboard
{
    class DDD_lboard_File
    {
        // DATA

        public static readonly string HEX_EOF = FormatHelper.repeatString("00", 16);

        public DDD_lboard_Header header { get; set; }
        public ObservableCollection<DDD_lboard_Board> boards { get; set; }

        // CONSTRUCTORS

        public DDD_lboard_File() { header = new DDD_lboard_Header(); boards = new ObservableCollection<DDD_lboard_Board>(); }
        public DDD_lboard_File(List<byte> byteFile)
        {
            header = BinaryWrapper.toObject<DDD_lboard_Header>(byteFile.GetRange(0, DDD_lboard_Header.SIZE));
            boards = new ObservableCollection<DDD_lboard_Board>();
            for (int i = 0; i < header.boardCount; i++)
            {
                int boardOffset = header.boardOffsets[i];
                int nextOffset;
                if (i == header.boardCount - 1) nextOffset = byteFile.Count - DDD_lboard_Entry.SIZE;
                else nextOffset = header.boardOffsets[i + 1];

                int boardSize = nextOffset - boardOffset;

                List<byte> byteEntry = byteFile.GetRange(boardOffset, boardSize);
                DDD_lboard_Board entry = new DDD_lboard_Board(byteEntry, i);
                boards.Add(entry);
            }
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            recalcCounts();

            List<byte> byteFile = new List<byte>();

            byteFile.AddRange(BinaryWrapper.toBytes(header));

            foreach (DDD_lboard_Board board in boards)
            {
                byteFile.AddRange(board.toBytes());
            }
            byteFile.AddRange(BinaryHelper.hexStringAsBytes(HEX_EOF));
            return byteFile;
        }

        public void recalcCounts()
        {
            header.resetCounts();

            header.boardCount = boards.Count;
            int currentOffset = DDD_lboard_Header.SIZE;
            for(int i = 0;  i < boards.Count; i++)
            {
                header.boardOffsets[i] = currentOffset;
                currentOffset += (boards[i].entries.Count * DDD_lboard_Entry.SIZE);
            }
        }
    }
}
