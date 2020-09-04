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
                        AccountId= "ACC334455",//args[0],
                        From=DateTime.Parse("20/10/2018 12:00:00"),
                        To=DateTime.Parse("20/10/2018 19:00:00")};
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