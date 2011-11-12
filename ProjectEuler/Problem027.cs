using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem027
    {
        public static long Solve()
        {
            long max = 1000;
            var aOpts = new List<long>();
            var bOpts = new List<long>();
            var coefs = new List<coef>();

            for (long i = 2; i < max; i++)
                if (i.IsPrime())
                    bOpts.Add(i);

            long n = 1;
            for (int a = -999; a < 1000; a++)
                foreach (var b in bOpts)
                    if (f(n, a, b).IsPrime())
                        coefs.Add(new coef(a, b));

            n = 2;
            while (coefs.Count > 1)
            {
                var coefsToRemove = new List<coef>();

                foreach (var c in coefs)
                    if (!f(n, c.a, c.b).IsPrime())
                        coefsToRemove.Add(c);

                foreach (var c in coefsToRemove)
                    coefs.Remove(c);

                n++;
            }

            return coefs[0].a * coefs[0].b;
        }

        struct coef
        {
            public coef(long a, long b)
            {
                this.a = a;
                this.b = b;
            }

            public long a;
            public long b;
        }

        private static long f(long n, long a, long b)
        {
            return n * n + a * n + b;
        }
    }
}
