using Data;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    
    public class RateBusiness
    {
        public static readonly string Euro = "EUR";
        public static readonly string Dollar = "USD";
        public static readonly string CanadianDollar = "CAD";

        RateData _rateData;

        public RateBusiness() {
            _rateData = new RateData();
        }

        public List<Rate> GetRates() => _rateData.GetRates();

        public Transaction ChangeRate(Transaction transaction, string to)
        {
            var rates = GetRates();
            foreach (Rate rate in rates) 
            {
                if (IsDirectChange(transaction, to))
                    if (transaction.Currency == rate.From && to == rate.To)
                    {
                        return new Transaction
                                {
                                    SKU = transaction.SKU,
                                    Amount = Math.Round((rate.RateNum * transaction.Amount), 2, MidpointRounding.ToEven),
                                    Currency = to
                        };
                    }
            }

            var newTransaction = new Transaction
            {
                SKU = transaction.SKU,
                Amount = Math.Round((rates.FirstOrDefault(r => r.From == transaction.Currency).RateNum * transaction.Amount), 2, MidpointRounding.ToEven),
                Currency = rates.FirstOrDefault(r => r.From == transaction.Currency).To
            };
            return ChangeRate(newTransaction, to);
        }

        public TransactionsSku GetTransactionsSku(List<Transaction> transactions)
        {
            var transactionsChanged = ChangeRateTransactionList(transactions, Euro);
            var transactionsSku = new TransactionsSku()
            {
                Transactions = transactionsChanged,
                Total = transactionsChanged.Sum(t => t.Amount)
            };
            return transactionsSku;
        }

        private List<Transaction> ChangeRateTransactionList(List<Transaction> list, string to)
        {
            var transactionsChanged = new List<Transaction>();
            list.ForEach(t => transactionsChanged.Add(ChangeRate(t, to)));
            return transactionsChanged;
        }

        private bool IsDirectChange(Transaction transaction, string to)
        {
            var rates = GetRates();
            foreach (Rate rate in rates)
            {
                if (transaction.Currency == rate.From && to == rate.To) return true;
            }
            return false;
        }

    }
}
