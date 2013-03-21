using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem045
    {
        public static long Solve()
        {
            long t, h;

            h = 144;
            while (true)
            {
                t = (h * 2) - 1;
                var number = T(t);
                if (number == H(h))
                    foreach (var p in Baskara(3.0 / 2.0, -1.0 / 2.0, -number))
                        if (p > 0 && (p == (int)p))
                            if (P((int)p) == number)
                                return number;

                h++;
            }
        }

        static long H(long n)
        {
            return n * (2 * n - 1);
        }

        static long T(long n)
        {
            return n * (n + 1) / 2;
        }

        static long P(long n)
        {
            return n * (3 * n - 1) / 2;
        }

        static double[] Baskara(double a, double b, double c)
        {
            double delta = (float)Math.Sqrt(b * b - 4 * a * c);
            double x0 = (-b + delta) / (2 * a);
            double x1 = (-b - delta) / (2 * a);

            return new double[] { x0, x1 };
        }
    }
}
