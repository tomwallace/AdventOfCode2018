using AdventOfCode2018.Four;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayFourTests
    {
        [Fact]
        public void DetermineMostAsleepGuardFactor()
        {
            var filePath = @"Four\DayFourTestInput.txt";
            var sut = new DayFour();
            var result = sut.DetermineMostAsleepGuardFactor(filePath);

            Assert.Equal(240, result);
        }

        [Fact]
        public void DetermineMinuteMostAsleepFactor()
        {
            var filePath = @"Four\DayFourTestInput.txt";
            var sut = new DayFour();
            var result = sut.DetermineMinuteMostAsleepFactor(filePath);

            Assert.Equal(4455, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayFour();
            var result = sut.PartA();

            Assert.Equal("67558", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayFour();
            var result = sut.PartB();

            Assert.Equal("78990", result);
        }
    }
}