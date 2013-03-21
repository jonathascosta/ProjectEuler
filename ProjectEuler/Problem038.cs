using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem038
    {
        public static long Solve()
        {
			var sequence = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            long largest = 0;
            for (int i = 1; i < 9999; i++)
            {
                var number = 0;
                for (int j = 1; j < 9; j++)
                {
                    var n = i * j;
                    var digitCount = n.GetDigits().Count();
                    var shift = (int)Math.Pow(10, digitCount);
                    number *= shift;
                    number += n;

                    if (number.GetDigits().Count() < 9)
                        continue;

                    if (number.GetDigits().Count() == 9 && number > largest && sequence.SequenceEqual(number.GetDigits().OrderBy(x => x)) )
                        largest = number;
                }
            }
            return largest;
        }
    }
}
