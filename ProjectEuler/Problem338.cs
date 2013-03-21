using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem338
    {
        private static long[,] matrix = new long[11, 11];

        public static long Solve()
        {
            long answer = G(10);

            for (int i = 0; i <= 10; i++)
            {
                if (i > 0)
                    Console.Write("\r\n{0:d2} ", i);
                else
                    Console.Write("\r\n   ");

                for (int j = 1; j <= 10; j++)
                {
                    if (i > 0)
                        Console.Write("{0:d2} ", matrix[i, j]);
                    else
                        Console.Write("{0:d2} ", j);
                }
            }
            return answer;
        }

        private static long G(long n)
        {
            long sum = 0;

            for (int h = 1; h <= n; h++)
                for (int w = h; w <= n; w++)
                    if (!(((w % 2) == 1) && ((h % 2) == 1)))
                    {
                        Console.Write("\r\n({0},{1})\t=>\t", w, h);
                        matrix[w, h] = F(w, h);
                        sum += matrix[w, h];
                    }

            return sum;
        }

        private static int F(long w, long h)
        {
            int sum = 0;

            if (h == 1 & w > 2)
            {
                Console.Write("({1},{0});", h * 2, w / 2.0);
                sum++;
            }
            else
            {
                for (long i = 2; i <= h; i++)
                {
                    if ((i > 1) && ((h % i) == 0) && (w % (i - 1) == 0) && (h * ((i - 1.0) / i) != w))
                    {
                        Console.Write("({1},{0});", h * ((i - 1.0) / i), w * (i / (i - 1.0)));
                        sum++;
                    }
                    if (((h % i) == 0) && (w % (i + 1) == 0) && (h * ((i + 1.0) / i) != w))
                    {
                        Console.Write("({1},{0});", h * ((i + 1.0) / i), w * (i / (i + 1.0)));
                        sum++;
                    }
                }
                for (long i = 2; i <= w; i++)
                {
                    if ((i > 1) && ((w % i) == 0) && (h % (i - 1) == 0) && (w * ((i - 1.0) / i) != h))
                    {
                        Console.Write("({1},{0});", w * ((i - 1.0) / i), h * (i / (i - 1.0)));
                        sum++;
                    }
                    if (((w % i) == 0) && (h % (i + 1) == 0) && (w * ((i + 1.0) / i) != h))
                    {
                        Console.Write("({1},{0});", w * ((i + 1.0) / i), h * (i / (i + 1.0)));
                        sum++;
                    }
                }
            }

            return sum;
        }
    }
}
