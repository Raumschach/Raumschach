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

        public Rook(bool white, string currentPos)
        {
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetMoves(Board board)
        {
            var moves = new List<string>();

            foreach (var direction in Enum.GetValues(typeof(Board.CellNeighbor)))
            {
                var blah = (Board.CellNeighbor) direction;
                var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), blah);

                while (currentCell != null && (currentCell.GetPiece() == null || currentCell.GetPiece().White != White))
                {
                    moves.Add(currentCell.GetName());
                    if (currentCell.HasPiece()) break;
                    currentCell = board.GetNeighborCell(currentCell, (Board.CellNeighbor)direction);
                }
            }

            return moves;
        }

        public override Image GetImage()
        {
            return White ? WhiteRook : BlackRook;
        }
    }
}
