using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENSOR.Infrastructure.Utilidades
{
    public static class Utils
    {
        public static List<string> GenerateMonthRanges(DateTime startDate, DateTime endDate)
        {
            var monthRanges = new List<string>();

            var startMonth = new DateTime(startDate.Year, startDate.Month, 1);
            var endMonth = new DateTime(endDate.Year, endDate.Month, 1).AddMonths(1).AddDays(-1);

            for (var date = startMonth; date <= endMonth; date = date.AddMonths(1))
            {
                var rangeStart = date;
                var rangeEnd = date.AddMonths(1).AddDays(-1);

                if (rangeEnd > endDate)
                {
                    rangeEnd = endDate;
                }

                monthRanges.Add($"{rangeStart:yyyy-MM-dd} – {rangeEnd:yyyy-MM-dd}");
            }

            return monthRanges;
        }
    }
}
