using System;
using System.ComponentModel;
using KH_Editor.Enums.MemoryPointers;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.KH_DDD.DDD_tools;
using KH_Editor.View.Common.TestComponent;

namespace KH_Editor.View.KH_DDD.DDD_Status
{
    class DDD_StatusComponentHandler : TestComponentSocket, INotifyPropertyChanged
    {
        ProcessHandler process;
        public TestComponent testComponent;
        public DDD_status_viewModel status { get; set; }

        public DDD_StatusComponentHandler()
        {
            process = new ProcessHandler(Enums.ProcessType.DDD_EGS);
            process.hookProcessByType();
            testComponent = new TestComponent(this);
            status = new DDD_status_viewModel();
        }

        public void readAction()
        {
            status.findPointers(process);
            status.Munny_VM = BinaryHelper.bytesAsInt(process.readBytesFromProcessModule((long)DDD_Pointers.MUNNY_MOD_EGS, (long)DDD_Pointers.MUNNY_MOD_EGS_SIZE));
            status.DropGauge_VM = BinaryHelper.bytesAsByte(process.readBytesFromProcess(status.dropGaugePointer, (long)DDD_Pointers.DROP_MOD_EGS_SIZE));
        }

        public void writeAction()
        {
            status.findPointers(process);
            process.writeBytesToProcessModule((long)DDD_Pointers.MUNNY_MOD_EGS, BinaryHelper.intAsBytes(status.Munny_VM));
            process.writeBytesToProcess(status.dropGaugePointer, BinaryHelper.byteAsBytes(status.DropGauge_VM));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        internal void NotifyPropertyChanged(String propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
