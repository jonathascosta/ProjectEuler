using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem049
    {
        public static long Solve()
        {
            long answer = 0;
            var primes = new PrimeNumbers(10000);

            for (int i = 2; i < 4500; i++)
            {
                for (int j = 1001; j < 5500; j += 2)
                {
                    if (j == 1487 && i == 3330)
                        continue;

                    // 1. First check
                    if (j.IsPrime() && (j + i).IsPrime() && (j + i + i).IsPrime())
                    {
                        var js = j.GetDigits().OrderBy(x => x);
                        var jis = (j + i).GetDigits().OrderBy(x => x);
                        var jiis = (j + i + i).GetDigits().OrderBy(x => x);
                        if (js.SequenceEqual(jis) && jis.SequenceEqual(jiis))
                        {
                            answer = j;
                            answer *= 10000;
                            answer += j + i;
                            answer *= 10000;
                            answer += j + i + i;
                            return answer;
                        }
                    }
                }
            }

            return answer;
        }
    }
}
