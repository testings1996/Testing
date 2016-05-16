using System;
using System.Reflection;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Simple_Marksmans.Interfaces;
using Simple_Marksmans.Plugins.Quinn.Modes;
using Color = System.Drawing.Color;

namespace Simple_Marksmans.Plugins.Vayne
{
    internal class Vayne : ChampionPlugin
    {
        public static Spell.Skillshot Q;

        static Vayne()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 300, SkillShotType.Linear);

            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                Modes.LaneClear.AfterAttack(target, args);
            }
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