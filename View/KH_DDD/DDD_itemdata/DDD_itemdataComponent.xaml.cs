using System.Windows;
using System.Windows.Controls;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_itemdata
{
    /// <summary>
    /// Interaction logic for DDD_itemdataComponent.xaml
    /// </summary>
    public partial class DDD_itemdataComponent : UserControl
    {
        DDD_itemdataHandler handler;

        public DDD_itemdataComponent(MainSocket mainSocketIn)
        {
            handler = new DDD_itemdataHandler(mainSocketIn);
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
