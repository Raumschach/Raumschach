using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using RaumschachForm;

namespace RaumschachTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPanelClick(){
            var target = new RaumschachForm.Form1();
         
            var Panel = new Panel();
            Panel.Click += target.SelectedSquare;
        }
    }
}