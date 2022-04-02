using System;
using System.Collections.Generic;
using System.Linq;

public class Printing3D
{
    const int mil = 1000000;
    static void Main(string[] args)
    {
        var testCases = int.Parse(Console.ReadLine());
        for (int i = 1; i < testCases + 1; i++)
        {
            var color1 = Console.ReadLine().Split(" ");
            var color2 = Console.ReadLine().Split(" ");
            var color3 = Console.ReadLine().Split(" ");

            var c1 = color1.ToList().Select(x => int.Parse(x)).ToArray();
            var c2 = color2.ToList().Select(x => int.Parse(x)).ToArray();
            var c3 = color3.ToList().Select(x => int.Parse(x)).ToArray();

            FindMutualColor(i, c1, c2, c3);
        }
    }

    static void FindMutualColor(int caseNr, int[] c1, int[] c2, int[] c3)
    {
        var caseText = "Case #" + caseNr + ":";
        var resultText = " IMPOSSIBLE";
        var availableInk = new int[4] { mil, mil, mil, mil };

        for (int i = 0; i < 4; i++)
        {
            if(c1[i] < availableInk[i]) availableInk[i] = c1[i];
            if(c2[i] < availableInk[i]) availableInk[i] = c2[i];
            if(c3[i] < availableInk[i]) availableInk[i] = c3[i];
        }

        var totalAvailable = availableInk[0] + availableInk[1] + availableInk[2] + availableInk[3];
        if (totalAvailable >= mil)
        {
            var inkToRemove = -mil + totalAvailable;

            if(inkToRemove > 0)
            {
                RemoveInk(availableInk[3], inkToRemove, out availableInk[3], out inkToRemove);
                RemoveInk(availableInk[2], inkToRemove, out availableInk[2], out inkToRemove);
                RemoveInk(availableInk[1], inkToRemove, out availableInk[1], out inkToRemove);
                RemoveInk(availableInk[0], inkToRemove, out availableInk[0], out inkToRemove);
            }
            resultText = " " + availableInk[0] + " " + availableInk[1] + " " + availableInk[2] + " " + availableInk[3];
        }

        Console.WriteLine(caseText + resultText);
    }

    static void RemoveInk(int availableInk, int inkToRemove, out int inkLeft, out int inkToRemoveLeft)
    {
        availableInk -= inkToRemove;

        if (availableInk < 0)
        {
            inkToRemoveLeft = -availableInk;
            inkLeft = 0;
        }
        else
        {
            inkToRemoveLeft = 0;
            inkLeft = availableInk;
        }
    }
}