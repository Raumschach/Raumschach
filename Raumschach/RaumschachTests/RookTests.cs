using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestFixture]
    public class RookTests
    {
        private Board _board;

        [SetUp]
        public void TestSetup()
        {
            _board = new Board();
        }
        [Test]
        public void TestNewRook()
        {
            var target = new Rook(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.White);
        }
        [Test]
        public void TestPieceGetMoves()
        {
            var target = new Rook(true, "Cc3");
            var movesList = new List<String> { "Cc4", "Cc5", "Cc2", "Cc1", "Cb3", "Ca3", "Cd3", "Ce3", "Bc3", "Ac3","Dc3","Ec3" };
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
        [Test]
        public void TestPieceGetMovesWithObstructionBlack()
        {
            var target = new Rook(true, "Cc3");
            _board.GetCell("Cb3").AddPiece(new Pawn(true, "Cb3"));
            var movesList = new List<String> { "Cc4", "Cc5", "Cc2", "Cc1", "Cd3", "Ce3", "Bc3", "Ac3", "Dc3", "Ec3" };
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
        [Test]
        public void TestPieceGetMovesWithObstructionWhite()
        {
            var target = new Rook(true, "Cc3");
            _board.GetCell("Cb3").AddPiece(new Pawn(false, "Cb3"));
            var movesList = new List<String> { "Cc4", "Cc5", "Cc2", "Cc1", "Cb3", "Cd3", "Ce3", "Bc3", "Ac3", "Dc3", "Ec3" };
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }

    }
}
