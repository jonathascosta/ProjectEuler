using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem006
    {
        /// <remarks>
        /// The sum of the squares of the first ten natural numbers is,
        /// 12 + 22 + ... + 102 = 385
        /// The square of the sum of the first ten natural numbers is,
        /// (1 + 2 + ... + 10)2 = 552 = 3025
        /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025  385 = 2640.
        /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        /// </remarks>
        public static long Solve()
        {
            long max = 100;
            long diff = 0;

            for (long i = 1; i <= max; i++)
                for (long j = i + 1; j <= max; j++)
                    diff += 2 * i * j;

            return diff;
        }
    }
}
