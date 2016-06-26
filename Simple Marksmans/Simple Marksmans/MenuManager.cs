#region Licensing
//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MenuManager.cs" company="EloBuddy">
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
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Utils;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans
{
    public static class MenuManager
    {
        public static Menu Menu { get; set; }
        public static Menu GapcloserMenu { get; set; }
        public static int GapclosersFound { get; private set; }
        public static int GapcloserScanRange { get; set; } = 1250;

        public static MenuValues MenuValues { get; set; } = new MenuValues();

        public static void CreateMenu()
        {
            Menu = MainMenu.AddMenu("Marksman AIO", "MarksmanAIO");
            Menu.AddSubMenu("Misc", "Miscc");

            BuildAntiGapcloserMenu();
        }

        private static void BuildAntiGapcloserMenu()
        {

            if (!EntityManager.Heroes.Enemies.Any(x => Gapcloser.GapCloserList.Exists(e => e.ChampName == x.ChampionName)))
            {
                return;
            }
            
            GapcloserMenu = Menu.AddSubMenu("Anti-Gapcloser");
            GapcloserMenu.AddGroupLabel("Global settings");
            GapcloserMenu.Add("MenuManager.GapcloserMenu.Enabled", new CheckBox("Anti-Gapcloser Enabled"));
            GapcloserMenu.Add("MenuManager.GapcloserMenu.OnlyInCombo", new CheckBox("Only in combo", false));
            GapcloserMenu.AddSeparator(15);

            foreach (
                var enemy in
                    EntityManager.Heroes.Enemies.Where(x => Gapcloser.GapCloserList.Exists(e => e.ChampName == x.ChampionName))
                )
            {
                var gapclosers = Gapcloser.GapCloserList.FindAll(e => e.ChampName == enemy.ChampionName);
                var gapclosersCount = Gapcloser.GapCloserList.FindAll(e => e.ChampName == enemy.ChampionName).Count;

                if (gapclosersCount > 0)
                {
                    GapcloserMenu.AddGroupLabel(enemy.ChampionName);

                    for (var i = 0; i < gapclosersCount; i++)
                    {
                        var gapcloser = gapclosers[i];

                        GapcloserMenu.AddLabel("[" + gapcloser.SpellSlot + "] " + gapcloser.SpellName);
                        GapcloserMenu.Add("MenuManager.GapcloserMenu." + enemy.ChampionName + "." + gapcloser.SpellSlot + ".Delay",
                            new Slider("Delay", 0, 0, 500));
                        GapcloserMenu.Add("MenuManager.GapcloserMenu." + enemy.ChampionName + "." + gapcloser.SpellSlot + ".Hp",
                            new Slider("Only if Im below of {0} % of my HP", 100));
                        GapcloserMenu.Add("MenuManager.GapcloserMenu." + enemy.ChampionName + "." + gapcloser.SpellSlot + ".Enemies",
                            new Slider("Only if {0} or less enemies are near", 5, 1, 5));
                        GapcloserMenu.Add("MenuManager.GapcloserMenu." + enemy.ChampionName + "." + gapcloser.SpellSlot + ".Enabled",
                            new CheckBox("Enabled"));

                        GapclosersFound++;
                    }
                }
            }
        }


        //    public static T Get<T>(Menu type, string uniqueIdentifier, ItemTypes itemtype, bool getSelectedText = false)
        //    {
        //        if (type[uniqueIdentifier] == null)
        //        {
        //            Logger.Error("[Error] Menu item : " + uniqueIdentifier + " doesn't exists.");
        //            return (T)Convert.ChangeType(false, typeof(T));
        //        }
        //        switch (itemtype)
        //        {
        //            case ItemTypes.ComboBox:
        //                if (getSelectedText)
        //                    return (T)Convert.ChangeType(type[uniqueIdentifier].Cast<ComboBox>().SelectedText, typeof(T));

        //                return (T)Convert.ChangeType(type[uniqueIdentifier].Cast<ComboBox>().CurrentValue, typeof(T));
        //            case ItemTypes.CheckBox:
        //                return (T)Convert.ChangeType(type[uniqueIdentifier].Cast<CheckBox>().CurrentValue, typeof(T));
        //            case ItemTypes.KeyBind:
        //                return (T)Convert.ChangeType(type[uniqueIdentifier].Cast<KeyBind>().CurrentValue, typeof(T));
        //            case ItemTypes.Slider:
        //                return (T)Convert.ChangeType(type[uniqueIdentifier].Cast<Slider>().CurrentValue, typeof(T));
        //            default:
        //                throw new ArgumentOutOfRangeException(nameof(itemtype), itemtype, null);
        //        }
        //    }

        //    public static void Set<T>(Menu type, string uniqueIdentifier, ItemTypes itemtype, T value,
        //        Tuple<uint, uint> keys = null)
        //    {
        //        if (type[uniqueIdentifier] == null)
        //        {
        //            Logger.Error("[Error] Menu item : " + uniqueIdentifier + " doesn't exists.");
        //            return;
        //        }
        //        switch (itemtype)
        //        {
        //            case ItemTypes.ComboBox:
        //                type[uniqueIdentifier].Cast<ComboBox>().CurrentValue = Convert.ToInt32(value);
        //                break;
        //            case ItemTypes.CheckBox:
        //                type[uniqueIdentifier].Cast<CheckBox>().CurrentValue = Convert.ToBoolean(value);
        //                break;
        //            case ItemTypes.KeyBind:
        //                if (keys != null)
        //                    type[uniqueIdentifier].Cast<KeyBind>().Keys = keys;
        //                else
        //                    type[uniqueIdentifier].Cast<KeyBind>().CurrentValue = Convert.ToBoolean(value);
        //                break;
        //            case ItemTypes.Slider:
        //                type[uniqueIdentifier].Cast<Slider>().CurrentValue = Convert.ToInt32(value);
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException(nameof(itemtype), itemtype, null);
        //        }
        //    }
    }
}
