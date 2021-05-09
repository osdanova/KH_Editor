using System;
using System.Windows;
using KH_Editor.View.Common;
using KH_Editor.View.KH_DDD.DDD_Status;
using KH_Editor.View.Main;

namespace KH_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, MainSocket
    {
        MainData mainData { get; set; }

        public MainWindow()
        {
            mainData = new MainData();
            mainData.infoLabel_VM = "Started";
            DataContext = mainData;
            InitializeComponent();
        }

        // LOAD PAGES

        private void executeCode(object sender, EventArgs e) { View_DebugTools.executeCode(); }

        private void loadPage_Debug(object sender, EventArgs e) { FrameToLoad.Content = new DebugView(); }
        private void loadPage_DDDStatus(object sender, EventArgs e) { FrameToLoad.Content = new DDD_StatusComponent(this); }

        // INFO LABEL

        public void writeInfoLabel(string info) { mainData.infoLabel_VM = info; }
    }
}
