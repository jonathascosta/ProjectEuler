using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem046
    {
        public static long Solve()
        {
            int[] squares = new int[(int)Math.Sqrt(int.MaxValue)];

            for (int i = 0; i < (int)Math.Sqrt(int.MaxValue); i++)
                squares[i] = (int)Math.Pow(i, 2);

            for (int i = 3; i < int.MaxValue; i += 2)
            {
                var found = false;

                for (int j = 2; j <= i; j++)
                    if (j.IsPrime())
                    {
                        for (int k = 0; k < squares.Length; k++)
                        {
                            if (j + 2 * squares[k] > i)
                                break;

                            if (j + 2 * squares[k] == i)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (found)
                            break;
                    }

                if (!found)
                    return i;
            }

            throw new ApplicationException();
        }
    }
}
