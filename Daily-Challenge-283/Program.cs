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

            Console.ReadLine();
        }

        static string Check(string input)
        {
            // Split the input string
            char[] delimiter = { '?' };            
            var words = input.Split(delimiter);

            // Preserve both parts of input string in two variables
            var f = words[0].Substring(0, words[0].Length - 1);
            var s = words[1].Substring(1);

            // Remove non-alphabetical characters
            var reg = new Regex("[^a-zA-Z?]");
            var first = reg.Replace(words[0].ToLower(), "");
            var second = reg.Replace(words[1].ToLower(), "");

            // Start checking letters
            var temp = "";
            for (int i = 0; i < second.Length; i++)
            {
                if (first.Contains(second[i]))
                {
                    temp += second[i];
                    first = Trim(first, second[i]);
                }
            }

            // If all letters are used AND there are no letters remaining, it's an anagram
            if (temp == second && first == "")
            {
                return string.Format("'{0}' is an anagram of '{1}'", f, s);
            }

            // Not an anagram
            return string.Format("'{0}' is NOT an anagram of '{1}'", f, s);
        }

        static string Trim(string letters, char letter)
        {
            string temp = "";

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters.IndexOf(letter) != -1)
                {
                    temp = letters.Remove(letters.IndexOf(letter), 1);
                    break;
                }
            }

            if (temp != letters)
            {
                return temp;
            }
            return letters;
        }
    }
}