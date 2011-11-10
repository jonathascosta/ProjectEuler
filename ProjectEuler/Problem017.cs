using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem017
    {
        public static long Solve()
        {
            IDictionary<int, int> number = new Dictionary<int, int>();
            number.Add(1, "one".Length);
            number.Add(2, "two".Length);
            number.Add(3, "three".Length);
            number.Add(4, "four".Length);
            number.Add(5, "five".Length);
            number.Add(6, "six".Length);
            number.Add(7, "seven".Length);
            number.Add(8, "eight".Length);
            number.Add(9, "nine".Length);
            number.Add(10, "ten".Length);
            number.Add(11, "eleven".Length);
            number.Add(12, "twelve".Length);
            number.Add(13, "thirteen".Length);
            number.Add(14, "fourteen".Length);
            number.Add(15, "fifteen".Length);
            number.Add(16, "sixteen".Length);
            number.Add(17, "seventeen".Length);
            number.Add(18, "eighteen".Length);
            number.Add(19, "nineteen".Length);
            number.Add(20, "twenty".Length);
            number.Add(30, "thirty".Length);
            number.Add(40, "forty".Length);
            number.Add(50, "fifty".Length);
            number.Add(60, "sixty".Length);
            number.Add(70, "seventy".Length);
            number.Add(80, "eighty".Length);
            number.Add(90, "ninety".Length);

            int max = 1000;
            long sum = 0;
            int and = "and".Length;
            int hundred = "hundred".Length;
            int thousand = "thousand".Length;

            for (int i = 0; i <= max; i++)
            {
                var n = i;
                if (n >= 1000)
                {
                    sum += number[n / 1000] + thousand;
                    n %= 1000;
                }

                if (n >= 100)
                {
                    sum += number[n / 100] + hundred;
                    n %= 100;
                    if (n > 0)
                        sum += and;
                }

                if (n >= 20)
                {
                    sum += number[(n / 10) * 10];
                    n %= 10;
                }

                if (n > 0)
                    sum += number[n];
            }

            return sum;
        }
    }
}
