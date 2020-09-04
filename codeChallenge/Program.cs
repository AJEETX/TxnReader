using System;
using Microsoft.Extensions.DependencyInjection;

namespace codeChallenge
{
    class Program
    {
        public static void Main(string[] args)
        {
            var provider = DependencyInjection.SetDependency();
            var data=provider.GetRequiredService<ITransactionManager>().ProcessRequest(args);
            Console.WriteLine("Relative balance for the period is: "+data.RelativeBalance);
            Console.WriteLine("Number of transactions included is: "+data.NoOfTransaction);
        }
    }
}
