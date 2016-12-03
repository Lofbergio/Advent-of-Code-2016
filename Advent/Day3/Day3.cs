#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Helper;
using static System.Console;

#endregion

namespace Day3
{
    internal static class Day3
    {
        [STAThread]
        private static void Main()
        {
            var input = Utilities.GetInput(3).Split('\n');
            var part1Input = input.Select(line =>
                            new Regex(@"\d+").Matches(line)).Select(matches =>
                            new Triangle(Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value), Convert.ToInt32(matches[2].Value))).ToList();

            var validTrianglesCount = part1Input.Count(t => t.IsValidTriangle);

            WriteLine($"First part answer: {validTrianglesCount}");
            Clipboard.SetText(validTrianglesCount.ToString());

            /***************
            * Second part! *
            ***************/

            var part2Input = new List<Triangle>();
            for (var line = 0; line < input.Length; line += 3)
            {
                var first = new Regex(@"\d+").Matches(input[line]);
                var second = new Regex(@"\d+").Matches(input[line+1]);
                var third = new Regex(@"\d+").Matches(input[line+2]);

                part2Input.Add(new Triangle(Convert.ToInt32(first[0].Value), Convert.ToInt32(second[0].Value), Convert.ToInt32(third[0].Value)));
                part2Input.Add(new Triangle(Convert.ToInt32(first[1].Value), Convert.ToInt32(second[1].Value), Convert.ToInt32(third[1].Value)));
                part2Input.Add(new Triangle(Convert.ToInt32(first[2].Value), Convert.ToInt32(second[2].Value), Convert.ToInt32(third[2].Value)));
            }

            validTrianglesCount = part2Input.Count(t => t.IsValidTriangle);

            WriteLine($"Second part answer: {validTrianglesCount}");
            Clipboard.SetText(validTrianglesCount.ToString());

            ReadKey();
        }

    }

    public class Triangle
    {
        private int SideA { get; }
        private int SideB { get; }
        private int SideC { get; }

        public bool IsValidTriangle { get; }

        public Triangle(int sideA, int sideB, int sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            var score = 0;
            if (SideA < (SideB + SideC))
                score++;
            if (SideB < (SideA + SideC))
                score++;
            if (SideC < (SideB + SideA))
                score++;

            if (score == 3)
                IsValidTriangle = true;
        }
    }
}