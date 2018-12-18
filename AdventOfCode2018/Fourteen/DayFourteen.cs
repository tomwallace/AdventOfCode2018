using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Fourteen
{
    public class DayFourteen : IAdventProblemSet
    {
        public static int Input = 157901;

        public string Description()
        {
            return "Chocolate Charts";
        }

        public int SortOrder()
        {
            return 14;
        }

        public string PartA()
        {
            return ScoreTenRecipes(Input);
        }

        public string PartB()
        {
            return FindRecipePattern(Input).ToString();
        }

        public string ScoreTenRecipes(int numberOfRecipes)
        {
            int elfOneIndex = 0;
            int elfTwoIndex = 1;

            List<int> recipes = new List<int> { 3, 7 };

            for (int i = 0; i < (numberOfRecipes + 10); i++)
            {
                int elfOneScore = recipes[elfOneIndex];
                int elfTwoScore = recipes[elfTwoIndex];
                int total = elfOneScore + elfTwoScore;

                recipes.AddRange(total.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray());

                elfOneIndex = (elfOneIndex + elfOneScore + 1) % recipes.Count;
                elfTwoIndex = (elfTwoIndex + elfTwoScore + 1) % recipes.Count;
            }

            StringBuilder builder = new StringBuilder();
            for (int i = numberOfRecipes; i < (numberOfRecipes + 10); i++)
            {
                builder.Append(recipes[i]);
            }

            return builder.ToString();
        }

        public int FindRecipePattern(int numberOfRecipes)
        {
            int elfOneIndex = 0;
            int elfTwoIndex = 1;

            int[] patternToFind = numberOfRecipes.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

            List<int> recipes = new List<int> { 3, 7 };

            bool patternFound = false;
            int index = 0;
            int positionToCheck = 0;

            do
            {
                int elfOneScore = recipes[elfOneIndex];
                int elfTwoScore = recipes[elfTwoIndex];
                int total = elfOneScore + elfTwoScore;

                recipes.AddRange(total.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray());

                elfOneIndex = (elfOneIndex + elfOneScore + 1) % recipes.Count;
                elfTwoIndex = (elfTwoIndex + elfTwoScore + 1) % recipes.Count;

                while (index + positionToCheck < recipes.Count)
                {
                    if (patternToFind[positionToCheck] == recipes[index + positionToCheck])
                    {
                        if (positionToCheck == patternToFind.Length - 1)
                        {
                            patternFound = true;
                            break;
                        }
                        positionToCheck++;
                    }
                    else
                    {
                        positionToCheck = 0;
                        index++;
                    }
                }
            } while (!patternFound);

            return index;
        }
    }
}