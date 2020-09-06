using System.Collections.Generic;
using System.Linq;
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
            var input=_inputFormatter.Cast2Type(args);

            var reversalTransactions=transactions.Where(txn=>txn.TransactionType.ToLowerInvariant()=="reversal");           
            
            var result=transactions.Where(txn=>
                !reversalTransactions.FirstOrDefault().RelatedTransaction.Contains(txn.TransactionId) && 
                 txn.FromAccountId==input.AccountId && txn.CreatedAt>=input.From && txn.CreatedAt<=input.To);
            
            var output=new Output{
                RelativeBalance=result.Sum(r=>r.FromAccountId==input.AccountId? -r.Amount:r.Amount),
                NoOfTransaction=result.Count()
            };
            
            return output;
        }
    }
}