using System;
using EloBuddy;

namespace Simple_Marksmans.Interfaces
{
    public interface IHeroAddon
    {
        void PermaActive();
        void ComboMode();
        void HarassMode();
        void Flee();
        void LaneClear();
        void JungleClear();
        void LastHit();
        void OnDraw();
    }
}
