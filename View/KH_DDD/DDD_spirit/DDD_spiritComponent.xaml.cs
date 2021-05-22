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
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_spirit
{
    /// <summary>
    /// Interaction logic for DDD_spiritComponent.xaml
    /// </summary>
    public partial class DDD_spiritComponent : UserControl
    {
        DDD_spiritHandler handler;

        public DDD_spiritComponent(MainSocket mainSocketIn)
        {
            handler = new DDD_spiritHandler(mainSocketIn);
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
