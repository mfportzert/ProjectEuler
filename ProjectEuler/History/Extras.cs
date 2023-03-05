using System;
namespace ProjectEuler
{
    public static class Extras
    {
        public static char[] InfiniteAddition(char[] a, char[] b)
        {
            var longest = (a.Length >= b.Length) ? a : b;
            var shortest = (a.Length >= b.Length) ? b : a;

            var resultLength = longest.Length;

            var hasExtraDigit = false;
            if (longest.Length == shortest.Length)
                hasExtraDigit = (longest[0] - '0') + (shortest[0] - '0') > 9;
            if (longest.Length > shortest.Length &&
                (longest[longest.Length - shortest.Length] - '0') + (shortest[0] - '0') > 9)
            {
                int tmpIndex = (longest.Length - shortest.Length) - 1;
                for (; tmpIndex >= 0; tmpIndex--)
                    if ((longest[tmpIndex] - '0') < 9) break;
                hasExtraDigit = tmpIndex < 0;
            }

            if (hasExtraDigit)
                resultLength++;

            var longestIndex = longest.Length - 1;
            var shortestIndex = shortest.Length - 1;
            var result = new char[resultLength];
            var carriedNumber = 0;
            for (int i = resultLength - 1; i >= 0; --i)
            {
                var digit = carriedNumber;
                carriedNumber = 0;

                if (shortestIndex < 0 && longestIndex >= 0)
                    digit += (longest[longestIndex] - '0');
                else if (longestIndex >= 0 && shortestIndex >= 0)
                    digit += (longest[longestIndex] - '0') + (shortest[shortestIndex] - '0');

                if (digit > 9)
                {
                    digit -= 10;
                    carriedNumber = 1;
                }

                result[i] = (char)(digit + '0');

                longestIndex--;
                shortestIndex--;
            }
            return result;
        }
    }
}

