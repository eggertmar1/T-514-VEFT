using System.Linq;
using System;
using System.Globalization;

namespace CleanThatCode.Community.Common
{
    // Your job is to implement this class
    public static class StringHelpers
    {
        // Instead of spaces it should be separated with dots, e.g. Hello World -> Hello.World
        public static string ToDotSeparatedString(this string str)
        {
            var new_str = str.Replace(' ', '.');
            return new_str;
        }
        
        // All words in the string should be capitalized, e.g. teenage mutant ninja turtles -> Teenage Mutant Ninja Turtles
        public static string CapitalizeAllWords(this string str)
        {
            string new_str = str;
            string title_str = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(new_str);
            /*
            TextInfo strInfo = new CultureInfo("en-us", false).TextInfo;
            string results = strInfo.ToTitleCase(inString);
            return "";
            */
            return title_str;
        }

        // The words should be reversed in the string, e.g. Hi Ho Silver Away! -> Away! Silver Ho Hi
        public static string ReverseWords(this string str)
        {
            //string str_split = str.Split();
            string reversed_str = "";
            foreach (string word in str.Split()){
                reversed_str = word + " " + reversed_str;
            }
            reversed_str = reversed_str.Remove(reversed_str.Length -1, 1);
            return reversed_str;
        }
    }
}