namespace codeChallenge
{
    public interface ITransactionManager
    {
        Output ProcessRequest(Input input);
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
        public Output ProcessRequest(Input input)
        {
            Output result=default;
            try{

                var transactions=_transactionDataProvider.GetTransactions();

                result= _transactionProcessor.ExtractTransaction(transactions,input);
            }
            catch
            {
                //log// throw
            }
            return result;
        }
    }
}