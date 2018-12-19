using AdventOfCode2018.Thirteen;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayThirteenTests
    {
        [Fact]
        public void FindFirstCollision()
        {
            var filePath = @"Thirteen\DayThirteenTestInput.txt";
            var sut = new DayThirteen();
            var result = sut.FindFirstCollision(filePath);

            Assert.Equal("7,3", result);
        }

        [Fact]
        public void FindLocationOfLastCart()
        {
            var filePath = @"Thirteen\DayThirteenTestInputB.txt";
            var sut = new DayThirteen();
            var result = sut.FindLocationOfLastCart(filePath);

            Assert.Equal("6,4", result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayThirteen();
            var result = sut.PartA();

            Assert.Equal("143,43", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayThirteen();
            var result = sut.PartB();
            Assert.Equal("116,125", result);
        }
    }
}