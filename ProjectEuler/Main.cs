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
            var sum = 0;
            var limit = 10000;
            var amicables = MathUtils.FindAmicableNumbers(limit);
            foreach (var amicable in amicables)
            {
                sum += amicable;
            }

            Console.WriteLine(sum);
        }
    }
}