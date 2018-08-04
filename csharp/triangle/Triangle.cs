using System;
using System.Linq;

public class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return IsValidTriangle(side1, side2, side3) && side1 != side2 && side1 != side3 && side2 != side3;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        return IsValidTriangle(side1, side2, side3) && (side1 == side2 || side1 == side3 || side2 == side3);
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        return IsValidTriangle(side1, side2, side3) && side1 == side2 && side1 == side3;
    }
    private static bool IsValidTriangle(double side1, double side2, double side3)
    {
        var sides = new double[] { side1, side2, side3 };

        // sides cannot be less than or equal to zero
        if(sides.Where(x => x <= 0).Count() > 0) return false;

        // sum of two side must be greater or equal to longest side
        var max = sides.Max();
        var lesserSides = sides.Where(x => x < max);

        if(lesserSides.Count() == 2) return lesserSides.Sum() >= max;

        // one or more sides are equal to max
        return true;
    }
}

public class TriangleException : Exception { }