using System;
using System.Windows;
using KH_Editor.Enums.DDD;
using KH_Editor.View.DebugComponent;
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

        private void loadPage_Debug(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.DEBUG); }
        private void loadPage_DDD_status(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.STATUS); }
        private void loadPage_DDD_inventory(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.INVENTORY); }
        private void loadPage_DDD_btlparam(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.BTLPARAM); }
        private void loadPage_DDD_itemdata(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.ITEMDATA); }

        // INFO LABEL

        public void writeInfoLabel(string info) { mainData.infoLabel_VM = info; }
    }
}
