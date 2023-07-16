using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Classes
{
    //blockedBy, blocked, timeStamp
    public class BlockedByInfo
    {
        public String blockedByPlayer;
        public int blockedStockCount;
        public DateTime timeStamp;

        public void blockStockByPlayer(string playerName, int stockCount){
            timeStamp = DateTime.Now;
            blockedByPlayer = playerName;
            blockedStockCount = stockCount;
            Debug.Log("DateTime.Now: " + timeStamp.ToString());
        }
    }
}
