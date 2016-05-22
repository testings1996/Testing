using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class HealthPotion : Item
    {
        public HealthPotion()
        {
            ItemName = "HealthPotion";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.HealthPotion;
            ItemType = ItemType.Potion;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}