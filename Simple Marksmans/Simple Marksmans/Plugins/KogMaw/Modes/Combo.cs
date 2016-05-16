using EloBuddy;

namespace Simple_Marksmans.Plugins.KogMaw.Modes
{
    internal class Combo : KogMaw
    {
        public static void Execute()
        {
            Chat.Print("Kog'Maw : Combo mode !");
        }

        private static void KogMaw_OnPostAttackEvent(AttackableUnit target, System.EventArgs args)
        {
            Chat.Print("Kog'Maw : OnPostAttack !");
        }
    }
}