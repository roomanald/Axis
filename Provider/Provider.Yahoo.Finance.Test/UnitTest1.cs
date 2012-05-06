using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Reactive;

namespace Provider.Yahoo.Finance.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //TimedSubscriber provider = new TimedSubscriber(TimeSpan.FromSeconds(1),new YahooFinanceStockRequester());
            //provider
            //    .GetUpdates(new YahooFinanceKey("ibm"))
            //    .Subscribe(update => Console.WriteLine(update));
            //Thread.Sleep(20000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckCannotAddSameKeyTwice()
        {
            //TimedSubscriber provider = new TimedSubscriber(TimeSpan.FromSeconds(1), new YahooFinanceStockRequester());
            //provider.GetUpdates(new YahooFinanceKey("ibm"));
            //provider.GetUpdates(new YahooFinanceKey("ibm"));
        }

        [TestMethod]
        public void UnSubscribe()
        {
            //TimedSubscriber provider = new TimedSubscriber(TimeSpan.FromSeconds(1), new YahooFinanceStockRequester());
            //provider.GetUpdates(new YahooFinanceKey("ibm"));
            //provider.GetUpdates(new YahooFinanceKey("google"));
            
            //Assert.AreEqual(2, provider.SubscriptionKeys.Count());
            //Assert.IsTrue(provider.SubscriptionKeys.Contains(new YahooFinanceKey("ibm")));
            //Assert.IsTrue(provider.SubscriptionKeys.Contains(new YahooFinanceKey("google")));

            //provider.UnSubscribe(new YahooFinanceKey("ibm"));

            //Assert.AreEqual(1, provider.SubscriptionKeys.Count());
            //Assert.IsTrue(provider.SubscriptionKeys.Contains(new YahooFinanceKey("google")));

        }
    }
}
