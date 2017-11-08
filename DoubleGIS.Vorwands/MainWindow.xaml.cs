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
using ServiceStack;
using DoubleGIS.Vorwands.Client;
using DoubleGIS.Vorwands.Client.Responses;
using DoubleGIS.Vorwands.ViewModels;

namespace DoubleGIS.Vorwands

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var client = new YouLaClient();
            var response = await client.GetCurrentUser();

            BtnLoad.Content = "Загружаю";

            UserTab.Text = "Пользователь: " + response.UserName;

            var vorwandResult = await client.GetVorwands();

            DataGrid.ItemsSource = vorwandResult.Paging.ResultItems;

            BtnLoad.Content = "Обновить";
        }

        private async void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row == null)
                return;

            var item = row.DataContext as ResultItem;
            if (item == null)
                return;


            var client = new YouLaClient();
            var vorwandFull = await client.GetFullVorwand(item.Id);

            var vorwandWindow = new VorwandWindow { DataContext = new ViewVorwandViewModel(vorwandFull) };
            vorwandWindow.ShowDialog();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }
    }


}
