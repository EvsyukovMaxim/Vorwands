using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using DoubleGIS.Vorwands.Client;
using DoubleGIS.Vorwands.Client.Responses;
using DoubleGIS.Vorwands.ViewModels;
using HTMLConverter;

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
    }
}
