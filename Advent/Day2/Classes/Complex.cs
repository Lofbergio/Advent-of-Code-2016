#region

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

#endregion

namespace Day2
{
    public class Complex : KeyPad
    {
        private readonly List<Key> _keys = new List<Key>();
        private Point _padPosition;

        public Complex(Point startPoint)
        {
            _padPosition = startPoint;

            var layout = new List<string>
                         {
                             "00100",
                             "02340",
                             "56789",
                             "0ABC0",
                             "00D00"
                         };

            var pattern = layout.Aggregate("", (agg, line) => agg + line);

            var indexCounter = 0;
            for (var r = 0; r < 5; r++)
                for (var c = 0; c < 5; c++)
                {
                    var key = pattern[indexCounter++].ToString();
                    _keys.Add(new Key(r, c, key));
                }
        }

        protected override string Move(Direction dir)
        {
            var newPosition = _padPosition;

            switch (dir)
            {
                case Direction.Up:
                    newPosition.Y--;
                    break;
                case Direction.Right:
                    newPosition.X++;
                    break;
                case Direction.Down:
                    newPosition.Y++;
                    break;
                case Direction.Left:
                    newPosition.X--;
                    break;
            }

            if (newPosition.Y > 4)
                newPosition.Y = 4;
            if (newPosition.Y < 0)
                newPosition.Y = 0;

            if (newPosition.X > 4)
                newPosition.X = 4;
            if (newPosition.X < 0)
                newPosition.X = 0;

            var keyValueAtPos = _keys.First(key => key.Column == newPosition.X && key.Row == newPosition.Y).Value;

            if (keyValueAtPos.Equals("0"))
                return _keys.First(key => key.Column == _padPosition.X && key.Row == _padPosition.Y).Value;

            _padPosition = newPosition;
            return keyValueAtPos;
        }
    }
}