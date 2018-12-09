using AdventOfCode2018.Nine;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayNineTests
    {
        [Theory]
        [InlineData(25, 9, 32)]
        [InlineData(1618, 10, 8317)]
        [InlineData(7999, 13, 146373)]
        [InlineData(6111, 21, 54718)]
        [InlineData(5807, 30, 37305)]
        public void FindWinningScore(int numberOfMarbles, int numberOfPlayers, int expected)
        {
            var sut = new DayNine();
            var result = sut.FindWinningScore(numberOfMarbles, numberOfPlayers);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayNine();
            var result = sut.PartA();

            Assert.Equal("436720", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayNine();
            var result = sut.PartB();

            Assert.Equal("3527845091", result);
        }
    }
}