using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem019
    {
        public static long Solve()
        {
            long sum = 0;
            DateTime date = new DateTime(1901, 1, 1);

            while (date.Year < 2001)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                    sum++;

                date = date.AddMonths(1);
            }

            return sum;
        }
    }
}
