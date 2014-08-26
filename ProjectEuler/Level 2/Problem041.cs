using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public static class Problem041
    {
        public static long Solve()
        {
            for (int i = 7654321; i >= 1234567; i -= 2)
                if (i.IsPrime() && i.GetDigits().Max() == 7 && i.GetDigits().Min() == 1)
                    return i;
            
            throw new NotImplementedException();
        }
    }
}
