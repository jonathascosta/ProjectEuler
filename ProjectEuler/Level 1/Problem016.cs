using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    static class Problem016
    {
        public static long Solve()
        {
            BigInteger number = BigInteger.Pow(2, 1000);
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
