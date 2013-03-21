using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;

namespace ProjectEuler
{
    static class MathExtensions
    {
        public static IDictionary<long, IList<long>> PrimeFactors = new Dictionary<long, IList<long>>();

        public static bool IsPrime(this int number)
        {
            return IsPrime((long)number);
        }

        public static bool IsPrime(this long number)
        {
            if (number < 2)
                return false;

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

        public static bool IsAbundant(this long number)
        {
            return (number.GetProperDivisors().Sum() > number);
        }

        public static long phi(this long number)
        {
            var primes = number.GetPrimeFactors().Distinct();
            var returnValue = number * primes.Select(p => 1 - 1.0 / p).Aggregate((a, b) => a * b);
            return (long)returnValue;
        }

        public static IEnumerable<long> GetPrimeFactors(this long number)
        {
            if (PrimeFactors.ContainsKey(number))
                return PrimeFactors[number];

            var original = number;
            var factors = new List<long>();
            double limit = Math.Max(2, Math.Sqrt(number));

            while (number != 1)
            {
                for (long i = 2; i <= number; i++)
                    if (number % i == 0)
                    {
                        factors.Add(i);
                        number /= i;
                        break;
                    }

                if (PrimeFactors.ContainsKey(number))
                {
                    factors.AddRange(PrimeFactors[number]);
                    break;
                }
            }

            PrimeFactors.Add(original, factors);
            return factors;
        }

        public static IEnumerable<long> GetFactors(this long number)
        {
            if (number <= 1)
                throw new ArgumentOutOfRangeException();

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

        public static IEnumerable<long> GetProperDivisors(this long number)
        {
            if (number <= 1)
                throw new ArgumentOutOfRangeException();

            var factors = new List<long>(new long[] { 1 });
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

        public static BigInteger GetFactorial(this int number)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= number; i++)
                factorial *= i;

            return factorial;
        }

        public static int DigitCount(this long number)
        {
            return ((int)Math.Log10(number) + 1);
        }

        public static int DigitCount(this BigInteger number)
        {
            return (int)BigInteger.Log10(number) + 1;
        }

        public static bool IsResilientFraction(this int numerator, int denominator)
        {
            return IsResilientFraction((long)numerator, (long)denominator);
        }

        public static bool IsResilientFraction(this long numerator, long denominator)
        {
            return (!numerator.GetPrimeFactors()
                              .Intersect(denominator.GetPrimeFactors())
                              .Any());
        }

        public static void Swap(this IList<long> list, int a, int b)
        {
            var temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }

        public static IEnumerable<int> GetDigits(this long number)
        {
            while (number > 0)
            {
                yield return (int)(number % 10);
                number /= 10;
            }
        }

        public static IEnumerable<int> GetDigits(this BigInteger number)
        {
            while (number > 0)
            {
                yield return (int)(number % 10);
                number /= 10;
            }
        }

        public static long Reverse(this long number)
        {
            long acc = 0;
            foreach (var n in number.GetDigits())
            {
                acc *= 10;
                acc += n;
            }
            return acc;
        }

        public static BigInteger Reverse(this BigInteger number)
        {
            BigInteger acc = 0;
            foreach (var n in number.GetDigits())
            {
                acc *= 10;
                acc += n;
            }
            return acc;
        }

        public static IEnumerable<int> GetDigits(this int number)
        {
            return GetDigits((long)number);
        }

        public static bool AreEqual<T>(this IEnumerable<T> a, IEnumerable<T> b)
        {
            var ea = a.GetEnumerator();
            var eb = b.GetEnumerator();

            while (ea.MoveNext() && eb.MoveNext())
                if (!ea.Current.Equals(eb.Current))
                    return false;

            return true;
        }

        public static long ToBase(this int a, int newBase)
        {
            var quotient = a / newBase;
            var remainder = a % newBase;

            var stack = new Stack<int>();
            stack.Push(remainder);

            while (quotient >= newBase)
            {
                remainder = quotient % newBase;
                stack.Push(remainder);

                quotient /= newBase;
            }

            stack.Push(quotient);

            var number = 0L;
            while (stack.Any())
            {
                number *= 10;
                number += stack.Pop();
            }

            return number;
        }

        public static IEnumerable<int> GetDigits(this int a, int newBase)
        {
            while (a > 0)
            {
                yield return a % newBase;
                a /= newBase;
            }
        }

        public static bool IsPalindromic(this int i)
        {
            return IsPalindromic((long)i);
        }

        public static bool IsPalindromic(this long i)
        {
            return i.GetDigits().SequenceEqual(i.GetDigits().Reverse());
        }

        public static bool IsPalindrome(this BigInteger number)
        {
            return number.GetDigits().SequenceEqual(number.GetDigits().Reverse());
        }
    }
}
