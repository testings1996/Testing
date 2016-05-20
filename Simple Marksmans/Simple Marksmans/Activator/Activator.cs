using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Simple_Marksmans.Activator.Items;
using Simple_Marksmans.Interfaces;
using Simple_Marksmans.Utils;

namespace Simple_Marksmans.Activator
{
    internal class Activator 
    {
        private static int _lastScanTick;
        private static Menu _menu;

        public static Menu ActivatorMenu { get; set; }

        public static IItem HealthPotion { get; private set; }
        public static IItem RefillablePotion { get; private set; }
        public static IItem HuntersPotion { get; private set; }
        public static IItem CorruptingPotion { get; private set; }
        public static IItem ElixirofIron { get; private set; }
        public static IItem ElixirofSorcery { get; private set; }
        public static IItem ElixirofWrath { get; private set; }
        public static IItem Scimitar { get; private set; }
        public static IItem Quicksilver { get; private set; }
        public static IItem Ghostblade { get; private set; }
        public static IItem Cutlass { get; private set; }
        public static IItem Gunblade { get; private set; }
        public static IItem Botrk { get; private set; }

        private static readonly List<int> ItemsId = new List<int>
        {
            2003,
            2031,
            2032,
            2033,
            2138,
            2139,
            2140,
            3139,
            3140,
            3142,
            3144,
            3146,
            3153
        };

        private static readonly Dictionary<Func<int, bool>, Action> ObjectInitializer = new Dictionary
            <Func<int, bool>, Action>
        {
            {
                itemId => itemId == 2003, delegate
                {
                    if (HealthPotion == null)
                        HealthPotion = new HealthPotion();
                }
            },
            {
                itemId => itemId == 2031, delegate
                {
                    if (RefillablePotion == null)
                        RefillablePotion = new RefillablePotion();
                }
            },
            {
                itemId => itemId == 2032, delegate
                {
                    if (HuntersPotion == null)
                        HuntersPotion = new HuntersPotion();
                }
            },
            {
                itemId => itemId == 2033, delegate
                {
                    if (CorruptingPotion == null)
                        CorruptingPotion = new CorruptingPotion();
                }
            },
            {
                itemId => itemId == 2138, delegate
                {
                    if (ElixirofIron == null)
                        ElixirofIron = new ElixirofIron();
                }
            },
            {
                itemId => itemId == 2139, delegate
                {
                    if (ElixirofSorcery == null)
                        ElixirofSorcery = new ElixirofSorcery();
                }
            },
            {
                itemId => itemId == 2140, delegate
                {
                    if (ElixirofWrath == null)
                        ElixirofWrath = new ElixirofWrath();
                }
            },
            {
                itemId => itemId == 3139, delegate
                {
                    if (Scimitar == null)
                        Scimitar = new Scimitar();
                }
            },
            {
                itemId => itemId == 3140, delegate
                {
                    if (Quicksilver == null)
                        Quicksilver = new Quicksilver();
                }
            },
            {
                itemId => itemId == 3142, delegate
                {
                    if (Ghostblade == null)
                        Ghostblade = new Ghostblade();
                }
            },
            {
                itemId => itemId == 3144, delegate
                {
                    if (Cutlass == null)
                        Cutlass = new Cutlass();
                }
            },
            {
                itemId => itemId == 3146, delegate
                {
                    if (Gunblade == null)
                        Gunblade = new Gunblade();
                }
            },
            {
                itemId => itemId == 3153, delegate
                {
                    if (Botrk == null)
                        Botrk = new Botrk();
                }
            }
        };

        private static readonly Dictionary<Func<int, bool>, Action> ObjectDestroyer = new Dictionary
            <Func<int, bool>, Action>
        {
            {itemId => itemId == 2003, () => HealthPotion = null},
            {itemId => itemId == 2031, () => RefillablePotion = null},
            {itemId => itemId == 2032, () => HuntersPotion = null},
            {itemId => itemId == 2033, () => CorruptingPotion = null},
            {itemId => itemId == 2138, () => ElixirofIron = null},
            {itemId => itemId == 2139, () => ElixirofSorcery = null},
            {itemId => itemId == 2140, () => ElixirofWrath = null},
            {itemId => itemId == 3139, () => Scimitar = null},
            {itemId => itemId == 3140, () => Quicksilver = null},
            {itemId => itemId == 3142, () => Ghostblade = null},
            {itemId => itemId == 3144, () => Cutlass = null},
            {itemId => itemId == 3146, () => Gunblade = null},
            {itemId => itemId == 3153, () => Botrk = null}
        };
        
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
        }

        private static void Shop_OnBuyItem(AIHeroClient sender, ShopActionEventArgs args)
        {
            Chat.Print(args.Id);
            LoadItem(args.Id);
        }

        private static void Shop_OnSellItem(AIHeroClient sender, ShopActionEventArgs args)
        {
            UnLoadItem(args.Id);
        }

        private static void ScanForItems()
        {
            _lastScanTick = (int) Game.Time*1000;

            foreach (var item in ItemsId)
            {
                var myItem = new EloBuddy.SDK.Item(item);

                if (myItem.IsOwned())
                {
                    LoadItem(item);
                }
                else
                {
                    UnLoadItem(item);
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

        public static void LoadItem(int id)
        {
            var output = ObjectInitializer.FirstOrDefault(comparer => comparer.Key(id)).Value;

            output?.Invoke();
        }

        public static void UnLoadItem(int id)
        {
            var output = ObjectDestroyer.FirstOrDefault(comparer => comparer.Key(id)).Value;

            output?.Invoke();
        }
    }
}