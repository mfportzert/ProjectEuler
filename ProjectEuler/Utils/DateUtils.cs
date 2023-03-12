using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public static class DateUtils
    {
        public enum Weekday
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6,
        }

        public enum Month
        {
            January = 0,
            February = 1,
            March = 2,
            April = 3,
            May = 4,
            June = 5,
            July = 6,
            August = 7,
            September = 8,
            October = 9,
            November = 10,
            December = 11,
        }

        public struct DayInfo
        {
            public int Year;
            public Month Month;
            public int DayNumber;
            public Weekday Weekday;
        }

        public static int GetDaysInMonth(int year, Month month)
        {
            var nbDays = 31;
            if (month == Month.February)
            {
                if (year % 100 == 0)
                    nbDays = (year % 400 == 0) ? 29 : 28;
                else
                    nbDays = (year % 4 == 0) ? 29 : 28;
            }
            else if (month == Month.April || month == Month.June ||
                month == Month.September || month == Month.November)
            {
                nbDays = 30;
            }
            return nbDays;
        }

        public static int CountDays(int startYear, int endYear, Weekday startDay)
        {
            return CountDays(startYear, endYear, startDay, (d) => true);
        }

        public static int CountDays(int startYear, int endYear, Weekday startDay, Predicate<DayInfo> predicate)
        {
            var dayInfo = new DayInfo();
            var currentDay = startDay;
            var count = 0;
            for (int year = startYear; year <= endYear; year++)
            {
                dayInfo.Year = year;

                for (int monthIndex = 0; monthIndex < 12; monthIndex++)
                {
                    var month = (Month)monthIndex;
                    dayInfo.Month = month;

                    var nbDays = DateUtils.GetDaysInMonth(year, month);
                    for (int dayIndex = 0; dayIndex < nbDays; dayIndex++)
                    {
                        dayInfo.DayNumber = dayIndex + 1;
                        dayInfo.Weekday = currentDay;
                        
                        if (predicate.Invoke(dayInfo))
                            count++;

                        currentDay++;
                        if (currentDay > Weekday.Sunday)
                            currentDay = Weekday.Monday;
                    }
                }
            }
            return count;
        }
    }
}

