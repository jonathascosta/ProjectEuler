using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var solution = Problem018.Solve();

            watch.Stop();
            Console.WriteLine("Solução = {0}", solution);
            Console.WriteLine("Execution time: {0} milliseconds", watch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
