using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  enum PlayerLetter { x = 'x', o = 'o' };

  class Board
  {
    readonly List<List<byte>>[] WinCombinations = {
            new List<List<byte>> { new List<byte> { 2, 3 }, new List<byte> { 4, 7 }, new List<byte> { 5, 9 } },
            new List<List<byte>> { new List<byte> { 1, 3 }, new List<byte> { 5, 8 } },
            new List<List<byte>> { new List<byte> { 1, 2 }, new List<byte> { 5, 7 }, new List<byte> { 6, 9 } },
            new List<List<byte>> { new List<byte> { 1, 7 }, new List<byte> { 5, 6 }, },
            new List<List<byte>> { new List<byte> { 1, 9 }, new List<byte> { 2, 8 }, new List<byte> { 3, 7 }, new List<byte> { 4, 6 } },
            new List<List<byte>> { new List<byte> { 3, 9 }, new List<byte> { 4, 5 }, },
            new List<List<byte>> { new List<byte> { 1, 4 }, new List<byte> { 8, 9 }, new List<byte> { 5, 3 } },
            new List<List<byte>> { new List<byte> { 7, 9 }, new List<byte> { 2, 5 } },
            new List<List<byte>> { new List<byte> { 7, 8 }, new List<byte> { 3, 6 }, new List<byte> { 1,5 } }};
    private readonly Char[] Tiles = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    private List<Char> AvailableTiles = new List<Char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public bool IsTileEmpty(byte Tile)
    {
      return ((Tile >= 1 && Tile <= 9) && (Tiles[--Tile] == ' '));
    }
    public void SetTileValue(byte Tile, Char TileValue)
    {
      AvailableTiles.Remove(Tile.ToString().ToCharArray()[0]);
      Tiles[--Tile] = TileValue;
    }
    public void DisplayAvailableTiles()
    {
      Console.WriteLine("Available Choices: " + String.Join(", ", AvailableTiles));
    }
    public bool HasAvailableChoices()
    {
      return AvailableTiles.Count > 0;
    }
    public Char GetTileValue(byte Tile)
    {
      return Tiles[--Tile];
    }
    public void DisplayTiles()
    {
      byte i = 0;
      Console.WriteLine(" {0} | {1} | {2} ", Tiles[i++], Tiles[i++], Tiles[i++]);
      Console.WriteLine("-----------");
      Console.WriteLine(" {0} | {1} | {2} ", Tiles[i++], Tiles[i++], Tiles[i++]);
      Console.WriteLine("-----------");
      Console.WriteLine(" {0} | {1} | {2} ", Tiles[i++], Tiles[i++], Tiles[i++]);
      Console.WriteLine("");
    }
    public bool DoesPlayerWins(Player Player)
    {
      // check all cobinations for winning
      foreach (List<byte> Combination in WinCombinations[Player.Tile - 1])
      {
        // If Has player letter in both win combinations positions then player wins
        if ((GetTileValue(Combination[0]) == Player.PlayerLetter) &&
            (GetTileValue(Combination[1]) == Player.PlayerLetter))
          return true;
      }

      return false;
    }
  }
}
