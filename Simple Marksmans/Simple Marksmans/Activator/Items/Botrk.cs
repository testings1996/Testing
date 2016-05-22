using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator.Items
{
    internal class Botrk : Item
    {
        public Botrk()
        {
            ItemName = "BladeOfTheRuinedKing";
            ItemTargettingType = ItemTargettingType.Unit;
            ItemId = ItemIds.BladeOfTheRuinedKing;
            ItemType = ItemType.Offensive;
            ItemUsageWhen = ItemUsageWhen.AfterAttack;
            Range = 550;
        }
    }
}