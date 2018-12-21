using AdventOfCode2018.Seventeen;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DaySeventeenTests
    {
        [Fact]
        public void DetermineWaterVolume()
        {
            var filePath = @"Seventeen\DaySeventeenTestInput.txt";
            var sut = new DaySeventeen();
            var result = sut.DetermineWaterVolume(filePath);

            Assert.Equal(57, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DaySeventeen();
            var result = sut.PartA();

            Assert.Equal("32439", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DaySeventeen();
            var result = sut.PartB();

            Assert.Equal("26729", result);
        }
    }
}