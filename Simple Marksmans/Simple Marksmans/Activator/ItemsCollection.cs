using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Simple_Marksmans.Interfaces;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator
{
    internal class ItemsCollection
    {
        public static IItem[] ItemsObject =
            new IItem[(int) Enum.GetValues(typeof(ItemsEnum)).Cast<ItemsEnum>().Max() + 1];

        public IItem this[ItemsEnum index]
        {
            get { return Enum.IsDefined(typeof(ItemsEnum), index) ? ItemsObject[(int) index] : null; }

            set
            {
                if (Enum.IsDefined(typeof(ItemsEnum), index))
                {
                    ItemsObject[(int) index] = value;
                }
            }
        }
    }
}