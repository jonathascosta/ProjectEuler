using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    static class Problem026
    {
        public static long Solve()
        {
            long longest = 0, longestLength = 0;
            int max = 1000;

            for (long d = 2; d < max; d++)
            {
                var remainders = new List<long>();
                long numerator = (long)Math.Pow(10, d.DigitCount());
                string result = "";

                while (true)
                {
                    var quotient = numerator / d;
                    var remainder = numerator % d;

                    if (remainder == 0)
                        break;

                    if (remainders.Contains(remainder))
                    {
                        if (result.Length > longestLength)
                        {
                            longest = d;
                            longestLength = result.Length;
                        }

                        break;
                    }

                    remainders.Add(remainder);
                    numerator = remainder * 10;
                    result += quotient.ToString();
                }
            }

            return longest;
        }
    }
}
