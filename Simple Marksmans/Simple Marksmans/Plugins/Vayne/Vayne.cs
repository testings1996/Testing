#region Licensing
//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Vayne.cs" company="EloBuddy">
// 
//  Marksman AIO
// 
//  Copyright (C) 2016 Krystian Tenerowicz
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/. 
//  </copyright>
//  <summary>
// 
//  Email: geroelobuddy@gmail.com
//  PayPal: geroelobuddy@gmail.com
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------
#endregion
using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Simple_Marksmans.Utils;
using Color = System.Drawing.Color;


namespace Simple_Marksmans.Plugins.Vayne
{
    internal class Vayne : ChampionPlugin
    {
        public static Spell.Skillshot Q { get; }
        public static Spell.Active W { get; }
        public static Spell.Targeted E { get; }
        public static Spell.Active R { get; }

        private static Menu ComboMenu { get; set; }
        private static Menu HarassMenu { get; set; }
        private static Menu JungleClearMenu { get; set; }
        private static Menu LaneClearMenu { get; set; }
        private static Menu MiscMenu { get; set; }
        private static Menu DrawingsMenu { get; set; }

        private static readonly ColorPicker[] ColorPicker;

        private static bool _changingRangeScan;

        static Vayne()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 300, SkillShotType.Linear);
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Targeted(SpellSlot.E, 650);
            R = new Spell.Active(SpellSlot.R);
        }
        
        protected override void OnInterruptible(AIHeroClient sender, InterrupterEventArgs args)
        {
            Misc.PrintInfoMessage("[Vayne : OnInterruptible] "+sender.ChampionName + " | "+args.SpellSlot+" | "+args.DangerLevel);
        }

        protected override void OnGapcloser(AIHeroClient sender, GapCloserEventArgs args)
        {
            Chat.Print(args.Enemies);
        }

        protected override void OnDraw()
        {
        }

        protected override void CreateMenu()
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