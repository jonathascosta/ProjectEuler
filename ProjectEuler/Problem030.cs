using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	static class Problem030
	{
		/// <summary>
		/// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
		/// 1634 = 1^4 + 6^4 + 3^4 + 4^4
		/// 8208 = 8^4 + 2^4 + 0^4 + 8^4
		/// 9474 = 9^4 + 4^4 + 7^4 + 4^4
		/// As 1 = 1^4 is not a sum it is not included.
		/// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
		/// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
		/// </summary>
		/// <returns></returns>
		public static long Solve()
		{
			var powers = new List<long>();
			var numbers = new List<long>();

			for (int i = 0; i < 10; i++)
				powers.Add((long)BigInteger.Pow(i, 5));

			for (int a = 0; a < 10; a++)
				for (int b = 0; b < 10; b++)
					for (int c = 0; c < 10; c++)
						for (int d = 0; d < 10; d++)
							for (int e = 0; e < 10; e++)
								for (int f = 0; f < 10; f++)
								{
									var number = powers[a] + powers[b] + powers[c] + powers[d] + powers[e] + powers[f];
									var ns1 = number.ToString().PadLeft(6, '0').Select(x => int.Parse(x.ToString())).OrderBy(x => x);
									var ns2 = new int[] { a, b, c, d, e, f }.OrderBy(x => x);

									if (ns1.SequenceEqual(ns2))
										if (!numbers.Contains(number))
											numbers.Add(number);
								}

			return numbers.Sum();
		}
	}
}
