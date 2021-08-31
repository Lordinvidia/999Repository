using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CHQ_Record_Generator.Baseclass
{
    class cUtil
    {
        public class cBetweenString
        {
            public int BeginIndex = -1;
            public int EndIndex = -1;
            private string _Text = "";
            public string Text
            {
                get { return _Text; }
            }
            public void LoadTextFrom(string strSource)
            {
                _Text = strSource.Substring(BeginIndex + 1, EndIndex - BeginIndex - 1);
            }
        }
        public static string GetStringBetween(string strSource, string Between, int NoofIndex)
        {
            //List<int> ListindexOfBetweenOdd = new List<int>();
            //List<int> ListindexofBetweenEven = new List<int>();
            List<cBetweenString> lstBetween = new List<cBetweenString>();
            int LastIndexof = int.MaxValue;
            cBetweenString CurrentBetween = new cBetweenString();
            String Result = null;
            while (LastIndexof > -1)
            {
                if (LastIndexof == int.MaxValue)
                {
                    LastIndexof = 0;
                }
                if (LastIndexof + 1 == strSource.Length)
                {
                    break;
                }
                LastIndexof = strSource.IndexOf(Between, LastIndexof + 1);
                if (LastIndexof > -1)
                {
                    if (CurrentBetween.BeginIndex == -1)
                    {
                        CurrentBetween.BeginIndex = LastIndexof;
                    }
                    else
                    {
                        CurrentBetween.EndIndex = LastIndexof;



                        if (lstBetween.Count == NoofIndex)
                        {
                            CurrentBetween.LoadTextFrom(strSource);
                            Result = CurrentBetween.Text;
                            break;
                        }
                        lstBetween.Add(CurrentBetween);

                        CurrentBetween = new cBetweenString();
                    }
                }
            }
            return Result;
        }
        public static List<String> GetUnitqueItem(string strLineofItems, string strDelimiter)
        {
            List<string> lst = new List<string>();
            string[] Arrstr = strLineofItems.Split(strDelimiter.ToCharArray()[0]);
            int i;
            for (i = 0; i < Arrstr.Length; i++)
            {
                String item = Arrstr[i];
                if (item.Trim() == "")
                {
                    continue;
                }
                bool IsExistInList = false;
                foreach (string itemExistsInList in lst)
                {
                    if (item == itemExistsInList)
                    {
                        IsExistInList = true;
                        break;
                    }
                }
                if (!IsExistInList)
                {
                    lst.Add(item);
                }
            }
            return lst;
        }

        public static List<String> GetItem(string strLineofItems, string strDelimiter)
        {
            List<string> lst = new List<string>();
            string[] Arrstr = strLineofItems.Split(strDelimiter.ToCharArray()[0]);
            int i;
            for (i = 0; i < Arrstr.Length; i++)
            {
                String item = Arrstr[i];
                if (item.Trim() == "")
                {
                    continue;
                }

                lst.Add(item);

            }
            return lst;
        }
        public static void CreateFileIfNotExist(string Path)
        {

            if (!System.IO.File.Exists(Path))
            {
                System.IO.File.Create(Path);
            }

        }
        public static void AppendFile(string Path, string Text)
        {
            try
            {
                using (System.IO.StreamWriter w = System.IO.File.AppendText(Path))
                {
                    w.WriteLine(Text);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void WriteFile(string str, string path)
        {

            String Dir = System.IO.Path.GetDirectoryName(path);
            if (!System.IO.Directory.Exists(Dir))
            {
                System.IO.Directory.CreateDirectory(Dir);
            }
            if (!System.IO.File.Exists(path))
            {

                System.IO.File.Create(path).Dispose();
            }
            System.IO.StreamWriter SW = new System.IO.StreamWriter(path);
            SW.Write(str);
            SW.Close();
        }


        public static string ReadFile(string Path)
        {
            using (FileStream file = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string str = "";
                    str = sr.ReadToEnd();
                    sr.Close();
                    return str;
                }
            }



        }

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
