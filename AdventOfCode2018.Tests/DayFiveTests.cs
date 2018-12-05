using AdventOfCode2018.Five;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayFiveTests
    {
        [Fact]
        public void CalculateUnitsRemainingAfterReactions()
        {
            var input = "dabAcCaCBAcCcaDA";
            var sut = new DayFive();
            var result = sut.CalculateUnitsRemainingAfterReactions(input);

            Assert.Equal(10, result);
        }

        [Fact]
        public void FindBestPolymerAfterRemovingAUnit()
        {
            var input = "dabAcCaCBAcCcaDA";
            var sut = new DayFive();
            var result = sut.FindBestPolymerAfterRemovingAUnit(input);

            Assert.Equal(4, result);
        }

        // TODO: Figure out how to change the process to make faster
        // Takes a minute to run, so commenting out
        /*
        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayFive();
            var result = sut.PartA();

            // 27612 is too high
            Assert.Equal("10250", result);
        }
        */

        // Takes 17 minutes to run, so commenting out
        /*
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayFive();
            var result = sut.PartB();

            Assert.Equal("6188", result);
        }
        */
    }
}