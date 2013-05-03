using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{
    
    public class Unicorn: Piece
    {

        private Board.CellNeighbor[,] _directions = new[,] 
            { 
                { Board.CellNeighbor.Right, Board.CellNeighbor.Forward},
                { Board.CellNeighbor.Right, Board.CellNeighbor.Backward},
                { Board.CellNeighbor.Left, Board.CellNeighbor.Forward},
                { Board.CellNeighbor.Left, Board.CellNeighbor.Backward}
            };
        private List<Board.CellNeighbor> smallList = new List<Board.CellNeighbor>{Board.CellNeighbor.Up,Board.CellNeighbor.Down};


#if (DEBUG && !MYTEST)
        public readonly Image BlackUnicorn = Image.FromFile
            (Environment.CurrentDirectory + @"\Images\UnicornB.png"); 

        public readonly Image WhiteUnicorn = Image.FromFile(Environment.CurrentDirectory + @"\Images\UnicornW.png"); 
        #endif
        #if (DEBUG && MYTEST)
                            public readonly Image BlackUnicorn;
                    public readonly Image WhiteUnicorn;
        #endif

        public Unicorn(bool white, string currentPos)
        {
        #if (DEBUG && MYTEST)
                    var folder = Environment.SpecialFolder.MyDocuments;
                    if (folder.ToString().Contains("iversoda"))
                    {
                        BlackUnicorn = Image.FromFile
                         (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\UnicornB.png");
                        WhiteUnicorn = Image.FromFile
                        (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\UnicornW.png");
                    }
                    if (folder.ToString().Contains("sternetj"))
                    {
                        BlackUnicorn = Image.FromFile
                         (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\UnicornB.png");
                        WhiteUnicorn = Image.FromFile
                        (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\UnicornW.png");
                    }
        #endif
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetMoves(Board board)
        {
            var moves = new List<string>();

            foreach (var mainDirc in smallList)
            {
                
                for (var i = 0; i < (_directions.Length)/2; i++)
                {
                    var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), mainDirc);
                    currentCell = board.GetNeighborCell(currentCell, _directions[i, 0]);
                    currentCell = board.GetNeighborCell(currentCell, _directions[i, 1]);


                    while (currentCell != null &&
                           (currentCell.GetPiece() == null || currentCell.GetPiece().White != White))
                    {
                        moves.Add(currentCell.GetName());
                        if (currentCell.HasPiece()) break;
                        currentCell = board.GetNeighborCell(currentCell, mainDirc);
                        currentCell = board.GetNeighborCell(currentCell, _directions[i, 0]);
                        currentCell = board.GetNeighborCell(currentCell, _directions[i, 1]);
                    }
                }
            }

            return moves;
        }

        public override Image GetImage()
        {
            return White ? WhiteUnicorn : BlackUnicorn;
        }
    }
}
