using System.ComponentModel;
using System.Runtime.CompilerServices;
using Connect4.Models.Boards;

namespace Connect4
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Board _board;
        public event PropertyChangedEventHandler PropertyChanged;

        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
