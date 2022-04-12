using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Permutate.Wordle
{
    public class Wordle
    {
        private string _theWord;
        private string _alaphbet;
        private HashSet<string> _dictionary;
        
        public Wordle(string[] args)
        {
            try
            {
                CheckArgs(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            _dictionary = File.ReadAllLines("dictionary.txt").ToHashSet();
        }

        private void CheckArgs(string[] args)
        {
            if (!args.Any())
                throw new Exception("No arguments supplied");

            if (args.Length == 1)
            {
                _theWord = args[0];
                CheckTheWord();
            }

            if (args.Length == 2)
                _alaphbet = args[1];
        }

        private void CheckTheWord()
        {
            if (_theWord.Length > 5)
                throw new Exception("Argument 1 cannot be greater than 5 characters");

            if (!_theWord.Contains(' '))
                throw new Exception("Argument 1 must contain at least one blank space");
        }

        public void Play()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            // load dictionary
            var dictionary = File.ReadLines("dictionary.txt").ToHashSet();
            var words = new List<string>();

            var numberOfPermutations = _theWord.Split(' ').Length - 1;

            var alphabet = Permutator.GetAlphabet(_alaphbet);

            var permutator = new Permutator();
            var permutations = permutator.GetPermutations(alphabet, numberOfPermutations);

            foreach (var permutation in permutations)
            {
                string theWord = string.Empty;
                int count = 0;
                foreach (var letter in _theWord)
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