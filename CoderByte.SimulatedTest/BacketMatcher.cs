using System;
using System.Collections.Generic;
using System.Text;

namespace CoderByte.SimulatedTest
{
    internal sealed class BacketMatcher
    {
        public static string IsMatch(string str)
        {
            int count = 0;
           foreach (char c in str) { 
               if (c == '(') count++;
               else if (c == ')') count--;
               if (count < 0) return "false";
            }

           if(count == 0) return "true";
            return "false";
        }
    }
}
