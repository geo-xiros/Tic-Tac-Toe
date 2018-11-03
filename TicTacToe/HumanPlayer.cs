using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  internal class HumanPlayer : Player
  {
    public HumanPlayer(string Name, PlayerLetter PlayerLetter) : base(Name, PlayerLetter)
    {
    }

    public override void ChooseATile(Board Board)
    {
      Console.WriteLine("Select a tile number: ");
      String Input = Console.ReadLine();

      while ((!byte.TryParse(Input, out _Tile)) || (!Board.IsTileEmpty(_Tile)))
      {
        Board.DisplayAvailableTiles();
        Console.WriteLine("Select an available tile number: ");
        Input = Console.ReadLine();
      }
    }
  }
}
