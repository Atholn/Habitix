using Habitix.Data;
using NUnit.Framework;

namespace Habitix.Tests.Data
{
    public class TestTDDTests
    {
        [TestCase(1,2,3)]
        [TestCase(-11, 22, 11)]
        public void Add_TwoInt_ReturnSum(int a, int b, int exceptedInt)
        {
            var summary = new TestTDD();
            int result = summary.testMethodTDD(a, b);
            Assert.AreEqual(exceptedInt, result);
        }
    }
}
