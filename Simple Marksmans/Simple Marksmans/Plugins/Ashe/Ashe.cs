#region Licensing
//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Ashe.cs" company="EloBuddy">
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
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Utils;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Plugins.Ashe
{
    internal class Ashe : ChampionPlugin
    {
        public static Spell.Active Q;
        public static Spell.Skillshot W, E, R;

        static Ashe()
        {
            Q = new Spell.Active(SpellSlot.Q);
            W = new Spell.Skillshot(SpellSlot.W, 1225, SkillShotType.Cone, 250, 2000, 20);
            E = new Spell.Skillshot(SpellSlot.E, uint.MaxValue, SkillShotType.Linear);
            R = new Spell.Skillshot(SpellSlot.R, uint.MaxValue, SkillShotType.Linear, 250, 1600, 120);
        }
        
        protected override void OnDraw()
        {
        }
        
        protected override void OnInterruptable()
        {
            throw new NotImplementedException();
        }

        protected override void OnGapcloser(GapCloserEventArgs args)
        {
            Logger.Debug(args.Delay.ToString());
            Logger.Debug(args.Enemies.ToString());
            Logger.Debug(args.HealthPercent.ToString());
            Logger.Debug(args.SpellSlot.ToString());
            Logger.Debug(args.End.ToString());
            Logger.Debug(args.Start.ToString());
            Logger.Debug(args.GapcloserType.ToString());
            Logger.Debug(args.Sender.ChampionName);
            Logger.Debug(args.GameTime+"");

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