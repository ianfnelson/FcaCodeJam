using FcaCodeJam.Weeks;
using FluentAssertions;
using NUnit.Framework;

namespace FcaCodeJamTests.Weeks;

[TestFixture]
public class Week202428bTests
{
    [Test]
    public void DoPuzzle_KnownInput_OutputIsAsExpected()
    {
        // Arrange
        var systemUnderTest = new Week202428b();
        
        // Act
        var output = systemUnderTest.DoPuzzle("TestData/2024-28.txt");
        
        // Assert
        output.Single().Should().Be("23");
    }
}