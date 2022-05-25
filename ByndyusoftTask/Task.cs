namespace ByndyusoftTask
{
    public static class Task
    {
        //I made it IEnumerable to optimise and allow lazy collections
        /// <summary>
        /// Returns a sum of two smallest numbers in <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">A collection of elements</param>
        /// <returns>The sum of two smallest numbers as <see cref="long"/>.</returns>
        /// <exception cref="ArgumentNullException">If array is null.</exception>
        /// <exception cref="ArgumentException">If array has less then 2 elements.</exception>
        public static long SumOfTwoMinimals(IEnumerable<int> collection)
        {
            if (collection is null) throw new ArgumentNullException(nameof(collection));
            if (collection.Count() < 2) throw new ArgumentException("Array must have at least 2 elements.", nameof(collection));

            int[] minimums = collection
                .OrderBy(n => n)
                .Take(2)
                .ToArray();
            //I will consider LINQ more optimised than what I could create

            //This is converted to long so that adding two extremely small numbers doesn't lead to overflow
            return minimums[0] + (long)minimums[1];
        }
    }
}