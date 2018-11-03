using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  internal class HumanPlayer : Player
  {
    public HumanPlayer(string name, PlayerLetter playerLetter) : base(name, playerLetter)
    {
    }

    public override void ChooseATile(Board board)
    {
      Tile = GetATileFromZeroToNine();
      while (!board.IsTileEmpty(Tile))
      {
        board.DisplayAvailableTiles();
        Tile = GetATileFromZeroToNine();
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
