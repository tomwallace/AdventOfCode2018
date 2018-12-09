using AdventOfCode2018.Seven;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DaySevenTests
    {
        [Fact]
        public void DetermineInstructionOrder()
        {
            var filePath = @"Seven\DaySevenTestInput.txt";
            var sut = new DaySeven();
            var result = sut.DetermineInstructionOrder(filePath);

            Assert.Equal("CABDFE", result);
        }

        [Theory]
        [InlineData('A', 0, 1)]
        [InlineData('C', 60, 63)]
        [InlineData('Z', 0, 26)]
        [InlineData('Z', 60, 86)]
        public void CalculateStepSeconds(char step, int offset, int expected)
        {
            var sut = new DaySeven();
            var result = sut.CalculateStepSeconds(step, offset);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DetermineAssemblyTime()
        {
            var filePath = @"Seven\DaySevenTestInput.txt";
            var sut = new DaySeven();
            var result = sut.DetermineAssemblyTime(filePath, 2, 0);

            Assert.Equal(15, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DaySeven();
            var result = sut.PartA();

            Assert.Equal("CQSWKZFJONPBEUMXADLYIGVRHT", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DaySeven();
            var result = sut.PartB();

            Assert.Equal("914", result);
        }
    }
}