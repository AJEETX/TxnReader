using System;
namespace codeChallenge
{
    public interface ITransactionDataFormatter
    {
        Transaction GetTransaction(string txn);
    }
    class TransactionDataFormatter : ITransactionDataFormatter
    {
        public Transaction GetTransaction(string txn)
        {
            var txnData=txn.Split(",");

            return new Transaction
            {
                TransactionId=txnData[0],
                FromAccountId=txnData[1],
                ToAccountId=txnData[2],
                CreatedAt=DateTime.Parse(txnData[3]),
                Amount=Convert.ToDecimal(txnData[4]),
                TransactionType=txnData[5],
                RelatedTransaction=txnData[5].Trim().ToLowerInvariant()=="reversal"?txnData[6]:string.Empty
            };
        }
    }
}