using FcaCodeJam.Weeks;
using NUnit.Framework;

namespace FcaCodeJamTests.Weeks;

[TestFixture]
public class Week202438Tests
{
    [Test]
    [TestCase(2, 3, 4, 58)]
    [TestCase(1, 1, 10, 43)]
    public void PresentWrappingRequired(int l, int w, int h, int expectedWrappingRequired)
    {
        var present = new Week202438.Present(l, w, h);

        var wrappingRequired = present.WrappingRequired;
        
        Assert.That(wrappingRequired, Is.EqualTo(expectedWrappingRequired));
    }
    
    [Test]
    [TestCase(2, 3, 4, 34)]
    [TestCase(1, 1, 10, 14)]
    public void PresentRibbonRequired(int l, int w, int h, int expectedRibbonRequired)
    {
        var present = new Week202438.Present(l, w, h);

        var ribbonRequired = present.RibbonRequired;
        
        Assert.That(ribbonRequired, Is.EqualTo(expectedRibbonRequired));
    } 
    
}