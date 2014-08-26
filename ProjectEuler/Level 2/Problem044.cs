using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem044
    {
        static int limit = 10000;
        static long[] p = new long[limit];

        public static long Solve()
        {
            long answer = long.MaxValue;

            for (long i = 0; i < limit; i++)
                p[i] = P(i);

            for (int j = 1; j < limit; j++)
            {
                for (int k = j + 1; k < limit; k++)
                {
                    var sum = p[j] + p[k];
                    if (!IsPentagonal(sum))
                        continue;

                    var diff = p[k] - p[j];
                    if (!IsPentagonal(diff))
                        continue;

                    var D = Math.Abs(diff);
                    if (D < answer)
                        answer = D;
                }
            }

            return answer;
        }

        public static long P(long n)
        {
            return n * (3 * n - 1) / 2;
        }

        static bool IsPentagonal(long n)
        {
            for (long i = 0; i < limit; i++)
            {
                if (p[i] == n)
                    return true;

                if (p[i] > n)
                    return false;
            }

            return false;
        }
    }
}
