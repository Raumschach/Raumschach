using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestFixture]
    public class BishopTest
    {
        private Board _board;

        [SetUp]
        public void TestSetup()
        {
            _board = new Board();
        }
        [Test]
        public void TestNewBishop()
        {
            var target = new Bishop(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.White);
        }
        [Test]
        public void TestGetMovesEmpty()
        {
            var target = new Bishop(true, "Cc3");
            var correct = new List<String> { "Cd4", "Ce5", "Cd2", "Ce1", "Dd3", "Ee3", "Bd3", "Ae3", "Cb4", "Ca5", "Cb2", "Ca1", "Db3", "Ea3", "Bb3", "Aa3", "Bc4", "Ac5", "Dc4", "Ec5", "Bc2", "Ac1", "Dc2", "Ec1"};
            var moves = target.GetMoves(_board);
            Assert.AreEqual(correct,moves);
            
        }
        [Test]
        public void TestGetMovesWithWhitePiece()
        {
            var target = new Bishop(true, "Cc3");
            var blocker = new Pawn(true, "Ae3");
            _board.GetCell("Ae3").AddPiece(blocker);
            var correct = new List<String> { "Cd4", "Ce5", "Cd2", "Ce1", "Dd3", "Ee3", "Bd3", "Cb4", "Ca5", "Cb2", "Ca1", "Db3", "Ea3", "Bb3", "Aa3", "Bc4", "Ac5", "Dc4", "Ec5", "Bc2", "Ac1", "Dc2", "Ec1" };
            var moves = target.GetMoves(_board);
            Assert.AreEqual(correct, moves);

        }
        [Test]
        public void TestGetMovesWithBlackPiece()
        {
            var target = new Bishop(true, "Cc3");
            var blocker = new Pawn(false, "Ae3");
            _board.GetCell("Ae3").AddPiece(blocker);
            var correct = new List<String> { "Cd4", "Ce5", "Cd2", "Ce1", "Dd3", "Ee3", "Bd3", "Ae3", "Cb4", "Ca5", "Cb2", "Ca1", "Db3", "Ea3", "Bb3", "Aa3", "Bc4", "Ac5", "Dc4", "Ec5", "Bc2", "Ac1", "Dc2", "Ec1" };
            var moves = target.GetMoves(_board);
            Assert.AreEqual(correct, moves);

        }
    }
}
