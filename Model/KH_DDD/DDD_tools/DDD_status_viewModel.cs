using System;
using System.ComponentModel;
using System.Diagnostics;
using KH_Editor.Enums.MemoryPointers;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;

namespace KH_Editor.Model.KH_DDD.DDD_tools
{
    class DDD_status_viewModel : DDD_status, INotifyPropertyChanged
    {
        // Pointers
        public long dropGaugePointer { get; set; }
        
        // Data
        public int Munny_VM { get => Munny; set { Munny = value; NotifyPropertyChanged("Munny_VM"); } }
        public byte DropGauge_VM { get => DropGauge; set { DropGauge = value; NotifyPropertyChanged("DropGauge_VM"); } }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        internal void NotifyPropertyChanged(String propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // Functions
        public void findPointers(ProcessHandler process)
        {
            if (process == null) return;
            dropGaugePointer = BinaryHelper.bytesAsLong(process.readBytesFromProcessModule((long)DDD_Pointers.DROP_MOD_EGS_POINTER, (long)DDD_Pointers.DROP_MOD_EGS_POINTER_SIZE));
            dropGaugePointer += (long)DDD_Pointers.DROP_MOD_EGS_POINTER_OFFSET;
        }
    }
}
