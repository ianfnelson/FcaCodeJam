using FcaCodeJam.Weeks;
using FluentAssertions;
using NUnit.Framework;

namespace FcaCodeJamTests.Weeks;

[TestFixture]
public class Week202445Tests
{
    [Test]
    [TestCase("BFFFBBFRRR", 70, 7, 567)]
    [TestCase("FFFBBBFRRR", 14, 7, 119)]
    [TestCase("BBFFBBFRLL", 102, 4, 820)]
    public void BoardingPassTest(string code, int expectedRow, int expectedColumn, int expectedSeatId)
    {
        var boardingPass = new Week202445.BoardingPass(code);
        
        boardingPass.Code.Should().Be(code);
        boardingPass.Row.Should().Be(expectedRow);
        boardingPass.Column.Should().Be(expectedColumn);
        boardingPass.SeatId.Should().Be(expectedSeatId);
    }
}