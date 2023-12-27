using System;

namespace Core
{
    public static class MathUtils
    {
        public static int PercentRange(this int input)
        {
            return Math.Max(0, Math.Min(100, input));
        }
        
        public static int MinMaxRange(this int input, int max, int min = 0)
        {
            if (min > max)
            {
                throw new ArgumentException("Error. The min value is greater than the max value");
            }
            return Math.Max(min, Math.Min(max, input));
        }
    }
}