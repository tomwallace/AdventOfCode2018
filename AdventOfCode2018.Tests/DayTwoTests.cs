using AdventOfCode2018.Two;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTwoTests
    {
        [Theory]
        [InlineData(@"Two\DayTwoTestInput.txt", 12)]
        public void CalculateCheckSum(string input, int expected)
        {
            var sut = new DayTwo();
            var result = sut.CalculateCheckSum(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("bababc", 2, true)]
        [InlineData("bababc", 3, true)]
        [InlineData("abcdef", 2, false)]
        [InlineData("abcdef", 3, false)]
        public void ContainsNumberOfDuplicateLetters(string input, int duplicatesRequired, bool expected)
        {
            var sut = new DayTwo();
            var result = sut.ContainsNumberOfDuplicateLetters(input, duplicatesRequired);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateCheckSumLines()
        {
            var filePath = @"Two\DayTwoTestInputB.txt";
            var sut = new DayTwo();
            var result = sut.FindCommonLetters(filePath);

            Assert.Equal("fgij", result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTwo();
            var result = sut.PartA();

            Assert.Equal("7192", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayTwo();
            var result = sut.PartB();

            Assert.Equal("mbruvapghxlzycbhmfqjonsie", result);
        }
    }
}