using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    static class Problem048
    {
        public static long Solve()
        {
            long answer = 0;

            BigInteger sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                sum += BigInteger.Pow(i, i);
            }
            answer = (long)(sum % 10000000000);
            return answer;
        }
    }
}
