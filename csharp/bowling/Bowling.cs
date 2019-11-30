using System;

public class BowlingGame
{
    int _score;

    public BowlingGame()
    {
        _score = 0;
    }
    public void Roll(int pins) 
    {
        _score += pins;
    }

    public int? Score()
    {
        return _score;
    }
}