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
            BigInteger prev = 1;
            BigInteger fib = 1;
            int index = 2;
            while (fib.GetDigitsCount() < 1000)
            {
                var tmp = fib;
                fib += prev;
                prev = tmp;
                index++;
            }

            Console.WriteLine(index);
        }
    }
}