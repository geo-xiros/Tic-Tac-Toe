using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Program
    {

        static void Main(string[] args)
        {
            var board = new Board();
            var playe1 = new HumanPlayer(board,"George", GameLetter.X);
            var player2 = new ComputerPlayer(board,"Computer", GameLetter.O);
            var game = new Game(board, playe1, player2);

            while (!game.GameIsOver)
            {
                game.RenderGame();
                game.NextPlayer();
                game.Play();
            }

            game.RenderGame();

            Console.ReadKey();

        }

    }
}
