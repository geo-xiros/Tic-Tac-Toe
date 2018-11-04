using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  abstract class Player
  {
    public String Name { get; private set; }
    public char PlayerLetter { get; private set; }
    private byte _Tile;
    public byte Tile { get { return (byte)(_Tile - 1); } protected set { _Tile = value; } }
    readonly List<byte[]>[] WinCombinations = {
            new List<byte[]> { new byte[] { 1, 2 }, new byte[] { 3, 6 }, new byte[] { 4, 8 } },
            new List<byte[]> { new byte[] { 0, 2 }, new byte[] { 4, 7 } },
            new List<byte[]> { new byte[] { 0, 1 }, new byte[] { 4, 6 }, new byte[] { 5, 8 } },
            new List<byte[]> { new byte[] { 0, 6 }, new byte[] { 4, 5 }, },
            new List<byte[]> { new byte[] { 0, 8 }, new byte[] { 1, 7 }, new byte[] { 2, 6 }, new byte[] { 3, 5 } },
            new List<byte[]> { new byte[] { 2, 8 }, new byte[] { 3, 4 }, },
            new List<byte[]> { new byte[] { 0, 3 }, new byte[] { 7, 8 }, new byte[] { 4, 2 } },
            new List<byte[]> { new byte[] { 6, 8 }, new byte[] { 1, 4 } },
            new List<byte[]> { new byte[] { 6, 7 }, new byte[] { 2, 5 }, new byte[] { 0, 4 } }};

    public Player(String name, PlayerLetter playerLetter)
    {
      Name = name;
      PlayerLetter = (char)playerLetter;
    }
    public bool DoesPlayerWins(Board board)
    {
      // check all cobinations for winning
      return DoesPlayerWins(board, Tile, PlayerLetter);
    }
    public bool DoesPlayerWins(Board board, byte tile, char playerLetter)
    {
      // check all cobinations for winning
      foreach (byte[] Combination in WinCombinations[tile])
      {
        // If Has player letter in both win combinations positions then player wins
        if ((board.GetTileValue(Combination[0]) == playerLetter) &&
            (board.GetTileValue(Combination[1]) == playerLetter))
          return true;
      }

      return false;
    }

    public abstract void ChooseATile(Board board);

  }


}
