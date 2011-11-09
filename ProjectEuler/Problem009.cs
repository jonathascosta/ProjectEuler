using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem009
    {
        /// <remarks>
        /// A Pythagorean triplet is a set of three natural numbers, a  b  c, for which,
        /// a2 + b2 = c2
        /// For example, 32 + 42 = 9 + 16 = 25 = 52.
        /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
        /// Find the product abc.
        /// </remarks>
        public static long Solve()
        {
            int sum = 1000;
            for (int a = 1; a < sum; a++)
                for (int b = a + 1; b < sum; b++)
                    for (int c = b + 1; c < sum; c++)
                        if ((a + b + c == sum) && (a * a + b * b == c * c))
                            return a * b * c;

            throw new Exception();
        }
    }
}
