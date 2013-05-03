#define MYTEST
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RaumschachForm
{
    public class King : Piece
    {
        private Board.CellNeighbor[,] _directions = new[,] 
            { 
                { Board.CellNeighbor.Forward, Board.CellNeighbor.Right},
                { Board.CellNeighbor.Forward, Board.CellNeighbor.Left},                
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Right},
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Left}

            };
        private List<Board.CellNeighbor> smallList = new List<Board.CellNeighbor>{Board.CellNeighbor.Up,Board.CellNeighbor.Down};
        #if (DEBUG && MYTEST)
                public readonly Image BlackKing = Image.FromFile
                    (Environment.CurrentDirectory + @"\Images\KingB.png");

                public readonly Image WhiteKing = Image.FromFile(Environment.CurrentDirectory + @"\Images\KingW.png");
        #endif
        #if (DEBUG && !MYTEST)
                public readonly Image BlackKing;
                public readonly Image WhiteKing;
        #endif
        public King(bool white, string currentPos)
        {
            #if (DEBUG && !MYTEST)
                        var folder = Environment.SpecialFolder.MyDocuments;
                        if (folder.ToString().Contains("iversoda"))
                        {
                            BlackKing = Image.FromFile
                             (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KingB.png");
                            WhiteKing = Image.FromFile
                            (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KingW.png");
                        }
                        if (folder.ToString().Contains("sternetj"))
                        {
                            BlackKing = Image.FromFile
                             (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KingB.png");
                            WhiteKing = Image.FromFile
                            (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\KingW.png");
                        }
            #endif

            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetMoves(Board board)
        {
            var boardNum = board.GetBoardNumber(CurrentPos);
            var rowNum = board.GetCellRow(CurrentPos);
            var colNum = board.GetCellCol(CurrentPos);
            var moves = new List<String>();

           foreach (var direction in Enum.GetValues(typeof(Board.CellNeighbor))){
               var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), (Board.CellNeighbor) direction);
               if (currentCell != null && (!currentCell.HasPiece() || (currentCell.HasPiece() && currentCell.GetPiece().White != this.White))){
                   moves.Add(currentCell.GetName());
               }

               if (!smallList.Contains((Board.CellNeighbor) direction)){
                   foreach (var dirc in smallList)
                   {
                       var tempCell = board.GetNeighborCell(currentCell, dirc);
                       if (tempCell != null && (!tempCell.HasPiece() || (tempCell.HasPiece() && tempCell.GetPiece().White != this.White)))
                       {
                           moves.Add(tempCell.GetName());
                       }
                   }
               }
           }

           for (var i = 0; i < (_directions.Length) / 2; i++)
           {
                var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), _directions[i,0]);
                currentCell = board.GetNeighborCell(currentCell, _directions[i, 1]);
                    if (currentCell != null && (!currentCell.HasPiece() || (currentCell.HasPiece() && currentCell.GetPiece().White != this.White))){
                        moves.Add(currentCell.GetName());
                    }

               foreach(var dirc in smallList){
                    var tempCell = board.GetNeighborCell(currentCell, dirc);
                    if (tempCell != null && (!tempCell.HasPiece() || (tempCell.HasPiece() && tempCell.GetPiece().White != this.White))){
                        moves.Add(tempCell.GetName());
                    }
               }
           }


            return moves;

        }

        public override Image GetImage()
        {
            return White ? WhiteKing : BlackKing;
        }
    }
}
