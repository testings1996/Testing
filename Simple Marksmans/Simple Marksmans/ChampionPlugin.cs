using System;
using EloBuddy;
using Simple_Marksmans.Interfaces;

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
        protected abstract void OnDraw();
        protected abstract void PermaActive();
        protected abstract void HarassMode();
        protected abstract void Flee();
        protected abstract void LaneClear();
        protected abstract void JungleClear();
        protected abstract void LastHit();
    }
}
