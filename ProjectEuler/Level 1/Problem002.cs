﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	static class Problem002
	{
		/// <remarks>
		/// Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
		/// By starting with 1 and 2, the first 10 terms will be: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
		/// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
		/// </remarks>
		public static long Solve()
		{
			long f1 = 1;
			long f2 = 2;
			long f3 = f1 + f2;
			long soma = 2;
			long max = 4000000;

			while (f3 < max)
			{
				if (f3.IsEven())
					soma += f3;

				f1 = f2;
				f2 = f3;
				f3 = f1 + f2;
			}

			return soma;
		}
	}
}
