using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DailyChallenge283
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Check("Clint Eastwood ? Old West Action"));
            Console.WriteLine(Check("parliament ? partial man"));
            Console.WriteLine(Check("wisdom ? mid sow"));
            Console.WriteLine(Check("Seth Rogan ? Gathers No"));
            Console.WriteLine(Check("Reddit ? Eat Dirt"));
            Console.WriteLine(Check("Schoolmaster ? The classroom"));
            Console.WriteLine(Check("Astronomers ? Moon starer"));
            Console.WriteLine(Check("Vacation Times ? I'm Not as Active"));
            Console.WriteLine(Check("Dormitory ? Dirty Rooms"));
            Console.WriteLine(Check("hh ? h"));

            Console.ReadLine();
        }

        static string Check(string input)
        {
            // Split the input string
            var words = input.Split(new char[] { '?' });

            // Preserve both parts of input string in two variables
            var f = words[0].Substring(0, words[0].Length - 1);
            var s = words[1].Substring(1);

            // Remove non-alphabetical characters
            var reg = new Regex("[^a-z?]");
            var first = reg.Replace(words[0].ToLower(), "");
            var second = reg.Replace(words[1].ToLower(), "");

            // Start checking letters
            var temp = "";
            for (int i = 0; i < second.Length; i++)
            {
                if (first.Contains(second[i]))
                {
                    temp += second[i];
                    first = first.Remove(first.IndexOf(second[i]), 1);
                }
            }

            // If all letters are used AND there are no letters remaining, it's an anagram
            if (temp == second && first == "")
            {
                return $"'{f}' is an anagram of '{s}'";
            }

            // Not an anagram
            return $"'{f}' is NOT an anagram of '{s}'";
        }
    }
}