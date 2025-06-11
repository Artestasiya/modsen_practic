using System;
using System.Collections.Generic;

namespace CW
{
    class UrlShortener
    {
        private Dictionary<string, string> longToShort = new Dictionary<string, string>();
        private Dictionary<string, string> shortToLong = new Dictionary<string, string>();
        private int counter = 0;
        private const string letters = "abcdefghijklmnopqrstuvwxyz";

        public string Shorten(string longURL)
        {
            if (longToShort.ContainsKey(longURL))
            {
                return longToShort[longURL];
            }

            string shortCode = GenerateLetterCode(counter);
            counter++;

            string shortURL = "short.ly/" + shortCode;

            longToShort[longURL] = shortURL;
            shortToLong[shortURL] = longURL;

            return shortURL;
        }

        public string Redirect(string shortURL)
        {
            if (shortToLong.TryGetValue(shortURL, out var longURL))
            {
                return longURL;
            }
            throw new Exception("URL not found");
        }

        private string GenerateLetterCode(int number)
        {
            string code = "";
            do
            {
                code = letters[number % letters.Length] + code;
                number = number / letters.Length - 1;
            } while (number >= 0);

            return code.Length > 4 ? code.Substring(0, 4) : code;
        }
    }
}