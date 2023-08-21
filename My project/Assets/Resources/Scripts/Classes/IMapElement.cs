using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Classes
{
    public interface IMapElement
    {
        GameObject GameObjectInstance { get; set; }
    }
}
