using AdventOfCode2018.TwentyThree;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTwentyThreeTests
    {
        [Fact]
        public void NumberOfBotsInRangeOfStrongest()
        {
            var filePath = @"TwentyThree\DayTwentyThreeTestInput.txt";
            var sut = new DayTwentyThree();
            var result = sut.NumberOfBotsInRangeOfStrongest(filePath);

            Assert.Equal(7, result);
        }

        [Fact]
        public void FindDistanceToOptimumLocation()
        {
            var filePath = @"TwentyThree\DayTwentyThreeTestInputB.txt";
            var sut = new DayTwentyThree();
            var result = sut.FindDistanceToOptimumLocation(filePath);

            Assert.Equal(36, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTwentyThree();
            var result = sut.PartA();

            Assert.Equal("616", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayTwentyThree();
            var result = sut.PartB();

            Assert.Equal("93750870", result);
        }
    }
}