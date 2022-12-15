using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp11
{
    public class ListPatternMatchingTests
    {
        [Fact]
        public void ListPatternMatchTestInts()
        {
            int[] items = new[] { "Mark".Length, "Grant".Length, 8, "Meg".Length };

            Assert.True(items is [.., 3]);
            Assert.True(items is [4, .., 3]);
        }

        [Fact]
        public void ListPatternMatchTestStrings()
        {
            string[] items = new[] { "Mark", "Grant", "Phil", "Meg" };

            Assert.True(items is [.., "Meg"]);
            Assert.True(items is ["Mark", .., "Meg"]);
            
            if (items is ["Mark", .., string lastName]) Assert.Equal("Meg", lastName);
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

        [Fact]
        public void ListPatternMatchTestChars()
        {
            string items = "ABCDEFG";

            Assert.True(items is [.., 'G']);
            Assert.True(items is ['A', .., 'G']);
            //Assert.True(items is [..,'D',..]); // Can't have two slice patterns
        }

        [Fact]
        public void ListPatternMatchTestChars2()
        {
            string items1 = "G";
            string items2 = "AEG";

            Assert.True(items1 is [.., 'G']);
            Assert.False(items1 is [_, .., 'G']);

            Assert.True(items2 is [.., 'G']);
            Assert.True(items2 is [_, .., 'G']);
        }

        //[Fact]
        //public void ListPatternMatchTestEnumerable()
        //{
        //    ICollection<char> items = "ABCDEFG";

        //    Assert.True(items is [.., 'G']);
        //    Assert.True(items is ['A', .., 'G']);
        //}

        [Fact]
        public void ListPatternMatchTestEnumerable()
        {
            Things<char> items = new();

            Assert.True(items is [.., 'G']);
            Assert.True(items is ['A', .., 'G']);
        }
    }

    public class Things<T> : ICollection<char>
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index] => throw new NotImplementedException();

        public void Add(char item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(char item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(char[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<char> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(char item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
