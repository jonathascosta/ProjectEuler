using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
	static class Problem031
	{
		/// <remarks>
		/// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
		/// 
		/// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
		/// It is possible to make £2 in the following way:
		/// 
		/// 1£1 + 150p + 220p + 15p + 12p + 31p
		/// How many different ways can £2 be made using any number of coins?
		/// </remarks>
		public static long Solve()
		{
			int max = 200;
			int sum = 0;
			int count = 0;

			for (int L2 = 0; L2 <= max; L2 += 200)
			{
				sum = L2;
				if ((sum) == 200)
					count++;
				if ((sum) >= 200)
					break;

				for (int L1 = 0; L1 <= max; L1 += 100)
				{
					sum = L1 + L2;
					if ((sum) == 200)
						count++;
					if ((sum) >= 200)
						break;

					for (int p50 = 0; p50 <= max; p50 += 50)
					{
						sum = p50 + L1 + L2;
						if ((sum) == 200)
							count++;
						if ((sum) >= 200)
							break;

						for (int p20 = 0; p20 <= max; p20 += 20)
						{
							sum = p20 + p50 + L1 + L2;
							if ((sum) == 200)
								count++;
							if ((sum) >= 200)
								break;

							for (int p10 = 0; p10 <= max; p10 += 10)
							{
								sum = p10 + p20 + p50 + L1 + L2;
								if ((sum) == 200)
									count++;
								if ((sum) >= 200)
									break;

								for (int p5 = 0; p5 <= max; p5 += 5)
								{
									sum = p5 + p10 + p20 + p50 + L1 + L2;
									if ((sum) == 200)
										count++;
									if ((sum) >= 200)
										break;

									for (int p2 = 0; p2 <= max; p2 += 2)
									{
										sum = p2 + p5 + p10 + p20 + p50 + L1 + L2;
										if ((sum) == 200)
											count++;
										if ((sum) >= 200)
											break;

										for (int p1 = 0; p1 <= max; p1++)
										{
											if ((sum + p1) == 200)
												count++;
											if ((sum + p1) >= 200)
												break;
										}
									}
								}
							}
						}
					}
				}
			}

			return count;
		}
	}
}
