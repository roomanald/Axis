using System;
using System.Collections.Generic;

namespace Provider
{
    public interface IRefCountSubscriber<TKey, TValue> : IDisposable
        where TKey : IKey
        where TValue : IValue

    {
        IObservable<KeyValuePair<TKey, TValue>> GetUpdates(TKey key);
        IObservable<KeyValuePair<TKey,TValue>> GetUpdates(IEnumerable<TKey> key);
        IEnumerable<TKey> SubscriptionKeys { get; }
    }
}