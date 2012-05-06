using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Provider
{
    public class RSSRequester : IRequester<RSSKey,NewsValue>
    {
        public NewsValue GetValue(RSSKey key)
        {
            XmlReader reader = XmlReader.Create(key.URL);
            Rss20FeedFormatter formatter =
            new Rss20FeedFormatter();
            formatter.ReadFrom(reader);
            reader.Close();
            return new NewsValue(
                formatter.Feed.Items
                .Select(item => 
                        new NewsItem
                        { 
                            Body = item.Summary.Text, 
                            Headline = item.Title.Text
                        }
                    ));
        }

        public IValue GetValue(IKey key)
        {
            return GetValue(key as RSSKey);
        }
    }
}
