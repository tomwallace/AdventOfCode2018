using AdventOfCode2018.Fourteen;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayFourteenTests
    {
        [Theory]
        [InlineData(9, "5158916779")]
        [InlineData(5, "0124515891")]
        [InlineData(18, "9251071085")]
        [InlineData(2018, "5941429882")]
        public void ScoreTenRecipes(int recipes, string expected)
        {
            var sut = new DayFourteen();
            var result = sut.ScoreTenRecipes(recipes);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(51589, 9)]
        [InlineData(92510, 18)]
        public void FindRecipePattern(int recipes, int expected)
        {
            var sut = new DayFourteen();
            var result = sut.FindRecipePattern(recipes);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayFourteen();
            var result = sut.PartA();

            Assert.Equal("9411137133", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayFourteen();
            var result = sut.PartB();

            Assert.Equal("20317612", result);
        }
    }
}