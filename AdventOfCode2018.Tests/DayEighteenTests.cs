using AdventOfCode2018.Eighteen;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayEighteenTests
    {
        [Fact]
        public void FindResourceValueAfterMinutes()
        {
            var filePath = @"Eighteen\DayEighteenTestInput.txt";
            var sut = new DayEighteen();
            var result = sut.FindResourceValueAfterMinutes(filePath, 10);

            Assert.Equal(1147, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayEighteen();
            var result = sut.PartA();

            Assert.Equal("621205", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayEighteen();
            var result = sut.PartB();
            Assert.Equal("228490", result);
        }
    }
}