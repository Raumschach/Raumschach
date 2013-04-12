using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestClass]
    public class PawnTests
    {
        [Test]
        public void TestnewPawn()
        {
            var target = new Pawn(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.White);

        }
        [Test]
        public void TestPiecegetMoves()
        {
           var target = new Pawn(true, "Ee4");
           var board = new Board();
            var tempList = new List<String> {"De4", "Ee3"};
            Assert.AreEqual(tempList, target.Getmoves(board));
           

        }
        [Test]
        public void TestwhitePawnTakeUpRight()
        {
            var target = new Pawn(true, "Dc4");
            var board = new Board();
            board.GetCell("Cb4").AddPiece(new Pawn(false, "Cb4"));
            var tempList = new List<String> {"Cc4", "Dc3", "Cb4"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TestwhitePawnTakeUpLeft()
        {
            var target = new Pawn(true, "Dc4");
            var board = new Board();
            board.GetCell("Cd4").AddPiece(new Pawn(false, "Cd4"));
            var tempList = new List<String> {"Cc4", "Dc3", "Cd4"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TestwhitePawnTakeForwardRight()
        {
            var target = new Pawn(true, "Dc4");
            var board = new Board();
            board.GetCell("Db3").AddPiece(new Pawn(false, "Db3"));
            var tempList = new List<String> {"Cc4", "Dc3", "Db3"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TestwhitePawnTakeForwardLeft()
        {
            var target = new Pawn(true, "Dc4");
            var board = new Board();
            board.GetCell("Dd3").AddPiece(new Pawn(false, "Dd3"));
            var tempList = new List<String> {"Cc4", "Dc3", "Dd3"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TestBlackPawnGetMoves()
        {
            var target = new Pawn(false, "Bd2");
            var board = new Board();
            var tempList = new List<String> {"Cd2", "Bd3"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TestBlackPawnTakeDownRight()
        {
            var target = new Pawn(false, "Bd2");
            var board = new Board();
            board.GetCell("Ce2").AddPiece(new Pawn(true, "Ce2"));
            var tempList = new List<String> {"Cd2", "Bd3", "Ce2"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TesBlackPawnTakeDownLeft()
        {
            var target = new Pawn(false, "Bd2");
            var board = new Board();
            board.GetCell("Cc2").AddPiece(new Pawn(true, "Cc2"));
            var tempList = new List<String> {"Cd2", "Bd3", "Cc2"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TestBlackPawnTakeForwardRight()
        {
            var target = new Pawn(false, "Bd2");
            var board = new Board();
            board.GetCell("Be3").AddPiece(new Pawn(true, "Be3"));
            var tempList = new List<String> {"Cd2", "Bd3", "Be3"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TestBlackPawnTakeForwardLeft()
        {
            var target = new Pawn(false, "Bd2");
            var board = new Board();
            board.GetCell("Bc3").AddPiece(new Pawn(true, "Bc3"));
            var tempList = new List<String> {"Cd2", "Bd3", "Bc3"};
            Assert.AreEqual(tempList, target.Getmoves(board));
        }
        [Test]
        public void TestGetImage()
        {
            var target = new Pawn(false, "Bd2");
            var im1 = target.GetImage();
            Assert.AreEqual(target.BlackPawn, im1);
            var targetWhite = new Pawn(true, "Bd2");
            var im2 = targetWhite.GetImage();
            Assert.AreEqual(targetWhite.WhitePawn, im2);
        }
        
    }
}
