using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    static class Problem050
    {
        public static long Solve()
        {
            var longest = 0;
            var count = 0;
            var limit = 1000000;
            var primes = new PrimeNumbers(limit);
            var test = 0;
            var queue = new Queue<int>();

            foreach (var prime in primes)
            {
                test += prime;
                if (test >= limit)
                    break;

                queue.Enqueue(prime);

                if (primes.IsPrime(test) && queue.Count > count)
                {
                    longest = test;
                    count = queue.Count;
                }
            }

            while (!primes.IsPrime(test))
            {
                queue.Dequeue();
                test = queue.Sum();

                if (primes.IsPrime(test) && queue.Count > count)
                {
                    longest = test;
                    count = queue.Count;
                }
            }

            return longest;
        }
    }
}
