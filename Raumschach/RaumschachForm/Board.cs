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
        public List<Cell[,]> _board;
        public Board()
        {

            #region Make Board
            var tempA = new Cell[,] 
            { 
                { new Cell("Aa1"), new Cell("Aa2"), new Cell("Aa3"), new Cell("Aa4"), new Cell("Aa5") },
                { new Cell("Ab1"), new Cell("Ab2"), new Cell("Ab3"), new Cell("Ab4"), new Cell("Ab5") },
                { new Cell("Ac1"), new Cell("Ac2"), new Cell("Ac3"), new Cell("Ac4"), new Cell("Ac5") },
                { new Cell("Ad1"), new Cell("Ad2"), new Cell("Ad3"), new Cell("Ad4"), new Cell("Ad5") },
                { new Cell("Ae1"), new Cell("Ae2"), new Cell("Ae3"), new Cell("Ae4"), new Cell("Ae5") }
            };

				 var tempB = new Cell[,] 
            { 
				{ new Cell("Ba1"), new Cell("Ba2"), new Cell("Ba3"), new Cell("Ba4"), new Cell("Ba5") },
                { new Cell("Bb1"), new Cell("Bb2"), new Cell("Bb3"), new Cell("Bb4"), new Cell("Bb5") },
                { new Cell("Bc1"), new Cell("Bc2"), new Cell("Bc3"), new Cell("Bc4"), new Cell("Bc5") },
                { new Cell("Bd1"), new Cell("Bd2"), new Cell("Bd3"), new Cell("Bd4"), new Cell("Bd5") },
                { new Cell("Be1"), new Cell("Be2"), new Cell("Be3"), new Cell("Be4"), new Cell("Be5") }
            };
				
             var tempC = new Cell[,] 
            { 
				{ new Cell("Ca1"), new Cell("Ca2"), new Cell("Ca3"), new Cell("Ca4"), new Cell("Ca5") },
                { new Cell("Cb1"), new Cell("Cb2"), new Cell("Cb3"), new Cell("Cb4"), new Cell("Cb5") },
                { new Cell("Cc1"), new Cell("Cc2"), new Cell("Cc3"), new Cell("Cc4"), new Cell("Cc5") },
                { new Cell("Cd1"), new Cell("Cd2"), new Cell("Cd3"), new Cell("Cd4"), new Cell("Cd5") },
                { new Cell("Ce1"), new Cell("Ce2"), new Cell("Ce3"), new Cell("Ce4"), new Cell("Ce5") }
            };
				 var tempD = new Cell[,] 
            { 
				{ new Cell("Da1"), new Cell("Da2"), new Cell("Da3"), new Cell("Da4"), new Cell("Da5") },
                { new Cell("Db1"), new Cell("Db2"), new Cell("Db3"), new Cell("Db4"), new Cell("Db5") },
                { new Cell("Dc1"), new Cell("Dc2"), new Cell("Dc3"), new Cell("Dc4"), new Cell("Dc5") },
                { new Cell("Dd1"), new Cell("Dd2"), new Cell("Dd3"), new Cell("Dd4"), new Cell("Dd5") },
                { new Cell("De1"), new Cell("De2"), new Cell("De3"), new Cell("De4"), new Cell("De5") }
            };
                 var tempE = new Cell[,] 
            { 
				
				{ new Cell("Ea1"), new Cell("Ea2"), new Cell("Ea3"), new Cell("Ea4"), new Cell("Ea5") },
                { new Cell("Eb1"), new Cell("Eb2"), new Cell("Eb3"), new Cell("Eb4"), new Cell("Eb5") },
                { new Cell("Ec1"), new Cell("Ec2"), new Cell("Ec3"), new Cell("Ec4"), new Cell("Ec5") },
                { new Cell("Ed1"), new Cell("Ed2"), new Cell("Ed3"), new Cell("Ed4"), new Cell("Ed5") },
                { new Cell("Ee1"), new Cell("Ee2"), new Cell("Ee3"), new Cell("Ee4"), new Cell("Ee5") }
            };
                 _board = new List<Cell[,]>(){tempA,tempB,tempC,tempD,tempE};
            #endregion

            _board[0][0, 0].addPiece(new Pawn(true,"Aa1"));
            //_board[0][1, 0].addPiece("WhiteBishop");
        }

        public void movePiece(string cellName1, string cellName2)
        {
            var cell1 = _board[getBoard(cellName1)][getCellRow(cellName1), getCellCol(cellName1)];
            var cell2 = _board[getBoard(cellName2)][getCellRow(cellName2), getCellCol(cellName2)];
            var temp = cell1.getPiece();
            if (temp == null) return;
            cell1.addPiece(null);
            cell2.addPiece(temp);
        }

        public int getCellRow(string cellName)
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

        public int getCellCol(string cellName)
        {
            var col = Convert.ToInt32(cellName.Substring(2, 1)) - 1;
            return col;
        }
        public int getBoard(string cellName)
        {
            var row = cellName.Substring(0, 1);
            int rowNumber = 0;
            switch (row)
            {
                case "A":
                    rowNumber = 0;
                    break;
                case "B":
                    rowNumber = 1;
                    break;
                case "C":
                    rowNumber = 2;
                    break;
                case "D":
                    rowNumber = 3;
                    break;
                case "E":
                    rowNumber = 4;
                    break;
            }
            return rowNumber;
        }

        public Cell getCell(string cellName)
        {
            return _board[getBoard(cellName)][getCellRow(cellName), getCellCol(cellName)];
        }
    }
}
