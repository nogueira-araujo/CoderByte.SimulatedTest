using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace CoderByte.SimulatedTest
{
    
    internal class LonguestWord
    {
        private const string REGEX = @"[^A-Za-z0-9\s]+";

        public static string LongestWord(string sen)
        {
            //cleaning the string and spliting it into words
            var splited = Regex.Replace(sen, REGEX, "").Split(" ");

            //getting the length of the longest word
            int maxLen = splited.OrderByDescending(x => x.Length).FirstOrDefault().Length;

            //returning the first word with the longest length
            return splited.Where(x => x.Length == maxLen).FirstOrDefault();
        }
    }
}
