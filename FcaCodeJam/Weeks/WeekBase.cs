namespace FcaCodeJam.Weeks;

public abstract class WeekBase : IWeek
{
    protected abstract IEnumerable<string> DoPuzzle(IEnumerable<string> inputData);
    public abstract int Year { get; }
    public abstract int WeekNumber { get; }
    public virtual string Suffix => "";
    public string Name => $"{Year}-{WeekNumber}{Suffix}";

    public string InputFile => $"{Year}-{WeekNumber}.txt";

    public IEnumerable<string> DoPuzzle(string path)
    {
        return DoPuzzle(File.ReadLines(path));
    }
}