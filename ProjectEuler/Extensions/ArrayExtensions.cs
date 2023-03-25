using System;
using System.Numerics;

namespace ProjectEuler.Extensions
{
    public static class ArrayExtensions
    {
        // 0123456789
        // Shift index 9 to 1
        // -> 0912345678
        public static void ShiftIndexTo<T>(this T[] array, int index, int to)
        {
            if (to == index)
                return;

            var tmpIndex = index;
            var direction = (to - index > 0) ? 1 : -1;
            while (tmpIndex != to)
            {
                // swap
                var tmp = array[tmpIndex];
                array[tmpIndex] = array[tmpIndex + direction];
                array[tmpIndex + direction] = tmp;

                tmpIndex += direction;
            }
        }
    }
}

