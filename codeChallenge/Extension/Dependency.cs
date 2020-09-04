using System;
using Microsoft.Extensions.DependencyInjection;

namespace codeChallenge
{
    class DependencyInjection
    {
        public static IServiceProvider SetDependency()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITransactionManager, TransactionManager>();
            services.AddSingleton<ITransactionDataProvider, TransactionDataProvider>();
            services.AddSingleton<ITransactionDataFormatter, TransactionDataFormatter>();
            services.AddSingleton<ITransactionProcessor, TransactionProcessor>();

           return services.BuildServiceProvider();
        }
    }
}