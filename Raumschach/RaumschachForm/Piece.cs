using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RaumschachForm
{
    public abstract class Piece
    {
        public Image MyImage;
        public bool White;
        public string CurrentPos;
        public abstract List<string> GetMoves(Board board);
        public abstract Image GetImage();
        public abstract List<string> GetBasicMoves(Board board);

        public bool Equals(Piece pc)
        {
            return White == pc.White && CurrentPos == pc.CurrentPos && MyImage == pc.MyImage;
        }
        public List<string> validMoves(List<string> possibleMoves, Board board)
        {
            List<string> finalmoves = new List<string>();
            string origin=this.CurrentPos;

            foreach (var mv in possibleMoves)
            {
                board.MovePiece(this.CurrentPos, mv);
                if (White)
                {
                    if (!board.wCheck())
                    {
                        finalmoves.Add(mv);
                    }
                }
                else
                {
                    if (!board.bCheck())
                    {
                        finalmoves.Add(mv);
                    }

                }
                board.GetCell(origin).RestorePreviousPiece(board);
                board.GetCell(mv).RestorePreviousPiece(board);

            }
            return finalmoves;
        }


    }
}