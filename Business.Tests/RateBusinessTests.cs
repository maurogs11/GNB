using Common;
using NUnit.Framework;
using System.Collections.Generic;

namespace Business.Tests
{
    public class RateBusinessTests
    {
        RateBusiness rateBusiness;

        public RateBusinessTests() 
        {
            rateBusiness = new RateBusiness();
        }

        [Test]
        public void ChangeRateTestNotDirectly()
        {
            var transaction = new Transaction() { SKU = "B2009", Amount = (decimal)21.23, Currency = "USD" };
            var transactionChanged = rateBusiness.ChangeRate(transaction, "CAD");
            Assert.IsTrue(transactionChanged.Currency == "CAD");
            Assert.IsFalse(transactionChanged.Amount == (decimal)21.23);
        }

        [Test]
        public void ChangeRateTestDirectly()
        {
            var transaction = new Transaction() { SKU = "M2007", Amount = (decimal) 34.57, Currency = "CAD" };
            var transactionChanged = rateBusiness.ChangeRate(transaction, "EUR");
            Assert.IsTrue(transactionChanged.Currency == "EUR");
            Assert.IsFalse(transactionChanged.Amount == (decimal)34.57);
        }

        [Test]
        public void GetTransactionsSkuTest()
        {
            var transactions = new List<Transaction>();
            transactions.Add(new Transaction() { SKU = "T2006", Amount = (decimal) 7.32, Currency = "EUR" });
            transactions.Add(new Transaction() { SKU = "T2006", Amount = (decimal) 7.63, Currency = "EUR" });

            var transactionsSku = rateBusiness.GetTransactionsSku(transactions);
            Assert.IsTrue(transactionsSku.Total == (transactions[0].Amount + transactions[1].Amount));
            Assert.IsTrue(transactionsSku.Transactions.Count > 1);
        }

        [Test]
        public void GetRatesTest()
        {
            var rates = rateBusiness.GetRates();
            Assert.IsTrue(rates.Count > 0);
        }



    }
}