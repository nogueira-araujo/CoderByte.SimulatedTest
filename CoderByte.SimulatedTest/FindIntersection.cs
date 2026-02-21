using System;
using System.Collections.Generic;
using System.Text;

namespace CoderByte.SimulatedTest
{
    internal class FindIntersection
    {
        public static string FindInter(params string[] strArr)
        {
            int[] intArray1 = strArr[0].Split(',').Select(x => int.Parse(x.Trim())).ToArray();
            int[] intArray2 = strArr[1].Split(',').Select(x => int.Parse(x.Trim())).ToArray();

            var intersection = intArray1.Intersect(intArray2).ToArray();
            return intersection.Length > 0 ? string.Join(",", intersection) : "false";
        }
    }
}
