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
      // CHECK IF AI IS READY TO WIN AND SELECT WINNING TILE

      // RANDOM SELECT TILE
      Tile = ChooseRandomTile(AvalableTiles);

      // set Tile Value
      board.SetTileValue(Tile, PlayerLetter);

      Console.WriteLine($"{Name} selected tile number: {Tile + 1}");
    }
    private byte ChooseRandomTile(IList<byte> AvalableTiles)
    {
      int RandomTile = Random.Next(AvalableTiles.Count);
      return AvalableTiles.ElementAt(RandomTile);
    }
  }
}
