using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProjectEuler
{
    static class Problem233
    {
        public static long Solve()
        {
            double SQRT2 = Math.Sqrt(2);
            long VAL = 420;
            var lista = new List<long>();

            var SLICE = 4; // 45°
            long SLICE_VAL = (VAL / 2) / SLICE;
            double SLICE_ANG = Math.Cos(Math.PI / SLICE);

            long LIM = 100000000000;
            //long LIM = 10000;
            long answer = 0;
            long max = 0;

            long INI = SLICE_VAL;

            //Parallel.For(SLICE_VAL, LIM, N =>
            // 3002033
            for (long N = INI; N <= LIM; N++)
            {
                //if (N % 1000 == 0)
                //    Debug.WriteLine("{0}: {1}", DateTime.Now, N);

                int count = 0;
                var x0 = (long)((N * SQRT2 / 2) * SLICE_ANG + (N / 2.0)) + 1;
                var x1 = (N * (1 + SQRT2) / 2);

                for (long x = x0; x <= x1; x++)
                {
                    double y = (N + Math.Sqrt(N * N - 4 * (x * x - N * x))) / 2;

                    if (y == (int)y)
                    {
                        count++;
                        //var teta = Math.Acos((x - N / 2.0) / (N * SQRT2));
                        //Debug.WriteLine("({0}, {1}) : {2}°, ", x, (long)y, (teta / Math.PI) * 180);
                    }

                    if (count > SLICE_VAL)
                        break;
                }

                if (count > max)
                    max = count;

                if (count == SLICE_VAL)
                {
                    lista.Add(N);
                    answer += N;
                }
            }
            //);

            return answer;
        }
    }
}
