using AdventOfCode2018.Six;
using AdventOfCode2018.Twenty;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTwentyTests
    {
        [Theory]
        [InlineData("^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$", 23)]
        [InlineData("^WSSEESWWWNW(S|NENNEEEENN(ESSSSW(NWSW|SSEN)|WSWWN(E|WWS(E|SS))))$", 31)]
        public void FindTheMostNumberOfDoors(string input, int expected)
        {
            var sut = new DayTwenty();
            var result = sut.FindTheMostNumberOfDoors(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("E|NNENN", 2)]
        [InlineData("E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE))", 2)]
        [InlineData("E|NNENN|WNSE|", 3)]
        public void SplitByBottomLevelPipe(string input, int expected)
        {
            var sut = new DayTwenty();
            var result = sut.SplitByBottomLevelPipe(input);

            Assert.Equal(expected, result.Count);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTwenty();
            var result = sut.PartA();

            Assert.Equal("-1", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DaySix();
            var result = sut.PartB();

            Assert.Equal("42123", result);
        }
    }
}