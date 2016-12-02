namespace Day2
{
    public class Key
    {
        public int Row { get; }
        public int Column { get; }
        public string Value { get; }

        public Key(int row, int column, string value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        public override string ToString()
        {
            return $"[R{Row}C{Column}] {Value}";
        }
    }
}