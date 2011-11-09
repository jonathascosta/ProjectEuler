using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class MathExtensions
    {
        public static bool IsPrime(this long number)
        {
            double limit = Math.Sqrt(number);

            for (int i = 2; i <= limit; i++)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static bool IsEven(this long number)
        {
            return (number % 2 == 0);
        }

        public static IEnumerable<long> GetPrimeFactors(this long number)
        {
            var factors = new List<long>();
            double limit = Math.Max(2, Math.Sqrt(number));

            while (number != 1)
                for (long i = 2; i <= number; i++)
                    if (number % i == 0)
                    {
                        factors.Add(i);
                        number /= i;
                        break;
                    }

            return factors;
        }

        public static IEnumerable<long> GetFactors(this long number)
        {
            var factors = new List<long>(new long[] { 1, number });
            double root = Math.Sqrt(number);

            for (long i = 2; i < root; i++)
                if (number % i == 0)
                {
                    factors.Add(i);
                    factors.Add(number / i);
                }

            if ((long)root == root)
                factors.Add((long)root);

            return factors;
        }
    }
}
