using NUnit.Framework;

namespace Data.Tests
{
    public class TransactionDataTests
    {
        TransactionData transactionData;

        public TransactionDataTests()
        {
            transactionData = new TransactionData();
        }

        [Test]
        public void TransactionDataTest()
        {
            var transactions = transactionData.GetTransactions();

            Assert.IsTrue(transactions.Count > 0);
        }
    }
}