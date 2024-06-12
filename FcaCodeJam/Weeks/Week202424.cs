namespace FcaCodeJam.Weeks;

public class Week202424 : WeekBase
{
    private Dictionary<Location, Square> _squares = null!;

    public override int Year => 2024;
    public override int WeekNumber => 24;

    protected override IEnumerable<string> DoPuzzle(IEnumerable<string> inputData)
    {
        _squares = ParseInput(inputData)
            .ToDictionary(x => x.Location, x => x);

        foreach (var square in _squares.Values)
        {
            square.NeighbouringMineCount = CountNeighbouringMines(square);
        }

        return OutputGridWithHints();
    }

    private IEnumerable<string> OutputGridWithHints()
    {
        var rows = _squares.GroupBy(s => s.Key.Y)
            .OrderBy(g => g.Key);

        foreach (var row in rows)
            yield return string.Concat(
                row.OrderBy(s => s.Key.X)
                    .Select(s => s.Value.Hint));
    }

    private static IEnumerable<Square> ParseInput(IEnumerable<string> inputData)
    {
        var lineCounter = 0;

        foreach (var line in inputData)
        {
            var characterCounter = 0;

            foreach (var character in line.ToCharArray())
            {
                yield return new Square(characterCounter, lineCounter, character);
                characterCounter++;
            }

            lineCounter++;
        }
    }

    private int CountNeighbouringMines(Square square)
    {
        var neighbours = square.Location.Neighbours().ToList();
        
        return _squares.Count(s => neighbours.Contains(s.Key) && s.Value.IsMine);
    }

    public class Square(int x, int y, char c)
    {
        public Location Location { get; } = new(x, y);

        public bool IsMine { get; } = c == '*';

        public int NeighbouringMineCount { get; set; }

        public char Hint
        {
            get
            {
                if (IsMine)
                {
                    return '*';
                }

                return NeighbouringMineCount == 0 ? '.' : NeighbouringMineCount.ToString()[0];
            }
        }
    }

    public readonly struct Location(int x, int y)
    {
        public int X { get; } = x;

        public int Y { get; } = y;

        public IEnumerable<Location> Neighbours()
        {
            for (var i = -1; i <= 1; i++)
            for (var j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                yield return new Location(X + i, Y + j);
            }
        }
    }
}