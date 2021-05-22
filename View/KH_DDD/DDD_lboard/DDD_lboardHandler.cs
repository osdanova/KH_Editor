using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_lboard;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_lboard
{
    class DDD_lboardHandler : MainTestSocketed
    {
        public DDD_lboard_File file { get; set; }

        //public ObservableCollection<DDD_lboard_Entry> loadedBoard { get; set; }
        public DDD_lboard_Board loadedBoard { get; set; }
        public DDD_lboard_Board loadedBoard_VM { get => loadedBoard; set { loadedBoard = value; NotifyPropertyChanged("loadedBoard_VM"); } }

        // CONSTRUCTORS

        public DDD_lboardHandler(MainSocket mainSocketIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS)
        {
            file = new DDD_lboard_File();
            //loadedBoard = new ObservableCollection<DDD_lboard_Entry>();
            loadedBoard_VM = new DDD_lboard_Board();
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            try
            {
                // NOTE: The file is loaded when the DE menu is loaded
                loadFile(processHandler.readBytesFromProcessModuleUntilHexString((long)DDD_Pointers.LBOARD_MOD_EGS_B, DDD_lboard_File.HEX_EOF));
            }
            catch { writeInfoLabel("Error reading"); }
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            try
            {
                processHandler.writeBytesToProcessModule((long)DDD_Pointers.LBOARD_MOD_EGS_B, file.toBytes());
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
            DDD_lboard_File readFile = new DDD_lboard_File(byteFile);
            file.header = readFile.header;
            file.boards.Clear();
            foreach (DDD_lboard_Board board in readFile.boards) file.boards.Add(board);
        }

        public void loadBoard(DDD_lboard_Board board)
        {
            //loadedBoard.Clear();
            //foreach (DDD_lboard_Entry entry in board.entries) loadedBoard.Add(entry);
            loadedBoard_VM = board;
        }
    }
}
