using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp11;

#if CSHARP11
public class ExpectedExceptionTests
{
    [Fact]
    public void RawStringLiterals()
    {
                           
        const string name = "Inigo Montoya";

        const string expected =
            $@"{{
    ""Name"": """"{name}"""",
    ""Phrase"": """"Stop saying that""""
}}";

        const string text = $$""""
            {
                "Name": ""{{
                    name}}"",
                "Phrase": ""Stop saying that""
            }
            """";

        Assert.Equal<string>(
                                 expected,
            text
            );
    }

    [ExpectedException(nameof(GenericAttributesTest))]
    [Fact]
    public void GenericAttributesTest()
    {

    }

    [Fact]
    public void StructDefaultConstructor()
    {
        Coordinate coordinate = new();
        Assert.Equal<double>(42, coordinate.Latitude);
    }

    [Fact]
    public void StructDefaultConstructorWithArrays()
    {
        Coordinate[] coordinates = new Coordinate[] { new(), new() };
        Assert.Equal<double>(42, coordinates[0].Latitude);
        Assert.Equal<double>(0, coordinates[0].Longitude);
    }
}

public class ExpectedException : Attribute
{
public ExpectedExceptionAttribute(string methodName)
{
    MethodName=methodName;
}

public string MethodName { get; }
}

public class ExpectedExceptionAtrribute : Attribute
{
public ExpectedExceptionAtrribute(string methodName)
{

}
}
public class ExpectedExceptionAtrribute<T> : ExpectedExceptionAtrribute
{
public Type ExpectedExceptionType { get; }
public ExpectedExceptionAtrribute(string methodName) : base(methodName)
{
    ExpectedExceptionType = typeof(T);
}

}
#endif
