using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{
    
    public class Unicorn: Piece
    {

        private Board.CellNeighbor[,] _directions = new[,] 
            { 
                { Board.CellNeighbor.Right, Board.CellNeighbor.Forward},
                { Board.CellNeighbor.Right, Board.CellNeighbor.Backward},
                { Board.CellNeighbor.Left, Board.CellNeighbor.Forward},
                { Board.CellNeighbor.Left, Board.CellNeighbor.Backward}
            };
        private List<Board.CellNeighbor> smallList = new List<Board.CellNeighbor>{Board.CellNeighbor.Up,Board.CellNeighbor.Down};

        public readonly Image BlackUnicorn = global::RaumschachForm.Properties.Resources.UnicornB;
        public readonly Image WhiteUnicorn = global::RaumschachForm.Properties.Resources.UnicornW; 

        public Unicorn(bool white, string currentPos)
        {
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetBasicMoves(Board board)
        {
            var moves = new List<string>();

            foreach (var mainDirc in smallList)
            {

                for (var i = 0; i < (_directions.Length) / 2; i++)
                {
                    var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), mainDirc);
                    currentCell = board.GetNeighborCell(currentCell, _directions[i, 0]);
                    currentCell = board.GetNeighborCell(currentCell, _directions[i, 1]);


                    while (currentCell != null &&
                           (currentCell.GetPiece() == null || currentCell.GetPiece().White != White))
                    {
                        moves.Add(currentCell.GetName());
                        if (currentCell.HasPiece()) break;
                        currentCell = board.GetNeighborCell(currentCell, mainDirc);
                        currentCell = board.GetNeighborCell(currentCell, _directions[i, 0]);
                        currentCell = board.GetNeighborCell(currentCell, _directions[i, 1]);
                    }
                }
            }
            return moves;
        }

        public override List<string> GetMoves(Board board)
        {
            

            return validMoves(this.GetBasicMoves(board), board);
        }

        public override Image GetImage()
        {
            return White ? WhiteUnicorn : BlackUnicorn;
        }
    }
}
