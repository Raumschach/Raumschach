#define MYTEST
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RaumschachForm
{
    public class Pawn : Piece
    {
        private Board.CellNeighbor[,] _WhiteDirections = new[,] 
            { 
                { Board.CellNeighbor.Up, Board.CellNeighbor.Up},
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Backward},
                { Board.CellNeighbor.Up, Board.CellNeighbor.Right},
                { Board.CellNeighbor.Up, Board.CellNeighbor.Left},
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Right},
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Left}
            };
        private Board.CellNeighbor[,] _BlackDirections = new[,] 
            { 
                { Board.CellNeighbor.Down, Board.CellNeighbor.Down},
                { Board.CellNeighbor.Forward, Board.CellNeighbor.Forward},
                { Board.CellNeighbor.Down, Board.CellNeighbor.Right},
                { Board.CellNeighbor.Down, Board.CellNeighbor.Left},
                { Board.CellNeighbor.Forward, Board.CellNeighbor.Right},
                { Board.CellNeighbor.Forward, Board.CellNeighbor.Left}
            };
        #if (MYTEST)
                public readonly Image BlackPawn = Image.FromFile
                    (Environment.CurrentDirectory + @"\Images\PawnB.png");

                public readonly Image WhitePawn = Image.FromFile(Environment.CurrentDirectory + @"\Images\PawnW.png");
        #endif
        #if (!MYTEST)
                public readonly Image BlackPawn;
                public readonly Image WhitePawn;
        #endif
        public Pawn(bool white, string currentPos)
        {
        #if (!MYTEST)
                    var folder = Environment.SpecialFolder.MyDocuments;
                    if (folder.ToString().Contains("iversoda"))
                    {
                        BlackPawn = Image.FromFile
                         (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\PawnB.png");
                        WhitePawn = Image.FromFile
                        (@"C:\Users\iversoda\Documents\SQA\Project\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\PawnW.png");
                    }
                    if (folder.ToString().Contains("sternetj"))
                    {
                        BlackPawn = Image.FromFile
                         (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\PawnB.png");
                        WhitePawn = Image.FromFile
                        (@"C:\Users\sternetj\Documents\GitHub\Raumschach\Raumschach\RaumschachForm\bin\Debug\Images\PawnW.png");
                    }
        #endif
            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> GetBasicMoves(Board board)
        {
            var boardNum = board.GetBoardNumber(CurrentPos);
            var rowNum = board.GetCellRow(CurrentPos);
            var colNum = board.GetCellCol(CurrentPos);
            var moves = new List<String>();

            var directions = White ? _WhiteDirections : _BlackDirections;
            for (var i = 0; i < (directions.Length) / 2; i++)
            {
                var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), directions[i, 0]);
                if (directions[i, 0] != directions[i, 1])
                {
                    currentCell = board.GetNeighborCell(currentCell, directions[i, 1]);
                    if (currentCell != null && currentCell.HasPiece() && currentCell.GetPiece().White != this.White)
                    {
                        moves.Add(currentCell.GetName());
                    }
                }
                else
                {
                    if (currentCell != null && !currentCell.HasPiece())
                    {
                        moves.Add(currentCell.GetName());
                    }
                }
            }
            return moves;
        }

        public override List<string> GetMoves(Board board)
        {
           

            return validMoves(this.GetBasicMoves(board),board);

        }
       

        public override Image GetImage()
        {
            return White ? WhitePawn : BlackPawn;
        }
    }
}
