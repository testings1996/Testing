using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK.Menu;

namespace Simple_Marksmans
{
    public static class MenuManager
    {
        public static Menu Menu { get; set; }

        public static void CreateMenu()
        {
            Menu = MainMenu.AddMenu("Marksman AIO", "MarksmanAIO");
            Menu.AddSubMenu("Misc", "Miscc");
        }
    }
}
