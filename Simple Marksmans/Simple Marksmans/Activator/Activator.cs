using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Simple_Marksmans.Activator.Items;
using Simple_Marksmans.Interfaces;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator
{
    internal class Activator : Item
    {
        private static int _lastScanTick;
        private static Menu _menu;
        public static Menu ActivatorMenu;

        private new static readonly Dictionary<string, int> ItemId = new Dictionary<string, int>
        {
            {"HealthPotion", 2003},
            {"RefillablePotion", 2031},
            {"HuntersPotion", 2032},
            {"CorruptingPotion", 2033},
            {"ElixirofIron", 2138},
            {"ElixirofSorcery", 2139},
            {"ElixirofWrath", 2140},
            {"Scimitar", 3139},
            {"Quicksilver", 3140},
            {"Ghostblade", 3142},
            {"Cutlass", 3144},
            {"Gunblade", 3146},
            {"Botrk", 3153}
        };

        public static IItem HealthPotion,
            RefillablePotion,
            HuntersPotion,
            CorruptingPotion,
            ElixirofIron,
            ElixirofSorcery,
            ElixirofWrath,
            Scimitar,
            Quicksilver,
            Ghostblade,
            Cutlass,
            Gunblade,
            Botrk;

        public static void InitializeActivator()
        {
            _menu = MenuManager.Menu;

            ScanForItems();
            InitializeMenu();

            Shop.OnBuyItem += Shop_OnBuyItem;
            Shop.OnSellItem += Shop_OnSellItem;
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Game.Time*1000 > _lastScanTick + 10000)
            {
                ScanForItems();
            }
            if ((Orbwalker.ActiveModesFlags & Orbwalker.ActiveModes.LaneClear) != 0)
            {
                HealthPotion.UseItem();
            }
        }

        private static void Shop_OnBuyItem(AIHeroClient sender, ShopActionEventArgs args)
        {
            Chat.Print(args.Id);
            LoadItem(args.Id);
        }

        private static void Shop_OnSellItem(AIHeroClient sender, ShopActionEventArgs args)
        {
            var item = ItemId.FirstOrDefault(id => id.Value == args.Id);
            if (item.Key == null)
                return;

            switch (item.Value)
            {
                case 2003:
                    HealthPotion = null;
                    break;
                case 2031:
                    RefillablePotion = null;
                    break;
                case 2032:
                    CorruptingPotion = null;
                    break;
                case 2138:
                    ElixirofIron = null;
                    break;
                case 2139:
                    ElixirofSorcery = null;
                    break;
                case 2140:
                    ElixirofWrath = null;
                    break;
                case 3139:
                    Scimitar = null;
                    break;
                case 3140:
                    Quicksilver = null;
                    break;
                case 3142:
                    Ghostblade = null;
                    break;
                case 3144:
                    Cutlass = null;
                    break;
                case 3146:
                    Gunblade = null;
                    break;
                case 3153:
                    Botrk = null;
                    break;
            }
        }

        private static void ScanForItems()
        {
            _lastScanTick = (int) Game.Time*1000;

            foreach (var item in ItemId)
            {
                if (EloBuddy.SDK.Item.HasItem(item.Value))
                {
                    LoadItem(item.Value);
                }
                else
                {
                    switch (item.Value)
                    {
                        case 2003:
                            HealthPotion = null;
                            break;
                        case 2031:
                            RefillablePotion = null;
                            break;
                        case 2032:
                            CorruptingPotion = null;
                            break;
                        case 2138:
                            ElixirofIron = null;
                            break;
                        case 2139:
                            ElixirofSorcery = null;
                            break;
                        case 2140:
                            ElixirofWrath = null;
                            break;
                        case 3139:
                            Scimitar = null;
                            break;
                        case 3140:
                            Quicksilver = null;
                            break;
                        case 3142:
                            Ghostblade = null;
                            break;
                        case 3144:
                            Cutlass = null;
                            break;
                        case 3146:
                            Gunblade = null;
                            break;
                        case 3153:
                            Botrk = null;
                            break;
                    }
                }
            }
        }

        private static void InitializeMenu()
        {
            ActivatorMenu = _menu.AddSubMenu("Activator");
            ActivatorMenu.AddGroupLabel("Potions and Elixirs : ");
            ActivatorMenu.AddLabel("Potions : ");
            ActivatorMenu.Add("Activator.UsePotions", new CheckBox("Use Potions"));
            ActivatorMenu.Add("Activator.BelowHealth", new Slider("Use potions if health is below {0}%", 35));
            ActivatorMenu.Add("Activator.HealthPotion", new CheckBox("Use Health Potion"));
            ActivatorMenu.Add("Activator.RefillablePotion", new CheckBox("Use Refillable Potion"));
            ActivatorMenu.Add("Activator.HuntersPotion", new CheckBox("Use Hunter's Potion"));
            ActivatorMenu.Add("Activator.CorruptingPotion", new CheckBox("Use Corrupting Potion"));
            ActivatorMenu.AddSeparator(10);
            ActivatorMenu.AddLabel("Elixirs : ");
            ActivatorMenu.Add("Activator.ElixirofIron", new CheckBox("Use Elixir of Iron"));
            ActivatorMenu.Add("Activator.ElixirofSorcery", new CheckBox("Use Elixir of Sorcery"));
            ActivatorMenu.Add("Activator.ElixirofWrath", new CheckBox("Use Elixir of Wrath"));
        }

        private static void LoadItem(int id)
        {
            switch (id)
            {
                case 2003:
                    if (HealthPotion == null)
                    {
                        HealthPotion = new HealthPotion();
                    }
                    break;
                case 2031:
                    if (RefillablePotion == null)
                    {
                        RefillablePotion = new RefillablePotion();
                    }
                    break;
                case 2032:
                    if (CorruptingPotion == null)
                    {
                        CorruptingPotion = new CorruptingPotion();
                    }
                    break;
                case 2138:
                    if (ElixirofIron == null)
                    {
                        ElixirofIron = new ElixirofIron();
                    }
                    break;
                case 2139:
                    if (ElixirofSorcery == null)
                    {
                        ElixirofSorcery = new ElixirofSorcery();
                    }
                    break;
                case 2140:
                    if (ElixirofWrath == null)
                    {
                        ElixirofWrath = new ElixirofWrath();
                    }
                    break;
                case 3139:
                    if (Scimitar == null)
                    {
                        Scimitar = new Scimitar();
                    }
                    break;
                case 3140:
                    if (Quicksilver == null)
                    {
                        Quicksilver = new Quicksilver();
                    }
                    break;
                case 3142:
                    if (Ghostblade == null)
                    {
                        Ghostblade = new Ghostblade();
                    }
                    break;
                case 3144:
                    if (Cutlass == null)
                    {
                        Cutlass = new Cutlass();
                    }
                    break;
                case 3146:
                    if (Gunblade == null)
                    {
                        Gunblade = new Gunblade();
                    }
                    break;
                case 3153:
                    if (Botrk == null)
                    {
                        Botrk = new Botrk();
                    }
                    break;
            }
        }
    }
}