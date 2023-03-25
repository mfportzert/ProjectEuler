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
            var digits = new char[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };


            MathUtils.ApplyLexicographicPermutation(digits, 1000000);
            var resultStr = string.Join("", digits);
            Console.WriteLine(resultStr);
        }
    }
}