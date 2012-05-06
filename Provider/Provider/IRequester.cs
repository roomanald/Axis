using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider
{
    public interface IRequester<TKey, TValue>
        where TKey : IKey
        where TValue : IValue 
    {
        TValue GetValue(TKey key);
    }
}
