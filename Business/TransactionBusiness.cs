using Common;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class TransactionBusiness
    {
        public static readonly string Euro = "EUR";

        TransactionData _transactionData;

        public TransactionBusiness()
        {
            _transactionData = new TransactionData();

        }

        public List<Transaction> GetTransactions() => 
            _transactionData.GetTransactions();

        public List<Transaction> GetTransactions(string sku) 
        {
            var transactions = GetTransactions();
            if (!HasAnyTransactionWithSku(transactions, sku)) return null;

            return transactions.Where(t => t.SKU == sku).ToList();
        }

        private bool HasAnyTransactionWithSku(List<Transaction> transactions, string sku) =>
            transactions.Any(t => t.SKU == sku);


        public bool IsValidSku(string sku) {
            if (string.IsNullOrEmpty(sku)) return false;
            var transactions = GetTransactions(sku);
            return transactions != null;
        }


    }
}
