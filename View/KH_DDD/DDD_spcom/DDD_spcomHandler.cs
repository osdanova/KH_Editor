using System.Collections.Generic;
using System.IO;
using System.Linq;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_spcom;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_spcom
{
    class DDD_spcomHandler : MainTestSocketed
    {
        public DDD_spcom_File file { get; set; }

        // CONSTRUCTORS

        public DDD_spcomHandler(MainSocket mainSocketIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS)
        {
            file = new DDD_spcom_File();
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            try
            {
                DDD_spcom_Header byteFileHeader = BinaryWrapper.toObject<DDD_spcom_Header>(processHandler.readBytesFromProcessModule((long)DDD_Pointers.SPCOM_MOD_EGS, DDD_spcom_Header.SIZE));

                loadFile(processHandler.readBytesFromProcessModule((long)DDD_Pointers.SPCOM_MOD_EGS, byteFileHeader.getFileSize()));
            }
            catch { writeInfoLabel("Error reading"); }
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            try
            {
                processHandler.writeBytesToProcessModule((long)DDD_Pointers.SPCOM_MOD_EGS, file.toBytes());
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
            DDD_spcom_File readFile = new DDD_spcom_File(byteFile);
            file.header = readFile.header;
            file.counts.Clear();
            file.entriesA.Clear();
            file.entriesB.Clear();
            foreach (DDD_spcom_Count count in readFile.counts) { file.counts.Add(count); }
            foreach (DDD_spcom_CombinationA entry in readFile.entriesA) { file.entriesA.Add(entry); }
            foreach (DDD_spcom_CombinationB entry in readFile.entriesB) { file.entriesB.Add(entry); }
        }
    }
}
