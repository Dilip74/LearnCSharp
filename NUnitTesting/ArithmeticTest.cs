using ArithmeticOperations;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Moq;

namespace NUnitTesting
{
    //[TestFixture]
    public class ArithmeticTest
    {
        public int i = 10, j = 5;
        public bool result;

        [SetUp]
        public void CheckNonNegative()
        {
            if (i > 0 && j > 0)
                result = true;
        }

        [Test]
        //[Ignore("Not Required to Test")]
        public void TestSum()
        {
            if (true || result)
            {
                ArithmeticOps ar = new ArithmeticOps();
                Assert.AreEqual(15, ar.Sum(i, j));
            }
            else
                Assert.Fail();
        }

        [Test]
        [TestCase(20, 5, 15)]
        [TestCase(40, 10, 30)]
        public void TestSub(int a, int b, int expected)
        {
            if (result)
            {
                ArithmeticOps ar = new ArithmeticOps();
                Assert.AreEqual(a, b, expected);
            }
            else
                Assert.Fail();
        }



        [Test]
        public void CheckValues()
        {
            Mock<ArithmeticOps> mock = new Mock<ArithmeticOps>();
            mock.Setup(x => x.CheckDigitsOnly()).Returns(true);

            Assert.AreEqual(true, mock.Object.CheckDigitsOnly());
        }
    }
}
