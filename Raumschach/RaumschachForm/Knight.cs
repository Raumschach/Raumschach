using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{
    //It's not the piece Gotham wants, it's the piece Gotham need
    //It's the Dark Knight
    public class Knight: Piece
    {
        public readonly Image BlackKnight = global::RaumschachForm.Properties.Resources.KnightB; //Bruce Wayne
        public readonly Image WhiteKnight = global::RaumschachForm.Properties.Resources.KnightW; //Harvey Two Face


        public Knight(bool white, string currentPos)
        {
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetBasicMoves(Board board)
        {
             var moves = new List<string>();

            foreach (var mainDirc in Enum.GetValues(typeof(Board.CellNeighbor)))
            {
                var mainCell = board.GetNeighborCell(board.GetCell(CurrentPos), (Board.CellNeighbor)mainDirc);
                if (mainCell == null) continue;
                mainCell = board.GetNeighborCell(mainCell, (Board.CellNeighbor)mainDirc);
                if (mainCell == null) continue;
                foreach(var secondaryDirc in Enum.GetValues(typeof(Board.CellNeighbor)))
                {
                    var checkCell = board.GetNeighborCell(mainCell, (Board.CellNeighbor)secondaryDirc);

                    if (board.IsSameOrOpposite((Board.CellNeighbor)mainDirc, (Board.CellNeighbor)secondaryDirc) ||
                        checkCell == null || (checkCell.GetPiece() != null && checkCell.GetPiece().White == this.White)) continue;
                    moves.Add(checkCell.GetName());

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
            return White ? WhiteKnight : BlackKnight;
        }
    }
}
