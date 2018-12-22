using AdventOfCode2018.Nineteen;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayNineteenTests
    {
        [Fact]
        public void FindValueInRegisterZero()
        {
            var filePath = @"Nineteen\DayNineteenTestInput.txt";
            var sut = new DayNineteen();
            var result = sut.FindValueInRegisterZero(filePath, 0);

            Assert.Equal(6, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayNineteen();
            var result = sut.PartA();

            Assert.Equal("1120", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayNineteen();
            var result = sut.PartB();
            Assert.Equal("12768192", result);
        }
    }
}