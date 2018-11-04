using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  enum PlayerLetter { x = 'x', o = 'o' };

  class Board
  {

    private readonly char[] Tiles = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

    public bool IsTileEmpty(byte tile)
    {
      return ((tile >= 0 && tile < 9) && (Tiles[tile] == ' '));
    }
    public void SetTileValue(byte tile, char tileValue)
    {
      Tiles[tile] = tileValue;
    }
    public string AvailableTilesString()
    {
      return "(Available Tiles : " + string.Join(", ", AvailableTiles()) + ") "; 
    }
    public IList<byte> AvailableTiles()
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

  }
}
