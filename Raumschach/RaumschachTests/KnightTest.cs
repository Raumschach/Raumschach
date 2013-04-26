using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestFixture]
    public class KnightTests
    {
        private Board _board;

        [SetUp]
        public void TestSetup()
        {
            _board = new Board();
        }
        [Test]
        public void TestNewKnight()
        {
            var target = new Knight(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.White);
        }

        [Test]
        public void TestKnightGetMoves()
        {
            var target = new Knight(true, "Cc3");
            var movesList = new List<String> { "Cb5", "Cd5", "Bc5", "Dc5", "Cb1", "Cd1", "Bc1", "Dc1", "Ca4", "Ca2", "Ba3", "Da3", "Ce4", "Ce2", "Be3", "De3", "Ac4", "Ac2", "Ab3", "Ad3", "Ec4", "Ec2", "Eb3", "Ed3"};
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
        [Test]
        public void TestKnightInCorner()
        {
            var target = new Knight(true, "Aa1");
            var movesList = new List<String> { "Ab3", "Ba3", "Ac2", "Bc1", "Ca2", "Cb1"};
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
        [Test]
        public void TestKnightWithBlockingPiece()
        {
            var target = new Knight(true, "Aa1");
            var target2 = new Pawn(true, "Bc1");
            var movesList = new List<String> { "Ab3", "Ba3", "Ac2", "Ca2", "Cb1" };
            _board.GetCell(target2.CurrentPos).AddPiece(target2);
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
        [Test]
        public void TestKnightWithTakeablePiece()
        {
            var target = new Knight(true, "Aa1");
            var target2 = new Pawn(false, "Bc1");
            var movesList = new List<String> { "Ab3", "Ba3", "Ac2", "Bc1", "Ca2", "Cb1" };
            _board.GetCell(target2.CurrentPos).AddPiece(target2);
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
        [Test]
        public void TestKnightWithSomeMoves()
        {
            var target = new Knight(true, "Ab1");
            var movesList = new List<String> { "Aa3", "Ac3", "Bb3", "Ad2", "Bd1","Cb2", "Ca1","Cc1" };
            Assert.AreEqual(movesList, target.GetMoves(_board));
        }
    }
}
