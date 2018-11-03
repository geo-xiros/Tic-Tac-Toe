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
    Board Board;
    public Game(Player Player1, Player Player2)
    {
      this.Board = new Board();
      this.Player1 = Player1;
      this.Player2 = Player2;
      this.CurrentPlayer = Player2;
      Winner = null;
    }
    public void Play()
    {
      Board.DisplayTiles();

      do
      {

        CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        CurrentPlayer.ChooseATile(Board);

        Board.SetTileValue(CurrentPlayer.Tile, CurrentPlayer.PlayerLetter);
        Board.DisplayTiles();

        if (Board.DoesPlayerWins(CurrentPlayer))
          Winner = CurrentPlayer;

      } while ((Board.HasAvailableChoices()) && (Winner == null));

      Console.WriteLine(GetWinnerString());
    }

    public String GetWinnerString()
    {
      return (Winner == null) ? "It is a tie !!!" : $"Player {Winner.Name} Wins!!!";
    }


  }
}
