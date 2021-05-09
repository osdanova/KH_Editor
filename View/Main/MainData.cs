using System;
using System.ComponentModel;

namespace KH_Editor.View.Main
{
    public class MainData : INotifyPropertyChanged
    {
        public string infoLabel { get; set; }
        public string infoLabel_VM { get => infoLabel; set { infoLabel = value; NotifyPropertyChanged("infoLabel_VM"); } }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        internal void NotifyPropertyChanged(String propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
