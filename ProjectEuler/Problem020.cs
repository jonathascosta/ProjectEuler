using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    static class Problem020
    {
        /// <remarks>
        /// n! means n  (n  1)  ...  3  2  1
        /// For example, 10! = 10 . 9  ...  3 . 2 . 1 = 3628800,
        /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
        /// Find the sum of the digits in the number 100!
        /// </remarks>
        public static long Solve()
        {
            int max = 100;
            BigInteger number = max.GetFactorial();
            long sum = 0;
            
            while (number > 0)
            {
                sum += (long)(number % 10);
                number /= 10;
            }

            return sum;
        }
    }
}
