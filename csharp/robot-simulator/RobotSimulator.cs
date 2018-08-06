using System;

public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public struct Coordinate
{
    private int _x;
    private int _y;
    public Coordinate(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public int X
    {
        get
        {
            return _x;
        }
        set
        {
            _x = value;
        }
    }
    public int Y
    {
        get
        {
            return _y;
        }
        set
        {
            _y = value;
        }
    }
}

public class RobotSimulator
{
    private int _direction;
    private Coordinate _coordinate;

    public RobotSimulator(Direction direction, Coordinate coordinate)
    {
        _direction = (int)direction;
        _coordinate = coordinate;
    }

    public Direction Direction
    {
        get
        {
            while(_direction < 0) _direction += 4;
            while(_direction >= 4) _direction -= 4;

            return (Direction)_direction;
        }
    }

    public Coordinate Coordinate
    {
        get
        {
            return _coordinate;
        }
    }

    public void TurnRight() => _direction++;

    public void TurnLeft() => _direction--;

    public void Advance()
    {
        switch(Direction)
        {
            case Direction.North:
                _coordinate.Y++;
                break;
            case Direction.East:
                _coordinate.X++;
                break;
            case Direction.South:
                _coordinate.Y--;
                break;
            case Direction.West:
                _coordinate.X--;
                break;
            default:
                throw new ApplicationException($"Invalid direction:'{_direction}'");
        }
    }

    public void Simulate(string instructions)
    {
        foreach(var instruction in instructions)
        {
            switch(instruction)
            {
                case 'A':
                    Advance();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"'{instruction}' is not a recognised instruction.");
            }
        }
    }
}