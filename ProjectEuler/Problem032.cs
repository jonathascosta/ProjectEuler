using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	static class Problem032
	{
		public static long Solve()
		{
			var sequence = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			var sums = new List<long>();

			for (long i = 1; i <= 99; i++)
			{
				for (long j = 1; j <= 9999; j++)
				{
					long k = i * j;
					List<int> digits = i.GetDigits().ToList();
					digits.AddRange(j.GetDigits());
					digits.AddRange(k.GetDigits());

					if (digits.Count != 9)
						continue;

					bool isPanDigital = digits.OrderBy(x => x).SequenceEqual(sequence);

					if (isPanDigital)
						sums.Add(k);
				}
			}

			return sums.Distinct().Sum();
		}
	}
}
