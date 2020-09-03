using System;
using Microsoft.Extensions.DependencyInjection;

namespace codeChallenge
{
    class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITransactionManager, TransactionManager>();
            services.AddSingleton<ITransactionDataProvider, TransactionDataProvider>();
            services.AddSingleton<ITransactionDataFormatter, TransactionDataFormatter>();
            services.AddSingleton<ITransactionProcessor, TransactionProcessor>();

           IServiceProvider Provider = services.BuildServiceProvider();
            var data=Provider.GetRequiredService<ITransactionManager>().ProcessRequest(new Input());
            Console.WriteLine("Relative balance for the period is: "+data.RelativeBalance);
            Console.WriteLine("Number of transactions included is: "+data.RelativeBalance);
        }
    }
}
