using System.Collections.Generic;
using KH_Editor.Enums.MemoryPointers;
using KH_Editor.Libs.Memory;
using KH_Editor.Model.KH_DDD.DDD_inventory;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_inventory
{
    class DDD_inventoryHandler : MainTestSocketed
    {
        public DDD_inventory_File itemFile { get; set; }
        public DDD_inventory_CommandFile commandFile { get; set; }

        // CONSTRUCTORS

        public DDD_inventoryHandler(MainSocket mainSocketIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS, true, true, false)
        {
            itemFile = new DDD_inventory_File();
            commandFile = new DDD_inventory_CommandFile();
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            try
            {
                loadItemFile(processHandler.readBytesFromProcessModule((long)DDD_Pointers.INVENTORY_ITEMS_MOD_EGS, DDD_inventory_File.getTotalByteSize()));
                loadCommandFile(processHandler.readBytesFromProcessModule((long)DDD_Pointers.INVENTORY_COMMANDS_MOD_EGS, DDD_inventory_CommandFile.getTotalByteSize()));
            }
            catch { writeInfoLabel("Error reading"); }
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            try
            {
                processHandler.writeBytesToProcessModule((long)DDD_Pointers.INVENTORY_ITEMS_MOD_EGS, itemFile.toBytes());
                processHandler.writeBytesToProcessModule((long)DDD_Pointers.INVENTORY_COMMANDS_MOD_EGS, commandFile.toBytes());
            }
            catch { writeInfoLabel("Error writing"); }
        }

        // FUNCTIONS

        public void loadItemFile(List<byte> byteFile)
        {
            DDD_inventory_File readFile = new DDD_inventory_File(byteFile);
            itemFile.entries.Clear();
            itemFile.entriesStack.Clear();
            foreach (DDD_inventory_Entry entry in readFile.entries) itemFile.entries.Add(entry);
            foreach (DDD_inventory_EntryStack entry in readFile.entriesStack) itemFile.entriesStack.Add(entry);
        }
        public void loadCommandFile(List<byte> byteFile)
        {
            DDD_inventory_CommandFile readFile = new DDD_inventory_CommandFile(byteFile);
            commandFile.entries.Clear();
            foreach (DDD_inventory_Command entry in readFile.entries) commandFile.entries.Add(entry);
        }
    }
}
