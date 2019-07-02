
using System;

namespace REST.Common.Helper
{
    public static class NumberHelper
    {
        internal static int Div(int first, int second)
        {
            return first - ((int)first / 2) * 2;
        }
    }
}