using AdventOfCode2018.TwentyFour;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTwentyFourTests
    {
        [Fact]
        public void DetermineHowManyUnitsLeft()
        {
            var filePath = @"TwentyFour\DayTwentyFourTestInput.txt";
            var sut = new DayTwentyFour();
            var result = sut.DetermineHowManyUnitsLeft(filePath, 0, false);

            Assert.Equal(5216, result);
        }

        [Fact]
        public void DetermineMinImmuneSystemUnits()
        {
            var filePath = @"TwentyFour\DayTwentyFourTestInput.txt";
            var sut = new DayTwentyFour();
            var result = sut.DetermineMinImmuneSystemUnits(filePath);

            Assert.Equal(51, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTwentyFour();
            var result = sut.PartA();

            Assert.Equal("14000", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayTwentyFour();
            var result = sut.PartB();
            // After boost 71, goes into a deadlock until boost 309, then immune system wins
            // Not 11088 is too high
            Assert.Equal("-1", result);
        }
    }
}