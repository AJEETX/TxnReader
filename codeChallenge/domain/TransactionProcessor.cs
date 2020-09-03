using System;
using System.Collections.Generic;

namespace codeChallenge
{
    public interface ITransactionProcessor
    {
        Output ExtractTransaction(IEnumerable<Transaction> transactions,Input input);
    }
    class TransactionProcessor : ITransactionProcessor
    {
        public Output ExtractTransaction(IEnumerable<Transaction> transactions,Input input)
        {
            throw new NotImplementedException();
        }
    }
}