﻿#define MYTEST
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RaumschachForm
{
    public class King : Piece
    {
        public List<string> movesList;
        public bool movesSet = false;
        

        private Board.CellNeighbor[,] _directions = new[,] 
            { 
                { Board.CellNeighbor.Forward, Board.CellNeighbor.Right},
                { Board.CellNeighbor.Forward, Board.CellNeighbor.Left},                
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Right},
                { Board.CellNeighbor.Backward, Board.CellNeighbor.Left}

            };
        private List<Board.CellNeighbor> smallList = new List<Board.CellNeighbor>{Board.CellNeighbor.Up,Board.CellNeighbor.Down};
        #if (MYTEST)
                public readonly Image BlackKing = Image.FromFile
                    (Environment.CurrentDirectory + @"\Images\KingB.png");

                public readonly Image WhiteKing = Image.FromFile(Environment.CurrentDirectory + @"\Images\KingW.png");
        #endif
        #if (!MYTEST)
                public readonly Image BlackKing;
                public readonly Image WhiteKing;
        #endif
        public King(bool white, string currentPos)
        {
            #if (!MYTEST)
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
            if (movesSet) return movesList;
            var moves = GetBasicMoves(board);
            return validMoves(moves, board);

        }

        public override List<string> GetBasicMoves(Board board)
        {
            var moves = new List<String>();
            foreach (var direction in Enum.GetValues(typeof(Board.CellNeighbor)))
            {
                var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), (Board.CellNeighbor)direction);
                if (currentCell != null && (!currentCell.HasPiece() || (currentCell.HasPiece() && currentCell.GetPiece().White != this.White)))
                {
                    moves.Add(currentCell.GetName());
                }

                if (!smallList.Contains((Board.CellNeighbor)direction))
                {
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
                var currentCell = board.GetNeighborCell(board.GetCell(CurrentPos), _directions[i, 0]);
                currentCell = board.GetNeighborCell(currentCell, _directions[i, 1]);
                if (currentCell != null && (!currentCell.HasPiece() || (currentCell.HasPiece() && currentCell.GetPiece().White != this.White)))
                {
                    moves.Add(currentCell.GetName());
                }

                foreach (var dirc in smallList)
                {
                    var tempCell = board.GetNeighborCell(currentCell, dirc);
                    if (tempCell != null && (!tempCell.HasPiece() || (tempCell.HasPiece() && tempCell.GetPiece().White != this.White)))
                    {
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
        public List<string> IsCheck(List<string> moves, Board board)
        {
            //var pieces = White ? board._blackPieces : board._whitePieces;
            var pieces = new List<Piece>();
            pieces.AddRange(White ? board._blackPieces : board._whitePieces);
            List<Piece> origPieces = new List<Piece>();
            List<Cell> origCells = new List<Cell>();
            foreach (var piece in pieces)
            {
                List<string> piecemoves;
                 piecemoves = piece.GetBasicMoves(board);
                if (piece.GetType() == typeof(Pawn))
                {                    
                    foreach (var mv in moves)
                    {
                        origPieces.Add(board.GetCell(mv).GetPiece());
                        origCells.Add(board.GetCell(mv));
                        board.GetCell(mv).AddPiece(new Pawn(White, mv));
                    }
                    piecemoves.AddRange(piece.GetMoves(board));
                }
               
                foreach (var move in piecemoves)
                {
                    moves.Remove(move);
                }

                for(var i = 0; i< origCells.Count; i++){
                    board.GetCell((origCells[i]).GetName()).AddPiece(origPieces[i]);
                }

            }
            return moves;
        }

        public void SetMoves(Board board)
        {
            movesList = new List<string>();
            movesList = GetBasicMoves(board);
            movesList = IsCheck(movesList, board);
            movesSet = true;
        }
    }
}
