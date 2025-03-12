using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Connect4.Models;
using Connect4.Models.Boards;

namespace Connect4
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Board _board = new Board();
        private Player _player1 = new Player("Red");
        private Player _player2 = new Player("Yellow");
        private Player _currentPlayer;
        private string _title = "Connect 4";

        public ICommand OnPlay { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            this.CurrentPlayer = this.Player1;
            this.OnPlay = new Command<Slot>(this.Play);
        }

        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged(nameof(this.Board));
            }
        }

        public Player Player1
        {
            get => _player1;
        }

        public Player Player2
        {
            get => _player2;
        }

        public Player CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(this.CurrentPlayer));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(this.Title));
            }
        }

        private void SwitchPlayer()
        {
            this.CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        private void Play(Slot slot)
        {
            if (!this.Board.IsGameWin() && this.Board.PlayerMove(slot.Column, this.CurrentPlayer.Color))
            {
                if (!this.Board.IsGameWin())
                {
                    this.SwitchPlayer();
                    this.Title = $"{this.CurrentPlayer.Color} turn";
                }
                else
                {
                    this.Title = $"{this.CurrentPlayer.Color} wins!";
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
