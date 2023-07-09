using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Resources.Scripts.Classes
{
    public class Buildings
    {
        public enum buildingType { Merchand, Factory, Warehouse };
        Vector3 posChunk;

        //1=100%
        float discounts = 1, extraCharges = 1;
        float blockingTime;
        SortedList<StockInfo, BlockedByInfo> stock; //StockName, Stock count, Price, <blockedBy, blocked, timeStamp>

        public void transfer(String stockName, int count) {
            //stock.
            ;
        }

        public void addStock(StockInfo si) {
            //TODO: When adding same stock only number needs to be increased
            stock.Add(si, new BlockedByInfo());
        }

        public String printStockList() {
            String output = "";

            foreach (KeyValuePair<StockInfo, BlockedByInfo> kv in stock) {
                output += kv.Key.stockName + " " + kv.Key.stockCount + "\n";
            }

            return output;
        }
    }
}
