using System;
using System.Runtime.Intrinsics.X86;
using System.Numerics;
using static ProjectEuler.DateUtils;

namespace ProjectEuler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<DayInfo> countFirstSundays = (DayInfo d) => { return d.Weekday == Weekday.Sunday && d.DayNumber == 1; };

            var count = DateUtils.CountDays(1901, 2000, Weekday.Tuesday, countFirstSundays);
            Console.WriteLine(count);
        }
    }
}