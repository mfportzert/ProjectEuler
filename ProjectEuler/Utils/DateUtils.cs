using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public static class DateUtils
    {
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
    }
}

