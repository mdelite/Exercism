using System;

public class Queen
{
    private int _row;
    private int _column;

    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row
    {
        get
        {
            return _row;
        }
        private set
        {
            if (value < 0 || value > 7)
                throw new ArgumentOutOfRangeException($"Row:'{value}' must be between 0 and 7.");
            _row = value;
        }
    }
    public int Column
    {
        get
        {
            return _column;
        }
        private set
        {
            if(value < 0 || value > 7)
                throw new ArgumentOutOfRangeException($"Column:'{value}' must be between 0 and 7.");
            _column = value;
        }
    }

    public bool IsValidMove(int row, int column) => 
        _row == row ||
        _column == column ||
        Math.Abs(_row - row) == Math.Abs(_column - column);
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black) => 
        white.IsValidMove(black.Row, black.Column);

    public static Queen Create(int row, int column) => 
        new Queen(row, column);
}