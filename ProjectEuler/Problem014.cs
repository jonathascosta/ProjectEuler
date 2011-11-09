using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectEuler
{
    static class Problem014
    {
        private static IDictionary<long, Node<long>> graph;

        /// <remarks>
        /// The following iterative sequence is defined for the set of positive integers:
        /// n -> n/2 (n is even)
        /// n -> 3n + 1 (n is odd)
        /// Using the rule above and starting with 13, we generate the following sequence:
        /// 13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1
        /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
        /// Which starting number, under one million, produces the longest chain?
        /// NOTE: Once the chain starts the terms are allowed to go above one million.
        /// </remarks>
        public static long Solve()
        {
            graph = new Dictionary<long, Node<long>>();
            var rootNode = new Node<long>()
            {
                Value = 1,
                PathLength = 1
            };
            graph.Add(1, rootNode);

            long max = 1000000;
            long longestChainNumber = 1;
            long longestChainLength = 1;

            for (int i = 2; i < max; i++)
            {
                var chainLength = CalculateChainLength(i);
                if (chainLength > longestChainLength)
                {
                    longestChainLength = chainLength;
                    longestChainNumber = i;
                }
            }

            return longestChainNumber;
        }

        private static long CalculateChainLength(long number)
        {
            if (!graph.ContainsKey(number))
            {
                var next = Function(number);
                var chainLength = CalculateChainLength(next) + 1;
                var node = new Node<long>()
                {
                    Value = number,
                    Next = graph[next],
                    PathLength = chainLength
                };
                graph.Add(number, node);
            }

            return graph[number].PathLength;
        }

        private static long Function(long number)
        {
            if (number.IsEven())
                return number / 2;
            else
                return 3 * number + 1;
        }
    }

    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public long PathLength { get; set; }

        public override string ToString()
        {
            if (Next != null)
                return string.Format("{0} -> {1}", Value, Next.ToString());
            else
                return string.Format("{0}", Value);
        }
    }
}
