#region

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Helper;
using static System.Console;

#endregion

namespace Day2
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    internal static class Day2
    {
        [STAThread]
        private static void Main()
        {
            var inputLines = Utilities.GetInput(2).Replace("\r", "").Split('\n').ToList();
            
            var simpleKeyPad = new Simple(new Point(1, 1));
            var keyCode = inputLines.Aggregate("", (current, line) => current + simpleKeyPad.ParseDirections(line));

            WriteLine($"First part answer: {keyCode}");
            Clipboard.SetText(keyCode);

            var complexKeyPad = new Complex(new Point(0, 2));
            var complexKeyCode = inputLines.Aggregate("", (current, line) => current + complexKeyPad.ParseDirections(line));

            WriteLine($"Second part answer: {complexKeyCode}");
            Clipboard.SetText(complexKeyCode);

            ReadKey();
        }
    }
}