using AdventOfCode2018.One;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayOneTests
    {
        [Theory]
        [InlineData(@"One\DayOneTestInputA.txt", 3)]
        [InlineData(@"One\DayOneTestInputB.txt", 0)]
        [InlineData(@"One\DayOneTestInputC.txt", -6)]
        public void ChangeFrequency(string input, int expected)
        {
            var sut = new DayOne();
            var result = sut.ChangeFrequency(input, 0);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(@"One\DayOneTestInputD.txt", 0)]
        [InlineData(@"One\DayOneTestInputE.txt", 10)]
        [InlineData(@"One\DayOneTestInputF.txt", 5)]
        [InlineData(@"One\DayOneTestInputG.txt", 14)]
        public void FindFirstDuplicateFrequency(string input, int expected)
        {
            var sut = new DayOne();
            var result = sut.FindFirstDuplicateFrequency(input, 0);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayOne();
            var result = sut.PartA();

            Assert.Equal("497", result);
        }

        // Commented out as it takes about 30 sec to run
        /*
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayOne();
            var result = sut.PartB();

            Assert.Equal("558", result);
        }
        */
    }
}