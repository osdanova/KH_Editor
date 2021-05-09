using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_tools;
using KH_Editor.View.Common.TestComponent;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_Status
{
    class DDD_StatusComponentHandler : TestComponentSocket
    {
        // COMPONENTS

        public DDD_status_viewModel status { get; set; }
        public TestComponent testComponent;
        public MainSocket mainSocket;

        // CONSTRUCTORS

        public DDD_StatusComponentHandler(MainSocket mainSocketIn)
        {
            mainSocket = mainSocketIn;
            status = new DDD_status_viewModel();
            testComponent = new TestComponent(Enums.ProcessType.DDD_EGS, this);
        }

        // ACTIONS

        public void readAction(ProcessHandler processHandler)
        {
            status.locateData(processHandler);
            status.Munny_VM = BinaryHelper.bytesAsInt(processHandler.readBytesFromProcessModule(status.Munny_Data));
            status.DropGauge_VM = BinaryHelper.bytesAsByte(processHandler.readBytesFromProcess(status.DropGauge_Data));
        }

        public void writeAction(ProcessHandler processHandler)
        {
            status.locateData(processHandler);
            processHandler.writeBytesToProcessModule(status.Munny_Data.address, BinaryHelper.intAsBytes(status.Munny_VM));
            processHandler.writeBytesToProcess(status.DropGauge_Data.address, BinaryHelper.byteAsBytes(status.DropGauge_VM));
        }

        // FUNCTIONS

        public void writeInfoLabel(string message)
        {
            if (mainSocket != null) mainSocket.writeInfoLabel(message);
        }
    }
}
