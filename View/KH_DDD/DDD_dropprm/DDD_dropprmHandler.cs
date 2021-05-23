using System.Collections.Generic;
using System.IO;
using System.Linq;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_dropprm;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_dropprm
{
    class DDD_dropprmHandler : MainTestSocketed
    {
        public DDD_dropprm_File file { get; set; }

        // CONSTRUCTORS

        public DDD_dropprmHandler(MainSocket mainSocketIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS)
        {
            file = new DDD_dropprm_File();
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            try
            {
                loadFile(processHandler.readBytesFromProcessModuleUntilHexString((long)DDD_Pointers.DROPPRM_MOD_EGS, DDD_dropprm_File.HEX_EOF));
            }
            catch { writeInfoLabel("Error reading"); }
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            try
            {
                processHandler.writeBytesToProcessModule((long)DDD_Pointers.DROPPRM_MOD_EGS, file.toBytes());
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
            DDD_dropprm_File readFile = new DDD_dropprm_File(byteFile);
            file.entries.Clear();
            foreach (DDD_dropprm_Entry entry in readFile.entries)
            {
                file.entries.Add(entry);
            }
        }
    }
}
