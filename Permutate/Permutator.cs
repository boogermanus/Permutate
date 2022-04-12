using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutate
{

    public class Permutator
    {
        public static string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        
        public IEnumerable<string> GetPermutations(string alphabet, int permutations = 1)
        {
            CheckArguments(alphabet, permutations);
            var q = alphabet.Select(x => x.ToString());

            for (var i = 0; i < permutations - 1; i++)
                q = q.SelectMany(x => alphabet, (x, y) => x + y);

            return q;
        }

        private static void CheckArguments(string alphabet, int permutations)
        {
            if (string.IsNullOrEmpty(alphabet))
                throw new ArgumentException("alphabet is null or empty",nameof(alphabet));

            if (permutations <= 0)
                throw new ArgumentException("Permutations cannot be 0", nameof(permutations));
        }

        public static string GetAlphabet(string charactersToRemove)
        {
            var value = Alphabet;
            
            foreach (var i in charactersToRemove)
            {
                var index = value.IndexOf(i);

                if (index > 0)
                    value = value.Remove(index, 1);
            }

            return value;
        }
    }
}
