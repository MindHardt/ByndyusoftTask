using Xunit;
using static ByndyusoftTask.Task;

namespace ByndyusoftTask.Tests
{
    public class TaskTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { -5, -4, -3, -2, -1 })]
        [InlineData(new int[] { 0, 0, 0, 0, 0 })]
        public void SumOfTwoMinimals_ValuesOK_ReturnOK(int[] value)
        {
            long expected = value[0] + value[1];
            long actual = SumOfTwoMinimals(value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SumOfTwoMinimals_ValueInvalid_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => SumOfTwoMinimals(null!));
            Assert.Throws<ArgumentException>(() => SumOfTwoMinimals(new int[1]));
        }

        [Theory]
        [InlineData(-500, 1000)]
        [InlineData(int.MinValue, 100_000_000)]
        public void SumOfTwoMinimals_ValueBig_ReturnOK(int min, int count)
        {
            IEnumerable<int> testData = Enumerable.Range(min, count);

            long expected = min + (long)min + 1;
            long actual = SumOfTwoMinimals(testData);

            Assert.Equal(expected, actual);
        }
    }
}