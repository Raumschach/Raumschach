using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

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
            var cell1 = _board[getCellRow(cellName1), getCellCol(cellName1)];
            var cell2 = _board[getCellRow(cellName2), getCellCol(cellName2)];
            var temp = cell1.getPiece();
            cell1.addPiece(null);
            cell2.addPiece(temp);
            Debug.WriteLine(cell1.getPiece());
        }

        private int getCellRow(string cellName)
        {
            var row = cellName.Substring(1, 1);
            int rowNumber = 0;
            switch (row)
            {
                case "a":
                    rowNumber = 0;
                    break;
                case "b":
                    rowNumber = 1;
                    break;
                case "c":
                    rowNumber = 2;
                    break;
                case "d":
                    rowNumber = 3;
                    break;
                case "e":
                    rowNumber = 4;
                    break;
            }
            return rowNumber;
        }

        private int getCellCol(string cellName)
        {
            var col = Convert.ToInt32(cellName.Substring(2, 1)) - 1;
            return col;
        }

    }
}
