using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem036
    {
        public static long Solve()
        {
            long answer = 0;

            for (int i = 1; i < 1000000; i += 2)
            {
                if (i.IsPalindromic())
                {
                    var digits = i.GetDigits(2);
                    if (digits.SequenceEqual(digits.Reverse()))
                        answer += i;
                }
            }

            return answer;
        }
    }
}
