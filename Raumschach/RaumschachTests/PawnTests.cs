using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using NUnit.Framework;
using RaumschachForm;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestClass]
    public class PawnTests
    {
             [Test()]
        public void TestnewPawn()
        {
            var target = new Pawn(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.white);

        }
        [Test()]
        public void TestPiecegetMoves()
        {
           var target = new Pawn(true, "Ee4");
           var board = new Board();
            var tempList = new List<String> {"De4", "Ee3"};
            Assert.AreEqual(tempList, target.getmoves(board));
           

        }
        [Test()]
        public void TestwhitePawnTakeUpRight()
        {
            var target = new RaumschachForm.Pawn(true, "Dc4");
            var board = new RaumschachForm.Board();
            board.getCell("Cb4").addPiece(new Pawn(false, "Cb4"));
            var tempList = new List<String> {"Cc4", "Dc3", "Cb4"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestwhitePawnTakeUpLeft()
        {
            var target = new RaumschachForm.Pawn(true, "Dc4");
            var board = new RaumschachForm.Board();
            board.getCell("Cd4").addPiece(new Pawn(false, "Cd4"));
            var tempList = new List<String> {"Cc4", "Dc3", "Cd4"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestwhitePawnTakeForwardRight()
        {
            var target = new RaumschachForm.Pawn(true, "Dc4");
            var board = new RaumschachForm.Board();
            board.getCell("Db3").addPiece(new Pawn(false, "Db3"));
            var tempList = new List<String> {"Cc4", "Dc3", "Db3"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestwhitePawnTakeForwardLeft()
        {
            var target = new RaumschachForm.Pawn(true, "Dc4");
            var board = new RaumschachForm.Board();
            board.getCell("Dd3").addPiece(new Pawn(false, "Dd3"));
            var tempList = new List<String> {"Cc4", "Dc3", "Dd3"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestBlackPawnGetMoves()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            var tempList = new List<String> {"Cd2", "Bd3"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestBlackPawnTakeDownRight()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            board.getCell("Ce2").addPiece(new Pawn(true, "Ce2"));
            var tempList = new List<String> {"Cd2", "Bd3", "Ce2"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TesBlackPawnTakeDownLeft()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            board.getCell("Cc2").addPiece(new Pawn(true, "Cc2"));
            var tempList = new List<String> {"Cd2", "Bd3", "Cc2"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestBlackPawnTakeForwardRight()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            board.getCell("Be3").addPiece(new Pawn(true, "Be3"));
            var tempList = new List<String> {"Cd2", "Bd3", "Be3"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        [Test()]
        public void TestBlackPawnTakeForwardLeft()
        {
            var target = new RaumschachForm.Pawn(false, "Bd2");
            var board = new RaumschachForm.Board();
            board.getCell("Bc3").addPiece(new Pawn(true, "Bc3"));
            var tempList = new List<String> {"Cd2", "Bd3", "Bc3"};
            Assert.AreEqual(tempList, target.getmoves(board));
        }
        
    }
}
