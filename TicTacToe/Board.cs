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
            new List<List<byte>> { new List<byte> { 1, 2 }, new List<byte> { 3, 6 }, new List<byte> { 4, 8 } },
            new List<List<byte>> { new List<byte> { 0, 2 }, new List<byte> { 4, 7 } },
            new List<List<byte>> { new List<byte> { 0, 1 }, new List<byte> { 4, 6 }, new List<byte> { 5, 8 } },
            new List<List<byte>> { new List<byte> { 0, 6 }, new List<byte> { 4, 5 }, },
            new List<List<byte>> { new List<byte> { 0, 8 }, new List<byte> { 1, 7 }, new List<byte> { 2, 6 }, new List<byte> { 3, 5 } },
            new List<List<byte>> { new List<byte> { 2, 8 }, new List<byte> { 3, 4 }, },
            new List<List<byte>> { new List<byte> { 0, 3 }, new List<byte> { 7, 8 }, new List<byte> { 4, 2 } },
            new List<List<byte>> { new List<byte> { 6, 8 }, new List<byte> { 1, 4 } },
            new List<List<byte>> { new List<byte> { 6, 7 }, new List<byte> { 2, 5 }, new List<byte> { 0, 4 } }};
    private readonly char[] Tiles = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

    public bool IsTileEmpty(byte tile)
    {
      return ((tile >= 0 && tile < 9) && (Tiles[tile] == ' '));
    }
    public void SetTileValue(byte tile, char tileValue)
    {
      Tiles[tile] = tileValue;
    }
    public void DisplayAvailableTiles()
    {
      Console.WriteLine("Available Choices: " + string.Join(", ", AvalableTiles()));// Tiles.Select((tile, index) => new { index, tile }).Where((item) => item.tile == ' ').Select((item) => item.index+1)));
    }
    public IList<byte> AvalableTiles()
    {
      return Tiles.Select((tile, index) => new { index, tile }).Where((item) => item.tile == ' ').Select((item) => (byte) (item.index + 1)).ToList();
    }
    public bool HasAvailableChoices()
    {
      return Tiles.Count((tile) => tile == ' ') > 0;
    }
    public char GetTileValue(byte tile)
    {
      return Tiles[tile];
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
    public bool DoesPlayerWins(Player player)
    {
      // check all cobinations for winning
      foreach (List<byte> Combination in WinCombinations[player.Tile])
      {
        // If Has player letter in both win combinations positions then player wins
        if ((GetTileValue(Combination[0]) == player.PlayerLetter) &&
            (GetTileValue(Combination[1]) == player.PlayerLetter))
          return true;
      }

      return false;
    }
  }
}
