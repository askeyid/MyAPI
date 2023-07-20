using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Framework.Utility
{
    public class TestDataGenerator
    {
        private static Random random = new Random();
        private static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static string RandomEmail(int min = 7, int max = 15, string domain = "gmail.com")
        {
            var stringLength = random.Next(min, max);
            var localPart = new string(Enumerable.Repeat(alphabet, stringLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            var email = localPart + "@" + domain;

            return email;
        }

        public static string RandomString(int min, int max)
        {
            var stringLength = random.Next(min - 1, max - 1);
            var letterIndex = random.Next(alphabet.Length);
            var firstLetter = char.ToUpper(alphabet[letterIndex]);
            var rndString = firstLetter + new string(Enumerable.Repeat(alphabet, stringLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return rndString;
        }
    }
}
