using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    static class Problem055
    {
        public static long Solve()
        {
            long count = 0;

            for (long i = 1; i <= 10000; i++)
            {
                BigInteger b = i + i.Reverse();
                var n = 1;
                while (!b.IsPalindrome() && n <= 50)
                {
                    b = b + b.Reverse();
                    n++;
                }

                if (!b.IsPalindrome())
                    count++;
            }

            return count;
        }
    }
}
