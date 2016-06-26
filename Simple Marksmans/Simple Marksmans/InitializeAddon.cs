#region Licensing
//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="InitializeAddon.cs" company="EloBuddy">
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
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Simple_Marksmans.Interfaces;
using Simple_Marksmans.Utils;

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
                Misc.PrintInfoMessage("<b><font color=\"#5ED43D\">" + Player.Instance.ChampionName + "</font></b> is not yet supported.");
                return false;
            }

            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast; ;

            return true;
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe)
                return;

            var enemy = sender as AIHeroClient;

            if (enemy == null)
                return;

            var menu = MenuManager.MenuValues;

            if (MenuManager.GapclosersFound == 0)
                return;

            if (!menu["MenuManager.GapcloserMenu.Enabled"] ||
                (menu["MenuManager.GapcloserMenu.OnlyInCombo"] && !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) || !Gapcloser.GapCloserList.Exists(e => e.ChampName == enemy.ChampionName))
                return;

            foreach (var gapcloser in Gapcloser.GapCloserList.Where(x=>x.ChampName == enemy.ChampionName && x.SpellSlot == args.Slot))
            {
                var hp = menu["MenuManager.GapcloserMenu." + enemy.ChampionName + "." + gapcloser.SpellSlot + ".Hp", true];
                var enemies = menu["MenuManager.GapcloserMenu." + enemy.ChampionName + "." + gapcloser.SpellSlot + ".Enemies", true];

                if (menu["MenuManager.GapcloserMenu." + enemy.ChampionName + "." + gapcloser.SpellSlot + ".Enabled"])// && Player.Instance.HealthPercent >= hp && Player.Instance.CountEnemiesInRange(MenuManager.GapcloserScanRange) <= enemies)
                {
                    _pluginInstance.OnGapcloser(new GapCloserEventArgs
                    {
                        Delay = menu["MenuManager.GapcloserMenu." + enemy.ChampionName + "." + gapcloser.SpellSlot + ".Delay", true],
                        HealthPercent = hp,
                        Enemies = enemies,
                        Sender = enemy,
                        GapcloserType = args.Target == null ? GapcloserTypes.Skillshot : GapcloserTypes.Targeted,
                        Target = args.Target,
                        End = args.End,
                        Start = args.Start,
                        SpellSlot = args.Slot,
                        GameTime = Game.Time * 1000
                    });
                }
            }
        }

        public static void LoadPlugin()
        {
            var typeName = "Simple_Marksmans.Plugins." + Player.Instance.ChampionName + "." + Player.Instance.ChampionName;

            var type = Type.GetType(typeName);
            if (type != null)
            {
                //var constructorInfo = type.GetConstructor(new Type[] {});

                //_plugin = (IHeroAddon) constructorInfo?.Invoke(new object[] {});

                _pluginInstance = (IHeroAddon)System.Activator.CreateInstance(type);
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