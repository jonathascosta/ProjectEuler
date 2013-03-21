using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	static class Problem004
	{
		/// <remarks>
		/// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 99.
		/// Find the largest palindrome made from the product of two 3-digit numbers.
		/// </remarks>
		public static long Solve()
		{
			long radical = 998;
			long largest = radical.GetPalindrome();
			while (!largest.IsMultipleOf3Digit())
			{
				radical--;
				largest = radical.GetPalindrome();
			}

			return largest;
		}

		private static long GetPalindrome(this long radical)
		{
			long u = radical % 10;
			long d = (radical % 100 - u) / 10;
			long c = (radical - d * 10 - u) / 100;

			return radical * 1000 + (u * 100) + (d * 10) + c;
		}

		private static bool IsMultipleOf3Digit(this long palindrome)
		{
			double limit = Math.Sqrt(palindrome);

			for (int i = 100; i <= limit; i++)
				if (palindrome % i == 0)
				{
					long divisor = palindrome / i;
					if (divisor >= 100 && divisor <= 999)
						return true;
				}

			return false;
		}
	}
}
