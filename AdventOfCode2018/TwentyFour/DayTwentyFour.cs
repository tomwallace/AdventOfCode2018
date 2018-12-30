using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AdventOfCode2018.TwentyThree;

namespace AdventOfCode2018.TwentyFour
{
    public class DayTwentyFour : IAdventProblemSet
    {
        public string Description()
        {
            return "Immune System Simulator 20XX";
        }

        public int SortOrder()
        {
            return 24;
        }

        public string PartA()
        {
            string filePath = @"TwentyFour\DayTwentyFourInput.txt";
            int units = DetermineHowManyUnitsLeft(filePath, 0, false);
            return units.ToString();
        }

        public string PartB()
        {
            string filePath = @"TwentyFour\DayTwentyFourInput.txt";
            int units = DetermineMinImmuneSystemUnits(filePath);
            return units.ToString();
        }

        public int DetermineMinImmuneSystemUnits(string filePath)
        {
            int boost = 0;
            int remainingUnits = -1;

            do
            {
                boost++;
                remainingUnits = DetermineHowManyUnitsLeft(filePath, boost, true);
            } while (remainingUnits < 0);

            return remainingUnits;
        }

        public int DetermineHowManyUnitsLeft(string filePath, int boost, bool checkCureOnly)
        {
            List<Group> armies = ParseArmies(filePath, boost);

            do
            {
                SelectTargets(armies);

                // Do Damage
                bool noDamageDone = true;
                armies = armies.OrderByDescending(a => a.Initiative).ToList();
                for (int i = 0; i < armies.Count; i++)
                {
                    Group group = armies[i];
                    if (group.Target == null)
                        continue;

                    int origUnits = group.Target.Units;
                    int damage = group.Target.CalculateDamageDone(group.AttackType, group.EffectivePower);
                    group.Target.ReceiveDamage(damage);

                    if (damage > 0 && origUnits > 0 && group.Target.Units != origUnits)
                        noDamageDone = false;

                    if (group.Target.Units <= 0)
                    {
                        if (armies.IndexOf(group.Target) < i)
                            i++;

                        armies.Remove(group.Target);
                        group.Target = null;
                    }
                }

                // If no units killed, there is a stalemate condition and battle will never resolve
                if (noDamageDone)
                {
                    Debug.WriteLine($"Boost: {boost} = stalemate");
                    return -1;
                }
                    

                // Reset all group targets
                foreach (Group group in armies)
                {
                    group.Target = null;
                }

            } while (armies.Count(a => a.IsInfection) > 0 && armies.Count(a => !a.IsInfection) > 0);

            int immuneSystemUnits = armies.Count(a => !a.IsInfection);
            if (checkCureOnly && immuneSystemUnits == 0)
            {
                Debug.WriteLine($"Boost: {boost} not enough.  All Immune died.");
                return -1;
            }
                

            return armies.Sum(a => a.Units);
        }

        private List<Group> SelectTargets(List<Group> armies)
        {
            armies = armies.OrderByDescending(a => a.EffectivePower).ThenByDescending(a => a.Initiative).ToList();
            List<Group> alreadySelected = new List<Group>();
            foreach (Group group in armies)
            {
                Group target =
                    armies.Select(a => a)
                        .Where(a => group.IsInfection != a.IsInfection && !alreadySelected.Contains(a))
                        .OrderByDescending(a => a.CalculateDamageDone(group.AttackType, group.EffectivePower))
                        .ThenByDescending(a => a.EffectivePower)
                        .ThenByDescending(a => a.Initiative)
                        .FirstOrDefault();

                group.Target = target;
                alreadySelected.Add(target);
            }
            return armies;
        }

        private List<Group> ParseArmies(string filePath, int boost)
        {
            List<Group> armies = new List<Group>();
            string line;
            StreamReader file = new StreamReader(filePath);

            bool isInfection = false;

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("Infection"))
                {
                    isInfection = true;
                    continue;
                }

                if (line.Contains("Immune System") || string.IsNullOrEmpty(line))
                    continue;

                string[] splitUnits = line.Split(new string[] { "units each with" }, StringSplitOptions.None);
                int units = int.Parse(splitUnits[0].Trim());
                string[] splitHp = splitUnits[1].Split(new string[] { "hit points" }, StringSplitOptions.None);
                int hitPoints = int.Parse(splitHp[0].Trim());
                string[] splitAttack = line.Split(new string[] { " with an attack that does " }, StringSplitOptions.None);
                string[] splitAttackSpace = splitAttack[1].Split(' ');
                int attackDamage = int.Parse(splitAttackSpace[0].Trim());
                if (!isInfection)
                    attackDamage += boost;

                string attackType = splitAttackSpace[1].Trim();
                int initiate = int.Parse(splitAttackSpace[5].Trim());

                Group group = new Group()
                {
                    Units = units,
                    HitPoints = hitPoints,
                    AttackDamage = attackDamage,
                    AttackType = attackType,
                    Initiative = initiate,
                    IsInfection = isInfection
                };

                if (line.Contains("("))
                {
                    string[] splitParen = line.Split('(');
                    string[] splitCloseParen = splitParen[1].Split(')');
                    string section = splitCloseParen[0];
                    string[] splitWeak = section.Split(new string[] { "weak to " }, StringSplitOptions.None);
                    if (splitWeak.Length > 1)
                    {
                        string weak = splitWeak[1];
                        if (weak.Contains(";"))
                        {
                            weak = weak.Substring(0, weak.IndexOf(";"));
                        }
                        group.Weaknesses = weak.Split(new string[] { ", " }, StringSplitOptions.None);
                    }

                    string[] splitImmune = section.Split(new string[] { "immune to " }, StringSplitOptions.None);
                    if (splitImmune.Length > 1)
                    {
                        string immune = splitImmune[1];
                        if (immune.Contains(";"))
                        {
                            immune = immune.Substring(0, immune.IndexOf(";"));
                        }
                        group.Immunities = immune.Split(new string[] { ", " }, StringSplitOptions.None);
                    }
                }

                armies.Add(group);
            }
            file.Close();

            return armies;
        }
    }

    public class Group
    {
        public bool IsInfection { get; set; }

        public int Units { get; set; }

        public int HitPoints { get; set; }

        public int AttackDamage { get; set; }

        public string[] Weaknesses { get; set; }

        public string[] Immunities { get; set; }

        public string AttackType { get; set; }

        public int Initiative { get; set; }

        public int EffectivePower => Units*AttackDamage;

        public Group Target { get; set; }

        public int CalculateDamageDone(string incomingAttackType, int effectivePower)
        {
            if (Immunities != null && Immunities.Contains(incomingAttackType))
                return 0;

            if (Weaknesses != null && Weaknesses.Contains(incomingAttackType))
                return effectivePower * 2;

            return effectivePower;
        }

        public void ReceiveDamage(int damage)
        {
            int lostUnits = (int)Math.Truncate((double)damage/HitPoints);
            Units -= lostUnits;
        }

        public override string ToString()
        {
            return $"{IsInfection}|{Units}";
        }
    }
}