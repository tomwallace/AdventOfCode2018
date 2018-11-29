using Xunit;

namespace AdventOfCode2018.Tests
{
    public class LastYearDayOneTests
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void testInverseCaptchaViaSum(string input, int expected)
        {
            var sut = new LastYearDayOne();
            var result = sut.InverseCaptchaViaSum(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void testCircularInverseCaptcha(string input, int expected)
        {
            var sut = new LastYearDayOne();
            var result = sut.CircularInverseCaptcha(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testPartA_actual()
        {
            var sut = new LastYearDayOne();
            var result = sut.PartA();

            Assert.Equal("1029", result);
        }

        [Fact]
        public void testPartB_actual()
        {
            var sut = new LastYearDayOne();
            var result = sut.PartB();

            Assert.Equal("1220", result);
        }
    }
}