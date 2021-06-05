using System.Windows;
using System.Windows.Controls;
using KH_Editor.View.Common.Test;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_spcom
{
    /// <summary>
    /// Interaction logic for DDD_spcomComponent.xaml
    /// </summary>
    public partial class DDD_spcomComponent : UserControl
    {
        DDD_spcomHandler handler;

        public DDD_spcomComponent(MainSocket mainSocketIn, bool isPlayerIn)
        {
            handler = new DDD_spcomHandler(mainSocketIn);
            DataContext = handler;
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
