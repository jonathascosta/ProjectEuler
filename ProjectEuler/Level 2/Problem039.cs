using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem039
    {
        public static long Solve()
        {
            long[] p = new long[1001];

            for (int a = 0; a < 1000; a++)
            {
                for (int b = 0; b < 1000; b++)
                {
                    var c = Math.Sqrt(a * a + b * b);
                    if (((c / (long)c) == 1) && (a + b + c <= 1000))
                        p[a + b + (long)c]++;
                }
            }

            long answer = p.Select((v, i) => new { Index = i, Value = v }).OrderByDescending(x => x.Value).First().Index;
            return answer;
        }
    }
}
