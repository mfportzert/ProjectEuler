using System;
using System.Runtime.Intrinsics.X86;
using System.Numerics;
using static ProjectEuler.DateUtils;
using ProjectEuler.Extensions;

namespace ProjectEuler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int limit = 28123;
            var abundants = MathUtils.GetAbundantNumbers(limit);
            var nbAbundants = abundants.Count;

            var areAbundantSums = new bool[limit];
            for (int i = 0; i < nbAbundants; ++i)
            {
                var valueA = abundants[i];
                for (int j = 0; j < nbAbundants; ++j)
                {
                    var valueB = abundants[j];
                    if (valueA + valueB < 28123)
                        areAbundantSums[valueA + valueB] = true;
                }
            }

            var sum = 0;
            for (int i = 0; i < areAbundantSums.Length; i++)
            {
                if (!areAbundantSums[i])
                    sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}