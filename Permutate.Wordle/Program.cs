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
            var wordle = new Wordle(args);
            wordle.Play();
        }
    }
}