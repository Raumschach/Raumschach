﻿using NUnit.Framework;
using RaumschachForm;

namespace RaumschachTests
{
    [TestFixture]
    public class BoardTests
    {
        private Board target;
        [SetUp]
        public void addInitialPiece()
        {
            target = new Board();
            target.GetCell("Aa1").AddPiece(new Pawn(true,"Aa1"));
            target._whitePieces.Add(target.GetCell("Aa1").GetPiece());
        }
        [Test]
        public void TestNewBoard(){
            var cell = new Cell("Aa1");
            cell.AddPiece(new Pawn(true, cell.GetName()));
            var boardCell = target._board[0][0, 0];
            Assert.IsTrue(cell.GetPiece().Equals( boardCell.GetPiece()));
            
        }
        [Test]
        public void MovePieceToEmpty()
        {
            target.MovePiece("Aa1", "Aa2");
            Assert.IsNull(target._board[0][0, 0].GetPiece());
            Assert.IsTrue(new Pawn(true, "Aa2").Equals(target._board[0][0, 1].GetPiece()));
        }
        [Test]
        public void MovePieceFromNullToNull()
        {
            target.MovePiece("Aa3", "Aa2");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals(target._board[0][0, 0].GetPiece()));
            Assert.IsNull(target._board[0][0, 1].GetPiece());
            Assert.IsNull(target._board[0][0, 2].GetPiece());
        }
        [Test]
        public void MovePieceFromNullToPiece()
        {
            target.MovePiece("Aa2", "Aa1");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals( target._board[0][0, 0].GetPiece()));
            Assert.IsNull(target._board[0][0, 1].GetPiece());
        }
        [Test]
        public void MovePieceToItself()
        {
            target.MovePiece("Aa1", "Aa1");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals( target._board[0][0, 0].GetPiece()));
        }
        [Test]
        public void MovePieceToPiece()
        {
            target.GetCell("Ab1").AddPiece(new Pawn(false, "Ab1"));
            target._blackPieces.Add(target.GetCell("Ab1").GetPiece());
            target.MovePiece("Aa1", "Ab1");
            Assert.IsNull(target._board[0][0, 0].GetPiece());
            Assert.IsTrue(new Pawn(true, "Ab1").Equals(target._board[0][1, 0].GetPiece()));
            Assert.IsFalse(target._blackPieces.Contains(new Pawn(false, "Ab1")));
            Assert.IsTrue(target._whitePieces[0].CurrentPos.Equals("Ab1"));

           
        }
        [Test]
        public void TestGetNeighborCell()
        {
            Assert.AreEqual(new Cell("Cc2"), target.GetNeighborCell(new Cell("Cc3"), Board.CellNeighbor.Backward));
            Assert.AreEqual(new Cell("Cc4"), target.GetNeighborCell(new Cell("Cc3"), Board.CellNeighbor.Forward));
            Assert.AreEqual(new Cell("Bc3"), target.GetNeighborCell(new Cell("Cc3"), Board.CellNeighbor.Up));
            Assert.AreEqual(new Cell("Dc3"), target.GetNeighborCell(new Cell("Cc3"), Board.CellNeighbor.Down));
            Assert.AreEqual(new Cell("Cb3"), target.GetNeighborCell(new Cell("Cc3"), Board.CellNeighbor.Left));
            Assert.AreEqual(new Cell("Cd3"), target.GetNeighborCell(new Cell("Cc3"), Board.CellNeighbor.Right));
        }
        [Test]
        public void TestIsSameOrOpposite()
        {
            Assert.IsFalse(target.IsSameOrOpposite(Board.CellNeighbor.Down, Board.CellNeighbor.Forward));
            Assert.IsFalse(target.IsSameOrOpposite(Board.CellNeighbor.Backward, Board.CellNeighbor.Down));
            Assert.IsTrue(target.IsSameOrOpposite(Board.CellNeighbor.Forward, Board.CellNeighbor.Forward));
            Assert.IsTrue(target.IsSameOrOpposite(Board.CellNeighbor.Forward, Board.CellNeighbor.Backward));
            Assert.IsTrue(target.IsSameOrOpposite(Board.CellNeighbor.Up, Board.CellNeighbor.Down));
            Assert.IsTrue(target.IsSameOrOpposite(Board.CellNeighbor.Left, Board.CellNeighbor.Right));
            Assert.IsTrue(target.IsSameOrOpposite(Board.CellNeighbor.Right, Board.CellNeighbor.Left));
        }
        
    }
}