using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public enum GameLetter { X = 'X', O = 'O', Empty = ' ' };

    public abstract class Player
    {

        public String Name { get; private set; }
        public GameLetter PlayerLetter { get; private set; }
        protected byte _tile;
        public byte Tile { get { return (byte)(_tile-1); } protected set { _tile = value; } }
        protected Board _board;

        public Player(Board board, String name, GameLetter playerLetter)
        {
            _board = board;
            Name = name;
            PlayerLetter = playerLetter;
        }


        public abstract void ChooseATile( string PromptMessage);

        public void PrintLastChoice()
        {
            Console.WriteLine($"{Name}({PlayerLetter}) selected tile number: {_tile}");
        }
    }


}
