using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaumschachForm
{
    public class Bishop: Piece
    {

        private Board.CellNeighbor[,] _directions = new[,] 
            { 
                { Board.CellNeighbor.Right, Board.CellNeighbor.Forward},
                { Board.CellNeighbor.Right, Board.CellNeighbor.Backward},
                { Board.CellNeighbor.Right, Board.CellNeighbor.Down},
                { Board.CellNeighbor.Right, Board.CellNeighbor.Up},
                { Board.CellNeighbor.Left, Board.CellNeighbor.Forward},
                { Board.CellNeighbor.Left, Board.CellNeighbor.Backward},
                { Board.CellNeighbor.Left, Board.CellNeighbor.Down},
                { Board.CellNeighbor.Left, Board.CellNeighbor.Up},
                 { Board.CellNeighbor.Forward, Board.CellNeighbor.Up},
                { Board.CellNeighbor.Forward, Board.CellNeighbor.Down},
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Up},
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Down}
            };
        #if (DEBUG && !MYTEST)
                public readonly Image BlackBishop = Image.FromFile
                    (Environment.CurrentDirectory + @"\Images\BishopB.png");

                public readonly Image WhiteBishop = Image.FromFile(Environment.CurrentDirectory + @"\Images\BishopW.png");
        #endif
        #if (DEBUG && MYTEST)
                        public readonly Image BlackBishop;
                public readonly Image WhiteBishop;
        #endif

        public Bishop(bool white, string currentPos)
        {
            #if (DEBUG && MYTEST)
                        var folder = Environment.SpecialFolder.MyDocuments;
                        if (folder.ToString().Contains("iversoda"))
                        {
                            BlackBishop = Image.FromFile
                             (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\BishopB.png");
                            WhiteBishop = Image.FromFile
                            (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\BishopW.png");
                        }
                        if (folder.ToString().Contains("sternetj"))
                        {
                            BlackBishop = Image.FromFile
                             (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\BishopB.png");
                            WhiteBishop = Image.FromFile
                            (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\BishopW.png");
                        }
            #endif

            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetBasicMoves(Board board)
        {
            
            var moves = new List<string>();
            for (var i = 0; i < (_directions.Length)/2; i++)
            {
                
                var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), _directions[i,0]);
                currentCell = board.GetNeighborCell(currentCell, _directions[i, 1]);


                while (currentCell != null && (currentCell.GetPiece() == null || currentCell.GetPiece().White != White))
                {
                    moves.Add(currentCell.GetName());
                    if (currentCell.HasPiece()) break;
                    currentCell = board.GetNeighborCell(currentCell, _directions[i, 0]);
                    currentCell = board.GetNeighborCell(currentCell, _directions[i, 1]);
                }
            }
            return moves;
        }

        public override List<string> GetMoves(Board board)
        {

            return validMoves(this.GetBasicMoves(board), board);
        }

        public override Image GetImage()
        {
            return White ? WhiteBishop : BlackBishop;
        }
    }
}
