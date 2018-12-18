using AdventOfCode2018.Sixteen;
using AdventOfCode2018.Thirteen;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DaySixteenTests
    {
        [Fact]
        public void HowManySamplesBehaveLikeAtLeastThreeOpcodes()
        {
            var filePath = @"Sixteen\DaySixteenTestInput.txt";
            var sut = new DaySixteen();
            var result = sut.HowManySamplesBehaveLikeAtLeastThreeOpcodes(filePath);

            Assert.Equal(1, result);
        }
        /*
        [Fact]
        public void FindLocationOfLastCart()
        {
            var filePath = @"Thirteen\DayThirteenTestInputB.txt";
            var sut = new DayThirteen();
            var result = sut.FindLocationOfLastCart(filePath);

            Assert.Equal("6,4", result);
        }
        */
        [Fact]
        public void PartA_Actual()
        {
            var sut = new DaySixteen();
            var result = sut.PartA();

            Assert.Equal("677", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DaySixteen();
            var result = sut.PartB();
            Assert.Equal("", result);
        }
    }
}