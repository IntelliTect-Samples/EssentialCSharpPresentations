using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp11
{
    public class AutoDefaultStructsTests
    {
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
            Assert.Equal<double>(1, coordinates[0].Longitude);
        }

        [Fact]
        public void StructOurConstructor()
        {
            Coordinate coordinate = new(30);
            Assert.Equal<double>(30, coordinate.Latitude);
            Assert.Equal<double>(1, coordinate.Longitude);
        }
    }

    // GUIDELINE : If you are initializing within a declaration you must use a default constructor
    public readonly struct Coordinate
    {
        //public Coordinate()
        //{

        //}

        public Coordinate(double latitude)
        {
            Latitude = latitude;
        }

        public double Latitude { get; init; } = 42;
        public double Longitude { get; init; } = 1;
    }
}
