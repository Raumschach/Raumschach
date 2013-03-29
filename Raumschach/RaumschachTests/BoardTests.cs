using NUnit.Framework;
using RaumschachForm;

namespace RaumschachTests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void TestNewBoard(){
            var target = new Board();
            var cell = new Cell("Aa1");
            cell.AddPiece(new Pawn(true, cell.GetName()));
            var boardCell = target._board[0][0, 0];
            Assert.IsTrue(cell.GetPiece().Equals( boardCell.GetPiece()));
            
        }
        [Test]
        public void MovePieceToEmpty()
        {
            var target = new Board();
            target.MovePiece("Aa1", "Aa2");
            Assert.IsNull(target._board[0][0, 0].GetPiece());
            Assert.IsTrue(new Pawn(true, "Aa2").Equals(target._board[0][0, 1].GetPiece()));
        }
        [Test]
        public void MovePieceFromNullToNull()
        {
            var target = new Board();
            target.MovePiece("Aa3", "Aa2");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals(target._board[0][0, 0].GetPiece()));
            Assert.IsNull(target._board[0][0, 1].GetPiece());
            Assert.IsNull(target._board[0][0, 2].GetPiece());
        }
        [Test]
        public void MovePieceFromNullToPiece()
        {
            var target = new Board();
            target.MovePiece("Aa2", "Aa1");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals( target._board[0][0, 0].GetPiece()));
            Assert.IsNull(target._board[0][0, 1].GetPiece());
        }
        [Test]
        public void MovePieceToItself()
        {
            var target = new Board();
            target.MovePiece("Aa1", "Aa1");
            Assert.IsTrue(new Pawn(true, "Aa1").Equals( target._board[0][0, 0].GetPiece()));
        }
        [Test]
        public void MovePieceToPiece()
        {
            var target = new Board();
            target.MovePiece("Aa1", "Ab1");
            Assert.IsNull(target._board[0][0, 0].GetPiece());
            Assert.IsTrue(new Pawn(true, "Ab1").Equals(target._board[0][1, 0].GetPiece()));

        }
        
    }
}