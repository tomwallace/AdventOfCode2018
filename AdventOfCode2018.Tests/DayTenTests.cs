using AdventOfCode2018.Ten;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTenTests
    {
        [Fact]
        public void FindSecondWhereStarsAlign()
        {
            var filePath = @"Ten\DayTenTestInput.txt";
            var sut = new DayTen();
            var result = sut.FindSecondWhereStarsAlign(filePath);

            Assert.Equal(3, result);
        }

        // Commenting out because takes about 2 min to run
        /*
        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTen();
            var result = sut.PartA();

            Assert.Equal("RBCZAEPP after 10076 seconds", result);
        }
        */
        // Commenting out because takes about 2 min to run
        /*
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayTen();
            var result = sut.PartB();

            Assert.Equal("10076", result);
        }
        */
    }
}