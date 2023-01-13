using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CSharp11;

// Extended nameof scope
// Generic attributes
// File-local/file-scoped types

public class ExpectedExceptionTests
{
    public ITestOutputHelper OutputHelper { get; }

    public ExpectedExceptionTests(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;
    }

    [Theory()]
    [InlineData(nameof(NameOfInAttributeTest))]
    public void NameOfInAttributeTest(string methodName)
    {
        Assert.Equal<string>(nameof(NameOfInAttributeTest), methodName);
    }

    [Theory()]
    [InlineData(typeof(string))]

    public void TypeOfTest(Type type)
    {
        Assert.Equal<Type>(typeof(string), type);
        Assert.Equal<string>("String", type.Name);
    }

    [Theory()]
    [InlineData(typeof(InlineDataAttribute<string>))]
    public void TypeOfTestFileScopedName(Type type)
    {
        Assert.Equal<Type>(typeof(InlineDataAttribute<string>), type);

        Assert.NotEqual<string>("InlineDataAttribute`1", type.Name);

        OutputHelper.WriteLine(typeof(InlineDataAttribute<string>).Name);
    }

    [Theory()]
    [InlineData<string>]
    public void TypeOfGenericTest(Type type)
    {
        Assert.Equal<Type>(typeof(string), type);
    }
}


// File scope types
file class InlineDataAttribute<T> : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { typeof(T) };
    }
}