using NUnit.Framework;

namespace Data.Tests
{
    public class RateDataTests
    {

        RateData rateData;

        public RateDataTests() 
        {
            rateData = new RateData();
        }

        [Test]
        public void RateDataTest()
        {
            var rates = rateData.GetRates();

            Assert.IsTrue(rates.Count > 0);
        }
    }
}