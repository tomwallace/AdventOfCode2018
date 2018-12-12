using AdventOfCode2018.Eleven;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayElevenTests
    {
        [Theory]
        [InlineData(8, 3, 5, 4)]
        [InlineData(57, 122, 79, -5)]
        [InlineData(39, 217, 196, 0)]
        [InlineData(71, 101, 153, 4)]
        public void DeterminePowerLevel(int serialNumber, int x, int y, int expected)
        {
            var sut = new DayEleven();
            var result = sut.DeterminePowerLevel(x, y, serialNumber);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(18, "33,45")]
        [InlineData(42, "21,61")]
        public void FindLargestThreeByThreePowerLevel(int serialNumber, string expected)
        {
            var sut = new DayEleven();
            var result = sut.FindLargestThreeByThreePowerLevel(serialNumber, 3);

            Assert.Equal(expected, result.Coords);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayEleven();
            var result = sut.PartA();

            Assert.Equal("20,43", result);
        }

        // Commented out as it takes 7 min to run
        /*
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayEleven();
            var result = sut.PartB();

            Assert.Equal("233,271,13", result);
        }
        */
    }
}