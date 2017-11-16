using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DoubleGIS.Vorwands.Client;
using DoubleGIS.Vorwands.Client.Responses;
using DoubleGIS.Vorwands.ViewModels;

namespace DoubleGIS.Vorwands
{
    /// <summary>
    /// Interaction logic for VorwandWindow.xaml
    /// </summary>
    public partial class VorwandWindow
    {
        public VorwandWindow()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            var vm = (ViewVorwandViewModel)DataContext;
            vm.LoadComments();
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
            vm.RevertVorwandNameChange();
            vm.EditMode = false;
        }

        private void ClickMouseToEditVorwandName(object sender, MouseButtonEventArgs e)
        {
            var vm = (ViewVorwandViewModel)DataContext;
            vm.EditMode = true;
        }

        private async void EventSetter_OnHandler(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            var row = sender as DataGridCell;
            if (row == null)
                return;

            var item = row.DataContext as Comment;
            if (item == null)
                return;


            var client = new YouLaClient();
            var comments = await client.GetComments(item.Id);
            DataGrid.ItemsSource = comments.Comments.ToString();
        }
    }
}
