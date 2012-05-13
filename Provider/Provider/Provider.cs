using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider
{
    public class Provider<TKey,TValue> : 
        IRefCountSubscriber<TKey,TValue>, 
        IPublisherComponent<TKey,TValue> 
        where TKey : IKey
        where TValue : IValue
    {
        private IPublisherComponent<TKey, TValue> _pub;
        private IRefCountSubscriber<TKey, TValue> _sub;

        public Provider(ISubscriberComponent<TKey,TValue> sub, IPublisherComponent<TKey, TValue> pub)
        {
            _sub = new RefCountSubscriber<TKey, TValue>(sub);
            _pub = pub;
        }

        public void Dispose()
        {
            _sub.Dispose();
            _pub.Dispose();
        }

        public IObservable<KeyValuePair<TKey, TValue>> GetUpdates(TKey key)
        {
            return _sub.GetUpdates(key);
        }

        public IObservable<KeyValuePair<TKey, TValue>> GetUpdates(IEnumerable<TKey> key)
        {
            return _sub.GetUpdates(key);
        }

        public IEnumerable<TKey> SubscriptionKeys
        {
            get { return _sub.SubscriptionKeys; }
        }

        public void Publish(TKey key, TValue value)
        {
            _pub.Publish(key,value);
        }
    }
}
