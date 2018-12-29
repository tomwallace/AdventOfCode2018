using AdventOfCode2018.TwentyTwo;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTwentyTwoTests
    {
        [Fact]
        public void DetermineRiskFactor()
        {
            var sut = new DayTwentyTwo();
            var result = sut.DetermineRiskFactor(510, 10, 10);

            Assert.Equal(114, result);
        }

        [Fact]
        public void FindBestTimeThroughCave()
        {
            var sut = new DayTwentyTwo();
            var result = sut.FindBestTimeThroughCave(510, 10, 10);

            Assert.Equal(45, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTwentyTwo();
            var result = sut.PartA();

            Assert.Equal("11972", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayTwentyTwo();
            var result = sut.PartB();

            Assert.Equal("1092", result);
        }
    }
}