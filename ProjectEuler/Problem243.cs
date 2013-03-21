using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem243
    {
        public static long Solve()
        {
            //long answer = 2L * 5L * 3L * 7L * 11L * 13L * 17L * 19L * 23L * 2L * 2L;
            double ratio = 15499.0 / 94744.0; //0.1635881955585578
            var primes = new PrimeNumbers();
            long denominator = 1L;
            double r = 1;

            foreach (var prime in primes)
            {
                // 2L * 5L * 3L * 7L * 11L * 13L * 17L * 19L * 23L
                r = (denominator * prime).phi() / ((denominator * prime) - 1.0);
                if (r > ratio)
                    denominator *= prime;
                else
                {
                    r = denominator.phi() / (denominator - 1.0);
                    break;
                }
            }
            
            while (r > ratio)
            {
                denominator *= primes.First();
                r = denominator.phi() / (denominator - 1.0);
                if (r < ratio)
                    break;
            }

            return denominator;
        }
    }
}
