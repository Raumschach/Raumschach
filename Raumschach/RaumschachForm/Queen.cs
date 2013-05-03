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
                    public readonly Image BlackQueen;
            public readonly Image WhiteQueen;
#endif

        public Queen(bool white, string currentPos)
        {
#if (DEBUG && MYTEST)
            var folder = Environment.SpecialFolder.MyDocuments;
            if (folder.ToString().Contains("iversoda"))
            {
                BlackQueen = Image.FromFile
                 (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\QueenB.png");
                WhiteQueen = Image.FromFile
                (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\QueenW.png");
            }
            if (folder.ToString().Contains("sternetj"))
            {
                BlackQueen = Image.FromFile
                 (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\QueenB.png");
                WhiteQueen = Image.FromFile
                (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\QueenW.png");
            }
#endif
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
