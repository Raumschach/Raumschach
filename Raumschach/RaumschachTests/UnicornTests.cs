using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestFixture]
    public class UnicornTests
    {
        private Board _board;

        [SetUp]
        public void TestSetup()
        {
            _board = new Board();
        }
        [Test]
        public void TestNewUnicorn()
        {
            var target = new Unicorn(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.White);
        }
        [Test]
        public void TestGetMovesEmpty()
        {
            var target = new Unicorn(true, "Cc3");
            var correct = new List<String> { "Bd4", "Ae5", "Bd2", "Ae1", "Bb4", "Aa5", "Bb2", "Aa1", "Dd4", "Ee5", "Dd2", "Ee1", "Db4", "Ea5", "Db2", "Ea1"};
            var moves = target.GetMoves(_board);
            Assert.AreEqual(correct,moves);
            
        }
        [Test]
        public void TestGetMovesWithWhitePiece()
        {
            var target = new Unicorn(true, "Cc3");
            var blocker = new Pawn(true, "Db2");
            _board.GetCell("Db2").AddPiece(blocker);
            var correct = new List<String> { "Bd4", "Ae5", "Bd2", "Ae1", "Bb4", "Aa5", "Bb2", "Aa1", "Dd4", "Ee5", "Dd2", "Ee1", "Db4", "Ea5" };
            var moves = target.GetMoves(_board);
            Assert.AreEqual(correct, moves);

        }
        [Test]
        public void TestGetMovesWithBlackPiece()
        {
            var target = new Unicorn(true, "Cc3");
            var blocker = new Pawn(false, "Db2");
            _board.GetCell("Db2").AddPiece(blocker);
            var correct = new List<String> { "Bd4", "Ae5", "Bd2", "Ae1", "Bb4", "Aa5", "Bb2", "Aa1", "Dd4", "Ee5", "Dd2", "Ee1", "Db4", "Ea5", "Db2" };
            var moves = target.GetMoves(_board);
            Assert.AreEqual(correct, moves);

        }
    }
}
