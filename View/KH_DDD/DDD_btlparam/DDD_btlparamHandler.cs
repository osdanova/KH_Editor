using KH_Editor.Enums.MemoryPointers;
using KH_Editor.Libs.Memory;
using KH_Editor.Model.KH_DDD.btlparam;
using KH_Editor.View.Common.TestComponent;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_btlparam
{
    class DDD_btlparamHandler : TestComponentSocket
    {
        public static readonly string EOF = "CDCDCDCDCDCDCDCD";

        public DDD_btlparam_File file { get; set; }
        public TestComponent testComponent;
        public MainSocket mainSocket;

        // CONSTRUCTORS

        public DDD_btlparamHandler(MainSocket mainSocketIn)
        {
            mainSocket = mainSocketIn;
            testComponent = new TestComponent(Enums.ProcessType.DDD_EGS, this);
            file = new DDD_btlparam_File();
        }

        // ACTIONS

        public void readAction(ProcessHandler processHandler)
        {
            DDD_btlparam_File readFile = new DDD_btlparam_File(processHandler.readBytesFromProcessModuleUntilHexString((long)DDD_Pointers.BTLPARAM_MOD_EGS, EOF));
            file.entries.Clear();
            foreach (DDD_btlparam_Entry entry in readFile.entries) file.entries.Add(entry);
        }

        public void writeAction(ProcessHandler processHandler)
        {
            processHandler.writeBytesToProcessModule((long)DDD_Pointers.BTLPARAM_MOD_EGS, file.toBytes());
        }

        // FUNCTIONS

        public void writeInfoLabel(string message)
        {
            if (mainSocket != null) mainSocket.writeInfoLabel(message);
        }
    }
}
