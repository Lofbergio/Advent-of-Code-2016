#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Day2
{
    public abstract class KeyPad
    {
        public string ParseDirections(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new Exception("Input line is empty");

            var directions = new List<Direction>();

            foreach (var letter in line)
            {
                switch (letter)
                {
                    case 'U':
                        directions.Add(Direction.Up);
                        break;
                    case 'R':
                        directions.Add(Direction.Right);
                        break;
                    case 'D':
                        directions.Add(Direction.Down);
                        break;
                    case 'L':
                        directions.Add(Direction.Left);
                        break;

                    default:
                        throw new Exception($"Invalid directional command({letter})");
                }
            }

            return GetDigit(directions);
        }

        private string GetDigit(IEnumerable<Direction> dirs)
        {
            return dirs.Select(Move).Last();
        }

        protected abstract string Move(Direction dir);
    }
}