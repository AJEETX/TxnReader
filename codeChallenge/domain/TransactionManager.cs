using System;

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

            //if(args.Length!=3) return result;

            var input=new Input{
                        AccountId= args[0],
                        From=DateTime.Parse(args[1]),
                        To=DateTime.Parse(args[2])};
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