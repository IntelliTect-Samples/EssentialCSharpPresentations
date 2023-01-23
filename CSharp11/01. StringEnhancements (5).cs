namespace CSharp11;

// Raw string literals.
// New line in interpolation
// UTF-8 as runtime constant

public class StringEnhancements
{
    [Fact]
    public void RawStringLiterals()
    {
        ReadOnlySpan<byte> name = "Inigo Montoya"u8;

        string expected = $@"{{
    ""Name"": ""{name.ToString()}"",
    ""Phrase"": ""Stop saying that""
}}";

        string actual = $$"""
        {
            "Name": "{{name.ToString()}}",
            "Phrase": "Stop saying that"
        }
        """;

        Assert.Equal<string>(expected, actual);
    }
}
