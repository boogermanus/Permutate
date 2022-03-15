using System;
using System.Diagnostics;
using Permutate;

namespace PermutateConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var permutator = new Permutator();
            var list = permutator.GetPermutations(permutator.Alphabet, 6);

            // foreach (var permutate in list)
            // {
            //     Console.WriteLine(permutate);
            // }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }
    }
}