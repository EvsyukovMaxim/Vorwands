using System.ComponentModel;
using System.Runtime.CompilerServices;
using DoubleGIS.Vorwands.Annotations;
using DoubleGIS.Vorwands.Client.Responses;

namespace DoubleGIS.Vorwands.ViewModels
{
    public class ViewVorwandViewModel : INotifyPropertyChanged
    {
        private readonly VorwandFull _model;
        private string _vorwandName;

        public ViewVorwandViewModel(VorwandFull model)
        {
            _model = model;
            _vorwandName = model.Name;
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

        public bool IsNameEmpty => string.IsNullOrWhiteSpace(_model.Name);
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}