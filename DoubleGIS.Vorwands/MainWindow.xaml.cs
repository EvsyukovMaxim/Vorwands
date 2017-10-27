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
            var client = new YouLaClient();
            var response = await client.GetCurrentUser();

            btnLoad.Content = "Загружаю";

            textBlock.Text = "User: " + response.UserName;

            var vorwandResult = await client.GetVorwands();

            dataGrid.ItemsSource = vorwandResult.Paging.ResultItems;
        }

        private async void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            if (row == null)
                return;

            var item = row.DataContext as ResultItem;

            if (item == null)
                return;


            var client = new YouLaClient();
            var vorwandFull = await client.GetFullVorwand(item.id);

            var vorwandWindow = new VorwandWindow { DataContext = vorwandFull };
            vorwandWindow.ShowDialog();
        }
    }


}
