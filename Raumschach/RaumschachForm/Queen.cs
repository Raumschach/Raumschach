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


#if (DEBUG && !MYTEST)
        public readonly Image BlackQueen = Image.FromFile
            (Environment.CurrentDirectory + @"\Images\QueenB.png"); 

        public readonly Image WhiteQueen = Image.FromFile(Environment.CurrentDirectory + @"\Images\QueenW.png"); 
        #endif
        #if (DEBUG && MYTEST)
                    public readonly Image BlackPawn = Image.FromFile
                 (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\QueenB.png");
            //(@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\QueenB.png");
            public readonly Image WhitePawn = Image.FromFile
            (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\QueenW.png");
            //(@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\QueenW.png");
        #endif

        public Queen(bool white, string currentPos)
        {
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetMoves(Board board)
        {
            var moves = new List<string>();

            moves.AddRange((new Rook(this.White,this.CurrentPos)).GetMoves(board));
            moves.AddRange((new Bishop(this.White, this.CurrentPos)).GetMoves(board));
            moves.AddRange((new Unicorn(this.White, this.CurrentPos)).GetMoves(board));
            return moves;
        }

        public override Image GetImage()
        {
            return White ? WhiteQueen : BlackQueen;
        }
    }
}
