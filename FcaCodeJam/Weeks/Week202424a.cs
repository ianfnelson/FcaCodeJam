namespace FcaCodeJam.Weeks;

public class Week202428a : WeekBase
{
    protected override IEnumerable<string> DoPuzzle(IEnumerable<string> inputData)
    {
        var triangle = inputData.Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(ParseLine)
            .ToList();

        yield return MaximumPathThroughTriangle(triangle).ToString();
    }
    
    /// <summary>
    /// This is the algorithm I wrote when I originally solved this problem circa 2004.
    /// Looping from the penultimate row, then inner looping from left-to-right, returning the value
    ///   from the position plus the maximum of the positions below left and below right.
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    private static long MaximumPathThroughTriangle(List<int[]> triangle)
    {
        for (var row = triangle.Count-2; row >= 0; row--)
        {
            for (var cell = 0; cell < triangle[row].Length; cell++)
            {
                triangle[row][cell] += Math.Max(triangle[row + 1][cell], triangle[row + 1][cell + 1]);
            }
        }

        return triangle[0][0];
    }

    private static int[] ParseLine(string line)
    {
        return line.Split(' ').Select(int.Parse).ToArray();
    }
    
    public override int Year => 2024;
    public override int WeekNumber => 28;
    public override string Suffix => "a";
}