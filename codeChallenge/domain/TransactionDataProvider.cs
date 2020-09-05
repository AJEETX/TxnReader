using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace codeChallenge
{
    public interface ITransactionDataProvider
    {
        IEnumerable<Transaction> GetTransactions();
    }
    class TransactionDataProvider : ITransactionDataProvider
    {
        ITransactionDataFormatter _transactionDataFormatter; 
        public TransactionDataProvider(ITransactionDataFormatter transactionDataFormatter)
        {
            _transactionDataFormatter=transactionDataFormatter;
        }
        public IEnumerable<Transaction> GetTransactions()
        {
            string path = @"transactions.csv";

            var rawTxnData=File.ReadAllLines(path).ToList();

            for(int i=1; i<rawTxnData.Count;i++)
            {
                 yield return _transactionDataFormatter.GetTransaction(rawTxnData[i]);
            }
        }
    }
}