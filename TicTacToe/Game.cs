using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        private readonly Player Player1;
        private readonly Player Player2;
        private Player CurrentPlayer;
        private Player Winner;
        private Board Board;
        public Game(Player player1, Player player2)
        {
            Board = new Board();
            Player1 = player1;
            Player2 = player2;
            CurrentPlayer = player2;
            Winner = null;
        }
        public void Play()
        {
            Board.DisplayTiles();

            do
            {

                CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
                CurrentPlayer.ChooseATile(Board);

                Console.Clear();
                Console.WriteLine($"{CurrentPlayer.Name} selected tile number: {CurrentPlayer.Tile + 1}");

                Board.SetTileValue(CurrentPlayer.Tile, CurrentPlayer.PlayerLetter);
                Board.DisplayTiles();

                if (CurrentPlayer.DoesPlayerWins(Board))
                {
                    Winner = CurrentPlayer;
                }
                    

            } while ((Board.HasAvailableTiles) && (Winner == null));

            Console.WriteLine(GetWinnerMessage());
        }

        public String GetWinnerMessage()
        {
            return (Winner == null) 
                ? "It is a tie !!!" 
                : $"Player {Winner.Name} Wins!!!";
        }


    }
}
