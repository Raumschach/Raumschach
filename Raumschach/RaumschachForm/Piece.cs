using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (possibleMoves.Count() == 0) return possibleMoves;
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

    public class CheckFormater
    {
        public List<string> moves;
        public Piece piece;
        public string currentPos;

        public CheckFormater(Piece genericPiece, List<string> pieceMoves, string location)
        {
            moves = pieceMoves;
            piece = genericPiece;
            currentPos = location;
        }
    }
}