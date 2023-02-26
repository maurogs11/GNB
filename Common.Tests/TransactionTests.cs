using NUnit.Framework;

namespace Common.Tests
{
    public class TransactionTests
    {

        [Test]
        public void TransactionTest()
        {
            var transaction = new Transaction() { SKU = "T2006", Amount = (decimal) 7.32, Currency = "EUR" };

            Assert.IsTrue(transaction.SKU == "T2006");
            Assert.IsTrue(transaction.Amount == (decimal) 7.32);
            Assert.IsTrue(transaction.Currency == "EUR");
        }
    }
}