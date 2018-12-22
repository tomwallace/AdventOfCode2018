using AdventOfCode2018.TwentyOne;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTwentyOneTests
    {
        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTwentyOne();
            var result = sut.PartA();

            Assert.Equal("10780777", result);
        }

        // Takes 4 min to run. so commenting out
        /*
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayTwentyOne();
            var result = sut.PartB();

            Assert.Equal("13599657", result);
        }
        */
    }
}