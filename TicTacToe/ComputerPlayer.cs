using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  class ComputerPlayer : Player
  {
    Random Random = new Random();

    public ComputerPlayer(string name, PlayerLetter playerLetter) : base(name, playerLetter) { }

    public override void ChooseATile(Board board)
    {
      IList<byte> AvalableTiles = board.AvailableTiles();

      // TODO:
      // CHECK IF THE OTHER USER IS READY TO WIN AND BLOCK HIM
      if (!FindWinningTile(board, AvalableTiles, PlayerLetter == 'x' ? 'o' : 'x'))
        // CHECK IF AI IS READY TO WIN AND SELECT WINNING TILE
        if (!FindWinningTile(board, AvalableTiles, PlayerLetter))
          // RANDOM SELECT TILE
          ChooseRandomTile(AvalableTiles);

      // set Tile Value
      board.SetTileValue(Tile, PlayerLetter);

      //Console.WriteLine($"{Name} selected tile number: {Tile + 1}");
    }
    private void ChooseRandomTile(IList<byte> AvalableTiles)
    {
      int RandomTile = Random.Next(AvalableTiles.Count);
      Tile = AvalableTiles.ElementAt(RandomTile);
    }

    private bool FindWinningTile(Board board, IList<byte> avalableTiles, char playerLetter)
    {
      foreach (byte TileToCheck in avalableTiles)
      {
        if (DoesPlayerWins(board, (byte)(TileToCheck-1), playerLetter))
        {
          Tile = TileToCheck;
          return true;
        }

      }
      return false;
    }
  }
}
