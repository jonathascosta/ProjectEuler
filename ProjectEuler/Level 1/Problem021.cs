using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem021
    {
        /// <remarks>
        /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
        /// If d(a) = b and d(b) = a, where a != b, then a and b are an amicable pair and each of a and b are called amicable numbers.
        /// 
        /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
        /// 
        /// Evaluate the sum of all the amicable numbers under 10000.
        /// </remarks>
        public static long Solve()
        {
            int max = 10000;
            long[] d = new long[max];
            long sum = 0;

            for (long i = 2; i < max; i++)
            {
                d[i] = i.GetProperDivisors().Sum();
            
                if (d[i] > 1 && d[i] < max && d[i] != i && d[d[i]] == i)
                    sum += i + d[i];
            }

            return sum;
        }
    }
}
