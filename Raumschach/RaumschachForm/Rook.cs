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
                public readonly Image BlackRook;
        public readonly Image WhiteRook;
#endif

        public Rook(bool white, string currentPos)
        {
            #if (DEBUG && MYTEST)
                        var folder = Environment.SpecialFolder.MyDocuments;
                        if (folder.ToString().Contains("iversoda"))
                        {
                            BlackRook = Image.FromFile
                             (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\RookB.png");
                            WhiteRook = Image.FromFile
                            (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\RookW.png");
                        }
                        if (folder.ToString().Contains("sternetj"))
                        {
                            BlackRook = Image.FromFile
                             (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\RookB.png");
                            WhiteRook = Image.FromFile
                            (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\RookW.png");
                        }
            #endif
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetMoves(Board board)
        {
            var moves = new List<string>();

            foreach (var direction in Enum.GetValues(typeof(Board.CellNeighbor)))
            {
                var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), (Board.CellNeighbor) direction);

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
