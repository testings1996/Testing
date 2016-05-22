using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class ElixirofSorcery : Item
    {
        public ElixirofSorcery()
        {
            ItemName = "ElixirofSorcery";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.ElixirofSorcery;
            ItemType = ItemType.Potion;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}