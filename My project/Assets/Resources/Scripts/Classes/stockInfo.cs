using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resources.Scripts.Classes
{
    //StockName, Stock count, Price, 
    public class StockInfo : IComparable
    {
        public String stockName;
        public int stockCount;
        public int pricePlayerBuy;
        public int pricePlayerSell;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            StockInfo sI = obj as StockInfo;
            if (sI != null)
                return this.stockName.CompareTo(sI.stockName);
            else
                throw new ArgumentException("Object is not a StockInfo");
        }
    }
}
