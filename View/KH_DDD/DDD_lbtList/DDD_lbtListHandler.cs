using System.Collections.Generic;
using System.IO;
using System.Linq;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_lbtList;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_lbtList
{
    class DDD_lbtListHandler : MainTestSocketed
    {
        public DDD_lbtList_File file { get; set; }

        public DDD_lbtList_Board loadedBoard { get; set; }
        public DDD_lbtList_Board loadedBoard_VM { get => loadedBoard; set { loadedBoard = value; NotifyPropertyChanged("loadedBoard_VM"); } }

        // CONSTRUCTORS

        public DDD_lbtListHandler(MainSocket mainSocketIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS)
        {
            file = new DDD_lbtList_File();
            loadedBoard_VM = new DDD_lbtList_Board();
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            try
            {
                int entryCount = BinaryHelper.bytesAsInt(processHandler.readBytesFromProcessModule((long)DDD_Pointers.LBT_LIST_MOD_EGS + 8, 4));
                int fileSize = DDD_lbtList_File.calcFileSizeByBoardCount(entryCount);
                loadFile(processHandler.readBytesFromProcessModule((long)DDD_Pointers.LBT_LIST_MOD_EGS, fileSize));
            }
            catch { writeInfoLabel("Error reading"); }
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            try
            {
                processHandler.writeBytesToProcessModule((long)DDD_Pointers.LBT_LIST_MOD_EGS, file.toBytes());
            }
            catch { writeInfoLabel("Error writing"); }
        }

        override
        public void exportAction()
        {
            FileHelper.saveFile(file.toBytes());
        }

        public void dropFile(string filePath)
        {
            writeInfoLabel("Loading file...");
            try
            {
                loadFile(File.ReadAllBytes(filePath).ToList());
                writeInfoLabel("File loaded");
            }
            catch { writeInfoLabel("Error loading file"); }
        }

        // FUNCTIONS

        public void loadFile(List<byte> byteFile)
        {
            DDD_lbtList_File readFile = new DDD_lbtList_File(byteFile);
            file.header = readFile.header;
            file.boards.Clear();
            file.filePadding = readFile.filePadding;
            foreach (DDD_lbtList_Board board in readFile.boards) file.boards.Add(board);
        }

        public void loadBoard(DDD_lbtList_Board board)
        {
            loadedBoard_VM = board;
        }
    }
}
