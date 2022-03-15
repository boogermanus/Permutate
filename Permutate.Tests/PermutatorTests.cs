using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Permutate.Tests
{
    [TestFixture]
    public class PermutatorTests
    {
        private Permutator _permutator;

        [SetUp]
        public void SetUp()
        {
            _permutator = new Permutator();
        }

        [TearDown]
        public void TearDown()
        {
            _permutator = null;
        }
        
        [Test]
        public void GetPermutationsShouldNotThrow()
        {
            Assert.That(() => _permutator.GetPermutations(new List<string>() {"a"}, 1), Throws.Nothing);
        }

        [Test]
        public void GetPermutationsShouldThrowForEmptyList()
        {
            Assert.That(() => _permutator.GetPermutations(new List<string>(), 0), 
                Throws.ArgumentException.With.Message.Contains("elements"));
        }

        [Test]
        public void GetPermutationsShouldThrowForNullList()
        {
            Assert.That(() => _permutator.GetPermutations(null, 0), 
                Throws.ArgumentNullException);
        }

        [Test]
        public void GetPermutationsShouldReturnSameList()
        {
            var list = new List<string>() {"a"};

            Assert.That(() => _permutator.GetPermutations(list), Is.EquivalentTo(list));
        }

        [Test]
        public void GetPermutationsShouldThrowForZero()
        {
            var list = new List<string>() {"a"};

            Assert.That(() => _permutator.GetPermutations(list, 0),
                Throws.ArgumentException.With.Message.Contains("cannot be 0"));
        }

        [Test]
        public void GetPermutationsShouldPermutate()
        {
            var list = new List<string> {"a", "b"};
            var expected = new List<string> {"aa", "ab", "ba", "bb"};

            Assert.That(() => _permutator.GetPermutations(list, 2), Is.EquivalentTo(expected));
        }
    }
}