using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{

    class Rook : Piece
    {
#if (DEBUG && !MYTEST)
        public readonly Image BlackRook = Image.FromFile
            (Environment.CurrentDirectory + @"\Images\RookB.png");

        public readonly Image WhiteRook = Image.FromFile(Environment.CurrentDirectory + @"\Images\RookW.png");
#endif
#if (DEBUG && MYTEST)
                public readonly Image BlackPawn = Image.FromFile
            //(@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\RookB.png");
        (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\RookB.png");
        public readonly Image WhitePawn = Image.FromFile
        //(@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\RookW.png");
        (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\RookW.png");
#endif
        public override List<string> Getmoves(Board board)
        {
            return null;
        }

        public override Image GetImage()
        {
            return White ? WhiteRook : BlackRook;
        }
    }
}
