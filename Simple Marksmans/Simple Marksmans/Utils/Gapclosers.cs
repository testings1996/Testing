using System.Collections.Generic;
using System.Reflection;
using EloBuddy;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace Simple_Marksmans.Utils
{
    /// <summary>
    /// Gapclosers database class
    /// </summary>
    public class GapCloserEventArgs
    {
        public AIHeroClient Sender { get; set; }
        public GameObject Target { get; set; }
        public Vector3 Start { get; set; }
        public Vector3 End { get; set; }
        public SpellSlot SpellSlot { get; set; }
        public GapcloserTypes GapcloserType { get; set; }
        public float GameTime { get; set; }
        public int Delay { get; set; }
        public int Enemies { get; set; }
        public int HealthPercent { get; set; }
    }
}