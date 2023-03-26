namespace Luisbreria
{
    /// <summary>
    /// Utilities
    /// </summary>
    public class Utils
    {
        static Random r = new Random();

        /// <summary>
        /// Gets a random double between a range.
        /// </summary>
        /// <param name="min">The min parameter of the range</param>
        /// <param name="max">The max parameter of the range</param>
        /// <returns>A random double between a range</returns>
        public static double RandomRange(double min, double max)
        {
            if (min < max)
                return RandomRange(max, min);

            return r.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Gets a random int between a range
        /// </summary>
        /// <param name="min">The min parameter of the range</param>
        /// <param name="max">The max parameter of the range</param>
        /// <returns>A random int between a range</returns>
        public static int RandomRangeInt(int min, int max)
        {
            if (min < max)
                return RandomRangeInt(max, min);

            int res = (int)RandomRange(min, max);
            if (res == max)
                return RandomRangeInt(min, max);

            return (int)RandomRange(min, max);
        }
    }
}
