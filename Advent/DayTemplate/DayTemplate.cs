#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Forms;
using Helper;
using static System.Console;

#endregion

namespace Advent
{
    internal static class DayTemplate
    {
        [STAThread]
        private static void Main()
        {
            var input = Utilities.GetInput(1);

            WriteLine($"First part answer: ");
            Clipboard.SetText(input);

            ReadKey();
        }
    }
}