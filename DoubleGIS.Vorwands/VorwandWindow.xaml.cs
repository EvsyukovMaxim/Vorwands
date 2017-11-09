using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DoubleGIS.Vorwands.Client;
using DoubleGIS.Vorwands.ViewModels;

namespace DoubleGIS.Vorwands
{
    /// <summary>
    /// Interaction logic for VorwandWindow.xaml
    /// </summary>
    public partial class VorwandWindow : Window
    {
        public VorwandWindow()
        {
            InitializeComponent();
        }
        
        private async void Click_BtnOk(object sender, RoutedEventArgs e)
        {
            var vm = (ViewVorwandViewModel)DataContext;

            if (!vm.IsNameChanged)
                return;

            var client = new YouLaClient();

            await client.EditVorwandName(vm.Id, vm.VorwandName);
            vm.EditMode = false;
        }

        private void Click_BtnCancel(object sender, RoutedEventArgs e)
        {
            var vm = (ViewVorwandViewModel)DataContext;
            vm.EditMode = false;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var vm = (ViewVorwandViewModel)DataContext;
            vm.EditMode = true;
        }

        private async Task GetVorwandComments()
        {
            var client = new YouLaClient();
            await client.GetComments();
        }
    }
}
