using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class ComputerPlayer : Player
    {
        Random Random = new Random();

        public ComputerPlayer(string name, PlayerLetter playerLetter) : base(name, playerLetter) { }

        public override void ChooseATile(Board board)
        {
            IList<byte> AvalableTiles = board.AvailableTiles();

            // CHECK IF AI IS READY TO WIN AND SELECT WINNING TILE
            if (!FindWinningTile(board, AvalableTiles, PlayerLetter))
                // CHECK IF THE OTHER USER IS READY TO WIN AND BLOCK HIM
                if (!FindWinningTile(board, AvalableTiles, PlayerLetter == 'x' ? 'o' : 'x'))
                    // RANDOM SELECT TILE
                    ChooseRandomTile(AvalableTiles);
        }
        private void ChooseRandomTile(IList<byte> avalableTiles)
        {
            int RandomTile = Random.Next(avalableTiles.Count);
            Tile = avalableTiles.ElementAt(RandomTile);
        }

        private bool FindWinningTile(Board board, IList<byte> avalableTiles, char playerLetter)
        {

            foreach (byte TileToCheck in avalableTiles)
                if (DoesPlayerWins(board, (byte)(TileToCheck - 1), playerLetter))
                {
                    Tile = TileToCheck;
                    return true;
                }

            return false;
        }
    }
}
