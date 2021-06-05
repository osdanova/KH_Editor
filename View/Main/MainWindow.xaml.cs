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
        private void loadPage_DDD_spirit(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.SPIRIT); }
        private void loadPage_DDD_btlparam(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.BTLPARAM); }
        private void loadPage_DDD_itemdata(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.ITEMDATA); }
        private void loadPage_DDD_tboxdtso(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.TBOXDTSO); }
        private void loadPage_DDD_tboxdtri(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.TBOXDTRI); }
        private void loadPage_DDD_lboard(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.LBOARD); }
        private void loadPage_DDD_lbtList(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.LBT_LIST); }
        private void loadPage_DDD_techprm(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.TECHPRM); }
        private void loadPage_DDD_techprmp(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.TECHPRMP); }
        private void loadPage_DDD_dropprm(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.DROPPRM); }
        private void loadPage_DDD_spcom(object sender, EventArgs e) { MainComponentLoader.loadComponent(this, FrameToLoad, DDD_Components.SPCOM); }

        // INFO LABEL

        public void writeInfoLabel(string info) { mainData.infoLabel_VM = info; }
    }
}
