using AdventOfCode2018.Fifteen;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class DayFifteenTests
    {
        [Fact]
        public void FindCombatOutcome()
        {
            var filePath = @"Fifteen\DayFifteenTestInput.txt";
            var sut = new DayFifteen();
            var result = sut.FindCombatOutcome(filePath, 3, false);

            Assert.Equal(27730, result);
        }

        [Fact]
        public void PartA_Actual()
        {
            var sut = new DayFifteen();
            var result = sut.PartA();

            Assert.Equal("239010", result);
        }

        [Fact]
        public void PartB_Actual()
        {
            var sut = new DayFifteen();
            var result = sut.PartB();

            Assert.Equal("62468", result);
        }
    }
}