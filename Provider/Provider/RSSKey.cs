using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider
{
    public class RSSKey : IKey
    {
        public RSSKey(string url)
        {
            URL = url;
        }
        public string URL { get; private set; }
    }
}
