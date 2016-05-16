using EloBuddy;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans
{
    internal class Bootstrap
    {
        public static void Initialize()
        {
            var pluginInitialized = InitializeAddon.Initialize();

            if (!pluginInitialized)
                return;

            MenuManager.CreateMenu();

            Misc.PrintInfoMessage("<b><font color=\"#5ED43D\">" + Player.Instance.ChampionName + "</font></b> loaded successfully.");
        }
    }
}