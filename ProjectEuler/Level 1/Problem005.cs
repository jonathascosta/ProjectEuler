using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	static class Problem005
	{
        /// <remarks>
        /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        /// </remarks>
		public static long Solve()
		{
			var factors = new List<long>();
            long max = 20;

            for (long i = 2; i <= max; i++)
			{
				var tempFactors = new List<long>(factors);
				foreach (var f in i.GetPrimeFactors())
				{
					if (!tempFactors.Contains(f))
						factors.Add(f);

					tempFactors.Remove(f);
				}
			}

			long largest = factors.Aggregate((a, b) => a * b);
            return largest;
		}
	}
}
