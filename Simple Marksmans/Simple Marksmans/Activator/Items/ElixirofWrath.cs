using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class ElixirofWrath : Item
    {
        public ElixirofWrath()
        {
            ItemName = "ElixirofWrath";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.ElixirofWrath;
            ItemType = ItemType.Potion;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}