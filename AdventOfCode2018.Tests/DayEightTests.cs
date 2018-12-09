using AdventOfCode2018.Eight;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayEightTests
    {
        [Fact]
        public void SumMetadata()
        {
            var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var sut = new DayEight();
            var result = sut.SumMetadata(input);

            Assert.Equal(138, result);
        }

        [Fact]
        public void SumChildWorth()
        {
            var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var sut = new DayEight();
            var result = sut.SumChildWorth(input);

            Assert.Equal(66, result);
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

            // TODO: Figure out why my final node has a bunch of children with zero
            // Not 0
            Assert.Equal("-1", result);
        }
    }
}