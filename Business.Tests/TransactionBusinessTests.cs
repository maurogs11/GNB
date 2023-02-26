using NUnit.Framework;

namespace Business.Tests
{
    public class TransactionBusinessTests
    {
        TransactionBusiness transactionBusiness;

        public TransactionBusinessTests()
        {
            transactionBusiness = new TransactionBusiness();
        }

        [Test]
        public void GetTransactionsTest()
        {
            var transactions = transactionBusiness.GetTransactions();
            Assert.IsTrue(transactions.Count > 0);
        }

        [Test]
        public void GetTransactionsWithValidSkuTest()
        {
            var transactions = transactionBusiness.GetTransactions("T2006");
            Assert.IsTrue(transactions.Count > 0);
        }

        [Test]
        public void GetTransactionsWithInvalidSkuTest()
        {
            var transactions = transactionBusiness.GetTransactions("PPPP");
            Assert.IsTrue(transactions == null);
        }
    }
}