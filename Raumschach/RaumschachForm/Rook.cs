using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{
    public class Rook : Piece
    {
        public readonly Image BlackRook = global::RaumschachForm.Properties.Resources.RookB;
        public readonly Image WhiteRook = global::RaumschachForm.Properties.Resources.RookW;

        public Rook(bool white, string currentPos)
        {
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetBasicMoves(Board board)
        {

            var moves = new List<string>();

            foreach (var direction in Enum.GetValues(typeof(Board.CellNeighbor)))
            {
                var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), (Board.CellNeighbor)direction);

                while (currentCell != null && (currentCell.GetPiece() == null || currentCell.GetPiece().White != White))
                {
                    moves.Add(currentCell.GetName());
                    if (currentCell.HasPiece()) break;
                    currentCell = board.GetNeighborCell(currentCell, (Board.CellNeighbor)direction);
                }
            }
            return moves;
        }

        public override List<string> GetMoves(Board board)
        {
            return validMoves(GetBasicMoves(board), board);
        }

        public override Image GetImage()
        {
            return White ? WhiteRook : BlackRook;
        }
    }
}
