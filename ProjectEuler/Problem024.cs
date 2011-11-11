using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem024
    {
        public static string Solve()
        {
            int n = 10;
            var a = new List<long>(n);
            int desiredIndex = 1000000;

            for (int i = 0; i < n; i++)
                a.Add(i);

            for (int index = 1; index < desiredIndex; index++)
                for (int k = n - 1; k >= 0; k--)
                    if (a[k - 1] < a[k])
                    {
                        for (int l = n - 1; l > k - 1; l--)
                            if (a[k - 1] < a[l])
                            {
                                a.Swap(k - 1, l);
                                a.Reverse(k, n - k);
                                break;
                            }

                        break;
                    }

            return string.Join("", a);
        }
    }
}
