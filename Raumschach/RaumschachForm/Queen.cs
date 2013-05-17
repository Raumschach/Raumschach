using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{
    
    public class Queen: Piece
    {
        public List<string> movesList;
        public bool movesSet = false;

        public readonly Image BlackQueen = global::RaumschachForm.Properties.Resources.QueenB;
        public readonly Image WhiteQueen = global::RaumschachForm.Properties.Resources.QueenW;


        public Queen(bool white, string currentPos)
        {
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetBasicMoves(Board board)
        {
           var moves = new List<string>();

            moves.AddRange((new Rook(this.White, this.CurrentPos)).GetBasicMoves(board));
            moves.AddRange((new Bishop(this.White, this.CurrentPos)).GetBasicMoves(board));
            moves.AddRange((new Unicorn(this.White, this.CurrentPos)).GetBasicMoves(board));

            return moves;
        }

        public override List<string> GetMoves(Board board)
        {
            if ( movesSet) return movesList;
            SetMoves(board);
            return movesList;
        }

        public void SetMoves(Board board)
        {
            movesList = new List<string>();
            movesList.AddRange((new Rook(this.White, this.CurrentPos)).GetMoves(board));
            movesList.AddRange((new Bishop(this.White, this.CurrentPos)).GetMoves(board));
            movesList.AddRange((new Unicorn(this.White, this.CurrentPos)).GetMoves(board));
            movesSet = true;
        }

        public override Image GetImage()
        {
            return White ? WhiteQueen : BlackQueen;
        }
    }
}
