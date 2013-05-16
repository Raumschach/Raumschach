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
            //My code
            List<CheckFormater> pieces = new List<CheckFormater>();
            List<CheckFormater> checkers = new List<CheckFormater>();
            King king;
            if (White)
            {
                king = (King)board._whitePieces.Find(c => c.GetType() == typeof(King));
                board._blackPieces.ForEach(d => pieces.Add(new CheckFormater(d, d.GetBasicMoves(board),d.CurrentPos)));
            }
            else
            {
                king = (King)board._blackPieces.Find(c => c.GetType() == typeof(King));
                board._whitePieces.ForEach(d => pieces.Add(new CheckFormater(d, d.GetBasicMoves(board),d.CurrentPos)));
            }

            (pieces.Where(f => f.moves.Contains(king.CurrentPos))).ToList().ForEach(g => checkers.Add(new CheckFormater(g.piece, g.moves, g.currentPos)));

            foreach (var mv in possibleMoves)
            {
                var possible = pieces.Where(e => e.moves.Contains(mv) || e.piece.CurrentPos == mv || e.moves.Contains(origin));
                foreach (CheckFormater curPiece in possible)
                {
                    board.MovePiece(this.CurrentPos, mv);
                    var otherPieces = (pieces.Where(f => f.piece != curPiece.piece)).Select(g => g.moves).ToList().SelectMany(h => h).Distinct().ToList();

                    if ((mv != curPiece.currentPos && curPiece.piece.GetBasicMoves(board).Contains(king.CurrentPos)) || otherPieces.Contains(king.CurrentPos))
                    {
                        finalmoves.Add(mv);
                    }
                    board.GetCell(origin).RestorePreviousPiece(board);
                    board.GetCell(mv).RestorePreviousPiece(board);

                }
                if (possible.Count() == 0 && pieces.Select(k => k.moves).ToList().SelectMany(l => l).ToList().Contains(king.CurrentPos))
                {
                    finalmoves.Add(mv);
                }
            }
            finalmoves.ForEach(j => possibleMoves.Remove(j));
            finalmoves = possibleMoves;


            //foreach (var mv in possibleMoves)
            //{
            //    board.MovePiece(this.CurrentPos, mv);
            //    if (White)
            //    {
            //        if (!board.wCheck())
            //        {
            //            finalmoves.Add(mv);
            //        }
            //    }
            //    else
            //    {
            //        if (!board.bCheck())
            //        {
            //            finalmoves.Add(mv);
            //        }

            //    }
            //    board.GetCell(origin).RestorePreviousPiece(board);
            //    board.GetCell(mv).RestorePreviousPiece(board);

            //}
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