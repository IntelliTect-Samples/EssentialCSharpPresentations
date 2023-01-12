namespace CSharp11;

public class ListPatternMatchingTests
{
    [Fact]
    public void ListPatternMatchTestStrings()
    {
        string[] items = new[] { "You", "killed", "my", "father" };

    }







     [Fact]
    public void SpanPatternMatchTestChar()
    {
        Span<char> items = "Hello World".ToArray().AsSpan();

        Assert.True(items is [.., 'd']);
        Assert.True(items is ['H', .., 'd']);
        Assert.True(items is "Hello World");
        
        if (items is ['H', .., char lastLetter]) Assert.Equal('d', lastLetter);
        else Assert.Fail("pattern match is false");
        
        items = new("Hello World".ToArray(), 6, 5);
    }
    
    [Fact]
    public void SpanPatternMatchTestInt()
    {
        Span<int> items = new(new []{ 1,2,3 });

        Assert.True(items is [.., 3]);
        Assert.True(items is [1, .., 3]);
        
        if (items is [1, .., int lastLetter]) Assert.Equal(3, lastLetter);
        else Assert.Fail("pattern match is false");
    }
}

