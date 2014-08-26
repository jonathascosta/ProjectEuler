using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem043
    {
        public static long Solve()
        {
            long answer = 0;
            var sequence = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var divisors = new int[] { 2, 3, 5, 7, 11, 13, 17 };

            long number;
            foreach (var d1 in sequence.Except(new int[] { 0 }))
            {
                foreach (var d2 in sequence.Except(new int[] { d1 }))
                {
                    foreach (var d3 in sequence.Except(new int[] { d1, d2 }))
                    {
                        foreach (var d4 in sequence.Except(new int[] { d1, d2, d3 }))
                        {
                            foreach (var d5 in sequence.Except(new int[] { d1, d2, d3, d4 }))
                            {
                                foreach (var d6 in sequence.Except(new int[] { d1, d2, d3, d4, d5 }))
                                {
                                    foreach (var d7 in sequence.Except(new int[] { d1, d2, d3, d4, d5, d6 }))
                                    {
                                        foreach (var d8 in sequence.Except(new int[] { d1, d2, d3, d4, d5, d6, d7 }))
                                        {
                                            foreach (var d9 in sequence.Except(new int[] { d1, d2, d3, d4, d5, d6, d7, d8 }))
                                            {
                                                foreach (var d10 in sequence.Except(new int[] { d1, d2, d3, d4, d5, d6, d7, d8, d9 }))
                                                {
                                                    number = d1;
                                                    number *= 10;
                                                    number += d2;
                                                    number *= 10;
                                                    number += d3;
                                                    number *= 10;
                                                    number += d4;
                                                    number *= 10;
                                                    number += d5;
                                                    number *= 10;
                                                    number += d6;
                                                    number *= 10;
                                                    number += d7;
                                                    number *= 10;
                                                    number += d8;
                                                    number *= 10;
                                                    number += d9;
                                                    number *= 10;
                                                    number += d10;

                                                    var ok = true;
                                                    int index = 2;
                                                    var digits = number.Reverse().GetDigits().ToList();
                                                    if (digits.Count == 9)
                                                        digits.Add(0);

                                                    foreach (var div in divisors)
                                                    {
                                                        var n = 0;
                                                        n += digits[index + 0 - 1];
                                                        n *= 10;
                                                        n += digits[index + 1 - 1];
                                                        n *= 10;
                                                        n += digits[index + 2 - 1];

                                                        if (n % div != 0)
                                                        {
                                                            ok = false;
                                                            break;
                                                        }

                                                        index++;
                                                    }

                                                    if (ok)
                                                        answer += number;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return answer;
        }
    }
}
