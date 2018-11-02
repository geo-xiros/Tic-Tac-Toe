using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Player
    {
        internal String Name { get; private set; }
        internal PlayerLetter PlayerLetter { get; private set; }
        private byte _Tile;
        internal byte Tile { get { return _Tile; } }

        public Player(String Name, PlayerLetter PlayerLetter)
        {
            this.Name = Name;
            this.PlayerLetter = PlayerLetter;
        }

        public void ChooseATile(Board Board)
        {
            Console.WriteLine("Select a tile number: ");
            String Input = Console.ReadLine();

            while ((!byte.TryParse(Input, out _Tile)) || (!Board.IsTileEmpty(_Tile)))
            {
                Board.DisplayAvailableTiles();
                Console.WriteLine("Select an available tile number: ");
                Input = Console.ReadLine();
            }

        }
    }
}
