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
            var factorial = MathUtils.GetFactorial(100);

            Console.WriteLine(factorial.GetDigitsSum());
        }
    }
}