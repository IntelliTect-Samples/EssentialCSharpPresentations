using System.Numerics;
using System.Text.RegularExpressions;

namespace CSharp11;

public readonly partial record struct Coordinate : IParsable<Coordinate>, IAdditionOperators<Coordinate, Coordinate, Coordinate>
{
    public static Coordinate Parse(string text)
    {
        if (text.Split(',') is [string longitudeText, string latitudeText] &&
            double.TryParse(longitudeText, out double longitude) && double.TryParse(latitudeText, out double latitude))
        {
            return new Coordinate() { Longitude= longitude, Latitude= latitude };
        }
        else return default;
    }

    public static Coordinate operator +(Coordinate left, Coordinate right)
    {
        throw new NotImplementedException();
    }


}