using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{

    public class Board
    {
        private readonly GameLetter[] Tiles = {
            GameLetter.Empty, GameLetter.Empty, GameLetter.Empty,
            GameLetter.Empty, GameLetter.Empty, GameLetter.Empty,
            GameLetter.Empty, GameLetter.Empty, GameLetter.Empty};

        #region Search for a winner
        private readonly List<byte[]>[] WinCombinations = {
            new List<byte[]> { new byte[] { 1, 2 }, new byte[] { 3, 6 }, new byte[] { 4, 8 } },
            new List<byte[]> { new byte[] { 0, 2 }, new byte[] { 4, 7 } },
            new List<byte[]> { new byte[] { 0, 1 }, new byte[] { 4, 6 }, new byte[] { 5, 8 } },
            new List<byte[]> { new byte[] { 0, 6 }, new byte[] { 4, 5 }, },
            new List<byte[]> { new byte[] { 0, 8 }, new byte[] { 1, 7 }, new byte[] { 2, 6 }, new byte[] { 3, 5 } },
            new List<byte[]> { new byte[] { 2, 8 }, new byte[] { 3, 4 }, },
            new List<byte[]> { new byte[] { 0, 3 }, new byte[] { 7, 8 }, new byte[] { 4, 2 } },
            new List<byte[]> { new byte[] { 6, 8 }, new byte[] { 1, 4 } },
            new List<byte[]> { new byte[] { 6, 7 }, new byte[] { 2, 5 }, new byte[] { 0, 4 } }};

        public bool DoesPlayerWins(Player player)
        {
            // check all cobinations for winning
            return DoesPlayerWins(player.Tile, player.PlayerLetter);
        }
        public bool DoesPlayerWins(byte tile, GameLetter playerLetter)
        {
            // check all cobinations for winning
            foreach (byte[] Combination in WinCombinations[tile])
            {
                // If Has player letter in both win combinations positions then player wins
                if ((GetTileValue(Combination[0]) == playerLetter) &&
                    (GetTileValue(Combination[1]) == playerLetter))
                    return true;
            }

            return false;
        }
        #endregion

        #region public methods
        public IEnumerable<byte> AvailableTiles
            => Tiles.Select((tile, index) => new { index, tile })
                .Where((item) => item.tile == GameLetter.Empty)
                .Select((item) => (byte)(item.index + 1));

        public void SetTileValue(byte tile,GameLetter value)
        {
            Tiles[tile] = value;
        }
        public GameLetter GetTileValue(byte tile)
        {
            return Tiles[tile];
        }
        public bool HasAvailableTiles
            => Tiles
                .Count((tile) => tile == GameLetter.Empty) > 0;

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
        #endregion

        #region private help methods
        public bool IsTileSelectionValid(byte tile)
        {
            return AvailableTiles
                .Contains((byte)(tile + 1));
        }

        public string AvailableTilesString
            => $"(Available Tiles : {string.Join(", ", AvailableTiles)}) ";


        #endregion

    }
}
