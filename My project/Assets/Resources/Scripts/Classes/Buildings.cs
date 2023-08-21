using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Resources.Scripts.Classes
{
    public class Buildings : IMapElement
    {
        public string name = "Ale duży budynek bez nazwy!";
        public enum buildingType { Merchand, Factory, Warehouse };
        public Vector3 posChunk = Vector3.zero;
        public Vector3 sizeChunk = Vector3.one/2;

        //1=100%
        float discounts = 1, extraCharges = 1;
        float blockingTime=10;
        //<StockName, StockInfo>>
        private SortedDictionary<string, StockInfo> stock;
        //StockName, Stock count, Price, <blockedBy, blocked, timeStamp>
        public GameObject go = null;

        public Buildings() {
            stock = new SortedDictionary<string, StockInfo>();

            //Starting stock
            addStock(new StockInfo("Złoto"));
            addStock(new StockInfo("Pasztet"));
        }
        public Buildings(Vector3 buildingsPos) {
            posChunk = buildingsPos;
        }

        public GameObject GameObjectInstance
        {
            get { return go; }
            set { go = value; }
        }

        public void transfer(String stockName, int count) {
            //stock.
            ;
        }

        public void addStock(StockInfo si)
        {
            StockInfo siFound = getStock(si.stockName);
            if (siFound == null)
            {
                stock.Add(si.stockName, si);
            }
            else {
                siFound.stockCount += si.stockCount;
            }
        }

        public StockInfo getStock(string name) {
            StockInfo value;
            if (stock.TryGetValue(name, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public SortedDictionary<string, StockInfo> GetAllStock() {
            return stock;
        }

        public string getAllStockToString() {
            string stocksString = "";

            foreach (KeyValuePair <string, StockInfo> stockInfo in stock) {
                stocksString += "(" + stockInfo.Value.ToString() + ") ";
            }
            if (stocksString.Length > 0) {
                stocksString = stocksString.Substring(0, stocksString.Length - 1);
            }

            return stocksString;
        }
        /*
            public String printStockList() {
            String output = "";

            foreach (KeyValuePair<StockInfo, BlockedByInfo> kv in stock) {
                output += kv.Key.stockName + " " + kv.Key.stockCount + "\n";
            }

            return output;
        }*/
    }
}
