using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DoubleGIS.Vorwands.Annotations;
using DoubleGIS.Vorwands.Client;
using DoubleGIS.Vorwands.Client.Responses;

namespace DoubleGIS.Vorwands.ViewModels
{
    public class ViewVorwandViewModel : INotifyPropertyChanged
    {
        private readonly VorwandFull _model;
        private readonly string _vorwandName;
        private bool _editMode;
        private Visibility _isReadonlyVisible;
        private Visibility _isEditVisible;

        public ObservableCollection<Comment> Comments { get; set; }

        public ViewVorwandViewModel(VorwandFull model)
        {
            _model = model;
            _vorwandName = model.Name;
            EditMode = false;

            Comments = new ObservableCollection<Comment>();
        }

        public string VorwandName
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNameEmpty));
            }
        }

        public void RevertVorwandNameChange()
        {
            VorwandName = _vorwandName;
        }

        public string VorwandDescription
        {
            get => _model.Description;
            set
            {
                _model.Description = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNameEmpty));
            }
        }

        public long Id => _model.Id;
        public bool IsNameChanged => _model.Name != _vorwandName;


        public bool EditMode
        {
            get => _editMode;
            set
            {

                _editMode = value;

                IsReadonlyVisible = _editMode ? Visibility.Collapsed : Visibility.Visible;
                IsEditVisible = _editMode ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility IsReadonlyVisible
        {
            get => _isReadonlyVisible;
            set { _isReadonlyVisible = value; OnPropertyChanged(); }
        }

        public Visibility IsEditVisible
        {
            get => _isEditVisible;
            set { _isEditVisible = value;
                OnPropertyChanged();
            }
        }

        public async void LoadComments()
        {
            var client = new YouLaClient();
            var comments = await client.GetComments(_model.Id);

            Comments.Clear();

            foreach (var commentsComment in comments.Comments)
            {
                Comments.Add(commentsComment);
            }
        }

        public bool IsNameEmpty => string.IsNullOrWhiteSpace(_model.Name);
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}