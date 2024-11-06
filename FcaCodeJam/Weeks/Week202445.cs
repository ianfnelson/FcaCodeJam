namespace FcaCodeJam.Weeks;

public class Week202445 : WeekBase
{
    protected override IEnumerable<string> DoPuzzle(IEnumerable<string> inputData)
    {
        yield return inputData
            .Select(code => new BoardingPass(code))
            .Select(boardingPass => boardingPass.SeatId)
            .Max()
            .ToString();
    }

    public override int Year => 2024;
    public override int WeekNumber => 45;

    public class BoardingPass(string code)
    {
        public string Code { get; } = code;

        public int Row { get; } = RowFromCode(code[..7]);

        public int Column { get; } = ColumnFromCode(code[7..]);

        public int SeatId => Row * 8 + Column;
        
        private static int RowFromCode(string encodedRow)
        {
            return ObfuscatedBinaryToInteger(encodedRow, 'F', 'B');
        }

        private static int ColumnFromCode(string encodedColumn)
        {
            return ObfuscatedBinaryToInteger(encodedColumn, 'L', 'R');
        }

        private static int ObfuscatedBinaryToInteger(string obfuscatedBinary, char zeroCharacter, char oneCharacter)
        {
            var binaryString = obfuscatedBinary
                .Replace(zeroCharacter, '0')
                .Replace(oneCharacter, '1');
            
            return Convert.ToInt32(binaryString, 2);
        }
    }
}