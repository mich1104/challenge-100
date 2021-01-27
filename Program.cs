using System;
using System.Collections.Generic;

namespace Challenges_100
{
    class Program
    {
        static ChallengeMethods cm = new ChallengeMethods();
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Select a method to run and supply parameters:\n\n FindMinMax: 1\n\n NameShuffle: 2\n\n SameCase: 3\n\n IsIsogram: 4\n\n MonthName: 5\n\n AlphabetIndex: 6\n\n Press 0 to exit\n");
                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        Console.WriteLine("\n\nPlease a list of numbers separated by ',':");
                        var numbersList = Console.ReadLine();
                        var split = numbersList.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        List<int> numbers = new();
                        foreach (var s in split)
                        {
                            if (int.TryParse(s, out int result)) numbers.Add(result);
                        }
                        var minMax = cm.FindMinMax(numbers);
                        Console.WriteLine($"FindMinMax returned '[{string.Join(", ", minMax)}]'");
                        break;
                    case '2':
                        Console.WriteLine("\n\nPlease enter a name to shuffle:");
                        var nameshuffleInput = Console.ReadLine();
                        Console.WriteLine($"SameCase returned '{cm.NameShuffleSafe(nameshuffleInput)}'");
                        break;

                    case '3':
                        Console.WriteLine("\n\nPlease enter a string to validate for same case:");
                        var samecaseInput = Console.ReadLine();
                        Console.WriteLine($"SameCase returned '{cm.SameCase(samecaseInput)}'");
                        break;

                    case '4':
                        Console.WriteLine("\n\nPlease enter a string to validate for isogram properties:");
                        var isIsogramInput = Console.ReadLine();
                        Console.WriteLine($"IsIsogram returned '{cm.IsIsogram(isIsogramInput)}'");
                        break;

                    case '5':
                        Console.WriteLine("\n\nPlease enter a number to convert it to a month:");
                        var monthInput = Console.ReadLine();
                        if (int.TryParse(monthInput, out int monthNumber))
                        {
                            try
                            {
                                Console.WriteLine($"MonthName returned '{cm.MonthName(monthNumber)}'");
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine($"Invalid number: {e.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Could not parse, please select new task:\n");
                        }
                        break;

                    case '6':
                        Console.WriteLine("\n\nPlease enter a string to convert it to numbers by the letter:");
                        var toNumbersConversionInput = Console.ReadLine();
                        Console.WriteLine($"AlphabetIndex returned '{cm.AlphabetIndex(toNumbersConversionInput)}'");
                        break;

                    case '0':
                        return; // exits the program

                    default:
                        Console.WriteLine("\n\nUnknown choice, please choose again:\n");
                        break;
                }
            }
            while (true);
        }
        
    }
}
