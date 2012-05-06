using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;

namespace Provider
{
    public interface ISubscriberComponent<TKey, TValue> : IDisposable
        where TKey : IKey
        where TValue : IValue
    {
        void Subscribe(TKey key);
        void UnSubscribe(TKey key);
        KeyValuePair<TKey, TValue> GetIntialValue(TKey key);
        IObservable<KeyValuePair<TKey, TValue>> Updates { get; }
    }

}
