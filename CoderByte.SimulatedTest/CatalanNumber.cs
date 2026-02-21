using System;
using System.Collections.Generic;
using System.Text;

namespace CoderByte.SimulatedTest
{
    internal class CatalanNumber
    {
        public static long Catalan(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Input must be a non-negative integer.");
                return -1; // Return -1 to indicate an error
            }
            try
            {
                //using the formula C(n) = (2n)! / ((n + 1)! * n!)
                long numerator = Factorial(2 * n);
                long denominator = Factorial(n + 1) * Factorial(n);
                return numerator / denominator;
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("Input is too large to compute the factorial.");
                return -1; // Return -1 to indicate an error
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return -1; // Return -1 to indicate an error
            }
        }

        private static long Factorial(int num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }
            else
            {
                return num * Factorial(num - 1);
            }
        }
    }

}
