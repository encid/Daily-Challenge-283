using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChallenge283
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine(Check("Clint Eastwood", "Old West Action"));
            //Console.WriteLine(Check("parliament", "partial man"));
            //Console.WriteLine(Check("wisdom", "mid sow"));            

            Console.WriteLine(Check("wisdom ? mid sow"));
            Console.WriteLine(Check("Seth Rogan ? Gathers No"));
            Console.WriteLine(Check("Reddit ? Eat Dirt"));
            Console.WriteLine(Check("Schoolmaster ? The classroom"));
            Console.WriteLine(Check("Astronomers ? Moon starer"));
            Console.WriteLine(Check("Vacation Times ? Im Not as Active"));
            Console.WriteLine(Check("Dormitory ? Dirty Rooms"));

            Console.ReadLine();
        }

        static string Check(string input)
        {
            var ls = input.ToLower().Replace(" ", "");

            char[] delimiter = { '?' };
            var s = ls.Split(delimiter);

            var f = s[0];
            var first = s[0];
            var second = s[1];
            var temp = "";

            for (int i = 0; i < second.Length; i++)
            {
                if (first.Contains(second[i]))
                {
                    temp += second[i];
                    first = Trim(first, second[i]);
                }
            }
            if (temp == second && first == "")
            {
                return string.Format("'{0}' is an anagram of '{1}'", f, second);
            }
            return string.Format("'{0}' is NOT an anagram of '{1}'", f, second);
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
