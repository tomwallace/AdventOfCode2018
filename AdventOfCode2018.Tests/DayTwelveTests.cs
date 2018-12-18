using AdventOfCode2018.Twelve;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayTwelveTests
    {
        [Fact]
        public void FindPlantSum()
        {
            var filePath = @"Twelve\DayTwelveTestInput.txt";
            var sut = new DayTwelve();
            var result = sut.FindPlantSum(filePath, 20);

            Assert.Equal(325, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayTwelve();
            var result = sut.PartA();

            Assert.Equal("4217", result);
        }

        // TODO: Figure out how to handle - as getting out of memory exception with the dictionary approach
        // TODO: Try running overnight without dictionary
        /*
        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayTwelve();
            var result = sut.PartB();
            Assert.Equal("", result);
        }
        */
    }
}