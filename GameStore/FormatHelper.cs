using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    public static class FormatHelper
    {
        public static string FormatMoney(decimal price)
        {
            // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
            // F2 = Fixed-point with 2 decimal places (e.g: 123.45)
            // N1 = Number with 1 decimal place and thousands separator (e.g: 1,234.5 in en-US)
            // P3 = Percentage with 3 decimal places (e.g: 12.345 % in en-US or 12,345 % in fr-FR)
            return string.Format("{0:F2}", price);
        }
    }
}
