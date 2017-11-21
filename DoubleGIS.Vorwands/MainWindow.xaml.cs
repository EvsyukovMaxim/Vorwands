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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnLoad_Click(object sender, RoutedEventArgs e)
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }
    }


}
