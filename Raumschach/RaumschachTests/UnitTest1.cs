using System;
using NUnit.Framework;
using System.Windows.Forms;
using RaumschachForm;

namespace RaumschachTests
{
    [TestFixture()]
    public class UnitTest1
    {
        [Test()]
        public void testNewBoard(){
            var target = new RaumschachForm.Board();
            var cell = new RaumschachForm.Cell("Aa1");
            cell.addPiece("WhitePawn");
            var boardCell = target._board[0, 0];
            Assert.AreEqual(cell.getPiece(), boardCell.getPiece());
            
        }
        [Test()]
        public void movePieceToEmpty()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Aa2");
            Assert.IsNull(target._board[0, 0].getPiece());
            Assert.AreEqual("WhitePawn", target._board[0, 1].getPiece());
        }
        [Test()]
        public void movePieceFromNullToNull()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa3", "Aa2");
            Assert.AreEqual("WhitePawn", target._board[0, 0].getPiece());
            Assert.IsNull(target._board[0, 1].getPiece());
            Assert.IsNull(target._board[0, 2].getPiece());
        }
        [Test()]
        public void movePieceFromNullToPiece()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa2", "Aa1");
            Assert.AreEqual("WhitePawn", target._board[0, 0].getPiece());
            Assert.IsNull(target._board[0, 1].getPiece());
        }
        [Test()]
        public void movePieceToItself()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Aa1");
            Assert.AreEqual("WhitePawn", target._board[0, 0].getPiece());
        }
        [Test()]
        public void movePieceToPiece()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Ab1");
            Assert.IsNull(target._board[0, 0].getPiece());
            Assert.AreEqual("WhitePawn", target._board[1, 0].getPiece());

        }
        [Test()]
        public void TestnewPawn()
        {
            var target = new RaumschachForm.Pawn(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.white);

        }
        [Test()]
        public void TestPiecegetMoves()
        {
           var target = new RaumschachForm.Pawn(true, "Aa2");
            Assert.AreEqual(new List() { "Aa3" }, target.getmoves());
           

        }
    }
}