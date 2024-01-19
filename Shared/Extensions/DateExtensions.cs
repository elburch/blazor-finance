using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFinance.Shared.Extensions
{
    public static class DateExtensions
    {
        public static IEnumerable<DateOnly> YearsUntil(this DateOnly start, DateOnly end)
        {
            for (DateOnly date = start; date < end; date = date.AddYears(1))
                yield return date;
        }
        public static IEnumerable<DateOnly> MonthsUntil(this DateOnly start, DateOnly end)
        {
            for (DateOnly date = start; date < end; date = date.AddMonths(1))
                yield return date;
        }

        public static IEnumerable<DateOnly> DaysUntil(this DateOnly start, DateOnly end)
        {
            for (DateOnly date = start; date < end; date = date.AddDays(1))
                yield return date;
        }
    }
}
