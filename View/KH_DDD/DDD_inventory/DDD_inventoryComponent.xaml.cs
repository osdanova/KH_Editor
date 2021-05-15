using System.Windows.Controls;
using KH_Editor.View.Main;

namespace KH_Editor.View.KH_DDD.DDD_inventory
{
    /// <summary>
    /// Interaction logic for DDD_inventoryComponent.xaml
    /// </summary>
    public partial class DDD_inventoryComponent : UserControl
    {
        DDD_inventoryHandler handler;

        public DDD_inventoryComponent(MainSocket mainSocketIn)
        {
            handler = new DDD_inventoryHandler(mainSocketIn);
            DataContext = handler;
            InitializeComponent();

            TestComponent.Content = handler.testComponent;
        }
    }
}
