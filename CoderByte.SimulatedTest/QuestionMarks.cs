using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CoderByte.SimulatedTest
{
    internal static class QuestionMarks
    {
        public static string QuestionsMarks(string str)
        {
            bool foundPair = false;

            int? lastDigit = null;
            int questionCount = 0;

            foreach (char c in str)
            {
                if (c == '?')
                {
                    if (lastDigit.HasValue)
                        questionCount++;
                    continue;
                }

                if (c >= '0' && c <= '9')
                {
                    int currentDigit = int.Parse(c.ToString());

                    if (lastDigit.HasValue)
                    {
                        if (lastDigit.Value + currentDigit == 10)
                        {
                            foundPair = true;
                            if (questionCount != 3)
                                return "false";
                        }
                    }

                    lastDigit = currentDigit;
                    questionCount = 0;
                }
                
            }

            if (foundPair)
                return "true";
            else
                return "false";
        }
    }
}
