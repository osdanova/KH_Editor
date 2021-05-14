using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_tools;
using KH_Editor.View.Common.Base;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_Status
{
    class DDD_StatusComponentHandler : MainTestSocketed
    {
        // COMPONENTS

        public DDD_status_viewModel status { get; set; }

        // CONSTRUCTORS

        public DDD_StatusComponentHandler(MainSocket mainSocketIn) : base(mainSocketIn, Enums.ProcessType.DDD_EGS, true, true, false)
        {
            status = new DDD_status_viewModel();
        }

        // ACTIONS

        override
        public void readAction(ProcessHandler processHandler)
        {
            status.locateData(processHandler);
            status.Munny_VM = BinaryHelper.bytesAsInt(processHandler.readBytesFromProcessModule(status.Munny_Data));
            status.DropGauge_VM = BinaryHelper.bytesAsByte(processHandler.readBytesFromProcess(status.DropGauge_Data));
        }

        override
        public void writeAction(ProcessHandler processHandler)
        {
            status.locateData(processHandler);
            processHandler.writeBytesToProcessModule(status.Munny_Data.address, BinaryHelper.intAsBytes(status.Munny_VM));
            processHandler.writeBytesToProcess(status.DropGauge_Data.address, BinaryHelper.byteAsBytes(status.DropGauge_VM));
        }
    }
}
