#region

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

#endregion

namespace Day2
{
    public class Simple : KeyPad
    {
        private readonly List<Key> _digits = new List<Key>();
        private Point _padPosition;

        public Simple(Point startPoint)
        {
            _padPosition = startPoint;

            var digitCounter = 0;
            for (var r = 0; r < 3; r++)
                for (var c = 0; c < 3; c++)
                {
                    _digits.Add(new Key(r, c, (++digitCounter).ToString()));
                }
        }

        protected override string Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    _padPosition.Y--;
                    break;
                case Direction.Right:
                    _padPosition.X++;
                    break;
                case Direction.Down:
                    _padPosition.Y++;
                    break;
                case Direction.Left:
                    _padPosition.X--;
                    break;
            }

            if (_padPosition.Y > 2)
                _padPosition.Y = 2;
            if (_padPosition.Y < 0)
                _padPosition.Y = 0;

            if (_padPosition.X > 2)
                _padPosition.X = 2;
            if (_padPosition.X < 0)
                _padPosition.X = 0;

            return _digits.First(key => key.Column == _padPosition.X && key.Row == _padPosition.Y).Value;
        }
    }
}