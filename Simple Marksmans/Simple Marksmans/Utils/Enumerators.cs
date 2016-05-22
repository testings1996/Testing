using System;

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
        Unit,
        None
    }

    public enum ItemUsageWhen
    {
        Always,
        AfterAttack,
        ComboMode,
    }

    public enum ItemsEnum
    {
        HealthPotion,
        RefillablePotion,
        HuntersPotion,
        CorruptingPotion,
        ElixirofIron,
        ElixirofSorcery,
        ElixirofWrath,
        Scimitar,
        Quicksilver,
        Ghostblade,
        Cutlass,
        Gunblade,
        BladeOfTheRuinedKing
    }

    public enum ItemIds
    {
        HealthPotion = 2003,
        Biscuit = 2010,
        RefillablePotion = 2031,
        HuntersPotion = 2032,
        CorruptingPotion = 2033,
        ElixirofIron = 2138,
        ElixirofSorcery = 2139,
        ElixirofWrath = 2140,
        Scimitar = 3139,
        Quicksilver = 3140,
        Ghostblade = 3142,
        Cutlass = 3144,
        Gunblade = 3146,
        BladeOfTheRuinedKing = 3153
    }
}