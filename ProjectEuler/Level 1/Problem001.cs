using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	static class Problem001
	{
		/// <remarks>
		/// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
		/// The sum of these multiples is 23.
		/// Find the sum of all the multiples of 3 or 5 below 1000.
		/// </remarks>
		public static int Solve()
		{
			int soma = 0;
			int max = 1000;

			for (int i = 1; i < max; i++)
				if (i % 3 == 0 || i % 5 == 0)
					soma += i;

			return soma;
		}
	}
}
