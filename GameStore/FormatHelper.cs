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
            return string.Format("{0:F2}", price);
        }
    }
}
