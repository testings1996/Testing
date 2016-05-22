using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;

namespace Simple_Marksmans.Utils
{
    internal static class ObjAiBaseExtensions
    {
        public static bool IsUsingHealingPotion(this Obj_AI_Base unit)
        {
            return unit.HasBuff("ItemMiniRegenPotion") || unit.HasBuff("ItemCrystalFlask") ||
                   unit.HasBuff("ItemCrystalFlaskJungle") || unit.HasBuff("ItemDarkCrystalFlask") || unit.HasBuff("Health Potion");
        }

    }
}
