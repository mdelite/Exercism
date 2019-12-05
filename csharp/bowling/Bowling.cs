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
            .Sum(r => _rolls[r]);
    }
}