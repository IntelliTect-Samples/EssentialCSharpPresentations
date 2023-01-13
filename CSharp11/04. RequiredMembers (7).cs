namespace CSharp11;

// Discuss DateOnly

public class RequiredMemberTests
{
    public class Person
    {
        public Person(string firstName)
        {
            FirstName=firstName;
        }
        public Person() { }

        public string? FirstName { get; set; }
        public required string? LastName { get; set; }
        public required DateOnly? Dob { get; set; }
    }
    
    [Fact]
    public void NonRequiredMembersAreNull()
    {
        Person person = new() { 
            LastName="Montoya", 
            Dob=DateOnly.FromDateTime( DateTime.Now.AddYears(-42)) };
        Assert.Null(person.FirstName);
    }
    [Fact]
    public void RequiredValuesAreAllSet()
    {
        Person person = new() { 
            FirstName = "Inigo", 
            LastName="Montoya", 
            Dob= DateOnly.FromDateTime(DateTime.Now.AddYears(-42)) };
        Assert.NotNull(person.LastName);
        Assert.NotNull(person.Dob);
    }

    [Fact]
    public void LastNameIsNotNull()
    {
        Person person = new("Inigo" ) {
            LastName = "Montoya", 
            Dob=DateOnly.FromDateTime(DateTime.Now.AddYears(-42)) };
        Assert.NotNull(person.LastName);
    }
}


/*
Guidelines
* DO NOT use constructor parameters to initialize required properties, instead rely 
*   on object initializer specified values.
* DO NOT use the SetRequiredParameters attribute unless all required parameters 
*   are assigned valid values during construction.
* CONSIDER only having a default constructor on types with required parameters, 
*   relying on the object initializer to set both required and non-required members.
* AVOID required members where the default value of the type is valid. 
*   (E.g. Reference type properties should not be nullable.)
* AVOID adding required members to released types to avoid breaking the compile 
*   on existing code.
* 
* FYI:
* Serialization ignores required
* Scope modifiers on the required members must match the visibility of the 
*   containing class
*/