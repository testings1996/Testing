using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class Scimitar : Item
    {
        public Scimitar()
        {
            ItemName = "Mercurial Scimitar";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.Scimitar;
            ItemType = ItemType.Defensive;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}