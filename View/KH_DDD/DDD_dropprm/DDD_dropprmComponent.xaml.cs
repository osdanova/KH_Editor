using System.Windows;
using System.Windows.Controls;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_dropprm
{
    /// <summary>
    /// Interaction logic for DDD_dropprmComponent.xaml
    /// </summary>
    public partial class DDD_dropprmComponent : UserControl
    {
        DDD_dropprmHandler handler;

        public DDD_dropprmComponent(MainSocket mainSocketIn, bool isPlayerIn)
        {
            handler = new DDD_dropprmHandler(mainSocketIn);
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
