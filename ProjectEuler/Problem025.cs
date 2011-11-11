using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    static class Problem025
    {
        public static long Solve()
        {
            BigInteger f1 = 1;
            BigInteger f2 = 1;
            BigInteger f3 = f1 + f2;
            long nth = 3;
            BigInteger fn = BigInteger.Pow(10, 999);

            while (f3 < fn)
            {
                f1 = f2;
                f2 = f3;
                f3 = f1 + f2;
                nth++;
            }

            return nth;
        }
    }
}
