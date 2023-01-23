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
        Assert.Equal<string>("String", type.Name);
    }

    [Theory()]
    [InlineData<string>]
    public void TypeOfGenericTest(Type type)
    {
        Assert.Equal<Type>(typeof(string), type);
    }

    [Theory()]
    [InlineData(typeof(InlineData<string>))]
    public void TypeOfTestFileScopedName(Type type)
    {
        Assert.Equal<Type>(typeof(InlineData<string>), type);

        Assert.NotEqual<string>("InlineData`1", type.Name);

        OutputHelper.WriteLine(typeof(InlineData<string>).Name);
    }
}


// File scope types
file class InlineData<T> : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] { typeof(T) };
    }
}