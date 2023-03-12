using System;
using System.Runtime.Intrinsics.X86;
using System.Numerics;

namespace ProjectEuler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startYear = 1901;
            int endYear = 2000;
            var currentDay = Weekday.Tuesday;
            var specialSundaysCount = 0;
            for (int year = startYear; year <= endYear; year++)
            {
                for (int monthIndex = 0; monthIndex < 12; monthIndex++)
                {
                    var nbDays = DateUtils.GetDaysInMonth(year, (Month)monthIndex);
                    for (int dayIndex = 0; dayIndex < nbDays; dayIndex++)
                    {
                        if (currentDay == Weekday.Sunday && dayIndex == 0)
                        {
                            specialSundaysCount++;
                        }

                        currentDay++;

                        if (currentDay > Weekday.Sunday)
                            currentDay = Weekday.Monday;
                    }
                }
            }

            Console.WriteLine(specialSundaysCount);
        }
    }
}