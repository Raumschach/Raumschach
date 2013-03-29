using System;
using NUnit.Framework;
using System.Windows.Forms;
using RaumschachForm;
using System.Collections.Generic;

namespace RaumschachTests
{
    [TestFixture()]
    public class BoardTests
    {
        [Test()]
        public void TestNewBoard(){
            var target = new RaumschachForm.Board();
            var cell = new RaumschachForm.Cell("Aa1");
            cell.addPiece(new Pawn(true, cell.getName()));
            var boardCell = target._board[0][0, 0];
            Assert.IsTrue(cell.getPiece().Equals( boardCell.getPiece()));
            
        }
        [Test()]
        public void MovePieceToEmpty()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Aa2");
            Assert.IsNull(target._board[0][0, 0].getPiece());
            Assert.IsTrue(new Pawn(true, "Aa2").Equals(target._board[0][0, 1].getPiece()));
        }
        [Test()]
        public void MovePieceFromNullToNull()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa3", "Aa2");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals(target._board[0][0, 0].getPiece()));
            Assert.IsNull(target._board[0][0, 1].getPiece());
            Assert.IsNull(target._board[0][0, 2].getPiece());
        }
        [Test()]
        public void MovePieceFromNullToPiece()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa2", "Aa1");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals( target._board[0][0, 0].getPiece()));
            Assert.IsNull(target._board[0][0, 1].getPiece());
        }
        [Test()]
        public void MovePieceToItself()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Aa1");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals( target._board[0][0, 0].getPiece()));
        }
        [Test()]
        public void MovePieceToPiece()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Ab1");
            Assert.IsNull(target._board[0][0, 0].getPiece());
            Assert.IsTrue(new Pawn(true, "Ab1").Equals(target._board[0][1, 0].getPiece()));

        }
        
    }
}