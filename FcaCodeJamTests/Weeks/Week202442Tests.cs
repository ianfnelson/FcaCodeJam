using FcaCodeJam.Weeks;
using NUnit.Framework;

namespace FcaCodeJamTests.Weeks;

[TestFixture]
public class Week202442Tests
{
    [Test]
    [TestCase('a', 'A', true)]
    [TestCase('A', 'a', true)]
    [TestCase('a', 'a', false)]
    [TestCase('a', 'B', false)]
    [TestCase('a', 'b', false)]
    [TestCase('B', 'a', false)]
    [TestCase('b', 'a', false)]
    public void ChemTrailChemicalsReactTest(char chemical1, char chemical2, bool expectedToReact)
    {
        var chemicalsReact = Week202442.ChemTrail.ChemicalsReact(chemical1, chemical2);
        
        Assert.That(chemicalsReact, Is.EqualTo(expectedToReact));
    }
    
    [Test]
    [TestCase("", "", 0)]
    [TestCase("a", "a", 1)]
    [TestCase("aA", "", 0)]
    [TestCase("abBA", "", 0)]
    [TestCase("abAB", "abAB", 4)]
    [TestCase("aAbB", "", 0)]
    [TestCase("aabAAB", "aabAAB", 6)]
    [TestCase("dabAcCaCBAcCcaDA", "dabCBAcaDA", 10)]
    public void ChemTrailReductionTest(string input, string expectedResidue, int expectedResidueSize)
    {
        var chemTrail = new Week202442.ChemTrail(input);
        
        chemTrail.Reduce();
        
        Assert.That(chemTrail.Size, Is.EqualTo(expectedResidueSize));
        Assert.That(chemTrail.ToString(), Is.EqualTo(expectedResidue));
    }
}