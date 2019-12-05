using System;
using System.Collections.Generic;
using System.Linq;

public class BowlingGame
{
    List<int> _rolls;

    public BowlingGame()
    {
        _rolls = new List<int>();
    }

    public void Roll(int pins)
    {
        _rolls.Add(pins);
    }

    public int? Score()
    {
        return Enumerable.Range(0, _rolls.Count)
            .Where(x => Math.Abs(GetFrame(x)) <= 10)
            .Sum(r => _rolls[r] + GetBonus(r));
    }

    private int GetBonus(int rollNumber)
    {
        if (IsSpare(rollNumber))
        {
            return _rolls[rollNumber + 1];
        }

        return 0;
    }

    private bool IsSpare(int rollNumber)
    {
        return GetFrame(rollNumber) > 0 && _rolls[rollNumber] + _rolls[rollNumber - 1] == 10;
    }

    private int GetFrame(int rollNumber)
    {
        var frame = -1;

        for (int i = 0; i < rollNumber; i++)
        {
            if (frame < 0)
            {
                if (_rolls[rollNumber] == 10)
                {
                    frame--;
                }
                else
                {
                    frame *= -1;
                }
            }
            else
            {
                frame++;
                frame *= -1;
            }
        }

        return frame;
    }
}