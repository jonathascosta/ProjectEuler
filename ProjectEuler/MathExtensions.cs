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

        public static IEnumerable<long> GetFactors(this long number)
        {
            if (number.IsPrime())
                return new long[] { number };

            var factors = new List<long>();
            double limit = Math.Sqrt(number);

            while (number != 1)
                for (long i = 2; i <= limit; i++)
                    if (number % i == 0 && i.IsPrime())
                    {
                        factors.Add(i);
                        number /= i;
                        if (number.IsPrime())
                        {
                            factors.Add(number);
                            number /= number;
                        }
                        break;
                    }

            return factors;
        }
    }
}
