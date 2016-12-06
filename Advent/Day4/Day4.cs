#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Helper;
using static System.Console;

#endregion

namespace Day4
{
    public class Room
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    internal static class Day4
    {
        [STAThread]
        private static void Main()
        {
            var input = Utilities.GetInput(4).Split('\n');
            var idSum = 0;
            var rotatedNameList = new List<Room>();

            foreach (var line in input)
            {
                var idAndCheckSum = new Regex(@"(\d+)\[(.+?)\]").Match(line);
                var id = int.Parse(idAndCheckSum.Groups[1].Value);
                var checkSum = idAndCheckSum.Groups[2].Value;

                var name = line.Remove(line.LastIndexOf("-", StringComparison.Ordinal)).Replace("-", string.Empty).ToCharArray();
                idSum += new string(name.GroupBy(c => c)
                                        .OrderByDescending(x => x.Count()).ThenBy(x => x.Key)
                                        .Take(checkSum.Length)
                                        .Select(x => x.Key)
                                        .ToArray()).Equals(checkSum) ? id : 0;

                //Rotate the letter through the alphabet
                for (var k = 0; k < name.Length; k++)
                    for (var lol = 0; lol < id%26; lol++) //26 letters in the english alphabet
                        name[k] = name[k] == 'z' ? 'a' : (char)(name[k] + 1);

                rotatedNameList.Add(new Room
                {
                    Name = new string(name),
                    Id = id
                });
            }

            WriteLine($"First part answer: {idSum}");
            Clipboard.SetText(idSum.ToString());

            var northpoleRoom = rotatedNameList.First(room => room.Name.Contains("northpole"));

            WriteLine($"Second part answer: {northpoleRoom.Id}");
            Clipboard.SetText(northpoleRoom.Id.ToString());

            ReadKey();
        }
    }
}