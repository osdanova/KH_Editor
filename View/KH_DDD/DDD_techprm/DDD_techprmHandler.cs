using System.Collections.Generic;
using System.IO;
using System.Linq;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_techprm;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_techprm
{
    class DDD_techprmHandler : MainTestSocketed
    {
        // True if techprmp, false if techprm
        public bool isPlayer { get; set; }
        public long fileAddress { get; set; }

        public DDD_techprm_File file { get; set; }

        // CONSTRUCTORS

        public DDD_techprmHandler(MainSocket mainSocketIn, bool isPlayerIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS)
        {
            file = new DDD_techprm_File();
            isPlayer = isPlayerIn;
            if (isPlayer) fileAddress = (long)DDD_Pointers.TECHPRMP_MOD_EGS;
            else fileAddress = (long)DDD_Pointers.TECHPRM_MOD_EGS;
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            try
            {
                loadFile(processHandler.readBytesFromProcessModuleUntilHexString(fileAddress, DDD_techprm_File.HEX_EOF));
            }
            catch { writeInfoLabel("Error reading"); }
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            try
            {
                processHandler.writeBytesToProcessModule(fileAddress, file.toBytes());
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
            DDD_techprm_File readFile = new DDD_techprm_File(byteFile);
            file.entries.Clear();
            foreach (DDD_techprm_Entry entry in readFile.entries)
            {
                file.entries.Add(entry);
            }
        }
    }
}
