using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{

    class Board
    {

        private readonly GameLetter[] Tiles = {
            GameLetter.Empty, GameLetter.Empty, GameLetter.Empty,
            GameLetter.Empty, GameLetter.Empty, GameLetter.Empty,
            GameLetter.Empty, GameLetter.Empty, GameLetter.Empty};

        public bool IsTileSelectionValid(byte tile)
        {
            return AvailableTiles()
                .Contains(tile);
        }
        public void SetTileValue(byte tile, GameLetter letter)
        {
            Tiles[tile] = letter;
        }
        public GameLetter GetTileValue(byte tile)
        {
            return Tiles[tile];
        }
        public string AvailableTilesString()
        {
            return $"(Available Tiles : {string.Join(", ", AvailableTiles())}) ";
        }
        public IList<byte> AvailableTiles()
        {
            return Tiles
                .Select((tile, index) => new { index, tile })
                .Where((item) => item.tile == GameLetter.Empty)
                .Select((item) => (byte)(item.index + 1))
                .ToList();
        }
        public bool HasAvailableTiles()
        {
            return Tiles
                .Count((tile) => tile == GameLetter.Empty) > 0;
        }

        public void DisplayTiles()
        {
            byte i = 0;

            Console.WriteLine($" {(char)Tiles[i++]} | {(char)Tiles[i++]} | {(char)Tiles[i++]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {(char)Tiles[i++]} | {(char)Tiles[i++]} | {(char)Tiles[i++]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {(char)Tiles[i++]} | {(char)Tiles[i++]} | {(char)Tiles[i++]} ");
            Console.WriteLine("");
        }

    }
}
