using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CSharp11;

// Extended nameof scope
// Generic attributes
// File-local/file-scoped types

public class ExpectedExceptionTests
{
    [Theory()]
    [InlineData(nameof(methodName))]
    public void NameOfInAttributeTest(string methodName)
    {
        Assert.Equal<string>(nameof(methodName), methodName);
    }

    [Theory()]
    [InlineData(typeof(string))]

    public void TypeOfTest(Type type)
    {
        Assert.Equal<Type>(typeof(string), type);
    }

    [Theory()]
    [InlineData<string>]
    public void TypeOfGenericTest(Type type)
    {
        Assert.Equal<Type>(typeof(string), type);
    }

    [Theory()]
    [InlineData(typeof(InlineDataAttribute<string>))]
    public void TypeOfTestFileScopedName(Type type)
    {
        Assert.Equal<Type>(typeof(InlineDataAttribute<string>), type);

        Assert.NotEqual<string>("InlineDataAttribute`1", type.Name);

        OutputHelper.WriteLine(typeof(InlineDataAttribute<string>).Name);
    }
    
    public ITestOutputHelper OutputHelper { get; }
    public ExpectedExceptionTests(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;
    }

}


// File scoped types
file class InlineDataAttribute<T> : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { typeof(T) };
    }
}