using NUnit.Framework;

namespace Common.Tests
{
    public class TransactionsSkuTests
    {

        [Test]
        public void TransactionsSkuTest()
        {
            var transactionsSku = new TransactionsSku();
            transactionsSku.Transactions.Add(new Transaction() { SKU = "T2006", Amount = (decimal) 7.32, Currency = "EUR" });
            transactionsSku.Transactions.Add(new Transaction() { SKU = "T2006", Amount = (decimal) 7.63, Currency = "EUR" });
            transactionsSku.Total = 40;
            Assert.IsTrue(transactionsSku.Transactions.Count == 2);
            Assert.IsTrue(transactionsSku.Total == 40);
        }
    }
}