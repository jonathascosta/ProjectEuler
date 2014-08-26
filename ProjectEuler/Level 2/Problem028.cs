using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	static class Problem028
	{
		public static long Solve()
		{
			int i = 2;
			int j = 4;
			long sum = 1;
			long d0 = 1, d1 = 1;

			for (int s = 1; s < 1001; s++)
			{
				d0 += i;
				d1 += j;
				sum += d0 + d1;

				i += 2;
				if (s % 2 == 0)
					j += 4;
			}

			return sum;
		}
	}
}
