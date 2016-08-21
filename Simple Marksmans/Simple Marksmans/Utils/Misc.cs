﻿#region Licensing
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

using System;
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

        public static System.Drawing.Color ColorFromHsv(double hue, double saturation, double brightness)
        {
            if (hue > 360 || hue < 0 || saturation > 1 || saturation < 0 || brightness > 1 || brightness < 0)
                throw new ArgumentOutOfRangeException();

            var chroma = brightness * saturation;
            var x = chroma * (1 - Math.Abs(hue / 60f % 2 - 1));
            var m = brightness - chroma;
            ColorObject color;

            if (0 <= hue && 60 > hue)
                color = new ColorObject(chroma, x, 0);
            else if (60 <= hue && 120 > hue)
                color = new ColorObject(x, chroma, 0);
            else if (120 <= hue && 180 > hue)
                color = new ColorObject(0, chroma, x);
            else if (180 <= hue && 240 > hue)
                color = new ColorObject(0, x, chroma);
            else if (240 <= hue && 300 > hue)
                color = new ColorObject(x, 0, chroma);
            else if (300 <= hue && 360 > hue)
                color = new ColorObject(chroma, 0, x);
            else
                color = new ColorObject(0, 0, 0);

            color.R = (color.R + m) * 255;
            color.G = (color.G + m) * 255;
            color.B = (color.B + m) * 255;

            return System.Drawing.Color.FromArgb(255, Convert.ToInt32(color.R), Convert.ToInt32(color.G), Convert.ToInt32(color.B));
        }

        public static System.Drawing.Color ColorFromHsv(this HsvColor c)
        {
            var hue = c.Hue;
            var saturation = c.Saturation;
            var brightness = c.Value;

            if (hue > 360 || hue < 0 || saturation > 1 || saturation < 0 || brightness > 1 || brightness < 0)
                throw new ArgumentOutOfRangeException();

            var chroma = brightness * saturation;
            var x = chroma * (1 - Math.Abs(hue / 60f % 2 - 1));
            var m = brightness - chroma;
            ColorObject color;

            if (0 <= hue && 60 > hue)
                color = new ColorObject(chroma, x, 0);
            else if (60 <= hue && 120 > hue)
                color = new ColorObject(x, chroma, 0);
            else if (120 <= hue && 180 > hue)
                color = new ColorObject(0, chroma, x);
            else if (180 <= hue && 240 > hue)
                color = new ColorObject(0, x, chroma);
            else if (240 <= hue && 300 > hue)
                color = new ColorObject(x, 0, chroma);
            else if (300 <= hue && 360 > hue)
                color = new ColorObject(chroma, 0, x);
            else
                color = new ColorObject(0, 0, 0);

            color.R = (color.R + m) * 255;
            color.G = (color.G + m) * 255;
            color.B = (color.B + m) * 255;

            return System.Drawing.Color.FromArgb(255, Convert.ToInt32(color.R), Convert.ToInt32(color.G), Convert.ToInt32(color.B));
        }

        public static Color SharpDxColorFromHsv(double hue, double saturation, double brightness)
        {
            if (hue > 360 || hue < 0 || saturation > 1 || saturation < 0 || brightness > 1 || brightness < 0)
                throw new ArgumentOutOfRangeException();

            var chroma = brightness * saturation;
            var x = chroma * (1 - Math.Abs(hue / 60f % 2 - 1));
            var m = brightness - chroma;
            ColorObject color;

            if (0 <= hue && 60 > hue)
                color = new ColorObject(chroma, x, 0);
            else if (60 <= hue && 120 > hue)
                color = new ColorObject(x, chroma, 0);
            else if (120 <= hue && 180 > hue)
                color = new ColorObject(0, chroma, x);
            else if (180 <= hue && 240 > hue)
                color = new ColorObject(0, x, chroma);
            else if (240 <= hue && 300 > hue)
                color = new ColorObject(x, 0, chroma);
            else if (300 <= hue && 360 > hue)
                color = new ColorObject(chroma, 0, x);
            else
                color = new ColorObject(0, 0, 0);

            color.R = (color.R + m) * 255;
            color.G = (color.G + m) * 255;
            color.B = (color.B + m) * 255;

            return new Color(Convert.ToInt32(color.R), Convert.ToInt32(color.G), Convert.ToInt32(color.B), 255);
        }

        public static Color SharpDxColorFromHsv(this HsvColor c)
        {
            var hue = c.Hue;
            var saturation = c.Saturation;
            var brightness = c.Value;

            if (hue > 360 || hue < 0 || saturation > 1 || saturation < 0 || brightness > 1 || brightness < 0)
                throw new ArgumentOutOfRangeException();

            var chroma = brightness * saturation;
            var x = chroma * (1 - Math.Abs(hue / 60f % 2 - 1));
            var m = brightness - chroma;
            ColorObject color;

            if (0 <= hue && 60 > hue)
                color = new ColorObject(chroma, x, 0);
            else if (60 <= hue && 120 > hue)
                color = new ColorObject(x, chroma, 0);
            else if (120 <= hue && 180 > hue)
                color = new ColorObject(0, chroma, x);
            else if (180 <= hue && 240 > hue)
                color = new ColorObject(0, x, chroma);
            else if (240 <= hue && 300 > hue)
                color = new ColorObject(x, 0, chroma);
            else if (300 <= hue && 360 > hue)
                color = new ColorObject(chroma, 0, x);
            else
                color = new ColorObject(0, 0, 0);

            color.R = (color.R + m) * 255;
            color.G = (color.G + m) * 255;
            color.B = (color.B + m) * 255;

            return new Color(Convert.ToInt32(color.R), Convert.ToInt32(color.G), Convert.ToInt32(color.B), 255);
        }

        public static double GetNumberInRangeFromProcent(double percent, double min, double max)
        {
            return (percent / 100f * (min - max) - min) * -1;
        }

        public static double GetProcentFromNumberRange(double value, double min, double max)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException();

            return (min - value) / (min - max) * 100f;
        }

        public static HsvColor ToHsv(this System.Drawing.Color color)
        {
            var r = color.R / 255d;
            var g = color.G / 255d;
            var b = color.B / 255d;

            var cMax = Math.Max(r, Math.Max(g, b));
            var cMin = Math.Min(r, Math.Min(g, b));

            var delta = cMax - cMin;
            double hue = 0;
            double saturation = 0;

            if (Math.Abs(cMax - r) < 0.000001)
            {
                hue = 60 * (((g - b) / delta) % 6);
            }
            else if (Math.Abs(cMax - g) < 0.000001)
            {
                hue = 60 * (((b - r) / delta) + 2);
            }
            else if (Math.Abs(cMax - b) < 0.000001)
            {
                hue = 60 * (((r - g) / delta) + 4);
            }

            if (Math.Abs(cMax) < 0.000001)
            {
                saturation = 0;
            }
            else if (Math.Abs(cMax) > 0.000001)
            {
                saturation = delta / cMax;
            }
            return new HsvColor(hue, saturation, cMax);
        }

        public static HsvColor ToHsv(this Color color)
        {
            var r = color.R / 255d;
            var g = color.G / 255d;
            var b = color.B / 255d;

            var cMax = Math.Max(r, Math.Max(g, b));
            var cMin = Math.Min(r, Math.Min(g, b));

            var delta = cMax - cMin;
            double hue = 0;
            double saturation = 0;

            if (Math.Abs(cMax - r) < 0.000001)
            {
                hue = 60 * (((g - b) / delta) % 6);
            }
            else if (Math.Abs(cMax - g) < 0.000001)
            {
                hue = 60 * (((b - r) / delta) + 2);
            }
            else if (Math.Abs(cMax - b) < 0.000001)
            {
                hue = 60 * (((r - g) / delta) + 4);
            }

            if (Math.Abs(cMax) < 0.000001)
            {
                saturation = 0;
            }
            else if (Math.Abs(cMax) > 0.000001)
            {
                saturation = delta / cMax;
            }
            return new HsvColor(hue, saturation, cMax);
        }


        private struct ColorObject
        {
            private double _r;
            private double _g;
            private double _b;

            public double R
            {
                get
                {
                    if (_r > 255)
                    {
                        return 255;
                    }
                    return _r < 0 ? 0 : _r;
                }
                set
                {
                    if (value > 255)
                    {
                        _r = 255;
                    }
                    else if (value < 0)
                    {
                        _r = 0;
                    } else _r = value;
                }
            }

            public double G
            {
                get
                {
                    if (_g > 255)
                    {
                        return 255;
                    }
                    return _g < 0 ? 0 : _g;
                }
                set
                {
                    if (value > 255)
                    {
                        _g = 255;
                    }
                    else if (value < 0)
                    {
                        _g = 0;
                    } else _g = value;
                }
            }

            public double B
            {
                get
                {
                    if (_b > 255)
                    {
                        return 255;
                    }
                    return _b < 0 ? 0 : _b;
                }
                set
                {
                    if (value > 255)
                    {
                        _b = 255;
                    }
                    else if (value < 0)
                    {
                        _b = 0;
                    } else _b = value;
                }
            }

            public ColorObject(double r, double g, double b)
            {
                _r = r;
                _g = g;
                _b = b;
            }
        }

        internal struct HsvColor
        {
            private double _h;
            private double _s;
            private double _v;

            public double Hue
            {
                get
                {
                    if (_h > 360)
                    {
                        return 360;
                    }
                    return _h < 0 ? 0 : _h;
                }
                set
                {
                    if (value > 360)
                    {
                        _h = 360;
                    }
                    else if (value < 0)
                    {
                        _h = 0;
                    } else _h = value;
                }
            }

            public double Saturation
            {
                get
                {
                    if (_s > 1)
                    {
                        return 1;
                    }
                    return _s < 0 ? 0 : _s;
                }
                set
                {
                    if (value > 1)
                    {
                        _s = 1;
                    }
                    else if (value < 0)
                    {
                        _s = 0;
                    } else _s = value;
                }
            }

            public double Value
            {
                get
                {
                    if (_v > 1)
                    {
                        return 1;
                    }
                    return _v < 0 ? 0 : _v;
                }
                set
                {
                    if (value > 1)
                    {
                        _v = 1;
                    }
                    else if (value < 0)
                    {
                        _v = 0;
                    } else _v = value;
                }
            }

            public HsvColor(double hue, double saturation, double value)
            {
                _h = hue;
                _s = saturation;
                _v = value;
            }

            public override string ToString()
            {
                return "HsvColor [H=" + _h + ", S=" + _s + ", V=" + _v + "]";
            }
        }
    }
}