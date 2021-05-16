using System;
using System.ComponentModel;
using KH_Editor.Enums.DDD;
using KH_Editor.Libs.Memory;
using KH_Editor.Libs.Utils;
using KH_Editor.Model.Structures;

namespace KH_Editor.Model.KH_DDD.DDD_tools
{
    class DDD_status_viewModel : DDD_status, INotifyPropertyChanged
    {
        // DATA

        public int Munny_VM { get => Munny; set { Munny = value; NotifyPropertyChanged("Munny_VM"); } }
        public byte DropGauge_VM { get => DropGauge; set { DropGauge = value; NotifyPropertyChanged("DropGauge_VM"); } }

        // DATA LOCATION

        public MemoryData Munny_Data { get; set; }
        public MemoryData DropGauge_Data { get; set; }

        public void locateData(ProcessHandler processHandler)
        {
            if (processHandler == null) return;

            // Location via pointers
            long dropGaugePointer = BinaryHelper.bytesAsLong(processHandler.readBytesFromProcessModule((long)DDD_Pointers.DROP_MOD_EGS_POINTER, (long)DDD_Pointers.DROP_MOD_EGS_POINTER_SIZE));
            dropGaugePointer += (long)DDD_Pointers.DROP_MOD_EGS_POINTER_OFFSET;

            Munny_Data = new MemoryData((long)DDD_Pointers.MUNNY_MOD_EGS, (int)DDD_Pointers.MUNNY_MOD_EGS_SIZE);
            DropGauge_Data = new MemoryData(dropGaugePointer, (int)DDD_Pointers.DROP_MOD_EGS_SIZE);
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        internal void NotifyPropertyChanged(String propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
