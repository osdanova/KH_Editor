using System.Windows.Controls;

namespace KH_Editor.View.KH_DDD.DDD_Status
{
    /// <summary>
    /// Interaction logic for DDD_StatusComponent.xaml
    /// </summary>
    public partial class DDD_StatusComponent : UserControl
    {
        DDD_StatusComponentHandler handler;

        public DDD_StatusComponent()
        {
            handler = new DDD_StatusComponentHandler();
            DataContext = handler.status;
            InitializeComponent();

            TestComponent.Content = handler.testComponent;
        }
    }
}
