using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutate
{

    public class Permutator
    {
        public readonly List<string> Alphabet = new List<string>
        {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z"
        };
        
        public IEnumerable<string> GetPermutations(List<string> list, int permutations = 1)
        {
            CheckArguments(list, permutations);
            var original = new List<string>(list);
            return GetPermutations(list, original, permutations);
        }

        private static void CheckArguments(List<string> list, int permutations)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (!list.Any())
                throw new ArgumentException("No elements specified", nameof(list));

            if (permutations <= 0)
                throw new ArgumentException("Permutations cannot be 0", nameof(permutations));
        }

        private IEnumerable<string> GetPermutations(List<string> list, List<string> original, int permutations = 1)
        {
            if (permutations == 1)
                return list;

            var newPermutation = new List<string>();

            // old 'n busted
            // foreach (var item in original)
            // {
            //     for (var i = 0; i < original.Count; i++)
            //     {
            //         var element = list[i];
            //         newPermutation.Add(list[i] + item);
            //     }
            // }

            // new hotness
            foreach (var element in list)
            {
                foreach (var item in original)
                {
                    newPermutation.Add(element + item);
                }
            }

            return GetPermutations(newPermutation, original, permutations - 1);
        }
    }
}
