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

    public Player(String name, PlayerLetter playerLetter)
    {
      this.Name = name;
      this.PlayerLetter = (char)playerLetter;
    }

    public abstract void ChooseATile(Board board);
  }


}
