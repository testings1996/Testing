#region Licensing
//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ChampionPlugin.cs" company="EloBuddy">
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
using EloBuddy.SDK.Events;
using Simple_Marksmans.Interfaces;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans
{
    internal abstract class ChampionPlugin : IHeroAddon
    {
        void IHeroAddon.ComboMode()
        {
            ComboMode();
        }

        void IHeroAddon.OnDraw()
        {
            OnDraw();
        }

        void IHeroAddon.OnGapcloser(GapCloserEventArgs args)
        {
            OnGapcloser(args);
        }

        void IHeroAddon.OnInterruptable()
        {
            OnInterruptable();
        }

        void IHeroAddon.PermaActive()
        {
            PermaActive();
        }

        void IHeroAddon.HarassMode()
        {
            HarassMode();
        }

        void IHeroAddon.Flee()
        {
            Flee();
        }

        void IHeroAddon.LaneClear()
        {
            LaneClear();
        }

        void IHeroAddon.JungleClear()
        {
            JungleClear();
        }

        void IHeroAddon.LastHit()
        {
            LastHit();
        }
        
        protected abstract void ComboMode();
        protected abstract void OnGapcloser(GapCloserEventArgs args);
        protected abstract void OnInterruptable();
        protected abstract void OnDraw();
        protected abstract void PermaActive();
        protected abstract void HarassMode();
        protected abstract void Flee();
        protected abstract void LaneClear();
        protected abstract void JungleClear();
        protected abstract void LastHit();
    }
}
