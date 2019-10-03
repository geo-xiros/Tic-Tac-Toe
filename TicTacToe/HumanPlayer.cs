using System;

namespace TicTacToe
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(Board board, string name, GameLetter playerLetter) : base(board, name, playerLetter) { }

        public override void ChooseATile(string promptMessage)
        {
            string Input;

            do
            {
                Console.Write(promptMessage);
                Input = Console.ReadLine();
            } while (!byte.TryParse(Input, out _tile));

        }

    }
}
