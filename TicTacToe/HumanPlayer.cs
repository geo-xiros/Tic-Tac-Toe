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
      string AvailableTilesString = board.AvailableTilesString();
      Tile = GetATileFromZeroToNine("");
      while (!board.IsTileEmpty(Tile))
      {
        Tile = GetATileFromZeroToNine(AvailableTilesString);
      } 
      
    }
    private byte GetATileFromZeroToNine(string AvailableTilesString)
    {
      byte InputByte;
      string Input;
      do
      {
        Console.Write($"{Name} select a tile number {AvailableTilesString}: ");
        Input = Console.ReadLine();
      } while (!byte.TryParse(Input, out InputByte) ||
               !IsValueBetweenOneAndNine(InputByte));

      return InputByte;
    }
    private bool IsValueBetweenOneAndNine(byte value)
    {
      return (value >= 1 && value <= 9);
    }
  }
}
