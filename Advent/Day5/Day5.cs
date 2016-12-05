#region

using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Helper;
using static System.Console;

#endregion

namespace Day5
{

    // ReSharper disable once InconsistentNaming
    public class MD5Generator
    {
        private readonly MD5 _md5Instance;

        public MD5Generator()
        {
            _md5Instance = MD5.Create();
        }

        public string Hash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = _md5Instance.ComputeHash(inputBytes).ToList();
            var hashString = string.Empty;

            hash.ForEach(b => hashString += b.ToString("X2"));

            return hashString;
        }
    }

    internal static class Day5
    {
        [STAThread]
        private static void Main()
        {
            var input = Utilities.GetInput(5);
            var generator = new MD5Generator(); //Optimization

            const int passwordLength = 8;
            var password = string.Empty;
            
            var index = 0;
            var resultHash = string.Empty;
            for (var i = 0; i < passwordLength; i++)
            {
                resultHash = string.Empty;
                while (!resultHash.StartsWith("00000"))
                {
                    resultHash = generator.Hash(input + index);
                    Write($"\rPassword: {password.PadRight(passwordLength, '_')} ({index}: {resultHash})");
                    index++;
                }

                password += resultHash.Substring(5, 1);
            }
            WriteLine($"\rPassword: {password.PadRight(passwordLength, '_')} ({index}: {resultHash})"); // We gotta break that password searching line
            
            WriteLine($"First part answer: {password}");
            Clipboard.SetText(password);
            
            /***************
            * Second part! *
            ***************/
            
            index = 0;
            resultHash = string.Empty;
            var passwordArray = new string[passwordLength];
            for (var i = 0; i < passwordLength; i++)
                passwordArray[i] = "_";

            var moviePassword = passwordArray.EasyJoin(); // An extensionmethod in Helper project

            while (passwordArray.Contains("_"))
            {
                resultHash = string.Empty;
                while (!resultHash.StartsWith("00000"))
                {
                    resultHash = generator.Hash(input + index);
                    Write($"\rMovie Password: {moviePassword} ({index}: {resultHash})");
                    index++;
                }

                var pos = int.Parse(resultHash.Substring(5, 1), NumberStyles.HexNumber);
                if (pos >= passwordLength) //Skip it if the position is out of bounds
                    continue;

                if(!passwordArray[pos].Equals("_")) //Skip it since its already filled in
                    continue;

                passwordArray[pos] = resultHash.Substring(6, 1);
                moviePassword = passwordArray.EasyJoin();
            }
            WriteLine($"\rMovie Password: {moviePassword} ({index-1}: {resultHash})"); // We gotta break that password searching line
            
            WriteLine($"Second part answer: {moviePassword}");
            Clipboard.SetText(moviePassword);
            ReadKey();
        }
    }
}