using System;

public class BowlingGame
{
    int _score;
    int _bonus;
    bool _newFrame;
    int _frameScore;

    public BowlingGame()
    {
        _score = 0;
        _bonus = 0;
        _newFrame = true;
        _frameScore = 0;
    }
    public void Roll(int pins) 
    {
        _score += pins;
        _frameScore += pins;

        if(_bonus > 0)
        {
            _score += pins;
            _bonus--;
        }

        if(_frameScore == 10)
        {
            _bonus = 1;
        }

        if(!_newFrame)
        {
            _frameScore = 0;
        }

        _newFrame = !_newFrame;
    }

    public int? Score()
    {
        return _score;
    }

    private void ResetFrame()
    {
        _newFrame = true;
    }
}