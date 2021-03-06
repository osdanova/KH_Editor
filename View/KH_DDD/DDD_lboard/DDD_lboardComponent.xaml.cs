using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KH_Editor.Model.KH_DDD.DDD_lboard;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_lboard
{
    /// <summary>
    /// Interaction logic for DDD_lboardComponent.xaml
    /// </summary>
    public partial class DDD_lboardComponent : UserControl
    {
        DDD_lboardHandler handler;

        public DDD_lboardComponent(MainSocket mainSocketIn)
        {
            handler = new DDD_lboardHandler(mainSocketIn);
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

        private void loadBoard(object sender, MouseButtonEventArgs args)
        {
            // Makes sure the code only executes once
            if (sender is ListViewItem)
            {
                if (!((ListViewItem)sender).IsSelected)
                {
                    return;
                }
            }
            handler.loadBoard((DDD_lboard_Board)boardList.SelectedItem);
        }
    }
}
