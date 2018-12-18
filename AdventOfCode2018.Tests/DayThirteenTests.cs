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

        // TODO: Figure out why not working - we have changed a lot
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayThirteen();
            var result = sut.PartB();
            // Not 140,52
            // Not 83,100
            // Not 82,100
            // Not 56,51
            Assert.Equal("", result);
        }
    }
}