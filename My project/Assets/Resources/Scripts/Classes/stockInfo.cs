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
        public int stockCount=10;
        public int pricePlayerBuy;
        public int pricePlayerSell;
        //<playerName, BlockedByInfo>
        SortedDictionary<string, BlockedByInfo> blockedBy;

        public StockInfo(string stockName) {
            this.stockName = stockName;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentException("Object is null"); ;

            StockInfo sI = obj as StockInfo;
            if (sI != null)
                //CompareOrdinal may be necessary
                return this.stockName.CompareTo(sI.stockName);
            else
                throw new ArgumentException("Object is not a StockInfo"); ;
        }

        override public string ToString() {
            return stockName + " in stock: " + stockCount;
        }
    }
}
