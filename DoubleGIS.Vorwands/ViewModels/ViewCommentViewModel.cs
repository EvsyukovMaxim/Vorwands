using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DoubleGIS.Vorwands.Annotations;
using DoubleGIS.Vorwands.Client.Responses;

namespace DoubleGIS.Vorwands.ViewModels
{
    class ViewCommentViewModel : INotifyPropertyChanged
    {
        private readonly Comment _model;
        private readonly string _commentText;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewCommentViewModel(Comment model)
        {
            _model = model;
            _commentText = _model.Text;
        }

        public string CommentText
        {
            get => _commentText;
            set
            {
                _model.Text = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
