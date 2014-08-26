using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem047
    {
        public static long Solve()
        {
            long answer = 0;
            long number = 2 * 3 * 5 * 7;
            int count = 0;
            int consecutive = 0;

            while (consecutive != 4)
            {
                count = number.GetPrimeFactors().Distinct().Count();
                if (count == 4)
                {
                    consecutive++;
                    if (consecutive == 1)
                        answer = number;
                }
                else
                {
                    consecutive = 0;
                }

                number++;
            }

            return answer;
        }
    }
}
