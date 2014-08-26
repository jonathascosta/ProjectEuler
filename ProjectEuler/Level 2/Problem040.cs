using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public static class Problem040
    {
        public static long Solve()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 1000000; i++)
                sb.Append(i);

            return (long)char.GetNumericValue(sb[1 - 1]) *
                   (long)char.GetNumericValue(sb[10 - 1]) *
                   (long)char.GetNumericValue(sb[100 - 1]) *
                   (long)char.GetNumericValue(sb[1000 - 1]) *
                   (long)char.GetNumericValue(sb[10000 - 1]) *
                   (long)char.GetNumericValue(sb[100000 - 1]) *
                   (long)char.GetNumericValue(sb[1000000 - 1]);
        }
    }
}
