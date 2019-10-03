using System;

namespace TicTacToe
{
    public class Game : IGame
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly Board _board;
        private Player _currentPlayer;
        private bool _currentPlayerWon;

        public bool GameIsOver { get; private set; }

        public Game(Board board, Player player1, Player player2)
        {
            _board = board;
            _player1 = player1;
            _player2 = player2;
        }

        public void Play()
        {
            _currentPlayer.ChooseATile($"{_currentPlayer.Name} select a tile number: ");

            while (!_board.IsTileSelectionValid(_currentPlayer.Tile))
            {
                _currentPlayer.ChooseATile($"{_currentPlayer.Name} select a tile number {_board.AvailableTilesString}: ");
            }

            _board.SetTileValue(_currentPlayer.Tile, _currentPlayer.PlayerLetter);


            _currentPlayerWon = _board.DoesPlayerWins(_currentPlayer);

            GameIsOver = _currentPlayerWon || !_board.HasAvailableTiles;

        }

        public void RenderGame()
        {
            Console.Clear();
            _currentPlayer?.PrintLastChoice();

            _board.DisplayTiles();

            if (GameIsOver)
            {
                PrintWinner();
            }
        }

        public void NextPlayer()
        {
            _currentPlayer = (_currentPlayer == _player1) ? _player2 : _player1;
        }

        private void PrintWinner()
        {
            Console.WriteLine(GetWinnerMessage());
        }
        private String GetWinnerMessage()
        {
            return _currentPlayerWon
                ? $"Player {_currentPlayer.Name} Wins!!!"
                : "It is a tie !!!";
        }
    }
}
