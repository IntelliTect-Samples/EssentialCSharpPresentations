using NuGet.Frameworks;
using System.Diagnostics.CodeAnalysis;

namespace CSharp11;

// Discuss DateOnly

public class RequiredMemberTests
{
    [Fact]
    public void NonRequiredMembersAreNull()
    {
        Person person = new("Mark") { LastName="Montoya", Dob=DateOnly.FromDateTime( DateTime.Now.AddYears(-42)) };

    }
    
    [Fact]
    public void RequiredValuesAreAllSet()
    {
        Person person = new() { FirstName = "Inigo", LastName="Montoya", Dob= DateOnly.FromDateTime(DateTime.Now.AddYears(-42)) };

    }

    [Fact]
    public void LastNameIsNotNull()
    {
        Person person = new("Inigo" ) 
        {
            FirstName = "Mark",
            Dob=DateOnly.FromDateTime(DateTime.Now.AddYears(-42))
        };
        Assert.Equal("Mark", person.FirstName);
        Assert.Null(person.LastName);
    }
}

public class Person
{
    [SetsRequiredMembers]
    public Person(string firstName)
    {
        FirstName = firstName;
    }
    public Person() { }

    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public DateOnly? Dob { get; set; }
}

/*
Guidelines
* DO NOT use constructor parameters to initialize required properties, instead rely on object initializer specified values.
* DO NOT use the SetRequiredParameters attribute unless all required parameters are assigned valid values during construction.
* CONSIDER only having a default constructor on types with required parameters, relying on the object initializer to set both required and non-required members.
* AVOID required members where the default value of the type is valid. (E.g. Reference type properties should not be nullable.)
* AVOID adding required members to released types to avoid breaking the compile on existing code.
* 
* FYI:
* Serialization ignores required
* Scope modifiers on the required members must match the vi
*/