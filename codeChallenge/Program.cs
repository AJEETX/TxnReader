using System;
using Microsoft.Extensions.DependencyInjection;

namespace codeChallenge
{
    class Program
    {
        public static void Main(string[] args)
        {
            var Provider = DependencyInjection.SetDependency();
            var data=Provider.GetRequiredService<ITransactionManager>().ProcessRequest(new Input());
            Console.WriteLine("Relative balance for the period is: "+data.RelativeBalance);
            Console.WriteLine("Number of transactions included is: "+data.RelativeBalance);
        }
    }
}
