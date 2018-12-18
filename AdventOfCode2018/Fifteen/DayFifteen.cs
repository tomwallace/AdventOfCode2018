namespace AdventOfCode2018.Fifteen
{
    public class DayFifteen : IAdventProblemSet
    {
        public string Description()
        {
            return "Beverage Bandits";
        }

        public int SortOrder()
        {
            return 15;
        }

        public string PartA()
        {
            string filePath = @"Four\DayFourInput.txt";
            //int factor = DetermineMostAsleepGuardFactor(filePath);
            return "".ToString();
        }

        public string PartB()
        {
            string filePath = @"Four\DayFourInput.txt";
            //int factor = DetermineMinuteMostAsleepFactor(filePath);
            return "".ToString();
        }
    }

    public class Combatant
    {
        public string Type { get; set; }


    }
}