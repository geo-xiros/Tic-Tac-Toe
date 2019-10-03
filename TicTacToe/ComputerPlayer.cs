using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class ComputerPlayer : Player
    {
        Random Random = new Random();

        public ComputerPlayer(Board board, string name, GameLetter playerLetter) : base(board, name, playerLetter) { }

        public override void ChooseATile(string promptMessage)
        {
            // CHECK IF AI IS READY TO WIN AND SELECT WINNING TILE
            if (!FindWinningTile(_board, _board.AvailableTiles, PlayerLetter))
                // CHECK IF THE OTHER USER IS READY TO WIN AND BLOCK HIM
                if (!FindWinningTile(_board, _board.AvailableTiles, PlayerLetter == GameLetter.X ? GameLetter.O : GameLetter.X))
                    // RANDOM SELECT TILE
                    ChooseRandomTile(_board.AvailableTiles);
        }
        private void ChooseRandomTile(IEnumerable<byte> avalableTiles)
        {
            int RandomTile = Random.Next(avalableTiles.Count());
            _tile = avalableTiles.ElementAt(RandomTile);
        }

        private bool FindWinningTile(Board board, IEnumerable<byte> avalableTiles, GameLetter playerLetter)
        {

            foreach (byte TileToCheck in avalableTiles)
                if (board.DoesPlayerWins((byte)(TileToCheck - 1), playerLetter))
                {
                    _tile = TileToCheck;
                    return true;
                }

            return false;
        }
    }
}
