﻿using System;
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

    public int Numerator{get; private set;}
    public int Denominator{get; private set;}
    public RationalNumber(int numerator, int denominator)
    {
        var flip = 1;
        if(denominator == 0) throw new DivideByZeroException();
        if(denominator < 0) flip = -1;
       
        Numerator = numerator * flip;
        Denominator = denominator * flip;

        this.Reduce();
    }

    public RationalNumber Add(RationalNumber r)
    {
        Numerator = Numerator * r.Denominator + r.Numerator * Denominator;
        Denominator = Denominator * r.Denominator;

        return this.Reduce();
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return r1.Add(r2);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        Numerator = Numerator * r.Denominator - r.Numerator * Denominator;
        Denominator = Denominator * r.Denominator;

        return this.Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return r1.Sub(r2);
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
        if(Numerator < 0)
        {
            Numerator *= -1;
        }

        return this;
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
        Numerator = (int)Math.Pow(Numerator, power);
        Denominator = (int)Math.Pow(Denominator, power);

        return this;
    }

    public double Expreal(int baseNumber)
    {
        var val = Math.Pow(baseNumber, Numerator);
        val = Math.Pow(val, 1D / Denominator);

        return val;
    }

    private int GCD(int n1, int n2)
    {
        var gcd = n1 % n2 == 0 ? n2 : GCD(n2, n1 % n2);

        return Math.Abs(gcd);
    }

}