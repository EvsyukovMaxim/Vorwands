using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DoubleGIS.Vorwands.Client;
using DoubleGIS.Vorwands.ViewModels;
using ServiceStack;

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
            { vm.VorwandNameEditMode = false; return;}

            var client = new YouLaClient();

            await client.EditVorwandName(vm.Id, vm.VorwandName);
            vm.VorwandNameEditMode = false;
        }

        private void Click_BtnCancel(object sender, RoutedEventArgs e)
        {
            var vm = (ViewVorwandViewModel)DataContext;
            vm.RevertVorwandNameChange();
            vm.VorwandNameEditMode = false;
        }
        
        private void ClickMouseToEditVorwandName(object sender, MouseButtonEventArgs e)
        {
            var vm = (ViewVorwandViewModel)DataContext;
            vm.VorwandNameEditMode = true;
        }

        private async void UpdateCommentText(object sender, KeyEventArgs e)
        {
            if(e.Key != Key.Enter)
                return;

            var cm = (ViewCommentViewModel) ((FrameworkElement) sender).DataContext;

            if (!cm.IsCommentChanged)
                return;

            var client = new YouLaClient();

            await client.UpdateComment(cm.CommentId, cm.CommentText);
        }
        private void AddNewComment_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = (ViewVorwandViewModel)DataContext;
            vm.AddCommentEditMode = true;
        }
        private async void SaveNewCommentKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            var vm = (ViewVorwandViewModel)DataContext;
            var client = new YouLaClient();

            await client.AddComment("Vorwand",vm.Id, NewCommentTextBox.Text);
            NewCommentTextBox.Text = "";
            vm.AddCommentEditMode = false;
        }
        private void CancelAddNewComment_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = (ViewVorwandViewModel)DataContext;
            NewCommentTextBox.Text = "";
            vm.AddCommentEditMode = false;
        }

        private void DataGridComments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
