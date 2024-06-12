namespace FcaCodeJam.Weeks;

public interface IWeek
{
    string Name { get; }

    IEnumerable<string> DoPuzzle(string path);
}