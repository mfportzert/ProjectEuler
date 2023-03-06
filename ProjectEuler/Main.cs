using System;
using System.Runtime.Intrinsics.X86;
using System.Numerics;

namespace ProjectEuler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                var letters = NumberToLetters.Convert(i);
                Console.WriteLine(letters);

                var shortVersion = letters
                    .Replace(" ", "")
                    .Replace("-", "");


                sum += shortVersion.Length;
            }
            Console.WriteLine(sum);
        }
    }
}