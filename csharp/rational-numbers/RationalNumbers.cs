using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

public struct RationalNumber
{

    private int _numerator, _denominator;
    public RationalNumber(int numerator, int denominator)
    {
        var flip = 1;

        if(denominator < 0) flip = -1;
       
        _numerator = numerator * flip;
        _denominator = denominator * flip;
    }

    public RationalNumber Add(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var n = r1._numerator * r2._denominator + r2._numerator * r1._denominator;
        var d = r1._denominator * r2._denominator;

        return new RationalNumber(n, d).Reduce();
    }

    public RationalNumber Sub(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return r1 + new RationalNumber(r2._numerator * -1, r2._denominator);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        var n = r1._numerator * r2._numerator;
        var d = r1._denominator * r2._denominator;

        return new RationalNumber(n, d).Reduce();
    }

    public RationalNumber Div(RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return r1 * new RationalNumber(r2._denominator, r2._numerator);
    }

    public RationalNumber Abs()
    {
        if(_numerator < 0)
        {
            _numerator *= -1;
        }

        return this;
    }

    public RationalNumber Reduce()
    {
        if(_numerator == 0) _denominator = 1;

        var gcd = GCD(_numerator, _denominator);

        _numerator /= gcd;
        _denominator /= gcd;

        return this;
    }

    public RationalNumber Exprational(int power)
    {
        _numerator = (int)Math.Pow(_numerator, power);
        _denominator = (int)Math.Pow(_denominator, power);

        return this;
    }

    public double Expreal(int baseNumber)
    {
        var val = Math.Pow(baseNumber, _numerator);
        val = Math.Pow(val, 1D / _denominator);

        return val;
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