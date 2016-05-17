using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Marksmans.Utils
{
    public enum ItemType
    {
        Defensive,
        Offensive,
        Potion
    }
    
    public enum ItemTargettingType
    {
        Self,
        Unit
    }

    public enum ItemUsageWhen
    {
        Always,
        AfterAttack,
        ComboMode,
    }
}