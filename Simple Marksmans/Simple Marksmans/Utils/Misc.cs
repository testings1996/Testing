using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EloBuddy;

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
                message = Regex.Replace(message, "him", "her", RegexOptions.IgnoreCase);
                message = Regex.Replace(message, "his", "hers", RegexOptions.IgnoreCase);
            }

            if (possibleFlood && _lastMessageTick + 500 > Game.Time * 1000 && _lastMessageString == message)
                return;

            _lastMessageTick = Game.Time * 1000;
            _lastMessageString = message;

            Chat.Print("<font size=\"21\"><font color=\"#0075B0\"><b>[Marksman AIO]</b></font> " + message + "</font>");
        }

    }
}