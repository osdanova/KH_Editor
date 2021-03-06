using System.Windows;
using System.Windows.Controls;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_tboxdt
{
    /// <summary>
    /// Interaction logic for DDD_tboxdtComponent.xaml
    /// </summary>
    public partial class DDD_tboxdtComponent : UserControl
    {
        DDD_tboxdtHandler handler;

        public DDD_tboxdtComponent(MainSocket mainSocketIn, bool isSoraIn)
        {
            handler = new DDD_tboxdtHandler(mainSocketIn, isSoraIn);
            DataContext = handler.file;
            InitializeComponent();

            TestComponent.Content = handler.testComponent;
        }

        private void dropFile(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                handler.dropFile(files[0]);
            }
        }
    }
}
