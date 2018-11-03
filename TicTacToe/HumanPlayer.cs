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
      _Tile = GetATileFromZeroToNine();
      while (!Board.IsTileEmpty(_Tile))
      {
        Board.DisplayAvailableTiles();
        _Tile = GetATileFromZeroToNine();
      }
    }
    private byte GetATileFromZeroToNine()
    {
      byte InputByte;
      string Input;
      do
      {
        Console.Write($"{Name} select a tile number: ");
        Input = Console.ReadLine();
      } while (!(byte.TryParse(Input, out InputByte)) ||
               !(InputByte>=1 && InputByte<=9));

      return InputByte;
    }
  }
}
