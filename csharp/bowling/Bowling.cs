using System;
using System.Collections.Generic;
using System.Linq;

public class BowlingGame
{
    List<int> _rolls;
    List<int> _frame;

    public BowlingGame()
    {
        _rolls = new List<int>();
        _frame = new List<int>();
    }

    public void Roll(int pins)
    {
        var thisFrame = NextFrame();

        if (pins < 0 || pins > 10)
        {
            throw new ArgumentException();
        }

        if (thisFrame > 0 && _rolls[_rolls.Count - 1] + pins > 10)
        {
            throw new ArgumentException();
        }

        if (thisFrame == -11 && !(IsStrike(_rolls.Count - 1) || IsSpare(_rolls.Count - 1)))
        {
            throw new ArgumentException();
        }

        if(thisFrame == 11 && !IsStrike(_rolls.Count - 2))
        {
            throw new ArgumentException();
        }

        if(Math.Abs(thisFrame) > 11 && !IsStrike(_rolls.Count - 1))
        {
            throw new ArgumentException();
        }

        _rolls.Add(pins);
        _frame.Add(thisFrame);
    }

    private int NextFrame()
    {
        var next = -1;

        if (_frame.Count > 0)
        {
            var p = _frame.Count - 1;
            var prevFrame = _frame[p];

            if (prevFrame < 0)
            {
                if (_rolls[p] == 10)
                {
                    next = --prevFrame;
                }
                else
                {
                    next = prevFrame * -1;
                }
            }
            else
            {
                next = ++prevFrame * -1;
            }
        }
        return next;
    }

    public int? Score()
    {
        if (_rolls.Count == 0 || Math.Abs(_frame.Last()) < 10)
        {
            throw new ArgumentException();
        }

        return Enumerable.Range(0, _rolls.Count)
            .Where(x => Math.Abs(_frame[x]) <= 10)
            .Sum(r => _rolls[r] + GetBonus(r));
    }

    private int GetBonus(int r)
    {
        if (IsSpare(r))
        {
            if (r + 1 >= _rolls.Count) throw new ArgumentException();

            return _rolls[r + 1];
        }

        if (IsStrike(r))
        {
            if (r + 2 >= _rolls.Count) throw new ArgumentException();

            return _rolls[r + 1] + _rolls[r + 2];
        }

        return 0;
    }

    private bool IsSpare(int r)
    {
        return _frame[r] > 0 && _rolls[r] + _rolls[r - 1] == 10;
    }

    private bool IsStrike(int r)
    {
        return _frame[r] < 0 && _rolls[r] == 10;
    }

}