using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class Ghostblade : Item
    {
        public Ghostblade()
        {
            ItemName = "Ghostblade";
            ItemTargettingType = ItemTargettingType.None;
            ItemId = ItemIds.Ghostblade;
            ItemType = ItemType.Offensive;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
        }
    }
}