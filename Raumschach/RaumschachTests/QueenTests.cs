using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestFixture]
    public class QueenTests
    {
        private Board _board;

        [SetUp]
        public void TestSetup()
        {
            _board = new Board();
        }
        [Test]
        public void TestNewQueen()
        {
            var target = new Queen(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.White);
        }
        [Test]
        public void TestPieceGetMoves()
        {
            var target = new Queen(true, "Cc3");
            var movesList = new List<String> { "Cc4", "Cc5", "Cc2", "Cc1", "Cb3", "Ca3", "Cd3", "Ce3", "Bc3", "Ac3", "Dc3", "Ec3", "Cd4", "Ce5", "Cd2", "Ce1", "Dd3", "Ee3", "Bd3", "Ae3", "Cb4", "Ca5", "Cb2", "Ca1", "Db3", "Ea3", "Bb3", "Aa3", "Bc4", "Ac5", "Dc4", "Ec5", "Bc2", "Ac1", "Dc2", "Ec1","Bd4", "Ae5", "Bd2", "Ae1", "Bb4", "Aa5", "Bb2", "Aa1", "Dd4", "Ee5", "Dd2", "Ee1", "Db4", "Ea5", "Db2", "Ea1" };
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
        [Test]
        public void TestPieceGetMovesWithObstructionBlack()
        {
            var target = new Queen(true, "Cc3");
            _board.GetCell("Cb3").AddPiece(new Pawn(true, "Cb3"));
            var movesList = new List<String> { "Cc4", "Cc5", "Cc2", "Cc1", "Cd3", "Ce3", "Bc3", "Ac3", "Dc3", "Ec3", "Cd4", "Ce5", "Cd2", "Ce1", "Dd3", "Ee3", "Bd3", "Ae3", "Cb4", "Ca5", "Cb2", "Ca1", "Db3", "Ea3", "Bb3", "Aa3", "Bc4", "Ac5", "Dc4", "Ec5", "Bc2", "Ac1", "Dc2", "Ec1", "Bd4", "Ae5", "Bd2", "Ae1", "Bb4", "Aa5", "Bb2", "Aa1", "Dd4", "Ee5", "Dd2", "Ee1", "Db4", "Ea5", "Db2", "Ea1" };
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
        [Test]
        public void TestPieceGetMovesWithObstructionWhite()
        {
            var target = new Queen(true, "Cc3");
            _board.GetCell("Cb3").AddPiece(new Pawn(false, "Cb3"));
            var movesList = new List<String> { "Cc4", "Cc5", "Cc2", "Cc1", "Cb3", "Cd3", "Ce3", "Bc3", "Ac3", "Dc3", "Ec3", "Cd4", "Ce5", "Cd2", "Ce1", "Dd3", "Ee3", "Bd3", "Ae3", "Cb4", "Ca5", "Cb2", "Ca1", "Db3", "Ea3", "Bb3", "Aa3", "Bc4", "Ac5", "Dc4", "Ec5", "Bc2", "Ac1", "Dc2", "Ec1", "Bd4", "Ae5", "Bd2", "Ae1", "Bb4", "Aa5", "Bb2", "Aa1", "Dd4", "Ee5", "Dd2", "Ee1", "Db4", "Ea5", "Db2", "Ea1" };
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }

    }
}
