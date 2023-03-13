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
            var primes = MathUtils.GeneratePrimesUntilLimit(limit);
            var dividersSums = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                var dividersSum = MathUtils.GetProperDivisorsSum(i);
                dividersSums[i] = dividersSum;
                //Console.WriteLine(i+" "+dividersSum);
                if (dividersSum < i)
                {
                    if (dividersSums[dividersSum] == i)
                    {
                        sum += i + dividersSum;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}