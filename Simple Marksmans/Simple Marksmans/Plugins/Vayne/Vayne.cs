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
        public static Spell.Skillshot Q;
        public static ColorPicker[] ColorPicker = new ColorPicker[3];
        public static Menu Menu;

        static Vayne()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 300, SkillShotType.Linear);

            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;

            ColorPicker[0] = new ColorPicker("VayneQ", new ColorBGRA(1, 222, 44, 255));
            ColorPicker[1] = new ColorPicker("VayneW", new ColorBGRA(2, 222, 44, 255));
            ColorPicker[2] = new ColorPicker("VayneE", new ColorBGRA(3, 222, 44, 255));
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                Modes.LaneClear.AfterAttack(target, args);
            }
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
            Circle.Draw(ColorPicker[0].Color, 1200, Player.Instance);
            Circle.Draw(ColorPicker[1].Color, 400, Player.Instance);
            Circle.Draw(ColorPicker[2].Color, 200, Player.Instance);
        }

        protected override void CreateMenu()
        {
            Menu = MenuManager.Menu.AddSubMenu("Vayne settings");
            Menu.Add("Open1", new CheckBox("Change Color 1")).OnValueChange += (s, a) => ColorPicker[0].Initialize(Color.Aquamarine);
            Menu.Add("Open2", new CheckBox("Change Color 2")).OnValueChange += (s, a) => ColorPicker[1].Initialize(Color.Aquamarine);
            Menu.Add("Open3", new CheckBox("Change Color 3")).OnValueChange += (s, a) => ColorPicker[2].Initialize(Color.Aquamarine);
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