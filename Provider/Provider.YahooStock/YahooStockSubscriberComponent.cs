using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider.YahooStock
{
    public class YahooStockSubscriberComponent : ISubscriberComponent<IYahooStockKey,IYahooStockValue>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Subscribe(IYahooStockKey key)
        {
            throw new NotImplementedException();
        }

        public void UnSubscribe(IYahooStockKey key)
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<IYahooStockKey, IYahooStockValue> GetIntialValue(IYahooStockKey key)
        {
            throw new NotImplementedException();
        }

        public IObservable<KeyValuePair<IYahooStockKey, IYahooStockValue>> Updates
        {
            get { throw new NotImplementedException(); }
        }
    }
}
