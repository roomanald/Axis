using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider.Yahoo.Finance
{
    public interface IYahooFinanceStockValue : IStockValue
    {

    }

    public interface IYahooFinanceNewsValue : INewsValue
    {
    }

    public class YahooFinanceStockValue : YahooFinanceValue, IYahooFinanceStockValue
    {
        private double _bid;
        private double _ask;
        private double _change;

        public YahooFinanceStockValue(string serialisedValue)
        {
            string[] values = serialisedValue.Split(',');
            double.TryParse(values[0], out _bid);
            double.TryParse(values[1], out _ask);
            double.TryParse(values[2], out _change);
        }

        public override string ToString()
        {
            return 
                Bid.ToString() + 
                Ask.ToString() + 
                Change.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(YahooFinanceKey))
            {
                return ((YahooFinanceKey)obj).ToString() == this.ToString();
            }
            return false;
        }

        public double Bid { get { return _bid; } }
        public double Ask { get { return _ask; } }
        public double Change { get { return _change; } }

    }

    public class YahooFinanceValue : IValue
    {
    
    }
}
