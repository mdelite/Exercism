using System;
using System.Linq;

public class Triangle
{
    [Flags]
    private enum TriangleType 
    { 
        None = 0,
        Scalene = 1, 
        Isosceles = 2, 
        Equilateral = 4 | TriangleType.Isosceles,
        Degenerate = 8
    }
    private TriangleType _triangleType;
    private double[] _sides;
    private Triangle(double side1, double side2, double side3)
    {
        _sides = new double[] { side1, side2, side3 };
        _triangleType = TriangleType.None;

        if(_sides.Where(s => s <= 0).Count() > 0) throw new TriangleException("No sides can be of a length less than or equal to zero.");

        var maxSide = _sides.Max();
        var lesserSides = _sides.Where(s => s < maxSide);
        
        if(lesserSides.Count() == 2)
        {
            var sum = lesserSides.Sum();

            if(sum < maxSide) throw new TriangleException("Sum of lengths of any two sides must be greater or equal to length of third side.");

            if(sum == maxSide) _triangleType |= TriangleType.Degenerate;
        }

        switch(_sides.Distinct().Count())
        {
            case 3:
                _triangleType |= TriangleType.Scalene;
                break;
            case 2:
                _triangleType |= TriangleType.Isosceles;
                break;
            case 1:
                _triangleType |= TriangleType.Equilateral;
                break;
            default:
                throw new ApplicationException();
        }
    }

    private bool HasFlag(TriangleType triangleType) => _triangleType.HasFlag(triangleType);

    public static bool IsScalene(double side1, double side2, double side3)
    {
        try
        {
            var triangle = new Triangle(side1, side2, side3);
            return triangle.HasFlag(TriangleType.Scalene);
        }
        catch (TriangleException)
        {
            return false;
        }
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        try
        {
            var triangle = new Triangle(side1, side2, side3);
            return triangle.HasFlag(TriangleType.Isosceles);
        }
        catch (TriangleException)
        {
            return false;
        }
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        try
        {
            var triangle = new Triangle(side1, side2, side3);
            return triangle.HasFlag(TriangleType.Equilateral);
        }
        catch (TriangleException)
        {
            return false;
        }
    }

    public static bool IsDegenerate(double side1, double side2, double side3) 
    {
        try
        {
            var triangle = new Triangle(side1, side2, side3);
            return triangle.HasFlag(TriangleType.Degenerate);
        }
        catch (TriangleException)
        {
            return false;
        }
    }
}

public class TriangleException : Exception
{
    public TriangleException(string message) : base(message)
    {
    }
}