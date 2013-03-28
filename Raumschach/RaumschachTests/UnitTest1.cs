using System;
using NUnit.Framework;
using System.Windows.Forms;
using RaumschachForm;
using System.Collections.Generic;

namespace RaumschachTests
{
    [TestFixture()]
    public class UnitTest1
    {
        [Test()]
        public void testNewBoard(){
            var target = new RaumschachForm.Board();
            var cell = new RaumschachForm.Cell("Aa1");
            cell.addPiece(new Pawn(true, cell.getName()));
            var boardCell = target._board[0][0, 0];
            Assert.IsTrue(cell.getPiece().Equals( boardCell.getPiece()));
            
        }
        [Test()]
        public void movePieceToEmpty()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Aa2");
            Assert.IsNull(target._board[0][0, 0].getPiece());
            Assert.IsTrue(new Pawn(true, "Aa2").Equals(target._board[0][0, 1].getPiece()));
        }
        [Test()]
        public void movePieceFromNullToNull()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa3", "Aa2");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals(target._board[0][0, 0].getPiece()));
            Assert.IsNull(target._board[0][0, 1].getPiece());
            Assert.IsNull(target._board[0][0, 2].getPiece());
        }
        [Test()]
        public void movePieceFromNullToPiece()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa2", "Aa1");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals( target._board[0][0, 0].getPiece()));
            Assert.IsNull(target._board[0][0, 1].getPiece());
        }
        [Test()]
        public void movePieceToItself()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Aa1");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals( target._board[0][0, 0].getPiece()));
        }
        [Test()]
        public void movePieceToPiece()
        {
            var target = new RaumschachForm.Board();
            target.movePiece("Aa1", "Ab1");
            Assert.IsNull(target._board[0][0, 0].getPiece());
            Assert.IsTrue(new Pawn(true, "Ab1").Equals(target._board[0][1, 0].getPiece()));

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
           var target = new RaumschachForm.Pawn(true, "Ee4");
           var board = new RaumschachForm.Board();
            var tempList = new List<String>();
           tempList.Add("De4");
            tempList.Add("Ee3");            
            Assert.AreEqual(tempList, target.getmoves(board));
           

        }
        [Test()]
        public void TestwhitePawnTakeUpRight()
        {
            var target = new RaumschachForm.Pawn(true, "Dc4");
            var board = new RaumschachForm.Board();
            board.getCell("Cb4").addPiece(new Pawn(false, "Cb4"));
            var tempList = new List<String>();
            tempList.Add("Cc4");
            tempList.Add("Dc3");
            tempList.Add("Cb4");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestwhitePawnTakeUpLeft()
        {
            var target = new RaumschachForm.Pawn(true, "Dc4");
            var board = new RaumschachForm.Board();
            board.getCell("Cd4").addPiece(new Pawn(false, "Cd4"));
            var tempList = new List<String>();
            tempList.Add("Cc4");
            tempList.Add("Dc3");
            tempList.Add("Cd4");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestwhitePawnTakeForwardRight()
        {
            var target = new RaumschachForm.Pawn(true, "Dc4");
            var board = new RaumschachForm.Board();
            board.getCell("Db3").addPiece(new Pawn(false, "Db3"));
            var tempList = new List<String>();
            tempList.Add("Cc4");
            tempList.Add("Dc3");
            tempList.Add("Db3");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestwhitePawnTakeForwardLeft()
        {
            var target = new RaumschachForm.Pawn(true, "Dc4");
            var board = new RaumschachForm.Board();
            board.getCell("Dd3").addPiece(new Pawn(false, "Dd3"));
            var tempList = new List<String>();
            tempList.Add("Cc4");
            tempList.Add("Dc3");
            tempList.Add("Dd3");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestBlackPawnGetMoves()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            var tempList = new List<String>();
            tempList.Add("Cd2");
            tempList.Add("Bd3");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestBlackPawnTakeDownRight()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            board.getCell("Ce2").addPiece(new Pawn(true, "Ce2"));
            var tempList = new List<String>();
            tempList.Add("Cd2");
            tempList.Add("Bd3");
            tempList.Add("Ce2");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TesBlackPawnTakeDownLeft()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            board.getCell("Cc2").addPiece(new Pawn(true, "Cc2"));
            var tempList = new List<String>();
            tempList.Add("Cd2");
            tempList.Add("Bd3");
            tempList.Add("Cc2");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestBlackPawnTakeForwardRight()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            board.getCell("Be3").addPiece(new Pawn(true, "Be3"));
            var tempList = new List<String>();
            tempList.Add("Cd2");
            tempList.Add("Bd3");
            tempList.Add("Be3");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestBlackPawnTakeForwardLeft()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            board.getCell("Bc3").addPiece(new Pawn(true, "Bc3"));
            var tempList = new List<String>();
            tempList.Add("Cd2");
            tempList.Add("Bd3");
            tempList.Add("Bc3");
            Assert.AreEqual(tempList, target.getmoves(board));
        }
    }
}