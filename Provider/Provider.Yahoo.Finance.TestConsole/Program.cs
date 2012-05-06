using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive;
using System.Reactive.Linq;

namespace Provider.Yahoo.Finance.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new TimedSubscriber<YahooFinanceKey, YahooFinanceStockValue>(TimeSpan.FromSeconds(1), new YahooFinanceStockRequester());
            Console.WriteLine("Enter Stock Symbol");
            var stockSymbol = Console.ReadLine();
            provider
                .GetUpdates(new YahooFinanceKey(stockSymbol))
                .GroupBy(value => value.ToString())
                .Select(group => group.First())
                .Subscribe(value =>
                {
                    Console.WriteLine("Bid {0} Ask {1} Change {2}", value.Bid, value.Ask, value.Change);
                });
            Console.WriteLine("Press Any Key to Quit");
            Console.ReadKey();
        }
    }
}
