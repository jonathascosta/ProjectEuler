using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem015
    {
        public static long Solve()
        {
            int size = 20;
            long[,] matrix = new long[size + 1, size + 1];

            for (int i = 0; i <= size; i++)
            {
                matrix[i, size] = 1;
                matrix[size, i] = 1;
            }

            while (size >= 0)
                for (int i = --size; i >= 0; i--)
                {
                    matrix[size, i] = matrix[size + 1, i] + matrix[size, i + 1];
                    matrix[i, size] = matrix[i + 1, size] + matrix[i, size + 1];
                }

            return matrix[0, 0];
        }
    }
}
