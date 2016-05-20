using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class RefillablePotion : Item
    {
        public RefillablePotion()
        {
            ItemName = "RefillablePotion";
            ItemTargettingType = ItemTargettingType.Unit;
            ItemId = 3153;
            ItemType = ItemType.Offensive;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}