namespace CSharp11;

// Raw string literals.
// UTF-8 as runtime constant
// New line in interpolation

public class StringEnhancements
{
    [Fact]
    public void RawStringLiterals()
    {
        // Start
        const string name = "Inigo Montoya";

        // Start
        const string expected = $@"{{
    ""Name"": ""{name}"",
    ""Phrase"": ""Stop saying that""
}}";

        // Finish
        var utf8 = "Inigo Montoya"u8;

        const string actual = $$"""
{
    "Name": "{{
            name}}",
    "Phrase": "Stop saying that"
}
""";

        Assert.Equal<string>(expected,actual);
    }
}
