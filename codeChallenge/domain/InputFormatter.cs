using System;
using System.Text.RegularExpressions;

namespace codeChallenge
{
    public interface IInputFormatter
    {
        Input Cast2Type(string[] args);
    }
    class InputFormatter : IInputFormatter
    {
        Regex accountRegex=new Regex(@"accountId:(?=([A-Z_0-9]{1,}))");
        Regex fromDatetime=new Regex(@"from:(?=(\d{2}\/\d{2}\/\d{4} \d{2}:\d{2}:\d{2}))");
        Regex toDatetime=new Regex(@"to:(?=(\d{2}\/\d{2}\/\d{4} \d{2}:\d{2}:\d{2}))");
        public Input Cast2Type(string[] args)
        {
            var input=new Input{
                AccountId= accountRegex.Match(args[0]).Groups[1].Value,
                From=DateTime.Parse(fromDatetime.Match((args[1] +" "+args[2])).Groups[1].Value),
                To=DateTime.Parse(toDatetime.Match((args[3] +" "+args[4])).Groups[1].Value)
            };
            return input;;
        }
    }
}