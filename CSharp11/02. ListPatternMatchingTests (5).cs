namespace CSharp11;

public class ListPatternMatchingTests
{

    // Start
    [Fact]
    public void ListPatternMatchTestStrings()
    {
        string[] items = new[] { "You", "killed", "my", "father" };

        Assert.True(items is ["You", "killed", "my", "father" ]);
        Assert.True(items is [.., "father"]);
        Assert.True(items is ["You", .., "father"]);
        Assert.True(items is [..]);
        Assert.True(items is [_, "killed", "my", _]);
        Assert.False(items is []);
        Assert.False(items is ["You", "killed"]);
        // Assert.True(items is [..,"killed", "my", ..]);  // Contains is not supported!!!
        Assert.True(items[1..^1] is ["killed", "my"]);


        Assert.True(items is [ ['Y', ..], .., ['f', ..]]);

        if (items is ["You", .., string lastWord])
        {
            Assert.Equal("father", lastWord);
        }
        else Assert.Fail("pattern match is false");
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

