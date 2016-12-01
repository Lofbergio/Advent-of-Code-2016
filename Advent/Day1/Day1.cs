#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Forms;
using Helper;
using static System.Console;

#endregion

namespace Day1
{
    internal static class Day1
    {
        private static int _lastTurn;
        private static Point _breadcrumbPosition;

        [STAThread]
        private static void Main()
        {
            var breadcrumbs = Utilities.GetInput(1).Split(new[] { ", " }, StringSplitOptions.None).ToList();
            var trail = new List<Point> { new Point() };

            foreach (var steps in breadcrumbs.Select(Turn))
                trail.AddRange(RecordAllSteps(steps));

            var distanceFromStart = Math.Abs(_breadcrumbPosition.X) + Math.Abs(_breadcrumbPosition.Y);

            WriteLine($"First part answer: {distanceFromStart}");
            Clipboard.SetText(distanceFromStart.ToString());

            var firstDuplicatePosition = trail.GroupBy(s => s).SelectMany(grp => grp.Skip(1)).First();
            distanceFromStart = Math.Abs(firstDuplicatePosition.X) + Math.Abs(firstDuplicatePosition.Y);

            WriteLine($"Second part answer: {distanceFromStart}");
            Clipboard.SetText(distanceFromStart.ToString());

            ReadKey();
        }

        private static IEnumerable<Point> RecordAllSteps(int steps)
        {
            var stepList = new List<Point>();

            for (var step = 1; step <= steps; step++)
            {
                switch (_lastTurn)
                {
                    case 0:
                        _breadcrumbPosition.Y++; // North
                        break;
                    case 1:
                        _breadcrumbPosition.X++; // East
                        break;
                    case 2:
                        _breadcrumbPosition.Y--; // South
                        break;
                    case 3:
                        _breadcrumbPosition.X--; // West
                        break;
                }

                stepList.Add(_breadcrumbPosition);
            }

            return stepList;
        }

        private static int Turn(string direction)
        {
            var rightOrLeft = direction.Substring(0, 1);

            if (rightOrLeft.Equals("R"))
                _lastTurn++;
            else
                _lastTurn--;

            // Keep things within 90 degrees turns
            switch (_lastTurn)
            {
                case 4:
                    _lastTurn = 0;
                    break;
                case -1:
                    _lastTurn = 3;
                    break;
            }

            return int.Parse(direction.Substring(1));
        }
    }
}