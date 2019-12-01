using System;

public class BowlingGame
{
    int _score;
    int _bonus;
    bool _newFrame;
    int _frame;
    int _frameScore;

    public BowlingGame()
    {
        _score = 0;
        _bonus = 0;
        _newFrame = true;
        _frame = 1;
        _frameScore = 0;
    }
    public void Roll(int pins)
    {
        if (_frame <= 10)
        {
            _score += pins;
            _frameScore += pins;
        }

        if (_bonus > 0)
        {
            _score += pins;
            _bonus--;
        }

        if (_frameScore == 10)
        {
            _bonus = 1;
        }

        if (!_newFrame)
        {
            _frame++;
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