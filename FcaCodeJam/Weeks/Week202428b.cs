namespace FcaCodeJam.Weeks;

public class Week202428b : WeekBase
{
    protected override IEnumerable<string> DoPuzzle(IEnumerable<string> inputData)
    {
        var triangle = inputData.Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(ParseLine)
            .ToList();

        yield return MaximumPathThroughTriangle(triangle,0,0).ToString();
    }

    /// <summary>
    /// This is my attempted algorithm from 2024, using recursion.
    /// </summary>
    /// <param name="triangle"></param>
    /// <param name="rowIndex"></param>
    /// <param name="cellIndex"></param>
    /// <returns></returns>
    private static long MaximumPathThroughTriangle(IReadOnlyList<int[]> triangle, int rowIndex, int cellIndex)
    {
        if (rowIndex >= triangle.Count) return 0;

        return triangle[rowIndex][cellIndex] + Math.Max(
            MaximumPathThroughTriangle(triangle, rowIndex + 1, cellIndex),
            MaximumPathThroughTriangle(triangle, rowIndex + 1, cellIndex + 1));
    }

    private static int[] ParseLine(string line)
    {
        return line.Split(' ').Select(int.Parse).ToArray();
    }
    
    public override int Year => 2024;
    public override int WeekNumber => 28;
    public override string Suffix => "b";
}