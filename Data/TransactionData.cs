using Common;
using System.Collections.Generic;

namespace Data
{
    public class TransactionData
    {
        public List<Transaction> GetTransactions()
        {
            return CreateTransactions();
        }

        private List<Transaction> CreateTransactions()
        {
            var transactionList = new List<Transaction>();
            transactionList.Add(CreateTransaction("T2006", (decimal) 10.00, "USD"));
            transactionList.Add(CreateTransaction("M2007", (decimal) 34.57, "CAD"));
            transactionList.Add(CreateTransaction("R2008", (decimal) 17.95, "USD"));
            transactionList.Add(CreateTransaction("T2006", (decimal) 7.63, "EUR"));
            transactionList.Add(CreateTransaction("B2009", (decimal) 21.23, "USD"));
            return transactionList;
        }

        private Transaction CreateTransaction(string sku, decimal amount, string currency) =>
            new Transaction()
            {
                SKU = sku,
                Amount = amount,
                Currency = currency
            };
    }
}
