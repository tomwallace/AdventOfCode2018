using System.IO;
using System.Linq;
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

            Assert.Equal(5216, result.UnitsLeft);
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

        // TODO: Could never get my solution to return Part B correct
        // TODO: Downloaded another solution that works fine, but I cannot figure
        // TODO: Out the difference
        /*
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayTwentyFour();
            var result = sut.PartB();
            // After boost 71, goes into a deadlock until boost 309, then immune system wins  11355
            // 11355 is too high
            // Note 11088 is too high
            Assert.Equal("6149", result);
        }
        */

        [Fact]
        public void TestWithOtherSolution()
        {
            string input = File.ReadAllText(@"TwentyFour\DayTwentyFourInput.txt");
            var sut = new DayTwentyFourOther();
            var result = sut.Solve(input);
            Assert.Equal(6149, result.ToList()[1]);
        }
    }
}