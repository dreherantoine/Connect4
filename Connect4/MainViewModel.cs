using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Connect4.Models.Boards;

namespace Connect4
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Board _board = new Board();
        private string _player1 = "Red";
        private string _player2 = "Yellow";

        public ICommand OnPlay { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            OnPlay = new Command<Slot>(Play);
        }

        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged();
            }
        }

        private void Play(Slot slot)
        {
            System.Diagnostics.Debug.WriteLine(slot.Column);
            System.Diagnostics.Debug.WriteLine(slot.Row);

            this._board.PlayerMove(slot.Column, "Red");
            OnPropertyChanged();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
