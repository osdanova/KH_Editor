using System;
using System.Windows;
using KH_Editor.View.Common;
using KH_Editor.View.KH_DDD.DDD_Status;
using KH_Editor.View.KH_DDD.DDD_btlparam;
using KH_Editor.View.Main;
using KH_Editor.View.KH_DDD.DDD_inventory;

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
        private void loadPage_DDD_status(object sender, EventArgs e) { FrameToLoad.Content = new DDD_StatusComponent(this); }
        private void loadPage_DDD_btlparam(object sender, EventArgs e) { FrameToLoad.Content = new DDD_btlparamComponent(this); }
        private void loadPage_DDD_inventory(object sender, EventArgs e) { FrameToLoad.Content = new DDD_inventoryComponent(this); }

        // INFO LABEL

        public void writeInfoLabel(string info) { mainData.infoLabel_VM = info; }
    }
}
