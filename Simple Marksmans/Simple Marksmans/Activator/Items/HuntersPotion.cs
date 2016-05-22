using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class HuntersPotion : Item
    {
        public HuntersPotion()
        {
            ItemName = "HuntersPotion";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.HuntersPotion;
            ItemType = ItemType.Potion;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}