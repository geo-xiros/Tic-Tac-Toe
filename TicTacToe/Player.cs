using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Player
    {
        internal String Name { get; private set; }
        internal TileChoices TileChoice { get; private set; }
        internal byte Tile { get; private set; }

        public Player(String Name, TileChoices TileChoice)
        {
            this.Name = Name;
            this.TileChoice = TileChoice;
        }

        public void ChooseATile(Board Board)
        {
            Console.WriteLine("Select a tile number: ");
            String Input = Console.ReadLine();
            byte Tile = 0;

            while ((!byte.TryParse(Input, out Tile)) || (!Board.IsTileEmpty(Tile)))
            {
                Board.DisplayAvailableChoices();
                Console.WriteLine("Select an available tile number: ");
                Input = Console.ReadLine();
            }

            this.Tile = Tile;
        }
    }
}
