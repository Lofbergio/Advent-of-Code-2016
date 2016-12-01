#region

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

#endregion

namespace Helper
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Utilities
    {
        public static readonly string InputsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Inputs");

        public static string GetInput(uint day)
        {
            var filepath = Path.Combine(InputsFolderPath, $"Day{day}.txt");

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

        public static string GetInput(string customFile)
        {
            var filepath = Path.Combine(InputsFolderPath, customFile);
            if (!Path.HasExtension(filepath) || !File.Exists(filepath))
                throw new FileNotFoundException($"Could not find {filepath}");

            string input;
            using (var fs = new StreamReader(filepath))
                input = fs.ReadToEnd();

            Debug.Assert(!string.IsNullOrWhiteSpace(input), "Custom inputfile is empty.");

            Console.WriteLine("------- Start of input -------");
            Console.WriteLine(input);
            Console.WriteLine("-------  End of input  -------");

            return input;
        }

        public static void OpenInputFolder()
        {
            Process.Start(InputsFolderPath);
        }
    }
}