using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoderByte.SimulatedTest
{
    internal class ReverseString
    {
        public static string ReverseStr(string str)
        {
            //converting the string to char array and reverse it then convert it back to string
            return new string(str.ToCharArray().Reverse<char>().ToArray<char>());
        }
    }
}
