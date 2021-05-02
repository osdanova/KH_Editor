using System;
using System.Diagnostics;
using System.Windows;
using KH_Editor.View.Common;
using KH_Editor.View.KH_DDD.DDD_Status;

namespace KH_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameToLoad.Content = new DDD_StatusComponent();
        }

        // Debug
        private void executeCode(object sender, EventArgs e) { View_DebugTools.executeCode(); }
    }
}
