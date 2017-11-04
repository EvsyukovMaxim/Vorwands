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
using System.Windows.Shapes;
using DoubleGIS.Vorwands.Client;
using DoubleGIS.Vorwands.Client.Responses;

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

        private async void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            var box = sender as TextBox;

            if (box != null)
            {
                var item = box.DataContext as VorwandFull;
                if (item == null)
                    return;
            }


            var client = new YouLaClient();
            var fullVorwand = new VorwandFull();
            var editName = await client.EditVorwandName(fullVorwand.Id, fullVorwand.Name);

            var vorwandWindow = new VorwandWindow { DataContext = editName };
            vorwandWindow.ShowDialog();
        }
    }
}
