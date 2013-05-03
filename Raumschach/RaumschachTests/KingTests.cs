using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void TestNewKing()
        {
            var target = new King(true, "test");
            Assert.IsNotNull(target);            
            Assert.IsTrue(target.White);
            target = new King(false, "test");
            Assert.IsNotNull(target);
            Assert.IsFalse(target.White);

        }
        [Test]
        public void TestPieceGetMoves()
        {
           var target = new King(true, "Cc3");
           var board = new Board();
           var tempList = new List<String> { "Cc4", "Bc4", "Dc4", "Cc2", "Bc2", "Dc2", "Cb3", "Bb3", "Db3", "Cd3", "Bd3", "Dd3", "Bc3", "Dc3", "Cd4", "Bd4", "Dd4", "Cb4", "Bb4", "Db4", "Cd2", "Bd2", "Dd2", "Cb2", "Bb2", "Db2" };
            Assert.AreEqual(tempList, target.GetMoves(board));
        }
        [Test]
        public void TestPieceGetMovesWithBlocker()
        {
            var target = new King(true, "Cc3");
            var board = new Board();
            board.GetCell("Cb4").AddPiece(new Pawn(true, "Cb4"));

            var blocky = new King(false, "Aa1");
            board.GetCell("Aa1").AddPiece(blocky);
            board._whitePieces.Add(board.GetCell("Cb4").GetPiece());
            board._blackPieces.Add(board.GetCell("Aa1").GetPiece());

            var tempList = new List<String> { "Cc4", "Bc4", "Dc4", "Cc2", "Bc2", "Dc2", "Cb3", "Bb3", "Db3", "Cd3", "Bd3", "Dd3", "Bc3", "Dc3", "Cd4", "Bd4", "Dd4", "Bb4", "Db4", "Cd2", "Bd2", "Dd2", "Cb2", "Bb2", "Db2" };
            Assert.AreEqual(tempList, target.GetMoves(board));
        }
        [Test]
        public void TestPieceGetMovesWithTakeable()
        {
            var target = new King(true, "Cc3");
            var board = new Board();
            board.GetCell("Cb4").AddPiece(new Pawn(false, "Cb4"));
            board.GetCell("Dc4").AddPiece(new Pawn(false, "Dc4"));
            board.GetCell("Cc4").AddPiece(new Pawn(false, "Cc4"));
            board._blackPieces.Add(board.GetCell("Cb4").GetPiece());
            board._blackPieces.Add(board.GetCell("Dc4").GetPiece());
            board._blackPieces.Add(board.GetCell("Cc4").GetPiece());
            var tempList = new List<String> { "Cc4", "Bc4", "Cc2", "Bc2", "Dc2", "Cb3", "Bb3", "Db3", "Cd3", "Bd3", "Dd3", "Bc3", "Dc3", "Cd4", "Bd4", "Cb4", "Bb4", "Cd2", "Bd2", "Dd2", "Cb2", "Bb2", "Db2" };
            Assert.AreEqual(tempList, target.GetMoves(board));
        }
        [Test]
        public void TestGetImage()
        {
            var target = new King(false, "Bd2");
            var im1 = target.GetImage();
            Assert.AreEqual(target.BlackKing, im1);
            var targetWhite = new King(true, "Bd2");
            var im2 = targetWhite.GetImage();
            Assert.AreEqual(targetWhite.WhiteKing, im2);
        }
        
    }
}
