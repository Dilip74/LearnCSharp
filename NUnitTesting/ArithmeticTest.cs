using ArithmeticOperations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace NUnitTesting
{
    [TestFixture]
    public class ArithmeticTest
    {
        public int i = 30, j = 5;
        [Test]
        public void TestSum()
        {
            ArithmeticOps ar = new ArithmeticOps();
            Assert.AreEqual(35, ar.Sum(i, j));
        }
    }
}
