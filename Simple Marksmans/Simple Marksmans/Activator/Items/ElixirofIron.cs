using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class ElixirofIron : Item
    {
        public ElixirofIron()
        {
            ItemName = "ElixirofIron";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.ElixirofIron;
            ItemType = ItemType.Potion;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}