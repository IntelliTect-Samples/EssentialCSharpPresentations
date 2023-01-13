namespace CSharp11;

// Raw string literals.
// UTF-8 as runtime constant
// New line in interpolation

public class StringEnhancements
{
    [Fact]
    public void RawStringLiterals()
    {
        ReadOnlySpan<byte> name = "Mark"u8;

        const string otherName = "inigo montoya";

        const string expected = $@"{{
    ""Name"": ""{otherName}"",
    ""Phrase"": ""Stop saying that""
}}";


        const string actual = $$$"""
    {
        "Name": "{{{
            otherName}}}",
        "Phrase": "Stop {{}}saying that"
    }
    """;

        Assert.Equal<string>(expected,actual);
    }
}
