using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    public static class MathUtils
    {
        public static List<int> GeneratePrimes(int nbPrimes)
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

        public static List<int> GeneratePrimesUntilLimit(int limit)
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
    }
}