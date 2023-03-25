using System;
using System.Collections.Generic;
using System.Numerics;
using ProjectEuler.Extensions;

namespace ProjectEuler
{
    public static class MathUtils
    {
        public static List<int> GetPrimes(int nbPrimes)
        {
            List<int> primes = new List<int>(new int[] { 2, 3 });
            int primesCount = 2;
            for (int n = 5; primesCount < nbPrimes; n += 2)
            {
                bool isPrime = true;
                foreach (int prime in primes)
                {
                    if (n % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(n);
                    primesCount++;
                }
            }
            return primes;
        }

        public static List<int> GetPrimesUntilLimit(int limit)
        {
            List<int> primes = new List<int>(new int[] { 2, 3 });
            int primesCount = 2;
            for (int n = 5; n < limit; n += 2)
            {
                bool isPrime = true;
                foreach (int prime in primes)
                {
                    if (n % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(n);
                    primesCount++;
                }
            }
            return primes;
        }

        // https://www.wikihow.com/Determine-the-Number-of-Divisors-of-an-Integer
        public static int GetDivisorsCount(double n, List<int> primes)
        {
            var nbDivisors = 1;
            foreach (var prime in primes)
            {
                if (prime > n)
                    break;

                if (n % prime == 0)
                {
                    int nbFactors = 0;
                    var tmp = n;
                    do
                    {
                        tmp = tmp / prime;
                        nbFactors++;
                    }
                    while (tmp % prime == 0);

                    nbDivisors *= (nbFactors + 1);
                }
            }
            return nbDivisors;
        }

        public static int GetProperDivisorsSum(int n)
        {
            int sum = 0;
            var sqrt = Math.Sqrt(n);
            for (int i = 1; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                    var opposite = n / i;
                    if (i > 1 && i != opposite)
                        sum += opposite;
                }
            }
            return sum;
        }

        // https://en.wikipedia.org/wiki/Binomial_coefficient
        // https://stackoverflow.com/a/55020224
        public static double BinomialCoefficient(int numerator, int denominator)
        {
            //invalid numbers
            if (denominator > numerator || denominator < 0 || numerator < 0)
                return -1;

            //default values
            if (denominator == numerator || denominator == 0 || numerator == 0)
                return 1;


            // Since C(n, k) = C(n, n-k) 
            if (denominator > (numerator - denominator))
                denominator = numerator - denominator;


            // Calculate value of [n * (n-1) *---* (n-k+1)] / [k * (k-1) *----* 1] 
            double res = 1;
            while (denominator >= 1)
            {
                res *= numerator;
                res /= denominator;

                denominator--;
                numerator--;
            }
            return res;
        }

        public static BigInteger GetFactorial(int number)
        {
            BigInteger result = number;
            for (int i = number - 1; i > 1; i--)
                result *= i;
            return result;
        }

        public static List<int> FindAmicableNumbers(int limit)
        {
            List<int> amicables = new List<int>();
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
                        amicables.Add(i);
                        amicables.Add(dividersSum);
                    }
                }
            }
            return amicables;
        }

        public static List<int> GetAbundantNumbers(int limit)
        {
            var numbers = new List<int>();
            for (int i = 1; i < limit; i++)
            {
                var divisorsSum = GetProperDivisorsSum(i);
                if (divisorsSum > i)
                    numbers.Add(i);
            }
            return numbers;
        }

        // Example: [0,1,2,3,4] is given, permutation 12
        // 
        // [0,1,2,3,4] is 5 elements
        //
        // 4 3 2 1 0  -> !4 !3 !2 !1 !0 -> 24 6 2 1 0
        //
        // We want permutation 12:
        // -> Remove 1, take 11
        // -> 11 < 24.. skip first digit
        // -> 11 > 6 -> Floor(11 / 6) = 1; 11 % 6 = 5
        // -> 5 > 2 -> Floor(5 / 2) = 2; 5 % 2 = 1
        // -> 1 / 1 = 1; 1 % 1 = 0
        // -> 0
        //
        // Result:
        // [0, 1, 2, 1] -> (0 x 24) + (1 x 6) + (2 x 2) + (1 x 1) + 1 
        // 
        // Next: shift [0, 1, 2, 3, 4] using [0, 1, 2, 1], left to right...
        //  -> [0, 1, 2, 3, 4] shifted by [0, --> 1 <--, 2, 1] (from this index, take 1 index to the right and shift it here)
        //  -> [0, 2, 1, 3, 4] shifted by [0, 1, --> 2 <--, 1] (from this index, take 2 indexes to the right here and shift it here)
        //  -> [0, 2, 4, 1, 3] shifted by [0, 1, 2, --> 1 <--] (same rule)
        //  -> Permutation 12 is [0, 2, 4, 3, 1]
        //
        public static void ApplyLexicographicPermutation(char[] array, int permutationNumber)
        {
            if (permutationNumber <= 1)
                return;

            var totalPermutations = (int)GetFactorial(array.Length);
            if (permutationNumber > totalPermutations)
                return; // permutation doesn't exist

            int[] factorials = new int[array.Length - 1];
            for (int i = 0; i < factorials.Length; i++)
                factorials[i] = (int) GetFactorial(factorials.Length - i);

            double tmpPermuationsNumber = permutationNumber;
            tmpPermuationsNumber--;

            // calculate shifts
            int[] shifts = new int[factorials.Length];
            for (int i = 0; i < factorials.Length; i++)
            {
                if (permutationNumber < factorials[i])
                    continue;

                var dividedCount = tmpPermuationsNumber / factorials[i];
                shifts[i] = (int)Math.Floor(dividedCount);

                tmpPermuationsNumber -= factorials[i] * shifts[i];
            }

            //Console.WriteLine(string.Join("", shifts));

            // Apply shifts
            for (int i = 0; i < shifts.Length; i++)
            {
                if (shifts[i] == 0)
                    continue;

                array.ShiftIndexTo(i + shifts[i], i);
            }
            //Console.WriteLine(string.Join("", array));
        }
    }
}