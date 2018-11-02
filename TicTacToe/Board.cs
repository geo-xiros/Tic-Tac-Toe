using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    enum TileChoices { x = 'x', o = 'o' };

    class Board
    {
        private Char[] Tiles = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        private List<Char> TilesToChoose = new List<Char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public bool IsTileEmpty(byte Tile)
        {
            return ((Tile >= 1 && Tile <= 9) && (Tiles[Tile - 1] == ' '));
        }

        public void SetPlayersChoice(Player Player)
        {
            Tiles[Player.Tile - 1] = (char)Player.TileChoice;
            MakeTileUnavailable(Player);
        }

        private void MakeTileUnavailable(Player Player)
        {
            Char CharToFind = Player.Tile.ToString().ToCharArray()[0];
            TilesToChoose.Remove(CharToFind);
        }

        public void DisplayAvailableChoices()
        {
            Console.WriteLine("Available Choices: " + String.Join(", ", TilesToChoose));
        }

        public bool HasAvailableChoices()
        {
            return TilesToChoose.Count > 0;
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
