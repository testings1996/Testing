using System;
using EloBuddy;
using EloBuddy.SDK;
using Simple_Marksmans.Interfaces;
using Color = System.Drawing.Color;

namespace Simple_Marksmans.Plugins.Urgot
{
    internal class Urgot : ChampionPlugin
    {
        static Urgot()
        {

        }

        protected override void OnDraw()
        {
        }

        protected override void PermaActive()
        {
            Modes.PermaActive.Execute();
        }

        protected override void ComboMode()
        {
            Modes.Combo.Execute();
        }

        protected override void HarassMode()
        {
            Modes.Harass.Execute();
        }

        protected override void LaneClear()
        {
            Modes.LaneClear.Execute();
        }

        protected override void JungleClear()
        {
            Modes.JungleClear.Execute();
        }

        protected override void LastHit()
        {
            Modes.LastHit.Execute();
        }

        protected override void Flee()
        {
            Modes.Flee.Execute();
        }
    }
}