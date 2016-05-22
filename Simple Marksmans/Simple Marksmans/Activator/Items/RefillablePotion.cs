using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class RefillablePotion : Item
    {
        public RefillablePotion()
        {
            ItemName = "RefillablePotion";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.RefillablePotion;
            ItemType = ItemType.Potion;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}