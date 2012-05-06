using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Provider.Yahoo.Finance
{
    public class YahooFinanceStockRequester : IRequester<YahooFinanceKey,YahooFinanceStockValue>
    {
        /*
         * http://finance.yahoo.com/d/quotes.csv?s= a BUNCH of STOCK SYMBOLS separated by “+” &f=a bunch of special tags
**s=SYMBOL**: where SYMBOL is the actual stock symbol (e.g. 0001.HK)
**f=REQUESTED_FORMAT_STRING** where the REQUESTED_FORMAT_STRING is a string of letters representing what fields to be requested.
for example: http://finance.yahoo.com/d/quotes.csv?s=XOM+BBDb.TO+JNJ+MSFT&f=snd1l1yr
         * 
         * 
         */

        private string _baseUri = @"http://finance.yahoo.com/d/quotes.csv?s=";
        public YahooFinanceStockValue GetValue(YahooFinanceKey key)
        {
            // Create the web request  
            HttpWebRequest request = WebRequest.Create(_baseUri + key.ToString()) as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Read the whole contents and return as a string  
                var result = reader.ReadToEnd();

                return new YahooFinanceStockValue(result);
            }
        }
    }

}
