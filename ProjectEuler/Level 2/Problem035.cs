using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem035
    {
        public static long Solve()
        {
            // 2, 3, 5, 7
            long answer = 4;

            for (int i = 11; i < 1000000; i += 2)
            {
                if (i.IsPrime())
                {
                    var found = true;
                    int count = i.GetDigits().Count();
                    int m = (int)Math.Pow(10, count - 1);
                    var c = (i % m) * 10 + (i / m);
                    for (int j = 0; j < count - 1; j++)
                    {
                        if (!c.IsPrime())
                        {
                            found = false;
                            break;
                        }
                        c = (c % m) * 10 + (c / m);
                    }

                    if (found)
                        answer++;
                }
            }
            // 987654321
            
            return answer;
        }
    }
}
