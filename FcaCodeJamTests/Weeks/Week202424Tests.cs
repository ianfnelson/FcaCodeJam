using FcaCodeJam.Weeks;
using FluentAssertions;
using NUnit.Framework;

namespace FcaCodeJamTests.Weeks;

[TestFixture]
public class Week202424Tests
{

    [Test]
    public void DoPuzzle_KnownInput_OutputIsAsExpected()
    {
        // Arrange
        var systemUnderTest = new Week202424();
        
        // Act
        var output = systemUnderTest.DoPuzzle("TestData/2024-24.txt");

        // Assert
        output.Should().BeEquivalentTo([
            "11211",
            "1*3*1",
            "12*21",
            ".111."
        ]);
    }
    
    [Test]
    public void Location_Neighbours_HasEightExpectedNeighbours()
    {
        // Arrange
        var random = new Random();
        int x = random.Next(0, 20);
        int y = random.Next(0, 20);

        var systemUnderTest = new Week202424.Location(x, y);

        // Act
        var neighbours = systemUnderTest.Neighbours().ToList();

        // Assert
        neighbours.Count.Should().Be(8);
        neighbours.Distinct().Count().Should().Be(8);

        foreach (var neighbour in neighbours)
        {
            Assert.That(Math.Abs(neighbour.X - x) == 1 || Math.Abs(neighbour.Y - y) == 1);
        }
    }
}