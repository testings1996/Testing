#region Licensing
// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Vayne.cs" company="EloBuddy">
// //
// // Copyright (C) 2016 Krystian Tenerowicz
// //
// // This program is free software: you can redistribute it and/or modify
// // it under the +terms of the GNU General Public License as published by
// // the Free Software Foundation, either version 3 of the License, or
// // (at your option) any later version.
// //
// // This program is distributed in the hope that it will be useful,
// // but WITHOUT ANY WARRANTY; without even the implied warranty of
// // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// // GNU General Public License for more details.
// //
// // You should have received a copy of the GNU General Public License
// // along with this program.  If not, see http://www.gnu.org/licenses/. 
// // </copyright>
// // <summary>
// // Marksman AIO
// // 
// // Email: krystiantenerowicz424@gmail.com
// // PayPal: krystiantenerowicz424@gmail.com
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
#endregion
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