using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider
{
    public class NewsValue : INewsValue
    {
        public NewsValue(IEnumerable<INewsItem> newsItems)
        {
            NewsItems = newsItems;
        }

        public IEnumerable<INewsItem> NewsItems
        {
            get;
            private set;
        }
    }
    public interface INewsValue : IValue
    {
        IEnumerable<INewsItem> NewsItems { get; }
    }

}
