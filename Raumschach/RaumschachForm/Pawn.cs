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

             if (!board._board[boardNum + 1][rowNum, colNum].hasPiece())
             {
                 moves.Add(board._board[boardNum + 1][rowNum, colNum].getName());
             }
             if (!board._board[boardNum][rowNum, colNum+1].hasPiece())
             {
                 moves.Add(board._board[boardNum][rowNum, colNum+1].getName());
             }
             return moves;
         }


    }
}
