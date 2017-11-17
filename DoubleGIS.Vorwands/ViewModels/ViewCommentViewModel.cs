using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DoubleGIS.Vorwands.Annotations;
using DoubleGIS.Vorwands.Client;
using DoubleGIS.Vorwands.Client.Responses;

namespace DoubleGIS.Vorwands.ViewModels
{
    public class ViewCommentViewModel : INotifyPropertyChanged
    {
        private readonly Comment _model;
        private readonly string _commentText;
        public event PropertyChangedEventHandler PropertyChanged;


        public ViewCommentViewModel(Comment model)
        {
            _model = model;
            _commentText = _model.Text;
            Id = _model.Id;
            
        }

        public string CommentText
        {
            get => _model.Text;
            set => _model.Text = value;
        }

        public long Id { get;}

        public bool IsNameEmpty => string.IsNullOrWhiteSpace(_model.Text);
        public bool IsCommentChanged => _model.Text != _commentText;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
