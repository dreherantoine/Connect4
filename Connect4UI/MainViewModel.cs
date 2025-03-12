using System.ComponentModel;
using System.Runtime.CompilerServices;
using Connect4UI.Models.Boards;

namespace Connect4UI
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Board _board;

        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
