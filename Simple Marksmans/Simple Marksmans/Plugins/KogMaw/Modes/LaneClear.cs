using EloBuddy;

namespace Simple_Marksmans.Plugins.KogMaw.Modes
{
    internal class LaneClear : KogMaw
    {
        public static void Execute()
        {
        }

        private static void KogMaw_OnPostAttackEvent(AttackableUnit target, System.EventArgs args)
        {
            Chat.Print("Kog'Maw : OnPostAttack !");
        }
    }
}