﻿using System.Numerics;

namespace CSharp11;

public class GenericMathSupport
{
    [Fact]
    public void AddDoublesTest()
    {
        double number = Add(42.0, 77.0);
        Assert.Equal<double>(42 + 77, number);
    }

    [Fact]
    public void AddDecimalsTest()
    {
        decimal number = Add(42.0m, 77.0m);
        Assert.Equal<decimal>(42 + 77, number);
    }

    [Fact]
    public void AddOfTTest()
    {
        int number = Add(42, 77);
        Assert.Equal(42 + 77, number);
    }

    //private double Add(double left, double right) => left + right;
    //private decimal Add(decimal left, decimal right) => left + right;

    private T Add<T>(T left, T right)
        where T : INumber<T> => left + right;
}
