using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RaumschachForm;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace RaumschachTests
{
    [TestClass]
    public class RookTests
    {
        [Test]
        public void TestnewPawn()
        {
            var target = new Pawn(true, "test");
            Assert.IsNotNull(target);
            Assert.IsTrue(target.White);

        }
    }
}
