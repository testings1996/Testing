using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class CorruptingPotion : Item
    {
        public CorruptingPotion()
        {
            ItemName = "CorruptingPotion";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.CorruptingPotion;
            ItemType = ItemType.Potion;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}