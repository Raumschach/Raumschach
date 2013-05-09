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
            //var view = new BoardViewer();
            //System.Threading.Thread.Sleep(1000);
            //view.Show();                  
            //System.Threading.Thread.Sleep(1000);
            //view.sendClick("Eb4");        
            //System.Threading.Thread.Sleep(1000);
            //view.sendClick("Eb3");        
            //System.Threading.Thread.Sleep(1000);
            //var cell = view._board.GetCell("Eb3");
            //System.Threading.Thread.Sleep(1000);
            //Assert.IsNotNull(cell.GetPiece());
            //System.Threading.Thread.Sleep(1000);
            //Assert.IsNull(view._board.GetCell("Eb4").GetPiece());
            //System.Threading.Thread.Sleep(1000);
            //view.Dispose();
        }
        [Test]
        public void TestNotMovePiece()
        {
            var view = new BoardViewer();
            view.Show();
            view.sendClick("Eb4");
            view.sendClick("Eb4");
            var cell = view._board.GetCell("Eb3");
            Assert.IsNull(cell.GetPiece());
            Assert.IsNotNull(view._board.GetCell("Eb4").GetPiece());
            view.Dispose();
        }
        [Test]
        public void TestBadtMovePiece()
        {
            var view = new BoardViewer();
            view.Show();
            view.sendClick("Eb4");
            view.sendClick("Eb2");
            var cell = view._board.GetCell("Eb2");
            Assert.IsNull(cell.GetPiece());
            Assert.IsNotNull(view._board.GetCell("Eb4").GetPiece());
            view.Dispose();
        }
    }
}
