using System;
using System.Collections.Generic;
using System.Linq;

public class d1000000
{
    static void Main(string[] args)
    {
        var testCases = int.Parse(Console.ReadLine());
        for (int i = 1; i < testCases + 1; i++)
        {
            var numDice = Console.ReadLine();
            var diceString = Console.ReadLine().Split(" ");
            var diceInt = diceString.ToList().Select(x => int.Parse(x)).ToArray();

            CalcLongestStraight(i, diceInt);
        }
    }

    static void CalcLongestStraight(int caseNr, int[] dice)
    {
        var caseText = "Case #" + caseNr + ": ";
        var numDice = dice.Length;
        var possibleSequence = 0;

        var list = dice.ToList();
        list.Sort();
        list.Reverse();

        var reserveDice = new List<int>();

        for (int i = 0; i < numDice; i++)
        {
            var die = list[i];
            var requiredVal = numDice - i;
            if (die >= requiredVal)
            {
                possibleSequence++;
            }
            else if(reserveDice.Count > 0 && reserveDice[0] >= requiredVal)
            {
                possibleSequence++;
                reserveDice.RemoveAt(0);
            }
            else
            {
                reserveDice.Add(die);
            }
        }

        Console.WriteLine(caseText + possibleSequence);
    }
}