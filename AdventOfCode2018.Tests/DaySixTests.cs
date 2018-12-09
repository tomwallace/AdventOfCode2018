using AdventOfCode2018.Six;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DaySixTests
    {
        [Fact]
        public void SquareInchesOfFabricWithTwoOrMoreClaims()
        {
            var filePath = @"Six\DaySixTestInput.txt";
            var sut = new DaySix();
            var result = sut.FindLargestArea(filePath);

            Assert.Equal(17, result);
        }

        [Fact]
        public void GetIdOfUnoverlappingClaim()
        {
            var filePath = @"Six\DaySixTestInput.txt";
            var sut = new DaySix();
            var result = sut.FindSizeOfTargetArea(filePath, 32);

            Assert.Equal(16, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DaySix();
            var result = sut.PartA();

            Assert.Equal("3969", result);
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