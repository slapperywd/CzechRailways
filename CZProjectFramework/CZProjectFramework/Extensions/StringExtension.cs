using System;
using System.Linq;

namespace CZProjectFramework.Extensions
{
    public static class StringExtension
    {
        public static int ConvertToIntFormat(this string str)
        {
            var v = str.Where(x => char.IsDigit(x)).ToArray();
            var price = Convert.ToInt32(new string(v));
            return price;
        }
    }
}