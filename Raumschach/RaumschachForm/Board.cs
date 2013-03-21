using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RaumschachForm
{
    public class Board
    {
        public Cell[,] _board;
        public Board()
        {

            _board = new Cell[,] 
            { 
                { new Cell("Aa1"), new Cell("Aa2"), new Cell("Aa3"), new Cell("Aa4"), new Cell("Aa5") },
                { new Cell("Ab1"), new Cell("Ab2"), new Cell("Ab3"), new Cell("Ab4"), new Cell("Ab5") },
                { new Cell("Ac1"), new Cell("Ac2"), new Cell("Ac3"), new Cell("Ac4"), new Cell("Ac5") },
                { new Cell("Ad1"), new Cell("Ad2"), new Cell("Ad3"), new Cell("Ad4"), new Cell("Ad5") },
                { new Cell("Ae1"), new Cell("Ae2"), new Cell("Ae3"), new Cell("Ae4"), new Cell("Ae5") }
            };

            _board[0, 0].addPiece("WhitePawn");
        }

        public void movePiece(string cellName1, string cellName2)
        {
        }
    }
}
