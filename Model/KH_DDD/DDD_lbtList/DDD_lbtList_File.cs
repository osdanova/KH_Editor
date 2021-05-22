using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_lbtList
{
    class DDD_lbtList_File
    {
        // DATA

        public static readonly int HEADER_SIZE = 16;
        public static readonly int EOFPADDING_SIZE = 4 * DDD_lbtList_Entry.SIZE;
        public static readonly string HEX_EOF = FormatHelper.repeatString("00", EOFPADDING_SIZE);

        public DDD_lbtList_FileHeader header { get; set; }
        public ObservableCollection<DDD_lbtList_Board> boards { get; set; }
        public List<byte> filePadding { get; set; }

        // CONSTRUCTORS

        public DDD_lbtList_File() { header = new DDD_lbtList_FileHeader(); boards = new ObservableCollection<DDD_lbtList_Board>(); filePadding = new List<byte>(); }
        public DDD_lbtList_File(List<byte> byteFile)
        {
            // Header
            header = BinaryWrapper.toObject<DDD_lbtList_FileHeader>(byteFile.GetRange(0, HEADER_SIZE));

            // Boards
            boards = new ObservableCollection<DDD_lbtList_Board>();
            for (int i = 0; i < header.boardCount; i++)
            {
                List<byte> byteBoard = byteFile.GetRange(HEADER_SIZE + (i * DDD_lbtList_Board.SIZE), DDD_lbtList_Board.SIZE);
                DDD_lbtList_Board board = new DDD_lbtList_Board(byteBoard, i);
                boards.Add(board);
            }

            // EOF padding
            filePadding = byteFile.GetRange(byteFile.Count - EOFPADDING_SIZE, EOFPADDING_SIZE);
        }

        // FUNCTIONS

        public List<byte> toBytes()
        {
            List<byte> byteFile = new List<byte>();

            recalcCounts();
            byteFile.AddRange(BinaryWrapper.toBytes(header));

            foreach (DDD_lbtList_Board board in boards)
            {
                byteFile.AddRange(board.toBytes());
            }
            byteFile.AddRange(filePadding);
            return byteFile;
        }

        public void recalcCounts()
        {
            header.boardCount = boards.Count;
        }

        public static int calcFileSizeByBoardCount(int boardCount)
        {
            return HEADER_SIZE + (boardCount * DDD_lbtList_Board.SIZE) + EOFPADDING_SIZE;
        }
    }
}
