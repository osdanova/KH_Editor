using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using KH_Editor.Enums;
using KH_Editor.Libs.Memory;

namespace KH_Editor.View.Common.Test
{
    /// <summary>
    /// Interaction logic for TestComponent.xaml
    /// </summary>
    public partial class TestComponent : UserControl
    {
        // PROPERTIES

        public TestComponentSocket socket { get; set; } // Connected component that will receive the action calls
        public ProcessType processType { get; set; } // The process type to be handled. Eg: KH 2 EGS version

        // HANDLERS

        public ProcessHandler processHandler { get; set; } // Handler to access a process's memory. Accessible for the connected component through this component's actions.

        // CONSTRUCTORS

        public TestComponent()
        {
            InitializeComponent();
        }
        public TestComponent(ProcessType processTypeIn, TestComponentSocket socketIn)
        {
            if (processTypeIn == ProcessType.NULL || socketIn == null) { Debug.WriteLine("TestComponent > INVALID CONSTRUCTOR PARAMS"); return; }

            socket = socketIn;
            processType = processTypeIn;
            processHandler = new ProcessHandler(processType);
            InitializeComponent();
            loadLogo(processType);
        }
        public TestComponent(ProcessType processTypeIn, TestComponentSocket socketIn, bool readOn, bool writeOn, bool exportOn)
        {
            if (processTypeIn == ProcessType.NULL || socketIn == null) { Debug.WriteLine("TestComponent > INVALID CONSTRUCTOR PARAMS"); return; }

            socket = socketIn;
            processType = processTypeIn;
            processHandler = new ProcessHandler(processType);
            InitializeComponent();
            loadLogo(processType);
            if (!readOn) readButton.Visibility = Visibility.Hidden;
            if (!writeOn) writeButton.Visibility = Visibility.Hidden;
            if (!exportOn) exportButton.Visibility = Visibility.Hidden;
        }

        // ACTIONS

        public void readAction(object sender, RoutedEventArgs e)
        {
            if (!isProcessHookedCorrectly()) { socket.writeInfoLabel("Could not find the process"); return; }

            socket.writeInfoLabel("Reading...");
            socket.readAction(processHandler);
            socket.writeInfoLabel("Finished reading");
        }
        public void writeAction(object sender, RoutedEventArgs e)
        {
            if (!isProcessHookedCorrectly()) { socket.writeInfoLabel("Could not find the process"); return; }

            socket.writeInfoLabel("Writing...");
            socket.writeAction(processHandler);
            socket.writeInfoLabel("Finished writing");
        }
        public void exportAction(object sender, RoutedEventArgs e)
        {
            socket.writeInfoLabel("Exporting...");
            socket.exportAction();
            socket.writeInfoLabel("Finished exporting");
        }

        // FUNCTIONS

        public bool isProcessHookedCorrectly()
        {
            if (socket == null) { Debug.WriteLine("TestComponent > Socket is null"); return false; }
            processHandler.hookProcessByType();
            if (processHandler.hookedProcess == null) { Debug.WriteLine("TestComponent > Process not found"); return false; }

            return true;
        }

        public void loadLogo(ProcessType processTypeIn)
        {
            Debug.WriteLine("LoadLogo: " + processTypeIn.ToString());
            switch(processTypeIn)
            {
                case ProcessType.DDD_EGS:
                    logoImage.Source = new BitmapImage(new Uri(@"/Assets/Logos/Logo_DDD.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }
    }
}
