using System;
using System.Collections.Generic;
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
