using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    static class Problem052
    {
        public static long Solve()
        {
            var x = 1;
            while (true)
            {
                if (!(x * 2).GetDigits().OrderBy(i => i).SequenceEqual(x.GetDigits().OrderBy(i => i)))
                {
                    x++;
                    continue;
                }
                if (!(x * 3).GetDigits().OrderBy(i => i).SequenceEqual(x.GetDigits().OrderBy(i => i)))
                {
                    x++;
                    continue;
                }
                if (!(x * 4).GetDigits().OrderBy(i => i).SequenceEqual(x.GetDigits().OrderBy(i => i)))
                {
                    x++;
                    continue;
                }
                if (!(x * 5).GetDigits().OrderBy(i => i).SequenceEqual(x.GetDigits().OrderBy(i => i)))
                {
                    x++;
                    continue;
                }
                if (!(x * 6).GetDigits().OrderBy(i => i).SequenceEqual(x.GetDigits().OrderBy(i => i)))
                {
                    x++;
                    continue;
                }

                break;
            }

            return x;
        }
    }
}
