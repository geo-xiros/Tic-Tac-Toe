using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  class Game
  {
    List<List<byte>>[] WinCombinations = {
            new List<List<byte>> { new List<byte> { 2, 3 }, new List<byte> { 4, 7 }, new List<byte> { 5, 9 } },
            new List<List<byte>> { new List<byte> { 1, 3 }, new List<byte> { 5, 8 } },
            new List<List<byte>> { new List<byte> { 1, 2 }, new List<byte> { 5, 7 }, new List<byte> { 6, 9 } },
            new List<List<byte>> { new List<byte> { 1, 7 }, new List<byte> { 5, 6 }, },
            new List<List<byte>> { new List<byte> { 1, 9 }, new List<byte> { 2, 8 }, new List<byte> { 3, 7 }, new List<byte> { 4, 6 } },
            new List<List<byte>> { new List<byte> { 3, 9 }, new List<byte> { 4, 5 }, },
            new List<List<byte>> { new List<byte> { 1, 4 }, new List<byte> { 8, 9 }, new List<byte> { 5, 3 } },
            new List<List<byte>> { new List<byte> { 7, 9 }, new List<byte> { 2, 5 } },
            new List<List<byte>> { new List<byte> { 7, 8 }, new List<byte> { 3, 6 }, new List<byte> { 1,5 } }};
    Player Player1, Player2, CurrentPlayer, Winner;
    Board Board;
    public Game(Player Player1, Player Player2)
    {
      this.Board = new Board();
      this.Player1 = Player1;
      this.Player2 = Player2;
      this.CurrentPlayer = this.Player1;
      Winner = null;
    }
    public void Play()
    {
      Board.DisplayTiles();

      do
      {
        CurrentPlayer.ChooseATile(Board);
        Board.SetTileValue(CurrentPlayer.Tile, CurrentPlayer.PlayerLetter);
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

    public bool DoesPlayerWins(Board Board, Player Player)
    {
      // check all cobinations for winning
      foreach (List<byte> Combination in WinCombinations[Player.Tile - 1])
      {
        // If Has player letter in both win combinations positions then player wins
        if ((Board.GetTileValue(Combination[0]) == Player.PlayerLetter) &&
            (Board.GetTileValue(Combination[1]) == Player.PlayerLetter))
          return true;
      }

      return false;
    }
  }
}
