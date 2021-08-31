using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHQ_Record_Generator.Baseclass
{
    class cRandom
    {
        private static Random rnd = new Random();

        public static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));

        }
        public static int Random(int Min, int Max)
        {
            return rnd.Next(Min, Max);
        }
        public static String RandomNumber(int requestedLength)
        {
            StringBuilder strB = new StringBuilder();
            //int iMax=10 ^ (requestedLength -1);
            /*
            string Format = new String('0', requestedLength);

            if(requestedLength
            long iMax = int.Parse("1" + new String('0', requestedLength - 1));
           
            string Result = rnd.Next(1, iMax).ToString(Format);
             */
            int i;
            for (i = 0; i < requestedLength; i++)
            {
                strB.Append(rnd.Next(1, 9));
                if (strB.ToString().Length == requestedLength)
                {
                    break;
                }
            }
            return strB.ToString();

        }

        public static string WordFinder2(int requestedLength)
        {
            //Random rnd = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };

            string word = "";

            if (requestedLength == 1)
            {
                word = GetRandomLetter(rnd, vowels);
            }
            else
            {
                for (int i = 0; i < requestedLength; i += 2)
                {
                    word += GetRandomLetter(rnd, consonants) + GetRandomLetter(rnd, vowels);
                }

                word = word.Replace("q", "qu").Substring(0, requestedLength); // We may generate a string longer than requested length, but it doesn't matter if cut off the excess.
            }

            return word;
        }

        private static string GetRandomLetter(Random rnd, string[] letters)
        {
            return letters[rnd.Next(0, letters.Length - 1)];
        }
    }
}
