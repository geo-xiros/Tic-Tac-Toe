using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    enum PlayerLetter { x = 'x', o = 'o' };

    class Board
    {
        private Char[] Tiles = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        private List<Char> AvailableTiles = new List<Char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public bool IsTileEmpty(byte Tile)
        {
            return ((Tile >= 1 && Tile <= 9) && (Tiles[Tile - 1] == ' '));
        }

        public void SetPlayersChoice(Player Player)
        {
            Tiles[Player.Tile - 1] = (char)Player.PlayerLetter;
            MakeTileUnavailable(Player);
        }

        private void MakeTileUnavailable(Player Player)
        {
            Char CharToFind = Player.Tile.ToString().ToCharArray()[0];
            AvailableTiles.Remove(CharToFind);
        }

        public void DisplayAvailableTiles()
        {
            Console.WriteLine("Available Choices: " + String.Join(", ", AvailableTiles));
        }

        public bool HasAvailableChoices()
        {
            return AvailableTiles.Count > 0;
        }
        public Char GetTileValue(byte Tile)
        {
            return Tiles[Tile];
        }
        public void DisplayTiles()
        {
            byte i = 0;
            Console.WriteLine(" {0} | {1} | {2} ", Tiles[i++], Tiles[i++], Tiles[i++]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ", Tiles[i++], Tiles[i++], Tiles[i++]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ", Tiles[i++], Tiles[i++], Tiles[i++]);
            Console.WriteLine("");
        }
    }
}
