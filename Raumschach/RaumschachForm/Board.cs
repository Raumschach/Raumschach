using System;
using System.Collections.Generic;

namespace RaumschachForm
{
    public class Board
    {
        public List<Cell[,]> _board;
        public Board()
        {
            #region Make Board
            var tempA = new[,] 
            { 
                { new Cell("Aa1"), new Cell("Aa2"), new Cell("Aa3"), new Cell("Aa4"), new Cell("Aa5") },
                { new Cell("Ab1"), new Cell("Ab2"), new Cell("Ab3"), new Cell("Ab4"), new Cell("Ab5") },
                { new Cell("Ac1"), new Cell("Ac2"), new Cell("Ac3"), new Cell("Ac4"), new Cell("Ac5") },
                { new Cell("Ad1"), new Cell("Ad2"), new Cell("Ad3"), new Cell("Ad4"), new Cell("Ad5") },
                { new Cell("Ae1"), new Cell("Ae2"), new Cell("Ae3"), new Cell("Ae4"), new Cell("Ae5") }
            };

				 var tempB = new[,] 
            { 
				{ new Cell("Ba1"), new Cell("Ba2"), new Cell("Ba3"), new Cell("Ba4"), new Cell("Ba5") },
                { new Cell("Bb1"), new Cell("Bb2"), new Cell("Bb3"), new Cell("Bb4"), new Cell("Bb5") },
                { new Cell("Bc1"), new Cell("Bc2"), new Cell("Bc3"), new Cell("Bc4"), new Cell("Bc5") },
                { new Cell("Bd1"), new Cell("Bd2"), new Cell("Bd3"), new Cell("Bd4"), new Cell("Bd5") },
                { new Cell("Be1"), new Cell("Be2"), new Cell("Be3"), new Cell("Be4"), new Cell("Be5") }
            };
				
             var tempC = new[,] 
            { 
				{ new Cell("Ca1"), new Cell("Ca2"), new Cell("Ca3"), new Cell("Ca4"), new Cell("Ca5") },
                { new Cell("Cb1"), new Cell("Cb2"), new Cell("Cb3"), new Cell("Cb4"), new Cell("Cb5") },
                { new Cell("Cc1"), new Cell("Cc2"), new Cell("Cc3"), new Cell("Cc4"), new Cell("Cc5") },
                { new Cell("Cd1"), new Cell("Cd2"), new Cell("Cd3"), new Cell("Cd4"), new Cell("Cd5") },
                { new Cell("Ce1"), new Cell("Ce2"), new Cell("Ce3"), new Cell("Ce4"), new Cell("Ce5") }
            };
				 var tempD = new[,] 
            { 
				{ new Cell("Da1"), new Cell("Da2"), new Cell("Da3"), new Cell("Da4"), new Cell("Da5") },
                { new Cell("Db1"), new Cell("Db2"), new Cell("Db3"), new Cell("Db4"), new Cell("Db5") },
                { new Cell("Dc1"), new Cell("Dc2"), new Cell("Dc3"), new Cell("Dc4"), new Cell("Dc5") },
                { new Cell("Dd1"), new Cell("Dd2"), new Cell("Dd3"), new Cell("Dd4"), new Cell("Dd5") },
                { new Cell("De1"), new Cell("De2"), new Cell("De3"), new Cell("De4"), new Cell("De5") }
            };
                 var tempE = new[,] 
            { 
				
				{ new Cell("Ea1"), new Cell("Ea2"), new Cell("Ea3"), new Cell("Ea4"), new Cell("Ea5") },
                { new Cell("Eb1"), new Cell("Eb2"), new Cell("Eb3"), new Cell("Eb4"), new Cell("Eb5") },
                { new Cell("Ec1"), new Cell("Ec2"), new Cell("Ec3"), new Cell("Ec4"), new Cell("Ec5") },
                { new Cell("Ed1"), new Cell("Ed2"), new Cell("Ed3"), new Cell("Ed4"), new Cell("Ed5") },
                { new Cell("Ee1"), new Cell("Ee2"), new Cell("Ee3"), new Cell("Ee4"), new Cell("Ee5") }
            };
                 _board = new List<Cell[,]> {tempA,tempB,tempC,tempD,tempE};
            #endregion
        }

        public void NewGame()
        {
            _board[0][0, 1].AddPiece(new Pawn(false, "Aa2"));
            _board[0][1, 1].AddPiece(new Pawn(false, "Ab2"));
            _board[0][2, 1].AddPiece(new Pawn(false, "Ac2"));
            _board[0][3, 1].AddPiece(new Pawn(false, "Ad2"));
            _board[0][4, 1].AddPiece(new Pawn(false, "Ae2"));
            _board[1][0, 1].AddPiece(new Pawn(false, "Ba2"));
            _board[1][1, 1].AddPiece(new Pawn(false, "Bb2"));
            _board[1][2, 1].AddPiece(new Pawn(false, "Bc2"));
            _board[1][3, 1].AddPiece(new Pawn(false, "Bd2"));
            _board[1][4, 1].AddPiece(new Pawn(false, "Be2"));
            _board[0][4, 0].AddPiece(new Rook(false, "Ae1"));
            _board[0][0, 0].AddPiece(new Rook(false, "Aa1"));
            _board[0][3, 0].AddPiece(new Knight(false, "Ab1"));
            _board[0][1, 0].AddPiece(new Knight(false, "Ad1"));
            _board[1][3, 0].AddPiece(new Bishop(false, "Bd1"));
            _board[1][0, 0].AddPiece(new Bishop(false, "Ba1"));
            _board[1][4, 0].AddPiece(new Unicorn(false, "Be1"));
            _board[1][1, 0].AddPiece(new Unicorn(false, "Bb1"));
            _board[1][2, 0].AddPiece(new Queen(false, "Bc1"));


            _board[4][0, 3].AddPiece(new Pawn(true, "Ea4"));
            _board[4][1, 3].AddPiece(new Pawn(true, "Eb4"));
            _board[4][2, 3].AddPiece(new Pawn(true, "Ec4"));
            _board[4][3, 3].AddPiece(new Pawn(true, "Ed4"));
            _board[4][4, 3].AddPiece(new Pawn(true, "Ee4"));
            _board[3][0, 3].AddPiece(new Pawn(true, "Da4"));
            _board[3][1, 3].AddPiece(new Pawn(true, "Db4"));
            _board[3][2, 3].AddPiece(new Pawn(true, "Dc4"));
            _board[3][3, 3].AddPiece(new Pawn(true, "Dd4"));
            _board[3][4, 3].AddPiece(new Pawn(true, "De4"));
            _board[4][0, 4].AddPiece(new Rook(true, "Ea5"));
            _board[4][4, 4].AddPiece(new Rook(true, "Ee5"));
            _board[4][1, 4].AddPiece(new Knight(true, "Eb5"));
            _board[4][3, 4].AddPiece(new Knight(true, "Ed5"));
            _board[3][3, 4].AddPiece(new Bishop(true, "Dd5"));
            _board[3][0, 4].AddPiece(new Bishop(true, "Da5"));
            _board[3][1, 4].AddPiece(new Unicorn(true, "Db5"));
            _board[3][4, 4].AddPiece(new Unicorn(true, "De5"));
            _board[3][2, 4].AddPiece(new Queen(true, "Dc5"));
        }

        public void MovePiece(string cellName1, string cellName2)
        {
            var cell1 = _board[GetBoardNumber(cellName1)][GetCellRow(cellName1), GetCellCol(cellName1)];
            var cell2 = _board[GetBoardNumber(cellName2)][GetCellRow(cellName2), GetCellCol(cellName2)];
            var temp = cell1.GetPiece();
            if (temp == null) return;
            cell1.AddPiece(null);
            cell2.AddPiece(temp);
        }

        public Cell GetNeighborCell(Cell currentCell, CellNeighbor neighbor)
        {
            Cell nCell = null;
            try
            {
                switch (neighbor)
                {
                    case CellNeighbor.Backward:
                        nCell = _board[GetBoardNumber(currentCell.GetName())][GetCellRow(currentCell.GetName()), GetCellCol(currentCell.GetName()) - 1];
                        break;
                    case CellNeighbor.Forward:
                        nCell = _board[GetBoardNumber(currentCell.GetName())][GetCellRow(currentCell.GetName()), GetCellCol(currentCell.GetName()) + 1];
                        break;
                    case CellNeighbor.Up:
                        nCell = _board[GetBoardNumber(currentCell.GetName()) - 1][GetCellRow(currentCell.GetName()), GetCellCol(currentCell.GetName())];
                        break;
                    case CellNeighbor.Down:
                        nCell = _board[GetBoardNumber(currentCell.GetName()) + 1][GetCellRow(currentCell.GetName()), GetCellCol(currentCell.GetName())];
                        break;
                    case CellNeighbor.Left:
                        nCell = _board[GetBoardNumber(currentCell.GetName())][GetCellRow(currentCell.GetName()) - 1, GetCellCol(currentCell.GetName())];
                        break;
                    case CellNeighbor.Right:
                        nCell = _board[GetBoardNumber(currentCell.GetName())][GetCellRow(currentCell.GetName()) + 1, GetCellCol(currentCell.GetName())];
                        break;
                }
            }
            catch (Exception)
            {

                return null;
            }


            return nCell;
        }

        public enum CellNeighbor
        {
            Forward,
            Backward,
            Left,
            Right,
            Up,
            Down
        }

        public int GetCellRow(string cellName)
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

        public int GetCellCol(string cellName)
        {
            var col = Convert.ToInt32(cellName.Substring(2, 1)) - 1;
            return col;
        }
        public int GetBoardNumber(string cellName)
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

        public Cell GetCell(string cellName)
        {
            return _board[GetBoardNumber(cellName)][GetCellRow(cellName), GetCellCol(cellName)];
        }

        public bool IsSameOrOpposite(CellNeighbor direction1, CellNeighbor direction2)
        {
            if (direction1 == direction2) return true;
            switch (direction1)
            {
                case CellNeighbor.Backward:
                    return direction2 == CellNeighbor.Forward;
                case CellNeighbor.Forward:
                    return direction2 == CellNeighbor.Backward;
                case CellNeighbor.Up:
                    return direction2 == CellNeighbor.Down;
                case CellNeighbor.Down:
                    return direction2 == CellNeighbor.Up;
                case CellNeighbor.Left:
                    return direction2 == CellNeighbor.Right;
            }
            return direction2 == CellNeighbor.Left;
        }
    }
}
