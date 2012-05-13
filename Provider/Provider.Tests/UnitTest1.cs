using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider.YahooStock;

namespace Provider.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var yahooStockProvider = new Provider<IYahooStockKey, IYahooStockValue>(
                new YahooStockSubscriberComponent(),
                new YahooStockPublisherComponent());
        }
    }
}
