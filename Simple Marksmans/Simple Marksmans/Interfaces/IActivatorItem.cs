using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Marksmans.Interfaces
{
    public interface IActivatorItem
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
