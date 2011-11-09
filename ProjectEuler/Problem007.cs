using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem007
    {
        /// <remarks>
        /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
        /// What is the 10001st prime number?
        /// </remarks>
        public static long Solve()
        {
            long index = 1;
            long number = 1;
            long desired = 10001;

            do
            {
                number += 2;
                if (number.IsPrime())
                    index++;
            }
            while (index < desired);

            return number;
        }
    }
}
