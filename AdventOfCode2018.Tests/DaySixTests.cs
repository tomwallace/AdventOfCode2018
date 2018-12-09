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

        /*
        [Fact]
        public void GetIdOfUnoverlappingClaim()
        {
            var filePath = @"Three\DayThreeTestInput.txt";
            var sut = new DayThree();
            var result = sut.GetIdOfUnoverlappingClaim(filePath);

            Assert.Equal(3, result);
        }
        */

        // TODO: I don't think I am removing inputs that hit the edge properly, so I am not getting the correct answer.
        [Fact]
        public void PartA_Actual()
        {
            var sut = new DaySix();
            var result = sut.PartA();

            // 4678 are too high
            // 4136 is NOT correct
            // 4092 is NOT correct
            Assert.Equal("-1", result);
        }

        /*
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayThree();
            var result = sut.PartB();

            Assert.Equal("188", result);
        }
        */
    }
}