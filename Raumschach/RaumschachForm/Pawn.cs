using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace RaumschachForm
{
     public class Pawn:Piece
    {
   //     private Image blackPawn = Image.FromFile
   //(Environment.CurrentDirectory + @"\Images\PawnB.png");
   //     private Image whitePawn = Image.FromFile
   //(Environment.CurrentDirectory + @"\Images\PawnW.png");

        public Pawn(bool white, string currentPos){
            base.white = white;
            base.currentPos = currentPos;
    }
         public override List<string> getmoves(Board board){
             var boardNum = board.getBoard(base.currentPos);
             var rowNum = board.getCellRow(base.currentPos);
             var colNum = board.getCellCol(base.currentPos);
             var moves = new List<String>();

             //Black Moves
             if (!white && boardNum < 4 && !board._board[boardNum + 1][rowNum, colNum].hasPiece())
             {
                 moves.Add(board._board[boardNum + 1][rowNum, colNum].getName());
             }
             if (!white && colNum < 4 && !board._board[boardNum][rowNum, colNum + 1].hasPiece())
             {
                 moves.Add(board._board[boardNum][rowNum, colNum + 1].getName());
             }
             //Take Down and right
             if (!white && boardNum < 4 && rowNum < 4 && board._board[boardNum + 1][rowNum + 1, colNum].hasPiece() && board._board[boardNum + 1][rowNum + 1, colNum].getPiece().white)
             {
                 moves.Add(board._board[boardNum + 1][rowNum + 1, colNum].getName());
             }
             //Take Up and left
             if (!white && boardNum < 4 && rowNum > 0 && board._board[boardNum + 1][rowNum - 1, colNum].hasPiece() && board._board[boardNum + 1][rowNum - 1, colNum].getPiece().white)
             {
                 moves.Add(board._board[boardNum + 1][rowNum - 1, colNum].getName());
             }
             //Take foward and Right
             if (!white && rowNum < 4 && colNum < 4 && board._board[boardNum][rowNum + 1, colNum + 1].hasPiece() && board._board[boardNum][rowNum + 1, colNum + 1].getPiece().white)
             {
                 moves.Add(board._board[boardNum][rowNum + 1, colNum + 1].getName());
             }
             //Take foward and Left
             if (!white && rowNum > 0 && colNum < 4 && board._board[boardNum][rowNum - 1, colNum + 1].hasPiece() && board._board[boardNum][rowNum - 1, colNum + 1].getPiece().white)
             {
                 moves.Add(board._board[boardNum][rowNum - 1, colNum + 1]
                     .getName());
             }

             //White Moves
             if (white && boardNum > 0 && !board._board[boardNum - 1][rowNum, colNum].hasPiece())
             {
                 moves.Add(board._board[boardNum - 1][rowNum, colNum].getName());
             }
             if (white && colNum > 0 && !board._board[boardNum][rowNum, colNum - 1].hasPiece())
             {
                 moves.Add(board._board[boardNum][rowNum, colNum - 1].getName());
             }
             //Take Up and right
             if (white && boardNum > 0 && rowNum > 0 && board._board[boardNum - 1][rowNum - 1, colNum].hasPiece() && !board._board[boardNum - 1][rowNum - 1, colNum].getPiece().white)
             {
                 moves.Add(board._board[boardNum - 1][rowNum - 1, colNum].getName());
             }
             //Take Up and left
             if (white && boardNum > 0 && rowNum < 4 && board._board[boardNum - 1][rowNum + 1, colNum].hasPiece() && !board._board[boardNum - 1][rowNum + 1, colNum].getPiece().white)
             {
                 moves.Add(board._board[boardNum - 1][rowNum + 1, colNum].getName());
             }
             //Take foward and Right
             if (white && rowNum > 0 && colNum > 0 && board._board[boardNum][rowNum - 1, colNum - 1].hasPiece() && !board._board[boardNum][rowNum - 1, colNum - 1].getPiece().white)
             {
                 moves.Add(board._board[boardNum][rowNum - 1, colNum - 1].getName());
             }
             //Take foward and Left
             if (white && rowNum < 4 && colNum > 0 && board._board[boardNum][rowNum + 1, colNum - 1].hasPiece() && !board._board[boardNum][rowNum + 1, colNum - 1].getPiece().white)
             {
                 moves.Add(board._board[boardNum][rowNum + 1, colNum - 1].getName());
             }
             return moves;
         }



    }
}
