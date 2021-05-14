using System.Windows;
using System.Windows.Controls;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_btlparam
{
    /// <summary>
    /// Interaction logic for DDD_btlparamComponent.xaml
    /// </summary>
    public partial class DDD_btlparamComponent : UserControl
    {
        DDD_btlparamHandler handler;

        public DDD_btlparamComponent(MainSocket mainSocketIn)
        {
            handler = new DDD_btlparamHandler(mainSocketIn);
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
