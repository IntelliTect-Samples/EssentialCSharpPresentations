using System.Text.RegularExpressions;

namespace CSharp11;

public partial class RegularExpressionAtributeTests
{
    [Fact]
    public void MatchesRegEx()
    {
        Coordinate c = new("490,42");
        Assert.Equal(490, c.Latitude);
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
        if (match.Success)
        {
            Latitude = int.Parse(match.Groups["Left"].Value);
            Longitude = int.Parse(match.Groups["Right"].Value);
        }
        else
        {
            throw new ArgumentException("Invalid text", nameof(text));
        }
        Name = "";
    }
}