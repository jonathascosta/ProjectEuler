using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem037
    {
        public static long Solve()
        {
            int count = 0;
            int number = 11;
            int sum = 0;

            while (count < 11)
            {
                if (number.IsPrime())
                {
                    int right = number;
                    while (right.IsPrime() && right.GetDigits().Count() > 1)
                        right = right.GetDigits().Skip(1).Reverse().Aggregate((a, b) => a * 10 + b);

                    int left = number;
                    while (right.IsPrime() && left.IsPrime() && left.GetDigits().Count() > 1)
                        left = left.GetDigits().Reverse().Skip(1).Aggregate((a, b) => a * 10 + b);

                    if (right.IsPrime() && left.IsPrime())
                    {
                        count++;
                        sum += number;
                    }
                }

                number += 2;
            }
            return sum;
        }
    }
}
