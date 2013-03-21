using System;
using NUnit.Framework;
using System.Windows.Forms;
using RaumschachForm;

namespace RaumschachTests
{
    [TestFixture()]
    public class UnitTest1
    {
        [Test()]
        public void testNewBoard(){
            var target = new RaumschachForm.Board();
            var cell = new RaumschachForm.Cell("Aa1");
            cell.addPiece("WhitePawn");
            var boardCell = target._board[0, 0];
            Assert.AreEqual(cell.getPiece(), boardCell.getPiece());
            
        }
    }
}