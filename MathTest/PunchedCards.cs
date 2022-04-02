using System;
using System.Collections.Generic;
using System.Linq;

public class PunchedCards
{
    static void Main(string[] args)
    {
        var numLines = int.Parse(Console.ReadLine());
        for (int i = 1; i < numLines + 1; i++)
        {
            var rc = Console.ReadLine().Split(" ");
            var r = int.Parse(rc[0]);
            var c = int.Parse(rc[1]);

            PrintASCII(i, r, c);
            if (i < numLines) Console.Write("\n");
        }
    }

    static void PrintASCII(int caseNr, int r, int c)
    {
        Console.WriteLine("Case #" + caseNr + ":");
        Console.Write("..+" + string.Concat(Enumerable.Repeat("-+", c - 1)));

        var lines = new string[r * 2];
        for (int i = 1; i < lines.Length; i += 2)
        {
            lines[i] = "+";
            lines[i] += string.Concat(Enumerable.Repeat("-+", c));
        }

        for (int i = 0; i < lines.Length; i += 2)
        {
            lines[i] = i == 0 ? "." : "|";
            lines[i] += string.Concat(Enumerable.Repeat(".|", c));
        }

        lines.ToList().ForEach(x => 
            {
                Console.Write("\n");
                Console.Write(x);
            });
    }
}