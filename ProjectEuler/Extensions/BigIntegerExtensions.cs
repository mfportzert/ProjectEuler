using System;
using System.Numerics;

namespace ProjectEuler.Extensions
{
    public static class BigIntegerExtensions
    {
        public static int GetDigitsSum(this BigInteger value)
        {
            var strValue = value.ToString();
            var length = strValue.Length;
            var sum = 0;
            for (int i = 0; i < length; i++)
                sum += strValue[i] - '0';
            return sum;
        }

        public static int GetDigitsCount(this BigInteger value)
        {
            return (int) Math.Floor(BigInteger.Log10(value) + 1);
        }
    }
}