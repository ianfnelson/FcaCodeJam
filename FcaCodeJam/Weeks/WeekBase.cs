namespace FcaCodeJam.Weeks;

public abstract class WeekBase : IWeek
{
    protected abstract IEnumerable<string> DoPuzzle(IEnumerable<string> inputData);
    public abstract int Year { get; }
    public abstract int WeekNumber { get; }
    public string Name => $"{Year}-{WeekNumber}";

    public IEnumerable<string> DoPuzzle(string path)
    {
        return DoPuzzle(File.ReadLines(path));
    }
}