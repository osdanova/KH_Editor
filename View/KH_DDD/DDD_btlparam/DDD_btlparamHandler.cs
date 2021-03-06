using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_btlparam;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_btlparam
{
    class DDD_btlparamHandler : MainTestSocketed
    {
        public DDD_btlparam_File file { get; set; }

        public ObservableCollection<DDD_btlparam_Entry> displayEntries { get; set; }

        // CONSTRUCTORS

        public DDD_btlparamHandler(MainSocket mainSocketIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS)
        {
            file = new DDD_btlparam_File();
            displayEntries = new ObservableCollection<DDD_btlparam_Entry>();
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            try
            {
                loadFile(processHandler.readBytesFromProcessModuleUntilHexString((long)DDD_Pointers.BTLPARAM_MOD_EGS, DDD_btlparam_File.HEX_EOF));
            }
            catch { writeInfoLabel("Error reading"); }
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            try
            {
                processHandler.writeBytesToProcessModule((long)DDD_Pointers.BTLPARAM_MOD_EGS, file.toBytes());
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
            catch { writeInfoLabel("Error loading file");  }
        }

        // FUNCTIONS

        public void loadFile(List<byte> byteFile)
        {
            DDD_btlparam_File readFile = new DDD_btlparam_File(byteFile);
            file.entries.Clear();
            displayEntries.Clear();
            foreach (DDD_btlparam_Entry entry in readFile.entries)
            {
                file.entries.Add(entry);
                displayEntries.Add(entry);
            }
        }

        public void filterEntriesByName(string filter)
        {
            if (displayEntries.Count == 0) return;

            displayEntries.Clear();
            if(filter != "")
            {
                foreach (DDD_btlparam_Entry entry in file.entries)
                {
                    if (entry.name.ToLower().Contains(filter.ToLower())) displayEntries.Add(entry);
                }
            }
            else
            {
                foreach (DDD_btlparam_Entry entry in file.entries)
                {
                    displayEntries.Add(entry);
                }
            }
        }
    }
}
