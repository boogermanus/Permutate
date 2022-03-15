using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Permutate;

namespace PermutateConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            var permutator = new Permutator();
            stopWatch.Start();
            var list = permutator.GetPermutations(Permutator.Alphabet, 3);

            // foreach (var permutate in list)
            // {
            //     Console.WriteLine(permutate);
            // }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.ToString());
        }
    }
}
