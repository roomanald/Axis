using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider
{
    public interface IPublisherComponent<TKey, TValue>
        where TKey : IKey
        where TValue : IValue
    {
        void Publish(TKey key, TValue value);
    }
}
