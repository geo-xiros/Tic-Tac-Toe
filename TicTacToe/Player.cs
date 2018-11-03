using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  abstract class Player
  {
    internal String Name { get; private set; }
    internal Char PlayerLetter { get; private set; }
    protected byte _Tile;
    internal byte Tile { get { return _Tile; } }

    public Player(String Name, PlayerLetter PlayerLetter)
    {
      this.Name = Name;
      this.PlayerLetter = (Char) PlayerLetter;
    }

    public abstract void ChooseATile(Board Board);
  }


}
