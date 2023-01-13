namespace CSharp11;

// Raw string literals.
// New line in interpolation
// UTF-8 as runtime constant

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

        const string actual = $@"{{
    ""Name"": ""{name}"",
    ""Phrase"": ""Stop saying that""
}}";

        Assert.Equal<string>(expected, actual);
    }
}
