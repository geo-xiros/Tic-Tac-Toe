using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
  class Program
  {

    static void Main(string[] args)
    {
      Game Game = new Game(new HumanPlayer("George", PlayerLetter.x),
                           new HumanPlayer("Nick", PlayerLetter.o));
      Game.Play();

      Console.ReadKey();

    }

  }
}
