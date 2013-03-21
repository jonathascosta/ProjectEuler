using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem010
    {
        /// <remarks>
        /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        /// Find the sum of all the primes below two million.
        /// </remarks>
        public static long Solve()
        {
            long sum = 2;
            long max = 2000000;

            for (long i = 3; i < max; i += 2)
                if (i.IsPrime())
                    sum += i;

            return sum;
        }
    }
}
