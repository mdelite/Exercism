using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this extension method.");
    }
}

public struct RationalNumber
{
    public int Numerator, Denominator;
    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public RationalNumber Add(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var n = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
        var d = r1.Denominator * r2.Denominator;

        return new RationalNumber(n, d).Reduce();
    }

    public RationalNumber Sub(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return r1 + new RationalNumber(r2.Numerator * -1, r2.Denominator);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        var n = r1.Numerator * r2.Numerator;
        var d = r1.Denominator * r2.Denominator;

        return new RationalNumber(n, d).Reduce();
    }

    public RationalNumber Div(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return r1 * new RationalNumber(r2.Denominator, r2.Numerator);
    }

    public RationalNumber Abs()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Reduce()
    {
        if(Numerator == 0) Denominator = 1;

        var gcd = GCD(Numerator, Denominator);

        Numerator /= gcd;
        Denominator /= gcd;

        return this;
    }

    public RationalNumber Exprational(int power)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    private int GCD(int n1, int n2)
    {
        var mults1 = Multiples(Math.Abs(n1));
        var mults2 = Multiples(Math.Abs(n2));

        var common = mults1.Intersect(mults2);

        return common.Max();
    }

    private static IEnumerable<int> Multiples(int number)
    {
        var mults = new List<int>() {1};

        var c = 2;

        // lazy!  use primes.
        while(c < number)
        {
            if(number % c == 0) mults.Add(c);
            c++;
        }

        mults.Add(number);

        return mults;
    }
}