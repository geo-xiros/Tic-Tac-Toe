using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string name, GameLetter playerLetter) : base(name, playerLetter) { }

        public override void ChooseATile(Board board)
        {
            string AvailableTilesString = board.StringOfAvailableTiles;

            byte _Tile = ConsoleInputTileNumber(string.Empty);

            while (!board.IsTileSelectionValid(_Tile))
            {
                _Tile = ConsoleInputTileNumber(AvailableTilesString);
            }

            Tile = _Tile;
        }
        private byte ConsoleInputTileNumber(string availableTilesString)
        {
            byte InputByte;
            string Input;

            do
            {
                Console.Write($"{Name} select a tile number {availableTilesString}: ");
                Input = Console.ReadLine();
            } while (!byte.TryParse(Input, out InputByte));

            return InputByte;
        }
    }
}
