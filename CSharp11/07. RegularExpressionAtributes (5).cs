using System.Text.RegularExpressions;

namespace CSharp11;

// Start remove partial

public partial class RegularExpressionAtributesTests
{
    [Fact]
    public void MatchesRegEx()
    {
        Coordinate c = new("77,42");
        Assert.Equal(77, c.Latitude);
        Assert.Equal(42, c.Longitude);
    }
}


public partial record struct Coordinate
{
    [GeneratedRegex(@"(?<Left>\d+),(?<Right>\d+)")]
    private static partial Regex Regex();

    public Coordinate(string text)
    {
        Match match = Regex().Match(text);
        if(match.Success)
        {
            Latitude = double.Parse(match.Groups["Left"].Value);
            Longitude = double.Parse(match.Groups["Right"].Value);
        }
        Name = "";
    }
}