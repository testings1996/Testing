#region Licensing
//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Misc.cs" company="EloBuddy">
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
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EloBuddy;
using SharpDX;
using Simple_Marksmans.Interfaces;

namespace Simple_Marksmans.Utils
{
    internal static class Misc
    {
        /// <summary>
        /// Last message tick
        /// </summary>
        private static float _lastMessageTick;

        /// <summary>
        /// Last Message String
        /// </summary>
        private static string _lastMessageString;

        /// <summary>
        /// Female champions list
        /// </summary>
        private static readonly List<string> FemaleChampions = new List<string>
        {
            "Ahri", "Akali", "Anivia", "Annie",
            "Ashe", "Caitlyn", "Cassiopeia", "Diana",
            "Elise", "Evelynn", "Fiora", "Illaoi",
            "Irelia", "Janna", "Jinx", "Kalista",
            "Karma", "Katarina", "Kayle", "Kindred",
            "Leblanc", "Leona", "Lissandra", "Lulu",
            "Lux", "MissFortune", "Morgana", "Nami",
            "Nidalee", "Orianna", "Poppy", "Quinn",
            "RekSai", "Riven", "Sejuani", "Shyvana",
            "Sivir", "Sona", "Soraka", "Syndra",
            "Tristana", "Vayne",  "Vi", "Zyra"
        };


        /// <summary>
        /// Prints info message
        /// </summary>
        /// <param name="message">The message string</param>
        /// <param name="possibleFlood">Set to true if there is a flood possibility</param>
        public static void PrintInfoMessage(string message, bool possibleFlood = true)
        {
            if (FemaleChampions.Any(key => message.Contains(key)))
            {
                message = Regex.Replace(message, "he", "she", RegexOptions.IgnoreCase);
                message = Regex.Replace(message, "him", "her", RegexOptions.IgnoreCase);
                message = Regex.Replace(message, "his", "hers", RegexOptions.IgnoreCase);
            }

            if (possibleFlood && _lastMessageTick + 500 > Game.Time * 1000 && _lastMessageString == message)
                return;

            _lastMessageTick = Game.Time * 1000;
            _lastMessageString = message;

            Chat.Print("<font size=\"21\"><font color=\"#0075B0\"><b>[Marksman AIO]</b></font> " + message + "</font>");
        }

        public static void UseItem(this IItem item, Obj_AI_Base target = null)
        {
            if (item == null || item.ItemId == 0)
                return;
            
            var myItem = new EloBuddy.SDK.Item((int)item.ItemId, item.Range);

            if (item.ItemId == ItemIds.HealthPotion)
            {
                if(!myItem.IsOwned())
                    myItem = new EloBuddy.SDK.Item((int)ItemIds.Biscuit, item.Range);
            }

            if (!myItem.IsOwned() || !myItem.IsReady())
                return;

            if(target == null)
                myItem.Cast();
            else
            {
                myItem.Cast(target);
            }

            if(!myItem.IsOwned())
                Activator.Activator.UnLoadItem((int) item.ItemId);
        }

        public static void UseItem(this IItem item, Vector3? position)
        {
            if (item == null || item.ItemId == 0)
                return;

            var myItem = new EloBuddy.SDK.Item((int) item.ItemId, item.Range);

            if (item.ItemId == ItemIds.HealthPotion)
            {
                if (!myItem.IsOwned())
                    myItem = new EloBuddy.SDK.Item((int)ItemIds.Biscuit, item.Range);
            }

            if (!myItem.IsOwned() || !myItem.IsReady())
                return;

            if (!position.HasValue)
                myItem.Cast();
            else
            {
                myItem.Cast(position.Value);
            }

            if (!myItem.IsOwned())
                Activator.Activator.UnLoadItem((int)item.ItemId);
        }

        public static EloBuddy.SDK.Item ToItem(this IItem item)
        {
            return new EloBuddy.SDK.Item((int) item.ItemId, item.Range);
        }
    }
}