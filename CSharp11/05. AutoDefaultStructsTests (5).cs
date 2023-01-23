namespace CSharp11;

public class AutoDefaultStructsTests
{

    [Fact]
    public void StructDefaultConstructor()
    {
        Coordinate coordinate = default;
        //Assert.Equal(42, coordinate.Latitude);

    }

    [Fact]
    public void StructDefaultConstructorOnArray()
    {
        Coordinate[] coordinates = new Coordinate[1];
        //Assert.Equal(42, coordinates[0].Latitude);

    }

    [Fact]
    public void StructOurConstructor()
    {
        Coordinate coordinate = new(30);
        Assert.Equal(30, coordinate.Latitude);

    }
}

public readonly partial record struct Coordinate 
{
    public Coordinate()
    {
        Name = "";
    }

    public Coordinate(double latitude, string name= "")
    {
        Name = name;
        Latitude = latitude;
    }

    public Coordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        Name = "";
    }

    public double Longitude { get; init; } = 1;
    public double Latitude { get; init; } = 42;
    public string Name {  get; init; }
}

/*
Guidelines:
* DO write structs as readonly (immutable).
* DO NOT use member initialization in structs.
* DO initialize required members via the constructor.
* DO your darndest to have the default for all members be valid (without initialization)
*/
