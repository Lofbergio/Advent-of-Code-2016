#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helper;
using static System.Console;

#endregion

namespace Day6
{
    internal static class Day6
    {
        [STAThread]
        private static void Main()
        {
            var input = Utilities.GetInput(6).Replace("\r\n", "").ToCharArray();
            var message = string.Empty;
            var reverseMessage = string.Empty;

            for (var r = 0; r < 8; r++)
            {
                var charColumn = new List<char>();

                for (var c = r; c < input.Length; c += 8)
                    charColumn.Add(input[c]);

                var orderedList = charColumn.GroupBy(c => c).OrderByDescending(c => c.Count());

                message += orderedList.First().Key;
                reverseMessage += orderedList.Last().Key;
            }

            WriteLine($"First part answer: {message}");
            Clipboard.SetText(message);

            WriteLine($"Second part answer: {reverseMessage}");
            Clipboard.SetText(reverseMessage);

            ReadKey();
        }
    }
}