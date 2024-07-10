namespace FcaCodeJam.Weeks;

public interface IWeek
{
    string Name { get; }
    
    string InputFile { get; }

    IEnumerable<string> DoPuzzle(string path);
}