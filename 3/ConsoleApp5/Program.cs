using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

public interface IComparable<T>
{
    int CompareTo(T y);
}
public struct ComplexNumber : IComparable<ComplexNumber>
{
    public double Real { get; }
    public double Imaginary { get; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public int CompareTo(ComplexNumber other)
    {
        double magnitudeThis = Magnitude();
        double magnitudeOther = other.Magnitude();
        return magnitudeThis.CompareTo(magnitudeOther);
    }

    private double Magnitude()
    {
        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}
public struct RationalNumber : IComparable<RationalNumber>
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("знаменатель не может быть нулем ");

        Numerator = numerator;
        Denominator = denominator;

    }

    public int CompareTo(RationalNumber other)
    {
        double valueThis = (double)Numerator / Denominator;
        double valueOther = (double)other.Numerator / other.Denominator;
        return valueThis.CompareTo(valueOther);
    }


    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ComplexNumber complex1 = new ComplexNumber(3, 4);
        ComplexNumber complex2 = new ComplexNumber(1, 2);

        Console.WriteLine($"Комплексное число 1: {complex1}");
        Console.WriteLine($"Комплексное число 2: {complex2}");

             int comparisonComplex = complex1.CompareTo(complex2);
        if (comparisonComplex < 0)
        {
            Console.WriteLine($"{complex1} меньше чем {complex2}");
        }
        else if (comparisonComplex > 0)
        {
            Console.WriteLine($"{complex1} больше чем {complex2}");
        }
        else
        {
            Console.WriteLine($"{complex1} равно {complex2}");
        }

        Console.WriteLine();

        RationalNumber rational1 = new RationalNumber(3, 4);
        RationalNumber rational2 = new RationalNumber(1, 2);

        Console.WriteLine($"Рациональное число 1: {rational1}");
        Console.WriteLine($"Рациональное число 2: {rational2}");

        int comparisonRational = rational1.CompareTo(rational2);
        if (comparisonRational < 0)
        {
            Console.WriteLine($"{rational1} меньше чем {rational2}");
        }
        else if (comparisonRational > 0)
        {
            Console.WriteLine($"{rational1} больше чем {rational2}");
        }
        else
        {
            Console.WriteLine($"{rational1} равно {rational2}");
        }
        Console.ReadLine();
    }
}

