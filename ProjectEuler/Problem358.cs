using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler
{
    static class Problem358
    {
        public static long Solve()
        {
            int min = (int)(1 / 0.00000000138);
            int max = (int)(1 / 0.00000000137);

            for (int i = min; i < max; i++)
            {
                // Last 5 digits (56789) * i ends up in 99999,
                // which means i ends up in 09891
                if (i % 100000 == 09891)
                {
                    if (i.IsPrime())
                    {
                        long numerator = 10;
                        var suffix = 0L;

                        for (int j = 0; j <= (i - 1) / 2; j++)
                        {
                            var quotient = numerator / i;
                            var remainder = numerator % i;
                            if ((quotient != 0) && (remainder == 1 || remainder % 10 == 0))
                                break;

                            numerator = remainder * 10;

                            if (j >= ((i - 1) / 2) - 5)
                            {
                                suffix *= 10;
                                suffix += quotient;

                                if (j == ((i - 1) / 2) - 1)
                                {
                                    if (suffix == 43210)
                                        return 9L * ((i - 1) / 2);

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            throw new ApplicationException();
        }
    }
}
