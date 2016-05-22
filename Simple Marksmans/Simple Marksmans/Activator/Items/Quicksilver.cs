using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class Quicksilver : Item
    {
        public Quicksilver()
        {
            ItemName = "Quicksilver Sash";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.Quicksilver;
            ItemType = ItemType.Defensive;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}