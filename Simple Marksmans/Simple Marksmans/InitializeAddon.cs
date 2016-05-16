using System;
using EloBuddy;
using EloBuddy.SDK;
using Simple_Marksmans.Interfaces;

namespace Simple_Marksmans
{
    internal static class InitializeAddon
    {
        private static IHeroAddon _pluginInstance;

        public static bool Initialize()
        {
            LoadPlugin();

            if (_pluginInstance == null)
            { 
                Chat.Print(Player.Instance.ChampionName + " is not yet supported.");
                return false;
            }

            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;

            return true;
        }
        
        public static void LoadPlugin()
        {
            var typeName = "Simple_Marksmans.Plugins." + Player.Instance.ChampionName + "." + Player.Instance.ChampionName;

            var type = Type.GetType(typeName);
            if (type != null)
            {
                //var constructorInfo = type.GetConstructor(new Type[] {});

                //_plugin = (IHeroAddon) constructorInfo?.Invoke(new object[] {});

                _pluginInstance = (IHeroAddon)Activator.CreateInstance(type);
            }
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            _pluginInstance.OnDraw();
        }

        private static void Game_OnTick(EventArgs args)
        {
            _pluginInstance.PermaActive();

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                _pluginInstance.ComboMode();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                _pluginInstance.HarassMode();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                _pluginInstance.JungleClear();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                _pluginInstance.LaneClear();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
            {
                _pluginInstance.Flee();
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
            {
                _pluginInstance.LastHit();
            }
        }
    }
}