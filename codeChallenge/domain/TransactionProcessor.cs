using System.Collections.Generic;
using System.Linq;
using System;
namespace codeChallenge
{
    public interface ITransactionProcessor
    {
        Output ExtractTransaction(IEnumerable<Transaction> transactions,string[] args);
    }
    class TransactionProcessor : ITransactionProcessor
    {
        IInputFormatter _inputFormatter;
        public TransactionProcessor(IInputFormatter inputFormatter)
        {
            _inputFormatter=inputFormatter;
        }
        public Output ExtractTransaction(IEnumerable<Transaction> transactions,string[] args)
        {
            Output output=new Output{};
            
            var input=_inputFormatter.Cast2Type(args);

            var reversalTransactions=transactions.Where(txn=>txn.TransactionType.ToUpperInvariant()=="REVERSAL");           
            
            var result=transactions.Where(txn=>
                !reversalTransactions.FirstOrDefault().RelatedTransaction.Contains(txn.TransactionId) && 
                 txn.FromAccountId==input.AccountId && txn.CreatedAt>=input.From && txn.CreatedAt<=input.To);
            
            foreach(var r in result)
            {
                output.RelativeBalance-=r.Amount;
                output.NoOfTransaction++;
            }
            
            return output;;
        }
    }
}