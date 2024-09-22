namespace FcaCodeJam.Weeks;

public class Week202438 : WeekBase
{
    protected override IEnumerable<string> DoPuzzle(IEnumerable<string> inputData)
    {
        var presents = ParseInput(inputData).ToList();
        
        yield return presents.Sum(x => x.WrappingRequired).ToString();
        
        yield return presents.Sum(x => x.RibbonRequired).ToString();
    }   

    private static IEnumerable<Present> ParseInput(IEnumerable<string> inputData)
    {
        return inputData
            .Select(l => l.Split('x').Select(int.Parse).ToArray())
            .Select(d => new Present(d[0], d[1], d[2]));
    }

    public override int Year => 2024;
    public override int WeekNumber => 38;

    public class Present(int length, int width, int height)
    {
        public int Length { get; } = length;
        
        public int Width { get; } = width;
        
        public int Height { get; } = height;

        public int WrappingRequired
        {
            get
            {
                var areaLw = Length * Width;
                var areaLh = Length * Height;
                var areaWh = Width * Height;

                return 2 * (areaLw + areaLh + areaWh)
                       + new[] { areaLw, areaLh, areaWh }.Min();
            }
        }

        public int RibbonRequired
        {
            get
            {
                return 2 * (Length + Width + Height - new[] { Length, Width, Height }.Max())
                       + Length * Width * Height;
            }
        }
    }
}