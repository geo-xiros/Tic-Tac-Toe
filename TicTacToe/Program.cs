using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board Board = new Board();
            Player Player1 = new Player("George", PlayerLetter.x);
            Player Player2 = new Player("Nick", PlayerLetter.o);
            Player CurrentPlayer = Player1;

            Board.DisplayTiles();
            
            while (Board.HasAvailableChoices())
            {
                CurrentPlayer.ChooseATile(Board); 
                Board.SetPlayersChoice(CurrentPlayer); 
                Board.DisplayTiles();
                
                CurrentPlayer = (CurrentPlayer == Player1) ? Player2 :Player1;
            }
            
            Console.ReadKey();
        }
    }
}
