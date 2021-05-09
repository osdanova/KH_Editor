using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using KH_Editor.Enums;
using KH_Editor.Libs.Memory;

namespace KH_Editor.View.Common.TestComponent
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

        // FUNCTIONS

        public bool isProcessHookedCorrectly()
        {
            if (socket == null) { Debug.WriteLine("TestComponent > Socket is null"); return false; }
            processHandler.hookProcessByType();
            if (processHandler.hookedProcess == null) { Debug.WriteLine("TestComponent > Process not found"); return false; }

            return true;
        }
    }
}
