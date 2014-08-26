using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem034
    {
        public static long Solve()
        {
            long sum = 0;
            int[] fat = new int[10];

            fat[0] = 1;
            for (int i = 1; i < 10; i++)
                fat[i] = fat[i - 1] * i;

            for (int i = 3; i < 2999999; i++)
            {
                int f = i.GetDigits().Select(d => fat[d]).Sum();
                if (i == f)
                    sum += i;
            }

            return sum;
        }
    }
}
