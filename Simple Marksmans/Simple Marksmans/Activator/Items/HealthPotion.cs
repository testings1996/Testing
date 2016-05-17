using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class HealthPotion : Activator
    {
        public HealthPotion()
        {
            ItemName = "HealthPotion";
            ItemTargettingType = ItemTargettingType.Unit;
            ItemId = 2003;
            ItemType = ItemType.Offensive;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}