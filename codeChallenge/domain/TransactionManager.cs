namespace codeChallenge
{
    public interface ITransactionManager
    {
        Output ProcessRequest(string[] args);
    }
    class TransactionManager : ITransactionManager
    {
        ITransactionDataProvider _transactionDataProvider;
        ITransactionProcessor _transactionProcessor;
        public TransactionManager(ITransactionDataProvider transactionDataProvider,ITransactionProcessor transactionProcessor)
        {
            _transactionDataProvider=transactionDataProvider;
            _transactionProcessor=transactionProcessor;
        }
        public Output ProcessRequest(string[] args)
        {
            Output result=default;

            if(args.Length!=5) return result;

            try{

                var transactions=_transactionDataProvider.GetTransactions();

                result= _transactionProcessor.ExtractTransaction(transactions,args);
            }
            catch
            {
                //log// throw
            }
            return result;
        }
    }
}