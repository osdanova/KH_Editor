using System.Windows;
using System.Windows.Controls;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_techprm
{
    /// <summary>
    /// Interaction logic for DDD_techprmComponent.xaml
    /// </summary>
    public partial class DDD_techprmComponent : UserControl
    {
        DDD_techprmHandler handler;

        public DDD_techprmComponent(MainSocket mainSocketIn, bool isPlayerIn)
        {
            handler = new DDD_techprmHandler(mainSocketIn, isPlayerIn);
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
