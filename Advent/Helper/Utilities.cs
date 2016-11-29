#region

using System;
using System.Diagnostics;
using System.IO;

#endregion

namespace Helper
{
    public static class Utilities
    {
        public static string GetInput(uint day)
        {
            var separator = Path.DirectorySeparatorChar;
            var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..{separator}..{separator}..{separator}Inputs{separator}Day{day}.txt");

            if (!File.Exists(filepath))
                throw new FileNotFoundException($"Could not find {filepath}");

            string input;
            using (var fs = new StreamReader(filepath))
                input = fs.ReadToEnd();

            Debug.Assert(!string.IsNullOrWhiteSpace(input), $"Day{day}.txt is empty.");

            Console.WriteLine("------- Start of input -------");
            Console.WriteLine(input);
            Console.WriteLine("-------  End of input  -------");

            return input;
        }
    }
}