using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static List<List<byte>>[] WinCombinations = {
            new List<List<byte>> { new List<byte> { 2, 3 }, new List<byte> { 4, 7 }, new List<byte> { 5, 9 } },
            new List<List<byte>> { new List<byte> { 1, 3 }, new List<byte> { 5, 8 } },
            new List<List<byte>> { new List<byte> { 1, 2 }, new List<byte> { 5, 7 }, new List<byte> { 6, 9 } },
            new List<List<byte>> { new List<byte> { 1, 7 }, new List<byte> { 5, 6 }, },
            new List<List<byte>> { new List<byte> { 1, 9 }, new List<byte> { 2, 8 }, new List<byte> { 3, 7 }, new List<byte> { 4, 6 } },
            new List<List<byte>> { new List<byte> { 3, 9 }, new List<byte> { 4, 5 }, },
            new List<List<byte>> { new List<byte> { 1, 4 }, new List<byte> { 8, 9 }, new List<byte> { 5, 3 } },
            new List<List<byte>> { new List<byte> { 7, 9 }, new List<byte> { 2, 5 } },
            new List<List<byte>> { new List<byte> { 7, 8 }, new List<byte> { 3, 6 }, new List<byte> { 1,5 } }};

        static void Main(string[] args)
        {
            Board Board = new Board();
            Player Player1 = new Player("George", PlayerLetter.x);
            Player Player2 = new Player("Nick", PlayerLetter.o);
            Player CurrentPlayer = Player1;
            Player Winner = null;

            Board.DisplayTiles();

            do
            {
                CurrentPlayer.ChooseATile(Board);
                Board.SetPlayersChoice(CurrentPlayer);
                Board.DisplayTiles();
                if (DoesPlayerWins(Board, CurrentPlayer))
                    Winner = CurrentPlayer;

                CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;

            } while ((Board.HasAvailableChoices()) && (Winner == null));

            if (Winner == null)
                Console.WriteLine("It is a tie !!!");
            else
                Console.WriteLine("Player {0} Wins!!!", Winner.Name);

            Console.ReadKey();
        }

        static public bool DoesPlayerWins(Board Board, Player Player)
        {
            //foreach (List<List<byte>> l1 in WinCombinations)
            foreach (List<byte> l2 in WinCombinations[Player.Tile - 1])
            {
                byte Position1 = (byte)(l2[0] - 1);
                byte Position2 = (byte)(l2[1] - 1);

                if ((Board.GetTileValue(Position1) == (Char)Player.PlayerLetter) &&
                    (Board.GetTileValue(Position2) == (Char)Player.PlayerLetter))
                    return true;
            }


            return false;
        }

    }
}
