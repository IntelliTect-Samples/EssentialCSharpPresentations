namespace CSharp11;

// Raw string literals.
// UTF-8 as runtime constant
// New line in interpolation

public class StringEnhancements
{
    [Fact]
    public void RawStringLiterals()
    {
        const string name = "Inigo Montoya";

        const string expected = $@"{{
    ""Name"": ""{name}"",
    ""Phrase"": ""Stop saying that""
}}";

        string actual = $$"""
        {
            "Name": "{{name}}",
            "Phrase": "Stop saying that"
        }
        """;

        Assert.Equal<string>(expected, actual);
    }


    // Can't be a field or a property.
    public ReadOnlySpan<byte> GetUtf8Name() => "Inigo Montoya"u8;
}
