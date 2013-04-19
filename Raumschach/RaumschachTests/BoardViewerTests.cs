using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RaumschachTests
{
    [TestFixture]
    public class BoardViewerTests
    {
        [Test]
        public void TestSendClick()
        {
            var view = new BoardViewer();
            view.Show();
            view.sendClick("Aa1");
            view.Dispose();
        }
        [Test]
        public void TestFixColorsNull()
        {
            var view = new BoardViewer();
            var list = new List<string>();
            list.Add("Fb1");
            view.fixColors(list);
        }
        [Test]
        public void TestMovePiece()
        {
            var view = new BoardViewer();
            view.Show();
            view.sendClick("Ab2");
            view.sendClick("Ab3");
            var cell = view._board.GetCell("Ab3");
            Assert.IsNotNull(cell.GetPiece());
            Assert.IsNull(view._board.GetCell("Ab2").GetPiece());
            view.Dispose();
        }
        [Test]
        public void TestNotMovePiece()
        {
            var view = new BoardViewer();
            view.Show();
            view.sendClick("Ab2");
            view.sendClick("Ab2");
            var cell = view._board.GetCell("Ab3");
            Assert.IsNull(cell.GetPiece());
            Assert.IsNotNull(view._board.GetCell("Ab2").GetPiece());
            view.Dispose();
        }
        [Test]
        public void TestBadtMovePiece()
        {
            var view = new BoardViewer();
            view.Show();
            view.sendClick("Ab2");
            view.sendClick("Eb2");
            var cell = view._board.GetCell("Eb2");
            Assert.IsNull(cell.GetPiece());
            Assert.IsNotNull(view._board.GetCell("Ab2").GetPiece());
            view.Dispose();
        }
    }
}
