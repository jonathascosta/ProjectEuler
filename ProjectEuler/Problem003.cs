using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	static class Problem003
	{
		/// <remarks>
		/// The prime factors of 13195 are 5, 7, 13 and 29.
		/// What is the largest prime factor of the number 600851475143?
		/// </remarks>
		public static long Solve()
		{
			long largest = 1;
            long number = 600851475143;
            double limit = Math.Sqrt(number);

			for (long i = 1; i <= limit; i++)
                if ((number % i == 0) && i.IsPrime())
					largest = i;
			
			return largest;
		}
	}
}
