using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenges_100
{
    public class ChallengeMethods
    {
        #region challenge-101
        /// <summary>
        /// Returns the minimum and mazimum values of the array.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] FindMinMax(IEnumerable<int> arr)
        {
            var min = arr.Min();
            var max = arr.Max();

            return new int[]{ min, max };
        }
        #endregion

        #region challenge-102
        /// <summary>
        /// Swaps the first and last name of the supplied <paramref="name">.
        /// </summary>
        /// <param name="name">The name of the person whose name should be shuffled.</param>
        /// <returns>The shuffled name of the person</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public string NameShuffle(string name)
        {
            var split = name.Split(" ");

            // throw if invalid argument
            if (split.Length != 2) throw new ArgumentException("Argument must have two names.", nameof(name));

            return $"{split[1]} {split[0]}";
        }
        /// <summary>
        /// Swaps the first and last name of the supplied <paramref="name">.
        /// </summary>
        /// <param name="name">The name of the person whose name should be shuffled.</param>
        /// <returns>The shuffled name of the person</returns>
        public string NameShuffleSafe(string name)
        {
            var split = name.Split(' ');

            switch (split.Length)
            {
                case 1: // if no name or only one name supplied, just return the parameter value
                    return name;
                case 2: // if only two names, swap them around and return
                    return $"{split[1]} {split[0]}";
                default: // if 3 or more names are provided, swap the first and the last, join them, and return
                    var first = split[0];
                    split[0] = split[split.Length - 1];
                    split[split.Length - 1] = first;
                    return string.Join(' ', split);
            }
        }
        #endregion

        #region challenge-103
        /// <summary>
        /// Checks if the string contains only letters of the same case.
        /// </summary>
        /// <param name="str">The string to check</param>
        /// <returns>True if case match, false otherwise</returns>
        public bool SameCase(string str)
        {
            // unsure about handling fornon-alpha characters

            bool lowerCase = char.IsLower(str[0]);

            for (int i = 1; i < str.Length; i++)
            {
                // if any char does not match the casing of the first char, return false.
                if (char.IsLower(str[i]) != lowerCase) return false;
            }

            return true;

            // Alternate method
            //var upperCase = str.Select(c => char.IsUpper(c)).ToList();
            //return upperCase.Count == 0 || upperCase.Count == str.Length;
        }
        #endregion

        #region challenge-104
        /// <summary>
        /// Checks if the string is an isogram
        /// </summary>
        /// <param name="str">The string to check</param>
        /// <returns>True if string is isogram, false otherwise</returns>
        public bool IsIsogram(string str)
        {
            var lower = str.ToLower();
            HashSet<char> set = new();

            foreach (char c in lower)
            {
                if (set.Contains(c)) return false;
                set.Add(c);
            }
            return true;
        }
        #endregion

        #region challenge-105

        // would normally declare at top of class / by convention
        private static readonly IReadOnlyDictionary<int, string> Months = new Dictionary<int, string>()
        {
            { 1, "January" },
            { 2, "February" },
            { 3, "March" },
            { 4, "April" },
            { 5, "May" },
            { 6, "June" },
            { 7, "July" },
            { 8, "August" },
            { 9, "Septemper" },
            { 10, "October" },
            { 11, "November" },
            { 12, "December" }
        };
        /// <summary>
        /// Returns the name of the month
        /// </summary>
        /// <param name="number">The number of the month</param>
        /// <returns>The name of the month corresponding to the <paramref name="number"/> provided.</returns>
        /// <exception cref="System.ArgumentException">Number needs to be between 1 and 12</exception>
        public string MonthName(int number)
        {
            if (number < 1 || number > 12) throw new System.ArgumentException("Number needs to be between 1 and 12 (both included)");

            return Months[number];
        }
        #endregion

        #region challenge-106
        /// <summary>
        /// Replaces each letter of <paramref name="str"/> with its appropriate position in the alphabet
        /// </summary>
        /// <param name="str"></param>
        /// <returns>A string with letters replaced by numbers</returns>
        public string AlphabetIndex(string str)
        {
            var specialsRemoved = Regex.Replace(str.ToUpper(), "[^A-ZÆØÅ]+", "", RegexOptions.Compiled);
            List<int> list = new();

            foreach (char c in specialsRemoved)
            {
                switch (c)
                {
                    case 'Æ':
                        list.Add(27);
                        continue;
                    case 'Ø':
                        list.Add(28);
                        continue;
                    case 'Å':
                        list.Add(29);
                        continue;
                    default:
                        list.Add((int)c - 64);
                        continue;
                }
            }

            return string.Join(' ', list);
        }
        #endregion
    }
}
