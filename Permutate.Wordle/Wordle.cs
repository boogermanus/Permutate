using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Permutate.Wordle
{
    public class Wordle
    {
        private string _jsonFile = string.Empty;
        private readonly WordleInput _input;
        private readonly HashSet<string> _dictionary;
        
        public Wordle(string[] args)
        {
            CheckArgs(args);
            var input = File.ReadAllText(_jsonFile);
            _input = JsonConvert.DeserializeObject<WordleInput>(input) ?? new WordleInput();
            CheckTheWord(_input.Word);

            _dictionary = File.ReadAllLines("dictionary.txt").ToHashSet();
        }

        private void CheckArgs(string[] args)
        {
            if (!args.Any())
                throw new Exception("No arguments supplied");

            if (!File.Exists(args[0]))
                throw new FileNotFoundException($"{args[0]} does not exist");

            _jsonFile = args[0];
        }
        
        private void CheckTheWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new Exception("Word cannot be empty");
            
            if (word.Length > 5)
                throw new Exception("Argument 1 cannot be greater than 5 characters");
        
            if (!word.Contains(' '))
                throw new Exception("Argument 1 must contain at least one blank space");
        }

        public void Play()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            // load dictionary
            var words = new List<string>();

            var numberOfPermutations = _input.Word.Split(' ').Length - 1;

            var alphabet = Permutator.GetAlphabet(_input.CharactersToExclude);

            var permutator = new Permutator();
            var permutations = permutator.GetPermutations(alphabet, numberOfPermutations);
            
            foreach (var permutation in permutations)
            {
                var theWord = string.Empty;
                var count = 0;
                
                foreach (var letter in _input.Word)
                {
                    if (letter == ' ')
                        theWord += permutation.ElementAt(count++);
                    else
                        theWord += letter;
                }

                if (_input.CharactersToInclude != string.Empty)
                    AddWordsThatMatch(theWord, words);
                else
                    if (_dictionary.Contains(theWord))
                        words.Add(theWord);

            }
            
            Console.WriteLine($"Possible words found: {words.Count}");
            words.ForEach(Console.WriteLine);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }

        private void AddWordsThatMatch(string theWord, List<string> words)
        {
            var contains = new List<bool>();

            foreach (var charToInclude in _input.CharactersToInclude)
            {
                if (theWord.Contains(charToInclude))
                    contains.Add(true);
            }

            if (contains.Count(c => c) == _input.CharactersToInclude.Length && _dictionary.Contains(theWord))
                words.Add(theWord);
        }
    }
}