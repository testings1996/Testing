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
using EloBuddy.SDK.Menu;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans
{
    public static class MenuManager
    {
        public static Menu Menu { get; set; }
        public static Menu[] Menus { get; set; }
        public static MenuValues MenuValues = new MenuValues();

        public static void CreateMenu()
        {
            Menu = MainMenu.AddMenu("Marksman AIO", "MarksmanAIO");
            Menu.AddSubMenu("Misc", "Miscc");
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
