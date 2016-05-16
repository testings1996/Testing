using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Utils;
using Simple_Marksmans.Interfaces;

namespace Simple_Marksmans
{
    internal class Bootstrap
    {
        public static void Initialize()
        {
            var initialized = InitializeAddon.Initialize();

            if (initialized)
            {
                var menu = MainMenu.AddMenu("Marksman AIO", "MarksmanAIO");
                menu.AddSubMenu("Modes");

                Chat.Print(Player.Instance.ChampionName + " loaded succesfully.");
            }
        }
    }
}