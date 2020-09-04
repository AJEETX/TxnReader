using System.Collections.Generic;
using System.Linq;

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
            Output output=new Output{};
            var reversalTransactions=transactions.Where(txn=>txn.TransactionType.ToUpperInvariant()=="REVERSAL");           
            var result=transactions.Where(txn=>
                !reversalTransactions.FirstOrDefault().RelatedTransaction.Contains(txn.TransactionId) && 
                 txn.FromAccountId==input.AccountId && txn.CreatedAt>=input.From && txn.CreatedAt<=input.To);
                foreach(var r in result)
                {
                    output.RelativeBalance+=r.Amount;
                    output.NoOfTransaction++;
                }
            
            return output;;
        }
    }
}