using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KH_Editor.View.Common.TestComponent
{
    /// <summary>
    /// Interaction logic for TestComponent.xaml
    /// </summary>
    public partial class TestComponent : UserControl
    {
        public TestComponentSocket socket;

        public TestComponent()
        {
            InitializeComponent();
        }
        public TestComponent(TestComponentSocket socketIn)
        {
            socket = socketIn;
            InitializeComponent();
        }

        public void readAction(object sender, RoutedEventArgs e)
        {
            if (socket == null) { Debug.WriteLine("TestComponent > Socket is null"); return; }
            socket.readAction();
        }
        public void writeAction(object sender, RoutedEventArgs e)
        {
            if (socket == null) { Debug.WriteLine("TestComponent > Socket is null"); return; }
            socket.writeAction();
        }
    }
}
