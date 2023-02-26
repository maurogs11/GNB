using NUnit.Framework;

namespace Common.Tests
{
    public class RateTests
    {

        [Test]
        public void RateTest()
        {
            var rate = new Rate() { From = "CAD", To = "EUR", RateNum = (decimal) 0.732 };

            Assert.IsTrue(rate.From == "CAD");
            Assert.IsTrue(rate.To == "EUR");
            Assert.IsTrue(rate.RateNum == (decimal) 0.732);
        }
    }
}