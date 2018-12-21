using AdventOfCode2018.Eight;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayEightTests
    {
        [Fact]
        public void ProcessAndDetermineRoot_Sum()
        {
            var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var sut = new DayEight();
            var result = sut.ProcessAndDetermineRoot(input);

            Assert.Equal(138, result.Sum());
        }

        [Fact]
        public void ProcessAndDetermineRoot_Value()
        {
            var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var sut = new DayEight();
            var result = sut.ProcessAndDetermineRoot(input);

            Assert.Equal(66, result.Value());
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayEight();
            var result = sut.PartA();

            Assert.Equal("46578", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayEight();
            var result = sut.PartB();

            Assert.Equal("31251", result);
        }
    }
}