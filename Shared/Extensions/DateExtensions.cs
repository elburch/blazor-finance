using BlazorFinance.Shared.Types;
using LiteDB;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFinance.Shared.Extensions
{
    public static class DateExtensions
    {
        // *******************************************************************************
        // Iteration
        // *******************************************************************************
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

        // *******************************************************************************
        // Examination
        // *******************************************************************************
        public static bool IsWeekly(this DateOnly day)
        {
            return day.DayOfYear % 7 == 0;
        }

        public static bool IsWeekly(this DateOnly day, DateOnly start, IncomeType type)
        {
            // Wages assume Payday Friday
            if (type == IncomeType.Wages)
            {
                if (start.DayOfWeek == DayOfWeek.Friday)
                {
                    return Math.Abs(day.DayOfYear - start.DayOfYear) % 7 == 0;
                }

                int days = ((int)DayOfWeek.Friday - (int)start.DayOfWeek + 7) % 7;

                return Math.Abs(day.DayOfYear - start.AddDays(days).DayOfYear) % 7 == 0;
            }

            return day.DayOfYear % 7 == 0;
        }

        public static bool IsBiWeekly(this DateOnly day)
        {
            return day.DayOfYear % 14 == 0;
        }

        public static bool IsBiWeekly(this DateOnly day, DateOnly start)
        {
            return Math.Abs(day.DayOfYear - start.DayOfYear) % 14 == 0;
        }

        public static bool IsBiWeekly(this DateOnly day, DateOnly start, IncomeType type)
        {
            // Wages assume Payday Friday
            if (type == IncomeType.Wages)
            {
                if (start.DayOfWeek == DayOfWeek.Friday)
                {
                    return Math.Abs(day.DayOfYear - start.DayOfYear) % 14 == 0;
                }

                int days = ((int)DayOfWeek.Friday - (int)start.DayOfWeek + 7) % 7;

                return Math.Abs(day.DayOfYear - start.AddDays(days).DayOfYear) % 14 == 0;
            }

            return day.DayOfYear % 14 == 0;
        }

        public static bool IsSemiMonthly(this DateOnly day)
        {
            return day.Day == 15 || day.Day == DateTime.DaysInMonth(day.Year, day.Month);
        }

        public static bool IsMonthly(this DateOnly day)
        {
            return (day.Day == DateTime.DaysInMonth(day.Year, day.Month));
        }

        public static bool IsQuarterly(this DateOnly day)
        {
            switch (day.Month)
            {
                case 1:
                case 2:
                case 3:
                    return day == new DateOnly(day.Year, 1, 1);
                case 4:
                case 5:
                case 6:
                    return day == new DateOnly(day.Year, 4, 1);
                case 7:
                case 8:
                case 9:
                    return day == new DateOnly(day.Year, 7, 1);
                case 10:
                case 11:
                case 12:
                    return day == new DateOnly(day.Year, 10, 1);
                default:
                    return false;
            }
        }

        public static bool IsSemiAnnually(this DateOnly day)
        {
            return day == new DateOnly(day.Year, 1, 1) || day == new DateOnly(day.Year, 6, 15);
        }

        public static bool IsAnnually(this DateOnly day)
        {
            return day == new DateOnly(day.Year, 1, 1);
        }
    }
}
