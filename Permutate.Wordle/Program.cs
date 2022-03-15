using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Permutate.Wordle
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            // load dictionary
            var dictionary = File.ReadLines("dictionary.txt").ToHashSet();
            var words = new List<string>();
            Console.WriteLine("Please enter a word, blank letters are spaces (e.x. 't s t'");
            Console.Write(">");
            var word = Console.ReadLine();

            var numberOfPermutations = word.Split(' ').Length - 1;

            var permutator = new PermutatorOriginal();
            var permutations = permutator.GetPermutations(permutator.Alphabet, numberOfPermutations);

            foreach (var permutation in permutations)
            {
                string theWord = string.Empty;
                int count = 0;
                foreach (var letter in word)
                {
                    if (letter == ' ')
                        theWord += permutation.ElementAt(count++);
                    else
                        theWord += letter;
                }
                
                if(dictionary.Contains(theWord))
                    words.Add(theWord);
            }

            Console.WriteLine($"Possible words found: {words.Count}");
            words.ForEach(Console.WriteLine);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }
    }
}