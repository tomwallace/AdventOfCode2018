using AdventOfCode2018.Three;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayThreeTests
    {
        [Fact]
        public void SquareInchesOfFabricWithTwoOrMoreClaims()
        {
            var filePath = @"Three\DayThreeTestInput.txt";
            var sut = new DayThree();
            var result = sut.SquareInchesOfFabricWithTwoOrMoreClaims(filePath);

            Assert.Equal(4, result);
        }

        [Fact]
        public void GetIdOfUnoverlappingClaim()
        {
            var filePath = @"Three\DayThreeTestInput.txt";
            var sut = new DayThree();
            var result = sut.GetIdOfUnoverlappingClaim(filePath);

            Assert.Equal(3, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayThree();
            var result = sut.PartA();

            Assert.Equal("115348", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayThree();
            var result = sut.PartB();

            Assert.Equal("188", result);
        }
    }
}