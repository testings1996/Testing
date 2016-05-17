using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple_Marksmans.Interfaces;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator
{
    internal class Item : IItem
    {
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public float Range { get; set; }
        public ItemType ItemType { get; set; }
        public ItemTargettingType ItemTargettingType { get; set; }
        public ItemUsageWhen ItemUsageWhen { get; set; }
    }
}
