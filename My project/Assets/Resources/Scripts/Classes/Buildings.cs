using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Resources.Scripts.Classes
{
    class Buildings
    {
        public enum buildingType { Merchand, Factory, Warehouse };
        Vector3 position;
        
        //1=100%
        float discounts =1, extraCharges=1;
        float blockingTime;
        List<Tuple<stockInfo, blockedByInfo>> stock; //StockName, Stock count, Price, <blockedBy, blocked, timeStamp>

        public transfer(String stockName, int count) {
            stock.
        }
    }
}
