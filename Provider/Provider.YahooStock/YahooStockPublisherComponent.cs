using System;

namespace Provider.YahooStock
{
    public class YahooStockPublisherComponent : 
        IPublisherComponent<IYahooStockKey,IYahooStockValue>
    {
        public void Publish(IYahooStockKey key, IYahooStockValue value)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}