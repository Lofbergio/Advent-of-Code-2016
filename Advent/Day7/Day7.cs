#region

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Helper;
using static System.Console;

#endregion

namespace Day7
{
    internal static class Day7
    {
        [STAThread]
        private static void Main()
        {
            var input = Utilities.GetInput(7).Replace("\r", "").Split('\n').ToList();

            // Skip all lines that have a pattern of "abba" within bracket segments and make note of those lines who have that pattern outside brackets
            var tlsValid = input.Where(line => !new Regex(@"\[(.+?)\]").Matches(line).Cast<Match>().Any(hypernet => new Regex(@"(.)(?!\1)(.)\2\1").IsMatch(hypernet.Groups[1].Value))).Count(line => new Regex(@"(.)(?!\1)(.)\2\1").IsMatch(line));

            // Find all segments that have the pattern "aba" and make sure that the line has the inverted pattern "bab" within brackets
            var sslValid = (from line in input
                            let hypernets = new Regex(@"\[(.+?)\]").Matches(line).Cast<Match>().Select(match => match.Groups[1].Value).ToList()
                            let supernets = new Regex(@"\[(.+?)\]").Split(line).Where((elem, idx) => idx%2 == 0).ToList()
                            where (from supernet in supernets
                                   from Match match in new Regex(@"(?=((.)(?!\2).\2))").Matches(supernet)
                                   select match.Groups[1].Value.ToCharArray()).Any(array => hypernets.Any(hyper => hyper.Contains(new string(new[]
                                                                                                                                             {
                                                                                                                                                 array[1],
                                                                                                                                                 array[0],
                                                                                                                                                 array[1]
                                                                                                                                             }))))
                            select hypernets).Count();


            WriteLine($"First part answer: {tlsValid}");
            Clipboard.SetText(tlsValid.ToString());

            WriteLine($"Second part answer: {sslValid}");
            Clipboard.SetText(sslValid.ToString());

            ReadKey();
        }
    }
}