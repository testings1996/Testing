using System;
using EloBuddy;
using EloBuddy.SDK;
using Simple_Marksmans.Interfaces;

namespace Simple_Marksmans.Plugins.Vayne.Modes
{
    internal class LaneClear : Vayne
    {
        public static void Execute()
        {

        }

        public static void AfterAttack(AttackableUnit target, EventArgs args)
        {
            Q.Cast(Player.Instance.Position.Extend(Game.CursorPos, 200).To3D());


        }
    }
}