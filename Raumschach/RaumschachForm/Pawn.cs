using System;
using System.Collections.Generic;
using System.Drawing;

namespace RaumschachForm
{
    public class Pawn : Piece
    {
        public readonly Image BlackPawn = Image.FromFile
            (Environment.CurrentDirectory + @"\Images\PawnB.png");

        public readonly Image WhitePawn = Image.FromFile
            (Environment.CurrentDirectory + @"\Images\PawnW.png");

        public Pawn(bool white, string currentPos)
        {
            //var filePath = Environment.CurrentDirectory;
            //var strArray = new string[] {"\\Raumschach\\Raumschach"};
            //filePath = filePath.Split(strArray,StringSplitOptions.None)[0];
            //BlackPawn = Image.FromFile(filePath + "\\Raumschach\\Raumschach\\RaumschachForm\\bin\\Debug\\Images\\PawnB.png");
            //WhitePawn = Image.FromFile(filePath + "\\Raumschach\\Raumschach\\RaumschachForm\\bin\\Debug\\Images\\PawnW.png");

            White = white;
            CurrentPos = currentPos;
        }

        public override List<string> Getmoves(Board board)
        {
            var boardNum = board.GetBoardNumber(CurrentPos);
            var rowNum = board.GetCellRow(CurrentPos);
            var colNum = board.GetCellCol(CurrentPos);
            var moves = new List<String>();

            //Black Moves
            if (!White && boardNum < 4 && !board._board[boardNum + 1][rowNum, colNum].HasPiece())
            {
                moves.Add(board._board[boardNum + 1][rowNum, colNum].GetName());
            }
            if (!White && colNum < 4 && !board._board[boardNum][rowNum, colNum + 1].HasPiece())
            {
                moves.Add(board._board[boardNum][rowNum, colNum + 1].GetName());
            }
            //Take Down and right
            if (!White && boardNum < 4 && rowNum < 4 && board._board[boardNum + 1][rowNum + 1, colNum].HasPiece() &&
                board._board[boardNum + 1][rowNum + 1, colNum].GetPiece().White)
            {
                moves.Add(board._board[boardNum + 1][rowNum + 1, colNum].GetName());
            }
            //Take Up and left
            if (!White && boardNum < 4 && rowNum > 0 && board._board[boardNum + 1][rowNum - 1, colNum].HasPiece() &&
                board._board[boardNum + 1][rowNum - 1, colNum].GetPiece().White)
            {
                moves.Add(board._board[boardNum + 1][rowNum - 1, colNum].GetName());
            }
            //Take foward and Right
            if (!White && rowNum < 4 && colNum < 4 && board._board[boardNum][rowNum + 1, colNum + 1].HasPiece() &&
                board._board[boardNum][rowNum + 1, colNum + 1].GetPiece().White)
            {
                moves.Add(board._board[boardNum][rowNum + 1, colNum + 1].GetName());
            }
            //Take foward and Left
            if (!White && rowNum > 0 && colNum < 4 && board._board[boardNum][rowNum - 1, colNum + 1].HasPiece() &&
                board._board[boardNum][rowNum - 1, colNum + 1].GetPiece().White)
            {
                moves.Add(board._board[boardNum][rowNum - 1, colNum + 1]
                              .GetName());
            }

            //White Moves
            if (White && boardNum > 0 && !board._board[boardNum - 1][rowNum, colNum].HasPiece())
            {
                moves.Add(board._board[boardNum - 1][rowNum, colNum].GetName());
            }
            if (White && colNum > 0 && !board._board[boardNum][rowNum, colNum - 1].HasPiece())
            {
                moves.Add(board._board[boardNum][rowNum, colNum - 1].GetName());
            }
            //Take Up and right
            if (White && boardNum > 0 && rowNum > 0 && board._board[boardNum - 1][rowNum - 1, colNum].HasPiece() &&
                !board._board[boardNum - 1][rowNum - 1, colNum].GetPiece().White)
            {
                moves.Add(board._board[boardNum - 1][rowNum - 1, colNum].GetName());
            }
            //Take Up and left
            if (White && boardNum > 0 && rowNum < 4 && board._board[boardNum - 1][rowNum + 1, colNum].HasPiece() &&
                !board._board[boardNum - 1][rowNum + 1, colNum].GetPiece().White)
            {
                moves.Add(board._board[boardNum - 1][rowNum + 1, colNum].GetName());
            }
            //Take foward and Right
            if (White && rowNum > 0 && colNum > 0 && board._board[boardNum][rowNum - 1, colNum - 1].HasPiece() &&
                !board._board[boardNum][rowNum - 1, colNum - 1].GetPiece().White)
            {
                moves.Add(board._board[boardNum][rowNum - 1, colNum - 1].GetName());
            }
            //Take foward and Left
            if (White && rowNum < 4 && colNum > 0 && board._board[boardNum][rowNum + 1, colNum - 1].HasPiece() &&
                !board._board[boardNum][rowNum + 1, colNum - 1].GetPiece().White)
            {
                moves.Add(board._board[boardNum][rowNum + 1, colNum - 1].GetName());
            }
            return moves;

        }

        public override Image GetImage()
        {
            return White ? WhitePawn : BlackPawn;
        }
    }
}
