using System.Windows.Controls;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_Status
{
    /// <summary>
    /// Interaction logic for DDD_StatusComponent.xaml
    /// </summary>
    public partial class DDD_StatusComponent : UserControl
    {
        DDD_StatusComponentHandler handler;

        public DDD_StatusComponent(MainSocket mainSocketIn)
        {
            handler = new DDD_StatusComponentHandler(mainSocketIn);
            DataContext = handler.status;
            InitializeComponent();

            TestComponent.Content = handler.testComponent;
        }
    }
}
