using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class ElixirofWrath : Item
    {
        public ElixirofWrath()
        {
            ItemName = "ElixirofWrath";
            ItemTargettingType = ItemTargettingType.Unit;
            ItemId = 3153;
            ItemType = ItemType.Offensive;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}