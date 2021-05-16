using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_tboxdt;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_tboxdt
{
    class DDD_tboxdtHandler : MainTestSocketed
    {
        public DDD_tboxdt_File file { get; set; }

        // CONSTRUCTORS

        public DDD_tboxdtHandler(MainSocket mainSocketIn, bool isSoraIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS)
        {
            file = new DDD_tboxdt_File();
            file.isSora = isSoraIn;
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            try
            {
                long fileOffset = (long)DDD_Pointers.TBOXDTSO_MOD_EGS;
                if(!file.isSora) fileOffset = (long)DDD_Pointers.TBOXDTRI_MOD_EGS;

                Debug.WriteLine("fileOffset: " + fileOffset);
                int entryCount = BinaryHelper.bytesAsByte(processHandler.readBytesFromProcessModule(fileOffset + 8, 1));
                Debug.WriteLine("entryCount: " + entryCount);
                int byteSize = DDD_tboxdt_File.HEADER_SIZE + (entryCount * DDD_tboxdt_File.ENTRY_SIZE);

                loadFile(processHandler.readBytesFromProcessModule(fileOffset, byteSize));
            }
            catch { writeInfoLabel("Error reading"); }
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            try
            {
                long fileOffset = (long)DDD_Pointers.TBOXDTSO_MOD_EGS;
                if(!file.isSora) fileOffset = (long)DDD_Pointers.TBOXDTRI_MOD_EGS;

                processHandler.writeBytesToProcessModule(fileOffset, file.toBytes());
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
            DDD_tboxdt_File readFile = new DDD_tboxdt_File(byteFile);
            file.entries.Clear();
            foreach (DDD_tboxdt_Entry entry in readFile.entries) file.entries.Add(entry);
        }
    }
}
