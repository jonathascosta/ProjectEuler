using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem023
    {
        /// <remarks>
        /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
        /// 
        /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
        /// 
        /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
        /// 
        /// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
        /// </remarks>
        public static long Solve()
        {
            int max = 28125;
            long[] numbers = new long[max];
            var abundants = new List<long>();

            for (int i = 1; i < max; i++)
                numbers[i] = i;

            for (long i = 2; i < max; i++)
            {
                if (i.IsAbundant())
                {
                    if (i * 2 < max)
                        numbers[i * 2] = 0;

                    foreach (var abundant in abundants)
                        if (i + abundant < max)
                            numbers[i + abundant] = 0;

                    abundants.Add(i);
                }
            }

            return numbers.Sum();
        }
    }
}
