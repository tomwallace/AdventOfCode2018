using AdventOfCode2018.TwentyFive;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTwentyFiveTests
    {
        [Fact]
        public void FindNumberOfConstellations()
        {
            var filePath = @"TwentyFive\DayTwentyFiveTestInput.txt";
            var sut = new DayTwentyFive();
            var result = sut.FindNumberOfConstellations(filePath);

            Assert.Equal(4, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTwentyFive();
            var result = sut.PartA();

            Assert.Equal("394", result);
        }
    }
}